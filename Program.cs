using Lab_14;

Console.OutputEncoding = System.Text.Encoding.UTF8;

while (true)
{
    Console.WriteLine("\n=== Лабораторна робота №14 (варіант 8, поведінкові шаблони) ===");
    Console.WriteLine("1 - Observer: події авто");
    Console.WriteLine("2 - Mediator: диспетчерська служба");
    Console.WriteLine("0 - Вихід");
    Console.Write("Ваш вибір: ");

    switch (Console.ReadLine()?.Trim())
    {
        case "1": DemoRunner.RunObserver(); break;
        case "2": DemoRunner.RunMediator(); break;
        case "0": return;
        default: Console.WriteLine("Невірний вибір"); break;
    }
}