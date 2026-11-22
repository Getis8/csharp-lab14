namespace Lab_14;

public class ClientApp : DispatchService
{
    public ClientApp() : base("Застосунок клієнта") { }

    public void ReportAccident(string plate) => Raise(DispatchEvent.AccidentReported, plate);

    public void EndTrip(string plate) =>
        Log.Write(Name, $"поїздку на {plate} завершено");
}

public class FleetMapService : DispatchService
{
    public FleetMapService() : base("Карта парку") { }

    public void RemoveCar(string plate) => Log.Write(Name, $"{plate} прибрано з карти");
    public void ReturnCar(string plate) => Log.Write(Name, $"{plate} повернено на карту");
}

public class TowService : DispatchService
{
    public TowService() : base("Служба евакуації") { }

    public void CallTow(string plate) => Log.Write(Name, $"Евакуатор виїхав до {plate}");
    public void FinishEvacuation(string plate) => Raise(DispatchEvent.TowCompleted, plate);
}

public class MaintenanceService : DispatchService
{
    public MaintenanceService() : base("Служба обслуговування") { }

    public void FinishRepair(string plate) => Raise(DispatchEvent.RepairFinished, plate);
}

public class SupportService : DispatchService
{
    public SupportService() : base("Служба підтримки") { }

    public void OpenCase(string plate) =>
        Log.Write(Name, $"Відкрито звернення щодо {plate}, зв'язуюсь із клієнтом");
}

// Нова служба: окремий клас, існуючі служби не змінюються
public class CarWashService : DispatchService
{
    public CarWashService() : base("Мийка") { }

    public void Wash(string plate) => Log.Write(Name, $"Авто {plate} прийнято на мийку");
}