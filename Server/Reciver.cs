using System.Net;

namespace Client
{
    internal class Reciver
    {
        string url;

        public Reciver() 
        {
            var config = new ConfigInfo();
            url = config.UrlString();
        }
        
        public void GetInfo()
        {
            try
            {
                var request = WebRequest.Create(url + "timetable");
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
                var request = WebRequest.Create(url + "Timetable/");
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

        public void GetProfessors(string name, string surname, string patronymic)
        {     
            try
            {
                var request = WebRequest.Create(url + $"professors?name={name}&surname={surname}&patronymic={patronymic}");
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

        public void GetProfessorsDate(string name, string surname, string patronymic, string day, string weekparity)
        {
            try
            {
                var request = WebRequest.Create(url + $"professorsDate?name={name}&surname={surname}&patronymic={patronymic}&weekDay={day}&parity={weekparity}");
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

        public void GetGroup(string group)
        {
            try
            {
                var request = WebRequest.Create(url + $"group?name={group}");
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

        public void GetGroupDate(string group, string day, string weekparity)
        {
            try
            {
                var request = WebRequest.Create(url + $"groupDate?name={group}&weekDay={day}&parity={weekparity}");
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

        public void GetClassroom(string number, string frame)
        {
            try
            {
                var request = WebRequest.Create(url + $"classroom?classroom={number}&frame={frame}");
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

        public void GetClassroomDate(string number, string frame, string day, string weekparity)
        {
            try
            {
                var request = WebRequest.Create(url + $"classroomDate?classroom={number}&frame={frame}&weekDay={day}&parity={weekparity}");
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
