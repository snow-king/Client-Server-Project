
namespace Client
{
	/**
	Класс для запуска клиента.
	
	+-------------------
	В коде нет документации.
	*/
    public class Runner
    {
        public void Run() 
        {
		   /**Метод для управления программой. 
            В формате диалога с пользователем выясняет что он хочет сделать:
			вывести все из таблиц, вывести определенную строку или отправить yaml файл. 
			В зависимости от выбора пользователя используя конструкцию switch case 
			отправляет GET запросы на получение и вывод информации с помощью методов 
			класса Reciver или POST запрос на отправку  yaml файла с помощью метода 
			класса Sender. Цикл будет повторяться до тех пор пока пользователь не  
			введет любую букву в меню выбора и программа не завершит свою работу.
			
			+-------------------	
			В case 11-15 программа просит пользователя ввести id, 
			но при этом не считывает строку символов из входного 
			потока (Console.ReadLine() в задокументированном коде). 
			Незавершенный код можно пометить маркером TODO.
			
			В case 1 вводимая пользователем переменная Id нигде не используется.
			Код можно пометить маркером TODO, если он будет использоваться в будущем 
			*/
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
