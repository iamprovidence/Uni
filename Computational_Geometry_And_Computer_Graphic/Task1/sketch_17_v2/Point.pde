class Point
{
  // FIELDS
  private float x;
  private float y;
  private color pointColor;
  private float size;
  
  // CONSTRUCTORS
  Point(float x, float y, color pointColor, float size)
  {
    this.x = x;
    this.y = y;
    this.pointColor = pointColor;
    this.size = size;
  }
  // METHODS
  void show()
  {
    noStroke();
    stroke(pointColor);
    strokeWeight(size);
    point(x, y);
  }
  float distance(Point B)
  {
    return sqrt(pow(this.x - B.x, 2) + pow(this.y - B.y, 2));
  }
  float distance(float x, float y)
  {
    return sqrt(pow(this.x - x, 2) + pow(this.y - y, 2));
  }
  void setX(float x)
  {
    this.x = x;
  }
}
