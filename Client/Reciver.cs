using System.Net;

namespace Client
{
	/**
	Класс для отправки GET запросов.
	
	+-------------------
	В коде нет документации.
	
	Во всех методах есть повторяющийся код (помечен в методах). 
	Алгоритм создания и отправки GET запроса можно 
	поместить в отдельный метод и вызывать его, 
	отправляя нужный url адрес в качестве входного аргумента. 
	*/
    internal class Reciver
    {
	    /**Метод получения информации из таблицы расписание.
        Создает с помощью метода Create HTTP-запрос типа «GET»,
		используя специальный URL-адрес в качестве параметра.
		Отправляет GET запрос на получение всей информации из таблицы расписания. 
		Получает ответ от сервера и выводит данные в консоль.
		*/
        public void GetInfo()
        {
            try
            {
                var url = "http://localhost:9911/timetable";
                //Повторяющийся код 1
                var request = WebRequest.Create(url);
                request.Method = "GET";

                using var webResponse = request.GetResponse();
                using var webStream = webResponse.GetResponseStream();

                using var reader = new StreamReader(webStream);

                var data = reader.ReadToEnd();

                Console.WriteLine(data);
            }
            catch (Exception e)
            { Console.WriteLine(e.Message); }
        }
		
		/**Метод получения информации из таблицы расписание по id.
        Создает с помощью метода Create HTTP-запрос типа «GET», 
		используя специальный URL-адрес в качестве параметра. 
		Отправляет GET запрос на получение всей информации из 
		таблицы расписания по id. Получает ответ от сервера и 
		выводит данные в консоль.
		
	    +-------------------
		Входной аргумент Id нигде не используется
		*/
        public void GetInfo(int Id)
        {
            try
            {
                var url = "http://localhost:9911/Timetable/";
                //Повторяющийся код 2
                var request = WebRequest.Create(url);
                request.Method = "GET";

                using var webResponse = request.GetResponse();
                using var webStream = webResponse.GetResponseStream();

                using var reader = new StreamReader(webStream);

                var data = reader.ReadToEnd();

                Console.WriteLine(data);
            }
            catch (Exception e)
            { Console.WriteLine(e.Message); }
        }
		
		/**Метод получения расписания по преподавателю.
        Создает с помощью метода Create HTTP-запрос типа «GET»,
		используя специальный URL-адрес в качестве параметра. 
		Отправляет GET запрос на получение расписания по преподавателю. 
		Получает ответ от сервера и выводит данные в консоль.	
	    */
        public void GetProfessors()
        {     
            try
            {
                var url = "http://localhost:9911/professors?name=Анатолий&surname=Ермаков&patronymic=Анатольевич";
                //Повторяющийся код 3
                var request = WebRequest.Create(url);
                request.Method = "GET";

                using var webResponse = request.GetResponse();
                using var webStream = webResponse.GetResponseStream();

                using var reader = new StreamReader(webStream);

                var data = reader.ReadToEnd();

                Console.WriteLine(data);
            }
            catch (Exception e)
            { Console.WriteLine(e.Message); }
        }
		
		/**Метод получения расписания по преподавателю в конкретный день.
        Создает с помощью метода Create HTTP-запрос типа «GET»,
		используя специальный URL-адрес в качестве параметра.
		Отправляет GET запрос на получение расписания по преподавателю
		в конкретный день. Получает ответ от сервера и выводит данные в консоль.
		*/
        public void GetProfessorsDate()
        {
            try
            {
                var url = "http://localhost:9911/professorsDate?name=Анатолий&surname=Ермаков&patronymic=Анатольевич&weekDay=Среда&parity=Числитель";
                //Повторяющийся код 4
                var request = WebRequest.Create(url);
                request.Method = "GET";

                using var webResponse = request.GetResponse();
                using var webStream = webResponse.GetResponseStream();

                using var reader = new StreamReader(webStream);

                var data = reader.ReadToEnd();

                Console.WriteLine(data);
            }
            catch (Exception e)
            { Console.WriteLine(e.Message); }
        }
		
		/**Метод получения расписания по группе.
        Создает с помощью метода Create HTTP-запрос типа «GET»,
		используя специальный URL-адрес в качестве параметра.
		Отправляет GET запрос на получение расписания по группе.
		Получает ответ от сервера и выводит данные в консоль.	
		*/
        public void GetGroup()
        {
            try
            {
                var url = "http://localhost:9911/group?name=ПИ.1-18-1";
                //Повторяющийся код 5
                var request = WebRequest.Create(url);
                request.Method = "GET";

                using var webResponse = request.GetResponse();
                using var webStream = webResponse.GetResponseStream();

                using var reader = new StreamReader(webStream);

                var data = reader.ReadToEnd();

                Console.WriteLine(data);
            }
            catch (Exception e)
            { Console.WriteLine(e.Message); }
        }
		
		/**Метод получения расписания по группе в конкретный день.
        Создает с помощью метода Create HTTP-запрос типа «GET»,
		используя специальный URL-адрес в качестве параметра.
		Отправляет GET запрос на получение расписания по группе
		в конкретный день. Получает ответ от сервера и выводит
		данные в консоль.	
		*/
        public void GetGroupDate()
        {
            try
            {
                var url = "http://localhost:9911/groupDate?name=ПИ.1-18-1&weekDay=Среда&parity=Числитель";
                //Повторяющийся код 6
                var request = WebRequest.Create(url);
                request.Method = "GET";

                using var webResponse = request.GetResponse();
                using var webStream = webResponse.GetResponseStream();

                using var reader = new StreamReader(webStream);

                var data = reader.ReadToEnd();

                Console.WriteLine(data);
            }
            catch (Exception e)
            { Console.WriteLine(e.Message); }
        }
		
		/**Метод получения расписания по аудитории.
        Создает с помощью метода Create HTTP-запрос типа «GET»,
		используя специальный URL-адрес в качестве параметра.
		Отправляет GET запрос на получение расписания по аудитории.
		Получает ответ от сервера и выводит данные в консоль.	
	    */
        public void GetClassroom()
        {
            try
            {
                var url = "http://localhost:9911/classroom?classroom=401&frame=А";
                //Повторяющийся код 7
                var request = WebRequest.Create(url);
                request.Method = "GET";

                using var webResponse = request.GetResponse();
                using var webStream = webResponse.GetResponseStream();

                using var reader = new StreamReader(webStream);

                var data = reader.ReadToEnd();

                Console.WriteLine(data);
            }
            catch (Exception e)
            { Console.WriteLine(e.Message); }
        }
		
		/**Метод получения расписания по аудитории в конкретный день.
        Создает с помощью метода Create HTTP-запрос типа «GET»,
		используя специальный URL-адрес в качестве параметра.
		Отправляет GET запрос на получение расписания по 
		аудитории в конкретный день. Получает ответ от сервера
		и выводит данные в консоль.	
		*/
        public void GetClassroomDate()
        {
            try
            {
                var url = "http://localhost:9911/classroomDate?classroom=401&frame=А&weekDay=Среда&parity=Числитель";
                //Повторяющийся код 8
                var request = WebRequest.Create(url);
                request.Method = "GET";

                using var webResponse = request.GetResponse();
                using var webStream = webResponse.GetResponseStream();

                using var reader = new StreamReader(webStream);

                var data = reader.ReadToEnd();

                Console.WriteLine(data);
            }
            catch (Exception e)
            { Console.WriteLine(e.Message); }
        }

    }
}
