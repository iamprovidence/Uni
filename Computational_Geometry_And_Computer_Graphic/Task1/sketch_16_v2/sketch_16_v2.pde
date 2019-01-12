// 16. Розробити анімаційну програму,
// яка виконує кольорову анімацію набору різнокольорових концентричних кіл 
// так, що за рахунок зміни кольорів та плавної зміни розмірів кіл 
// створити ілюзію руху.

int rows;
int cols;

float[][] previousState;
float[][] currentState;
float damping = 0.995; // 0 - 1

void setup()
{
  size(600, 600);
  
  rows = height;
  cols = width;
  
  previousState = new float[rows][cols];
  currentState = new float[rows][cols];
}

void draw()
{
  background(51);
  loadPixels();
  for(int i = 1; i < rows - 1; ++i)
  {
    for(int j = 1; j < cols - 1; ++j)
    {
      currentState[i][j] = (previousState[i-1][j] +// add the neighbour 
                            previousState[i+1][j] +// of previous
                            previousState[i][j-1] +// and subtract current cell
                            previousState[i][j+1])/2 - currentState[i][j];
                            
      currentState[i][j] *= damping;
      
      // showing current state
      int index = i + j*cols;
      pixels[index] = color(51, 51, currentState[i][j]*200);
    }
  } 
  
  updatePixels();
  
  // swaping
  float[][] temp = previousState;
  previousState = currentState;
  currentState = temp;
}

void mousePressed()
{
  currentState[mouseX][mouseY] = 255;
}
