🇬🇧 **English** | 🇺🇦 [Українська](README.uk.md)

# 🚗 Lab14: Behavioral Patterns in a Car-Sharing Service

A **C# / .NET** console project that models two problem situations of the car-sharing service "Miskavto" with the behavioral patterns **Observer** and **Mediator**. Every event is written to a journal in the format `[time] [source] event`, so it is visible who initiated an event and who reacted to it.

![C#](https://img.shields.io/badge/C%23-12-239120?logo=csharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-8.0%2B-512BD4?logo=dotnet&logoColor=white)

## 📖 About

| Task | Problem | Pattern | Solution |
|------|---------|---------|----------|
| 1 | The telematics module called every receiver directly, so connecting the insurer required changing it | **Observer** | `Car` (Subject) keeps a list of `ICarEventObserver` and notifies all subscribers. Each observer decides which events to react to. The client subscribes only for the duration of a trip |
| 2 | Every service called the methods of all others, and every class knew about all the rest | **Mediator** | Services only know `IDispatchMediator`. All reaction rules live in `DispatchCenter.Notify`. A new service (car wash) is added without changing existing ones |

## 👥 Authors

- **_Katya_**: [@kskrasssss](https://github.com/kskrasssss): task 1 (Observer)
- **_Stas_**: [@Getis8](https://github.com/Getis8): task 2 (Mediator)
- Cross-review: see [REVIEW.md](REVIEW.md)

## ⬇️ Download

```bash
git clone https://github.com/Getis8/csharp-lab14.git
cd your-repo
```

## ▶️ Run

1. Install the [.NET SDK](https://dotnet.microsoft.com/download).
2. From the project root:
   ```bash
   dotnet build
   dotnet run
   ```
3. Choose `1` (Observer) or `2` (Mediator) in the menu. Console text is in Ukrainian.

## 📁 Structure

```text
├── Program.cs              # menu
├── Common/                 # journal
├── Task1_Observer/         # Car, observers, events
├── Task2_Mediator/         # DispatchCenter, services
├── Runner/                 # one scenario method per situation
├── docs/diagrams/          # UML class diagrams (.mmd + .svg/.png)
└── REVIEW.md               # cross-review
```

## 📝 License

Created for educational purposes. Feel free to use it.