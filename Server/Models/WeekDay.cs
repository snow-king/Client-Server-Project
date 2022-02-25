
namespace Server.Models
{
    class WeekDay
    {
        public int Id_week_day { get; set; }
        public string Weekday { get; set; }

        public WeekDay(string[] data)
        {
            Id_week_day = System.Convert.ToInt32(data[0]);
            Weekday = data[1];
        }
    }
}
