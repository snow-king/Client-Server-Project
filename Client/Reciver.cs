using System.Net;

namespace Client
{
    internal class Reciver
    {
        public void GetInfo()
        {
            try
            {
                var url = "http://localhost:9911/timetable";

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

        public void GetInfo(int Id)
        {
            try
            {
                var url = "http://localhost:9911/Timetable/";

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

        public void GetProfessors()
        {     
            try
            {
                var url = "http://localhost:9911/professors?name=Анатолий&surname=Ермаков&patronymic=Анатольевич";

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

        public void GetProfessorsDate()
        {
            try
            {
                var url = "http://localhost:9911/professorsDate?name=Анатолий&surname=Ермаков&patronymic=Анатольевич&weekDay=Среда&parity=Числитель";

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

        public void GetGroup()
        {
            try
            {
                var url = "http://localhost:9911/group?name=ПИ.1-18-1";

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

        public void GetGroupDate()
        {
            try
            {
                var url = "http://localhost:9911/groupDate?name=ПИ.1-18-1&weekDay=Среда&parity=Числитель";

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

        public void GetClassroom()
        {
            try
            {
                var url = "http://localhost:9911/classroom?classroom=401&frame=А";

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

        public void GetClassroomDate()
        {
            try
            {
                var url = "http://localhost:9911/classroomDate?classroom=401&frame=А&weekDay=Среда&parity=Числитель";

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
