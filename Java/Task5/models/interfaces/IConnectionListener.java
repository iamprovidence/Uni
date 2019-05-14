package models.interfaces;

public interface IConnectionListener
{
    void connectedSet(Object object, models.eventArgs.ConnectionSetsEventArgs eventArgs);
    void connectedUnSet(Object object, Object eventArgs);
}
