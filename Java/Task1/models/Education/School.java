package models.Education;

public class School extends AbstractEducationalInstitution
{
    // FIELDS
    String number;
    int pupilsAmount;

    // CONSTRUCTORS
    public School()
    {
        this.number = randomNumber();
        this.pupilsAmount = randomPupilsAmount();
    }
    private String randomNumber()
    {
        return Integer.toString(random.nextInt());
    }
    private int randomPupilsAmount()
    {
        return random.nextInt( 500) + 100;
    }

    // METHODS
    public int getPupilsAmount()
    {
        return pupilsAmount;
    }
    @Override
    public String toString()
    {
        return String.join(" ",  "**School**", "number :", number, "name : ", name,
                "\n", "pupils amount :", Integer.toString(pupilsAmount) , "address :", address, "Founded in : ", year, "year", "\n");
    }
}
