🇬🇧 [English](README.md) | 🇺🇦 **Українська**

# 🚗 Lab14: Поведінкові шаблони в сервісі каршерингу

Консольний проєкт на **C# / .NET**, що моделює дві проблемні ситуації сервісу каршерингу «Міськавто» поведінковими шаблонами **Observer** і **Mediator**. Кожна подія виводиться в журнал у форматі `[час] [джерело] подія`, тому видно, хто ініціював подію і хто на неї відреагував.

![C#](https://img.shields.io/badge/C%23-12-239120?logo=csharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-8.0%2B-512BD4?logo=dotnet&logoColor=white)

## 📖 Про проєкт

| Завдання | Проблема | Шаблон | Рішення |
|----------|----------|--------|---------|
| 1 | Модуль телематики напряму викликав кожного отримувача, і підключення страхової вимагало змін у ньому | **Observer** | `Car` (Subject) тримає список `ICarEventObserver` і сповіщає всіх підписників. Кожен отримувач сам вирішує, на які події реагувати. Клієнт підписується лише на час поїздки |
| 2 | Кожна служба викликала методи всіх інших, і кожен клас знав про всі інші | **Mediator** | Служби знають лише `IDispatchMediator`. Усі правила реагування в `DispatchCenter.Notify`. Нова служба (мийка) додається без змін в існуючих |

## 👥 Автори

- **_Катя_**: [@kskrasssss](https://github.com/kskrasssss): завдання 1 (Observer)
- **_Стас_**: [@Getis8](https://github.com/Getis8): завдання 2 (Mediator)
- Крос-рев'ю: див. [REVIEW.md](REVIEW.md)

## ⬇️ Як завантажити

```bash
git clone https://github.com/Getis8/csharp-lab14.git
cd your-repo
```

## ▶️ Як запустити

1. Встанови [.NET SDK](https://dotnet.microsoft.com/download).
2. З кореня проєкту:
   ```bash
   dotnet build
   dotnet run
   ```
3. Обери `1` (Observer) або `2` (Mediator) у меню.

## 📁 Структура

```text
├── Program.cs              # меню
├── Common/                 # журнал
├── Task1_Observer/         # Car, підписники, події
├── Task2_Mediator/         # DispatchCenter, служби
├── Runner/                 # окремий метод для кожної ситуації
├── docs/diagrams/          # UML-діаграми класів (.mmd + .svg/.png)
└── REVIEW.md               # крос-рев'ю
```

## 📝 Ліцензія

Проєкт створено в навчальних цілях. Використовуй вільно.