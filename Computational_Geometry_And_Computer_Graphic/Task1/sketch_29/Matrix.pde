class Matrix
{
  // FIELDS
  private ArrayList<float[]> base;
  // CONSTRUCTORS
  Matrix()
  {
    base = new ArrayList<float[]>();
  }
  // METHODS
  void addRow(float v1, float v2, float v3, float v4)
  {
    base.add(new float[]{ v1, v2, v3, v4 }); 
  }
  void set(int i, int j, float v)
  {
    base.get(i)[j] = v;
  }
  float get(int i, int j)
  {
    return base.get(i)[j];
  }
  Matrix mult(Matrix m2)
  {
    // building empty
    Matrix res = new Matrix();
    for(int i = 0; i < this.row(); ++i)
    {
      res.base.add(new float[m2.col()]);
    }
    // multiplying
    for (int i = 0; i < this.row(); ++i) 
    {  
        for (int j = 0; j < m2.col(); ++j) 
        {  
            float sum = 0;
            for (int k = 0; k < this.col(); ++k) 
            {  
                sum += this.get(i, k) * m2.get(k, j);  
            }  
            res.base.get(i)[j] = sum; 
        }  
    }
    return res;
  }
  int row()
  {
    return base.size();
  }
  int col()
  {
    return 4;
  }
}
