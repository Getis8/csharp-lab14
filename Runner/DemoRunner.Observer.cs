namespace Lab_14;

public static partial class DemoRunner
{
    public static void RunObserver()
    {
        Log.Section("Завдання 1. Observer: події авто");

        var car = new Car("CE1234AA");
        var dispatcher = new DispatcherObserver();
        var fleetService = new FleetServiceObserver();
        var insurance = new InsuranceObserver();
        var client = new ClientObserver("Ткачук");

        // Постійні підписники
        car.Subscribe(dispatcher);
        car.Subscribe(fleetService);
        car.Subscribe(insurance);

        // Клієнт підписується лише на час поїздки
        Log.Write("Сценарій", "Клієнт починає поїздку");
        car.Subscribe(client);

        Log.Write("Сценарій", "Заряд падає до 10%");
        car.ReportCharge(10);                 // реагують клієнт і служба обслуговування

        Log.Write("Сценарій", "Фіксується удар");
        car.ReportCollision();                // реагують диспетчер і страхова

        Log.Write("Сценарій", "Поїздка завершується");
        car.FinishTrip();
        car.Unsubscribe(client);

        Log.Write("Сценарій", "Нова подія після відписки клієнта");
        car.ReportCharge(5);                  // клієнт уже не отримає
    }
}