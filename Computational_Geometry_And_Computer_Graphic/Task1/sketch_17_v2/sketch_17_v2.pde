// На горизонтальній прямій задано 2 точки відстань між якими дорівнює С
// Зобразити множину точок, для яких добуток відстаней до двох заданих точок дорівнює Р
// Р = С^2 / 4
// P < C^2 / 4
// C^2 / 4 < P < C^2 / 2
// P > C^2 / 4

Line[] lines;
int lineIndex = 0;
int linesAmount = 4;
float distance = 150;

void setup()
{
  size(480, 360, FX2D);
  String[] text = {"Р = D^2 / 4","P < D^2 / 4", "D^2 / 4 < P < D^2 / 2", "P > D^2 / 4"};
  lines = new Line[linesAmount];
  for (int i = 0; i < linesAmount; ++ i)
  {
    lines[i] = new Line(height/2, distance, i, text[i]);
  }
}
void draw()
{
  background(40);
  
  lines[lineIndex].show();
  lines[lineIndex].update(distance);
  
  color(255);
  text("Distance = " + distance, 20, 20);
}
void keyPressed()
{
  if (key == CODED)
  {
    if (keyCode == LEFT) -- distance;
    else if (keyCode == RIGHT) ++ distance;
    
    if (keyCode == UP) -- lineIndex;
    else if (keyCode == DOWN) ++ lineIndex;
    
    lineIndex = abs(lineIndex);
    lineIndex %= linesAmount;
  }
}
