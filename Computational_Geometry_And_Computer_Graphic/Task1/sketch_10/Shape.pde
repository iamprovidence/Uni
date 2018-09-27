class Shape
{
  // FIELDS
  Matrix coordinate;
  color strokeColor;
  int strokeWeight;
  // CONSTRUCTORS
  Shape(color strokeColor)
  {
    this.strokeColor = strokeColor;
    this.strokeWeight = 3;
    this.coordinate = new Matrix();    
  }
  // METHODS
  void setCoordinate(Matrix newCoordinate)
  {
    coordinate = newCoordinate;
  }
  Matrix getCoordinate()
  {
    return coordinate;
  }
  void addPoint(float x, float y)
  {
    coordinate.addRow(x, y, 1);
  }
  void show()
  {
    int rows = coordinate.row();
    strokeWeight(strokeWeight);
    stroke(strokeColor);
    // link each vertex with lines
    for (int i = 0; i < rows; ++i)
    {
      line(coordinate.get(i, 0), coordinate.get(i, 1), 
        coordinate.get((i+1)%rows, 0), coordinate.get((i+1)%rows, 1));
    }
  }
}
