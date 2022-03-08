
namespace Client
{
    public class Runner
    {
        public void Run() 
        {
            Reciver reciver = new Reciver();
            Sender sender = new Sender();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Введите цифру: \n0 - Чтобы вывести всё из таблиц.\n1 - Чтобы вывести нужную вам строку.\n2 - Чтобы отправить yaml файл.\nЛибо введите любую букву для завершения программы.");
            Console.ResetColor();

            while (Int32.TryParse(Console.ReadLine(),out int input)) 
            {
                switch (input) 
                {
                    case 0:
                        reciver.GetInfo();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Вывод закончен!");
                        Console.ResetColor();
                        break;
                    case 1:
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("Введите нужный Id:");
                        Console.ResetColor();
                        Int32.TryParse(Console.ReadLine(), out int Id);
                        Console.WriteLine("");
                        reciver.GetProfessors();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Вывод закончен!");
                        Console.ResetColor();
                        break;
                    case 11:
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("Введите нужный Id:");
                        Console.ResetColor();
                        //Int32.TryParse(Console.ReadLine(), out int Id);
                        Console.WriteLine("");
                        reciver.GetProfessorsDate();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Вывод закончен!");
                        Console.ResetColor();
                        break;
                    case 12:
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("Введите нужный Id:");
                        Console.ResetColor();
                        //Int32.TryParse(Console.ReadLine(), out int Id);
                        Console.WriteLine("");
                        reciver.GetClassroom();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Вывод закончен!");
                        Console.ResetColor();
                        break;
                    case 13:
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("Введите нужный Id:");
                        Console.ResetColor();
                        //Int32.TryParse(Console.ReadLine(), out int Id);
                        Console.WriteLine("");
                        reciver.GetClassroomDate();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Вывод закончен!");
                        Console.ResetColor();
                        break;
                    case 14:
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("Введите нужный Id:");
                        Console.ResetColor();
                        //Int32.TryParse(Console.ReadLine(), out int Id);
                        Console.WriteLine("");
                        reciver.GetGroup();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Вывод закончен!");
                        Console.ResetColor();
                        break;
                    case 15:
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("Введите нужный Id:");
                        Console.ResetColor();
                        //Int32.TryParse(Console.ReadLine(), out int Id);
                        Console.WriteLine("");
                        reciver.GetGroupDate();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Вывод закончен!");
                        Console.ResetColor();                        
                        break;
                    case 2:
                        Console.WriteLine("Введите путь к файлу:");
                        sender.UploadYamlFile(Console.ReadLine());
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Вывод закончен!");
                        Console.ResetColor();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Чтобы завершить программу - введите не цифру!");
                        Console.ResetColor();
                        break;

                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Введите цифру: \n0 - Чтобы вывести всё из таблиц.\n1 - Чтобы вывести нужную вам строку.\n2 - Чтобы отправить yaml файл.\nЛибо введите любую букву для завершения программы.");
                Console.ResetColor();
            }
        }
    }
}
