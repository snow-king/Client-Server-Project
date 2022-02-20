namespace Server.Models
{
    class Professors
    {
        public int Id_professors { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }

        public Professors(string[] data)
        {
            Id_professors = System.Convert.ToInt32(data[0]);
            Name = data[1];
            Surname = data[2];
            Patronymic = data[3];
        }
    }
}
