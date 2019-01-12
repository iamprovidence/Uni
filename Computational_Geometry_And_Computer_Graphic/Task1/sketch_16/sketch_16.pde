// 16. Розробити анімаційну програму,
// яка виконує кольорову анімацію набору різнокольорових концентричних кіл 
// так, що за рахунок зміни кольорів та плавної зміни розмірів кіл 
// створити ілюзію руху.

ArrayList<DropWave> waves;

void setup()
{
  size(400, 360);
  waves = new ArrayList<DropWave>();
}

void draw()
{
  background(240);
  for (DropWave dropWave: waves)
  {
    dropWave.update();
    dropWave.show();
  }
}

void mousePressed()
{
  waves.add(new DropWave(4, mouseX, mouseY, 8, 0.75));
  // cleaning time
  if(waves.size() > 20)
  {
    for (int i = 0; i < waves.size(); ++i) 
    {
     if (waves.get(i).isHidden()) 
     {
        waves.remove(i);
        -- i; // decrease the counter by one
     }
    }
  }
}
