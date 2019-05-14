package models;

public class HighlightText
{
    // FIELDS
    String text;
    int amount;

    // CONSTRUCTORS
    public HighlightText(String text)
    {
        this.text = text;
        this.amount = 0;
    }

    // METHODS
    public void nextChar()
    {
        amount = ++amount % (text.length()+1);
    }
    public int getAmount()
    {
        return amount;
    }
    public String charAt(int index)
    {
        return Character.toString(text.charAt(index));
    }
    public int count()
    {
        return text.length();
    }
    public String toString()
    {
        return text;
    }
}
