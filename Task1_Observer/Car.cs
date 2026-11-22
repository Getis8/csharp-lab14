namespace Lab_14;

public class Car
{
    private const int LowChargeThreshold = 10;

    private readonly List<ICarEventObserver> _observers = new();

    public string Plate { get; }

    public Car(string plate) => Plate = plate;

    public void Subscribe(ICarEventObserver observer)
    {
        ArgumentNullException.ThrowIfNull(observer);
        if (_observers.Contains(observer)) return;

        _observers.Add(observer);
        Log.Write($"Авто {Plate}", $"{observer.Name} підписався на події");
    }

    public void Unsubscribe(ICarEventObserver observer)
    {
        if (_observers.Remove(observer))
            Log.Write($"Авто {Plate}", $"{observer.Name} відписався від подій");
    }

    // Телематика авто фіксує події
    public void ReportCharge(int percent)
    {
        if (percent <= LowChargeThreshold)
            Publish(CarEventType.LowCharge, $"заряд {percent}%");
    }

    public void ReportCollision() => Publish(CarEventType.Collision, "зафіксовано удар");
    public void ReportLeftZone() => Publish(CarEventType.LeftZone, "виїзд за межі зони");
    public void FinishTrip() => Publish(CarEventType.TripFinished, "поїздку завершено");

    private void Publish(CarEventType type, string details)
    {
        var carEvent = new CarEvent(Plate, type, details);
        Log.Write($"Авто {Plate}", $"ініціює подію {type} ({details}), підписників: {_observers.Count}");

        // Копія списку: підписник може відписатися під час розсилки
        foreach (var observer in _observers.ToList())
            observer.OnCarEvent(carEvent);
    }
}