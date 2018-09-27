/*
Pеалізувати алгоритм двовимірного обертання 
одиничного квадрата та одиничного рівносторонього трикутника 
навколо довільної точки.
*/

Shape square;
Shape triangle;

// remember coordinate 
// because we rotate
// initial shape all the time
Matrix squareCoordinate;
Matrix triangleCoordinate;

int rotateX;
int rotateY;

float angle;
float speed;

Matrix rotateMatrix;

void setup()
{
  size(500, 500);
  speed = 0.01;
  
  rotateX = width/2;
  rotateY = width/2;
  
  square = new Shape(color(0, 255, 0));
  square.addPoint(width/2 - 20, height/2 - 20);
  square.addPoint(width/2 + 20, height/2 - 20);
  square.addPoint(width/2 + 20, height/2 + 20);
  square.addPoint(width/2 - 20, height/2 + 20);
  squareCoordinate = square.getCoordinate();
  
  triangle = new Shape(color(0, 0, 255));
  triangle.addPoint(width/2, height/2 + 60);
  triangle.addPoint(width/2 - 40, height/2 + 120);
  triangle.addPoint(width/2 + 40, height/2 + 120);
  triangleCoordinate = triangle.getCoordinate();
}

void draw()
{
  background(51);
  
  // calculating rotate matrix
  Matrix shift = new Matrix();
  shift.addRow(1, 0, 0);
  shift.addRow(0, 1, 0);  
  shift.addRow(-rotateX, -rotateY, 1);
  
  Matrix rotate = new Matrix();
  rotate.addRow(cos(angle), sin(angle), 0);
  rotate.addRow(-sin(angle), cos(angle), 0);  
  rotate.addRow(0, 0, 1);
  
  Matrix shiftBack = new Matrix();
  shiftBack.addRow(1, 0, 0);
  shiftBack.addRow(0, 1, 0);  
  shiftBack.addRow(rotateX, rotateY, 1);
  
  rotateMatrix = shift.mult(rotate).mult(shiftBack);
  
  /*
  // already calculated matrix
  rotateMatrix = new Matrix();
  rotateMatrix.addRow(cos(angle), sin(angle), 0);
  rotateMatrix.addRow(-sin(angle), cos(angle), 0);
  rotateMatrix.addRow(-rotateX*(cos(angle)-1) + rotateY * sin(angle), -rotateY * sin(angle) - rotateX*(cos(angle) - 1), 1);
  */

  // rotated shapes to show
  square.setCoordinate(squareCoordinate.mult(rotateMatrix));
  triangle.setCoordinate(triangleCoordinate.mult(rotateMatrix));
  
  square.show();
  triangle.show();  
  
  strokeWeight(5);
  stroke(255, 0, 0);
  point(rotateX, rotateY);
  
  angle += speed;
}

void mousePressed()
{
  rotateX = mouseX;
  rotateY = mouseY;
}
