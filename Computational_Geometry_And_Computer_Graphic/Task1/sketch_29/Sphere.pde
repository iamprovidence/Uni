class Sphere
{
  // FIELDS
  Matrix coordinate;
  int parallelCount;
  int meredianCount;
  // CONSTRUCTORS
  Sphere(int meredianCount, int parallelCount)
  {
    this.coordinate = new Matrix();
    this.meredianCount = meredianCount + 1;
    this.parallelCount = parallelCount;
  }
  // METHODS
  void setCoordinat(Matrix newCoordinate)
  {  
    coordinate = newCoordinate;
  }
  
  Matrix getCoordinate()
  {
    return coordinate;
  }
  
  void addPoint(float x, float y, float z)
  {
    coordinate.addRow(x, y, z, 1);
  }
  
  void show()
  {
    int rows = coordinate.row();
    
    for (int i = 0; i < rows; ++i)
    {      
      strokeWeight(1); 
      // meredian     
      stroke(120, 0, 0);
      for (int j = 0; j < rows; ++j)
      {        
        line(coordinate.get(i, 0), coordinate.get(i, 1), coordinate.get((i+meredianCount)%rows, 0), coordinate.get((i+meredianCount)%rows, 1));    
      } 
      // parallel
      strokeWeight(1); 
      stroke(0, 0, 120);
      line(coordinate.get(i, 0), coordinate.get(i, 1), coordinate.get((i+1)%rows, 0), coordinate.get((i+1)%rows, 1));
      
      // vertex
      strokeWeight(3);
      stroke(0, 255, 0);
      point(coordinate.get(i, 0), coordinate.get(i, 1));
    }
  }
}
