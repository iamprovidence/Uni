class DropWave
{
  int showToCircle; 
  int waveAmount;
  Wave[] waves;
  
  DropWave(int waveAmount ,float x, float y, float size, float speed)
  {
    this.waveAmount = waveAmount;
    this.waves = new Wave[waveAmount];
    for (int i = 0; i < waveAmount; ++i)
    {
       this.waves[i] = new Wave(x, y, size, speed);
    }
    this.showToCircle = 0;
  }
  void show()
  {
    for (int i = 0; i < showToCircle; ++i)
    {
       waves[i].show();
    }
    if (frameCount % 60 == 0)
    {
      if(showToCircle != waveAmount)
      {
        ++showToCircle;
      }
    }
  }
  void update()
  {
    for (int i = 0; i < showToCircle; ++i)
    {
       waves[i].update();
    }
  }
  boolean isHidden()
  {
    for (int i = 0; i < showToCircle; ++i)
    {
      if(!waves[i].isHidden())
      {
        return false;
      }
    }
    return true;
  }
}
