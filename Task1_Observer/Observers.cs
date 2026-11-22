namespace Lab_14;

public class ClientObserver : ICarEventObserver
{
    public string Name { get; }
    public ClientObserver(string clientName) => Name = $"Клієнт {clientName}";

    public void OnCarEvent(CarEvent e)
    {
        switch (e.Type)
        {
            case CarEventType.LowCharge:
                Log.Write(Name, $"отримав сповіщення: {e.Details}, потрібна зарядна станція");
                break;
            case CarEventType.LeftZone:
                Log.Write(Name, "отримав попередження: ви виїхали за межі зони");
                break;
            case CarEventType.TripFinished:
                Log.Write(Name, "отримав підсумок поїздки");
                break;
            // удар клієнта не стосується: реакції немає
        }
    }
}

public class FleetServiceObserver : ICarEventObserver
{
    public string Name => "Служба обслуговування";

    public void OnCarEvent(CarEvent e)
    {
        if (e.Type == CarEventType.LowCharge)
            Log.Write(Name, $"{e.Plate}: {e.Details}, відправляю техніка на підзарядку");
    }
}

public class InsuranceObserver : ICarEventObserver
{
    public string Name => "Страхова компанія";

    public void OnCarEvent(CarEvent e)
    {
        if (e.Type == CarEventType.Collision)
            Log.Write(Name, $"{e.Plate}: {e.Details}, відкрито страхову справу");
    }
}

public class DispatcherObserver : ICarEventObserver
{
    public string Name => "Диспетчер";

    public void OnCarEvent(CarEvent e)
    {
        switch (e.Type)
        {
            case CarEventType.Collision:
                Log.Write(Name, $"{e.Plate}: {e.Details}, зв'язуюсь із клієнтом");
                break;
            case CarEventType.LeftZone:
                Log.Write(Name, $"{e.Plate}: {e.Details}, фіксую порушення");
                break;
            case CarEventType.TripFinished:
                Log.Write(Name, $"{e.Plate}: поїздку закрито");
                break;
        }
    }
}