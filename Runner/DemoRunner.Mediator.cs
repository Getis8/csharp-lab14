namespace Lab_14;

public static partial class DemoRunner
{
    public static void RunMediator()
    {
        Log.Section("Завдання 2. Mediator: диспетчерська служба");

        var app = new ClientApp();
        var tow = new TowService();
        var maintenance = new MaintenanceService();
        var center = new DispatchCenter(app, new FleetMapService(), tow, maintenance, new SupportService());

        Log.Write("Сценарій", "Служба обслуговування завершила ремонт");
        maintenance.FinishRepair("CE1234AA");

        Log.Write("Сценарій", "Клієнт повідомляє про ДТП");
        app.ReportAccident("CE2345BB");

        Log.Write("Сценарій", "Підключаємо мийку (існуючі служби не змінюються)");
        center.ConnectCarWash(new CarWashService());

        Log.Write("Сценарій", "Евакуація завершена");
        tow.FinishEvacuation("CE2345BB");     // координатор направляє авто на мийку
    }
}