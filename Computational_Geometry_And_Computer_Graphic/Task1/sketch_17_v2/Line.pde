class Line
{
  // FIELDS
  private float lineHeight;
  private float distance;
  private String text;
  private int conditionIndex;
  
  private Point first;
  private Point second;
  
  private ArrayList<Point> points;
  // CONSTRUCTORS
  Line(float lineHeight, float distance,int conditionIndex, String text)
  {
    this.lineHeight = lineHeight;
    this.distance = distance;
    this.conditionIndex = conditionIndex;
    this.text = text;
    
    this.first = new Point((width - distance)/2, lineHeight, color(0, 255, 0), 8);
    this.second = new Point((width + distance)/2, lineHeight, color(0, 255, 0), 8);
    this.points = new ArrayList<Point>();
    fillWithPoint();
  }
  // METHODS
  void show()
  {
       
    
    for (int i = 0; i < points.size(); ++i)
    {
      points.get(i).show();
    }
    color(255);
    text(text, 20, 40);
    
    stroke(255, 0, 0);
    strokeWeight(4);
    line(0, lineHeight, width, lineHeight); 
    
    first.show();
    second.show();
  }
  void update(float distance)
  {
    if (distance != this.distance)
    {
        this.distance = distance;
  
        this.first.setX((width - distance)/2);
        this.second.setX((width + distance)/2);
        this.points.clear();
        fillWithPoint();        
    }
  }
  // Р = С^2 / 4
  // P < C^2 / 4
  // C^2 / 4 < P < C^2 / 2
  // P > C^2 / 4
  private boolean condition(int conditionIndex, float pointDistance)
  {
    switch (conditionIndex)
    {
      default:
      case 0: return pointDistance == distance*distance / 4;
      case 1: return pointDistance < distance*distance / 4;
      case 2: return pointDistance > distance*distance / 4 && pointDistance < distance*distance / 2;
      case 3: return pointDistance > distance*distance / 4;
    }    
  }
  private void fillWithPoint()
  {
    for (float i = 0; i < width; ++i)
    {
      for (float j = 0; j < height; ++j)
      {
        if (condition(conditionIndex, first.distance(i, j) * second.distance(i, j)))
        {
          points.add(new Point(i, j, color(0, 0, 255), 4));
        }
      }      
    }
  }  
}
