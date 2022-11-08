namespace aynur4pract
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Task> tasks = new List<Task>()
            {
                new Task() {header="Пойти в магазин", text = "Купить онигири", date = new DateTime(2022,11,08)},
                new Task() {header="Пойти в магазин", text = "Купить йогурт клубничный ЧУДО", date = new DateTime(2022,11,09)},
                new Task() {header="Пойти в магазин", text = "Купить Pringles со вкусом уксуса", date = new DateTime(2022,11,10)},
                new Task() {header="Пойти в магазин", text = "Купить BURN со вкусом яблоко - киви", date = new DateTime(2022,11,11)},
                new Task() {header="Пойти в магазин", text = "Купить Pringles со вкусом краба", date = new DateTime(2022,11,12)}
            };
            Cursor cursor = new Cursor() { style = ">>", lowestPos = 1, pos = 1 };
            DateTime date = DateTime.Today;
            bool exit = false;
            Task selectedTask = new Task();
            while (!exit)
            {
                cursor.lowestPos = 0;
                Console.Clear();
                Console.WriteLine("Сегодня " + date.ToShortDateString());
                for (int i = 0; i < tasks.Count; i++)
                {
                    if (tasks[i].date == date)
                    {
                        cursor.lowestPos += 1;
                        Console.WriteLine("   " + cursor.lowestPos + ". " + tasks[i].header);
                        if (cursor.pos == cursor.lowestPos)
                            selectedTask = tasks[i];
                    }
                }
                Console.SetCursorPosition(0, cursor.pos);
                Console.Write(cursor.style);
                ConsoleKeyInfo key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.Enter:
                        Console.Clear();
                        Console.WriteLine(selectedTask.header);
                        Console.WriteLine(selectedTask.text);
                        Console.ReadKey();
                        cursor.pos = 1;
                        break;
                    case ConsoleKey.Escape:
                        exit = true;
                        break;
                    case ConsoleKey.RightArrow:
                        date = date.AddDays(1);
                        break;
                    case ConsoleKey.LeftArrow:
                        date = date.AddDays(-1);
                        break;
                    case ConsoleKey.UpArrow:
                        if (cursor.pos == 1)
                            cursor.pos = cursor.lowestPos;
                        else
                            cursor.pos -= 1;
                        break;
                    case ConsoleKey.DownArrow:
                        if (cursor.pos == cursor.lowestPos)
                            cursor.pos = 1;
                        else
                            cursor.pos += 1;
                        break;
                }
            }
        }
    }
}