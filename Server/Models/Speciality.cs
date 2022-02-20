namespace Server.Models
{
    class Speciality
    {
        public int Id_speciality { get; set; }
        public string Name_speciality { get; set; }
        public string Abbreviated_speciality { get; set; }

        public Speciality(string[] data)
        {
            Id_speciality = System.Convert.ToInt32(data[0]);
            Name_speciality = data[1];
            Abbreviated_speciality = data[2];
        }
    }
}
