// Побудувати стандартну діаметричну проекцію зображення глобуса радіуса r, 
// що містить паралелі з кроком 30 градусів, меридіани з кроком 45 градусів і контур глобуса. 
// Реалізувати нахил зображення вправо відносно осі z на кут ϕ = 23,5 градуса

Sphere sphere;
Matrix result;
float radius = 100;

int parralelNum = 10;// 3
int meredianNum = 9;// 4

float angleAlpha = 23.5;
float anglePhi = -29.52;
float angleTeta = 26.23;

void setup()
{
  size(500, 500, FX2D);
  
  sphere = new Sphere(meredianNum, parralelNum);
  
  for (float phi = 0; phi < TWO_PI; phi += PI/parralelNum)// parallel
  {
    for (float teta = 0; teta <= PI; teta += PI/meredianNum)// meredian
    {
      sphere.addPoint(sin(teta)*cos(phi)*radius, sin(teta)*sin(phi)*radius, cos(teta)*radius);      
    }
  }

  result = sphere.getCoordinate();
}

void draw()
{
  background(51);
  Matrix rotateOZ = new Matrix();
  rotateOZ.addRow(cos(angleAlpha), sin(angleAlpha), 0, 0);
  rotateOZ.addRow(-sin(angleAlpha), cos(angleAlpha), 0, 0);
  rotateOZ.addRow(0, 0, 1, 0);
  rotateOZ.addRow(0, 0, 0, 1);
  
  Matrix dimetricProection = new Matrix();
  dimetricProection.addRow(cos(angleTeta), sin(angleTeta)*sin(anglePhi), -sin(angleTeta)*cos(anglePhi), 0);
  dimetricProection.addRow(0, cos(anglePhi), sin(anglePhi), 0);
  dimetricProection.addRow(sin(angleTeta), -cos(angleTeta)*sin(anglePhi), cos(angleTeta)*cos(anglePhi), 0);
  dimetricProection.addRow(width/2, height/2, 0, 1); 
  
  sphere.setCoordinat(result.mult(rotateOZ).mult(dimetricProection));
    
  sphere.show();
  
  // should be commented
  angleTeta += 0.01;
  anglePhi += 0.01;
}
