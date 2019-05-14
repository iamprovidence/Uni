package models.Education;

import java.util.Random;

public abstract class AbstractEducationalInstitution
{
    // FIELDS
    Random random;

    String name;
    String address;
    String year;


    // CONSTRUCTORS
    {
        this.random = new Random();
    }
    public AbstractEducationalInstitution()
    {
        this.name = randomName();
        this.address = randomAddress();
        this.year = randomYear();
    }
    public AbstractEducationalInstitution(String name, String address, String year)
    {
        this.name = name;
        this.address = address;
        this.year = year;
    }

    private String randomName()
    {
        double random = this.random.nextDouble();
        if (random < 0.1) return "Mars";
        if (random < 0.5) return "Portland";
        else              return "Venus";
    }
    private String randomAddress()
    {
        String[] words = new String[]{"lorem", "ipsum", "dolor", "sit", "amet", "consectetur", "adipiscing", "elit" };
        StringBuilder addressBuilder = new StringBuilder();

        int wordLength = (int)Math.random();
        for (int i = 0; i < wordLength; ++i)
        {
            addressBuilder.append(words[this.random.nextInt(words.length)]);
            addressBuilder.append(' ');
        }
        return addressBuilder.toString();
    }
    private String randomYear()
    {
        return new StringBuilder(4)
                .append(1)
                .append(this.random.nextInt(10))
                .append(this.random.nextInt(10))
                .append(this.random.nextInt(10))
                .toString();
    }

    // METHODS
    public String getName()
    {
        return name;
    }
    public String getAddress()
    {
        return address;
    }
    public String getYear()
    {
        return year;
    }
}
