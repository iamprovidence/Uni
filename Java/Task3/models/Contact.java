package models;

public class Contact implements java.io.Serializable
{
    // FIELDS
    String name;
    String phone;

    // CONSTRUCTORS
    public Contact(String name, String phone)
    {
        this.name = name;
        this.phone = phone;
    }

    // METHODS
    public String getName()
    {
        return name;
    }
    public String getPhone()
    {
        return phone;
    }
    public void setName(String name)
    {
        this.name = name;
    }
    public void setPhone(String phone)
    {
        this.phone = phone;
    }

    @Override
    public String toString()
    {
        return name + " - " + phone;
    }
}
