package models.Education;

import models.Education.Enums.InstitutionCompareType;

import java.util.Comparator;

public class InstitutionComparator implements Comparator<AbstractEducationalInstitution>
{
    // FIELDS
    InstitutionCompareType compareType;

    // CONSTRUCTORS
    public InstitutionComparator(InstitutionCompareType compareType)
    {
        this.compareType = compareType;
    }

    // METHODS
    public int compare(AbstractEducationalInstitution a, AbstractEducationalInstitution b)
    {
        switch (compareType)
        {
            case Name:      return a.name.compareTo(b.name);
            case Year:      return a.year.compareTo(b.year);
            case Address:   return a.address.compareTo(b.address);

            default:        throw new UnsupportedOperationException("Current comparing type is not allowed");
        }
    }
}
