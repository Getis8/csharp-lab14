namespace Lab_14;

public enum CarEventType
{
    LowCharge,
    Collision,
    LeftZone,
    TripFinished
}

public record CarEvent(string Plate, CarEventType Type, string Details);

// Observer: спільний контракт підписника
public interface ICarEventObserver
{
    string Name { get; }
    void OnCarEvent(CarEvent carEvent);
}