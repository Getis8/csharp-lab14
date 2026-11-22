namespace Lab_14;

public class DispatchCenter : IDispatchMediator
{
    private readonly ClientApp _app;
    private readonly FleetMapService _map;
    private readonly TowService _tow;
    private readonly MaintenanceService _maintenance;
    private readonly SupportService _support;
    private CarWashService? _wash;

    public DispatchCenter(ClientApp app, FleetMapService map, TowService tow,
        MaintenanceService maintenance, SupportService support)
    {
        _app = app;
        _map = map;
        _tow = tow;
        _maintenance = maintenance;
        _support = support;

        foreach (var service in new DispatchService[] { app, map, tow, maintenance, support })
            service.Mediator = this;
    }

    // Підключення нової служби: змінюється лише координатор
    public void ConnectCarWash(CarWashService wash)
    {
        _wash = wash;
        wash.Mediator = this;
        Log.Write("Координатор", "Підключено службу мийки");
    }

    public void Notify(DispatchService sender, DispatchEvent dispatchEvent, string plate)
    {
        Log.Write("Координатор", $"Отримав {dispatchEvent} ({plate}) від «{sender.Name}»");

        switch (dispatchEvent)
        {
            case DispatchEvent.AccidentReported:
                _app.EndTrip(plate);
                _tow.CallTow(plate);
                _map.RemoveCar(plate);
                _support.OpenCase(plate);
                break;

            case DispatchEvent.RepairFinished:
                _map.ReturnCar(plate);
                break;

            case DispatchEvent.TowCompleted:
                if (_wash is not null)
                    _wash.Wash(plate);
                break;
        }
    }
}