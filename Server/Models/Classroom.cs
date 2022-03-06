namespace Server.Models
{
    class Classroom
    {
        public int Id_classroom { get; set; }
        public string Frame { get; set; }
        public int Classroom_number { get; set; }

        public Classroom(string[] data)
        {
            Id_classroom = System.Convert.ToInt32(data[0]);
            Frame = data[1];
            Classroom_number = System.Convert.ToInt32(data[2]);
        }
    }
}
