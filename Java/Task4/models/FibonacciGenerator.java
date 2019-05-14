package models;

public class FibonacciGenerator
{
    // FIELDS
    int prev;
    int next;

    // CONSTRUCTORS
    public FibonacciGenerator()
    {
        this.prev = 1;
        this.next = 1;
    }

    // METHODS
    public int next()
    {
        int currentNext = prev + next;
        prev = next;
        next = currentNext;
        return next;
    }
    public int getNext()
    {
        return next;
    }
}
