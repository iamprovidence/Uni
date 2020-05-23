using System.Linq;
using System.Drawing;

namespace Bonus.Classes
{
    public class Polygon : System.IDisposable
    {
        // FIELDS
        PointF[] startPoints;
        PointF[] currentPoints;

        PointF startPosition;
        PointF endPosition;
        PointF stepSize;
        int stepsAmount;
        int stepsDone;

        SolidBrush brush;
        // CONSTRUCTORS
        public Polygon(PointF[] points, PointF startPosition, PointF endPosition, int stepsAmount, Color color)
        {
            this.startPoints = points;
            this.currentPoints = points.Clone() as PointF[];
            this.startPosition = startPosition;
            this.endPosition = endPosition;
            this.stepsAmount = stepsAmount;
            this.stepSize = new PointF
            {
                X = (endPosition.X - startPosition.X) / stepsAmount,
                Y = (endPosition.Y - startPosition.Y) / stepsAmount
            };
            this.stepsDone = 0;
            this.brush = new SolidBrush(color);
        }
        // PROPERTIRS
        public double S
        {
            get
            {
                double S = 0;
                for (int i = 0; i < currentPoints.Length - 1; ++i)
                {
                    S += currentPoints[i].X * currentPoints[i + 1].Y - currentPoints[i + 1].X * currentPoints[i].Y;
                }
                return System.Math.Abs(S / 2D);
            }
        }
        public int StepsAmount => stepsAmount;
        // METHODS
        public void Reset()
        {
            this.currentPoints = startPoints.Clone() as PointF[];
            stepsDone = 0;
        }
        public void Show(Graphics graphics)
        {
            graphics.FillPolygon(brush, currentPoints);            
        }
        public void PerformStep()
        {
            for (int i = 0; i < currentPoints.Length; i++)
            {
                currentPoints[i].X += stepSize.X;
                currentPoints[i].Y += stepSize.Y;
            }
            ++stepsDone;
            if (stepsDone >= stepsAmount)
            {
                this.Reset();
            }
        }
        public static Polygon CollidedZone(PointF[] collisionPoint)
        {
            
            System.Collections.Generic.LinkedList<PointF> pointSet = new System.Collections.Generic.LinkedList<PointF>(collisionPoint.Skip(1));
            PointF[] sortedPoints = new PointF[collisionPoint.Length];
            sortedPoints[0] = collisionPoint[0];

            int i = 1;
            while (pointSet.Count > 0)
            {
                double minPointDistance = double.MaxValue;
                PointF closestPoint = sortedPoints[0];

                foreach (PointF currentPoint in pointSet)
                {
                    double currentDistance = PointDistance(sortedPoints[sortedPoints.Length - 1], currentPoint);

                    if (currentDistance < minPointDistance)
                    {
                        minPointDistance = currentDistance;
                        closestPoint = currentPoint;
                    }
                }

                sortedPoints[i++] = closestPoint;
                pointSet.Remove(closestPoint);
            }

            
            
            return new Polygon
                (
                    points: collisionPoint,
                    endPosition: default(Point),
                    startPosition: default(Point),
                    color: Color.FromArgb(255, 150, 100),
                    stepsAmount: -1
                );
        }
        public static double PointDistance(PointF p1, PointF p2)
        {
            return System.Math.Sqrt(System.Math.Pow(p2.Y - p1.Y, 2) + System.Math.Pow(p2.X - p1.X, 2));
        }
        public static CollisionOption Collided(Polygon p1, Polygon p2)
        {
            // check collision for all pair of polygon's lines with each other             
            System.Collections.Generic.List<PointF> pointCollision = new System.Collections.Generic.List<PointF>(2);
            CollisionOption collision = new CollisionOption
            {
                Collided = false,
                Points = null
            };

            for (int current = 0; current < p1.currentPoints.Length; ++current)
            {
                // go through each of the vertices, plus the next vertex in the list
                PointF pc = p1.currentPoints[current];                                   // c for "current"
                PointF pn = p1.currentPoints[(current+1)%p1.currentPoints.Length];       // n for "next"
                
                // now we can use these two points (a line) to compare
                // to the other polygon's vertices using polyLine()
                CollisionOption res = PolyLine(p2, pc, pn);
                if (res.Points != null) pointCollision.AddRange(res.Points);
                collision.Collided |= res.Collided;
            }

            // if lines are not collided
            // check one point if it inside polygon
            if (collision.Collided == false)
            {
                // optional: check if the 2nd polygon is INSIDE the first
                bool isInside = PolyPoint(p1, p2.currentPoints[0]);
                // if it inside, collision points are same as second polygon point
                return new CollisionOption
                {
                    Collided = isInside,
                    Points = isInside ? p2.currentPoints : null
                };

            }
            else // if lines are collided
            {
                // check for vertexes to be inside polygon
                foreach (PointF p in p2.currentPoints)
                {
                    if (PolyPoint(p1, p))
                    {
                        pointCollision.Add(p);
                    }
                }
            }
            collision.Points = pointCollision.ToArray();
            return collision;
        }
        private static CollisionOption PolyLine(Polygon p, PointF p1, PointF p2)
        {
            System.Collections.Generic.List<PointF> pointCollision = new System.Collections.Generic.List<PointF>(2);

            for (int current = 0; current < p.currentPoints.Length; ++current)
            {
                PointF p3 = p.currentPoints[current];                               // current
                PointF p4 = p.currentPoints[(current + 1) % p.currentPoints.Length];// next

                // check if vertex are inside point
                if (PolyPoint(p, p3))
                {
                    pointCollision.Add(p3);
                }

                // do a Line/Line comparison
                // collect all point where line collide with polygone
                // could be more than 1
                CollisionOption hit = LineLine(p1, p2, p3, p4);
                if (hit.Collided == true)
                {
                    pointCollision.AddRange(hit.Points);
                }

                // check if vertex are inside point
                if (PolyPoint(p, p4))
                {
                    pointCollision.Add(p4);
                }
            }

            // all checking has been passed
            if (pointCollision.Count > 0)// collided
            {
                return new CollisionOption
                {
                    Collided = true,
                    Points = pointCollision.ToArray()
                };
            }
            else // never got hit
            {
                return new CollisionOption
                {
                    Collided = false,
                    Points = null
                };
            }
        }
        // LINE/LINE
        private static CollisionOption LineLine(PointF p1, PointF p2, PointF p3, PointF p4)
        {
            // calculate the direction of the lines
            float uA = ((p4.X - p3.X) * (p1.Y - p3.Y) - (p4.Y - p3.Y) * (p1.X - p3.X)) / ((p4.Y - p3.Y) * (p2.X - p1.X) - (p4.X - p3.X) * (p2.Y - p1.Y));
            float uB = ((p2.X - p1.X) * (p1.Y - p3.Y) - (p2.Y - p1.Y) * (p1.X - p3.X)) / ((p4.Y - p3.Y) * (p2.X - p1.X) - (p4.X - p3.X) * (p2.Y - p1.Y));

            // if uA and uB are between 0-1, lines are colliding
            if (uA >= 0 && uA <= 1 && uB >= 0 && uB <= 1)
            {
                return new CollisionOption
                {
                    Collided = true,
                    // A single point collision
                    Points = new PointF[1] { new PointF() { X = p1.X + (uA * (p2.X - p1.X)), Y = p1.Y + (uA * (p2.Y - p1.Y)) } }
                };
            }
            return new CollisionOption { Collided = false, Points = null };
        }
        // used to check if the second polygon is INSIDE the first
        // and vertex position inside polygon
        private static bool PolyPoint(Polygon poly, PointF point)
        {
            bool collision = false;

            // go through each of the vertices, plus the next
            // vertex in the list
            for (int current = 0; current < poly.currentPoints.Length; ++current)
            {
                PointF pc = poly.currentPoints[current];                                      // c for "current"
                PointF pn = poly.currentPoints[(current + 1) % poly.currentPoints.Length];    // n for "next"

                // compare position, flip 'collision' variable
                // back and forth
                if (((pc.Y > point.Y && pn.Y < point.Y) || (pc.Y < point.Y && pn.Y > point.Y)) &&
                     (point.X < (pn.X - pc.X) * (point.Y - pc.Y) / (pn.Y - pc.Y) + pc.X))
                {
                    collision = !collision;
                }
            }
            return collision;
        }

        public void Dispose()
        {
            brush.Dispose();
        }
    }
}