namespace Lab_14;

public enum DispatchEvent
{
    AccidentReported,
    RepairFinished,
    TowCompleted
}

// Mediator: єдина точка, куди служби повідомляють про події
public interface IDispatchMediator
{
    void Notify(DispatchService sender, DispatchEvent dispatchEvent, string plate);
}

// Colleague: служба знає лише посередника
public abstract class DispatchService
{
    public string Name { get; }
    public IDispatchMediator? Mediator { get; internal set; }

    protected DispatchService(string name) => Name = name;

    protected void Raise(DispatchEvent dispatchEvent, string plate)
    {
        if (Mediator is null)
            throw new InvalidOperationException($"{Name} не підключена до координатора");

        Log.Write(Name, $"ініціює подію {dispatchEvent} ({plate}), повідомляю координатору");
        Mediator.Notify(this, dispatchEvent, plate);
    }
}