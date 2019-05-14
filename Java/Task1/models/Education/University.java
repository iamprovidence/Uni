package models.Education;

import models.Education.Enums.LevelOfAccreditation;

public class University extends AbstractEducationalInstitution
{
    // FIELDS
    LevelOfAccreditation levelOfAccreditation;
    int facultiesAmount;

    // CONSTRUCTORS
    public University()
    {
        this.levelOfAccreditation = randomLevelOfAccreditation();
        this.facultiesAmount = randomFacultiesAmount();
    }
    private LevelOfAccreditation randomLevelOfAccreditation()
    {
        LevelOfAccreditation[] values = LevelOfAccreditation.values();
        return values[random.nextInt(values.length)];
    }
    private int randomFacultiesAmount()
    {
        return random.nextInt(25) + 5;
    }

    // METHODS
    public LevelOfAccreditation getLevelOfAccreditation()
    {
        return levelOfAccreditation;
    }

    public String toString()
    {
        return String.join(" ",  "**University**", "with accreditation level :", levelOfAccreditation.toString(), "name : ", name,
                "\n", "faculties amount :", Integer.toString(facultiesAmount) , "address :", address, "Founded in : ", year, "year", "\n");
    }
}
