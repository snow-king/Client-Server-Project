namespace Server.Models
{
    class Discipline
    {
        public int Id_discipline { get; set; }
        public string Name_discipline { get; set; }


        public Discipline(string[] data)
        {
            Id_discipline = System.Convert.ToInt32(data[0]);
            Name_discipline = data[1];
        }
    }
}
