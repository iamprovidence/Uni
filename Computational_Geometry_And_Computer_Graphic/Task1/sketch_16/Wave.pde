class Wave
{
  // FIELDS
  float x;
  float y;
  float size;
  float speed;
  float alpha;
  float weight;
  color fillColor;
  // CONSTRUCTORS
  Wave(float x, float y, float size, float speed)
  {
    this.x = x;
    this.y = y;
    this.size = size;
    this.speed = speed;
    this.alpha = 255;
    this.weight = 4;
    this.fillColor = color(random(255), random(255), random(255));
    // this.fillColor = color(0, 0, 255);
  }
  // METHODS
  void show()
  {
    stroke(fillColor, alpha);
    strokeWeight(weight);
    noFill();
    ellipse(x, y, size, size);
  }
  void update()
  {
    size += speed;
    alpha -= speed;
  }
  boolean isHidden()
  {
    return alpha <= 0;
  }
}
