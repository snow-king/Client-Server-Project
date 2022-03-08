
namespace Client
{
    public class Runner
    {
        public void Run() 
        {
            Reciver reciver = new Reciver();
            Sender sender = new Sender();
            string name, surname, patronomic, number, frame, group, day, parity;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Введите цифру: " +
                "\n0 - Чтобы вывести всё из таблиц." +
                "\n1 - Чтобы вывести расписание по ФИО преподпвателя." +
                "\n2 - Чтобы вывести расписание по ФИО и дню недели." +
                "\n3 - Чтобы вывести расписание по аудитории." +
                "\n4 - Чтобы вывести расписание по аудитории и дню недели." +
                "\n5 - Чтобы вывести расписание по группе." +
                "\n6 - Чтобы вывести расписание по группе и дню недели." +
                "\n7 - Чтобы отправить yaml файл." +
                "\nЛибо, введите любую букву для завершения программы.");
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
                        Console.Write("Введите фамилию преподавателя (пример: Курганская): ");
                        surname = Console.ReadLine();
                        Console.Write("Введите имя преподавателя (приемер: Ольга): ");
                        name = Console.ReadLine();
                        Console.Write("Введите отчество преподавателя (пример: Викторовна): ");
                        patronomic = Console.ReadLine();
                        Console.WriteLine("");
                        reciver.GetProfessors(name,surname,patronomic);
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Вывод закончен!");
                        Console.ResetColor();
                        break;
                    case 2:
                        Console.Write("Введите фамилию преподавателя (пример: Курганская): ");
                        surname = Console.ReadLine();
                        Console.Write("Введите имя преподавателя (приемер: Ольга): ");
                        name = Console.ReadLine();
                        Console.Write("Введите отчество преподавателя (пример: Викторовна): ");
                        patronomic = Console.ReadLine();
                        Console.Write("Введите день недели (пример Понедельник): ");
                        day = Console.ReadLine();
                        Console.Write("Введите вид недели (пример Числитель\\Знаменатель): ");
                        parity = Console.ReadLine();
                        Console.WriteLine();
                        reciver.GetProfessorsDate(name, surname, patronomic, day, parity);
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Вывод закончен!");
                        Console.ResetColor();
                        break;
                    case 3:
                        Console.Write("Введите номер аудитории (пример 401): ");
                        number = Console.ReadLine();
                        Console.Write("Введите букву корпуса (пример А): ");
                        frame = Console.ReadLine();
                        Console.WriteLine();
                        reciver.GetClassroom(number,frame);
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Вывод закончен!");
                        Console.ResetColor();
                        break;
                    case 4:
                        Console.Write("Введите номер аудитории (пример 401): ");
                        number = Console.ReadLine();
                        Console.Write("Введите букву корпуса (пример А): ");
                        frame = Console.ReadLine();
                        Console.Write("Введите день недели (пример Понедельник): ");
                        day = Console.ReadLine();
                        Console.Write("Введите вид недели (пример Числитель\\Знаменатель): ");
                        parity = Console.ReadLine();
                        Console.WriteLine();
                        reciver.GetClassroomDate(number, frame, day, parity);
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Вывод закончен!");
                        Console.ResetColor();
                        break;
                    case 5:
                        Console.Write("Введите группу (пример: ПИ.1-18-1): ");
                        group = Console.ReadLine();
                        Console.WriteLine();
                        reciver.GetGroup(group);
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Вывод закончен!");
                        Console.ResetColor();
                        break;
                    case 6:
                        Console.Write("Введите группу (пример: ПИ.1-18-1): ");
                        group = Console.ReadLine();
                        Console.Write("Введите день недели (пример Понедельник): ");
                        day = Console.ReadLine();
                        Console.Write("Введите вид недели (пример Числитель\\Знаменатель): ");
                        parity = Console.ReadLine();
                        Console.WriteLine();
                        reciver.GetGroupDate(group, day, parity);
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Вывод закончен!");
                        Console.ResetColor();                        
                        break;
                    case 7:
                        Console.WriteLine("Выберите таблицу для отправки:" +
                                "\n0 - для отправки в таблицу расписания" +
                                "\n1 - для отправки в таблицу учебных аудиторий" +
                                "\n2 - для отправки в таблицу учебных предметов" +
                                "\n3 - для отправки в таблицу факультетов" +
                                "\n4 - для отправки в таблицу времен занятий" +
                                "\n5 - для отправки в таблицу видов занятий" +
                                "\n6 - для отправки в таблицу преподавателей" +
                                "\n7 - для отправки в таблицу специальностей" +
                                "\n8 - для отправки в таблицу учебных групп" +
                                "\n9 - для отправки в таблицу дней недели" +
                                "\n10 - для отправки в таблицу видов недель");
                        
                        if (Int32.TryParse(Console.ReadLine(), out int choise))
                        {
                            SendSelect(choise);
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("Вывод закончен!");
                            Console.ResetColor();
                        }
                        else 
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Неправильный ввод!");
                            Console.ResetColor();
                        }
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Чтобы завершить программу - введите не цифру!");
                        Console.ResetColor();
                        break;

                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Введите цифру: " +
                "\n0 - Чтобы вывести всё из таблиц." +
                "\n1 - Чтобы вывести расписание по ФИО преподпвателя." +
                "\n2 - Чтобы вывести расписание по ФИО и дню недели." +
                "\n3 - Чтобы вывести расписание по аудитории." +
                "\n4 - Чтобы вывести расписание по аудитории и дню недели." +
                "\n5 - Чтобы вывести расписание по группе." +
                "\n6 - Чтобы вывести расписание по группе и дню недели." +
                "\n7 - Чтобы отправить yaml файл." +
                "\nЛибо, введите любую букву для завершения программы.");
                Console.ResetColor();
            }
        }

        private void SendSelect(int choise) 
        {
            var sender = new Sender();
            Console.WriteLine("Введите путь к файлу:");
            switch (choise) 
            {
                case 0:
                    sender.UploadYamlFile("timetable", Console.ReadLine());
                    break;
                case 1:
                    sender.UploadYamlFile("classroom", Console.ReadLine());
                    break;
                case 2:
                    sender.UploadYamlFile("discipline", Console.ReadLine());
                    break;
                case 3:
                    sender.UploadYamlFile("faculty", Console.ReadLine());
                    break;
                case 4:
                    sender.UploadYamlFile("lesson_time", Console.ReadLine());
                    break;
                case 5:
                    sender.UploadYamlFile("lesson_type", Console.ReadLine());
                    break;
                case 6:
                    sender.UploadYamlFile("professors", Console.ReadLine());
                    break;
                case 7:
                    sender.UploadYamlFile("speciality", Console.ReadLine());
                    break;
                case 8:
                    sender.UploadYamlFile("study_groups", Console.ReadLine());
                    break;
                case 9:
                    sender.UploadYamlFile("week_day", Console.ReadLine());
                    break;
                case 10:
                    sender.UploadYamlFile("week_parity", Console.ReadLine());
                    break;
                default:
                    sender.UploadYamlFile("", Console.ReadLine());
                    break;
            }
        }
    }
}
