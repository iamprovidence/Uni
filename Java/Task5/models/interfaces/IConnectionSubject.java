package models.interfaces;

public interface IConnectionSubject
{
    void addConnectionListener(IConnectionListener connectionListener);
    void removeConnectionListener(IConnectionListener connectionListener);
    void fireConnectedListener();
    void fireDisconnectedListener();
}
