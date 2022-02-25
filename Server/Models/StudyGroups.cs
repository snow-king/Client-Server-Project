namespace Server.Models
{
    class StudyGroups
    {
        public int Id_study_groups { get; set; }
        public string Name_group { get; set; }
        public int Id_faculty { get; set; }
        public int Id_speciality { get; set; }
        public int Course { get; set; }
        public string Form_education { get; set; }

        public StudyGroups(string[] data)
        {
            Id_study_groups = System.Convert.ToInt32(data[0]);
            Name_group = data[1];
            Id_faculty = System.Convert.ToInt32(data[2]);
            Id_speciality = System.Convert.ToInt32(data[3]);
            Course = System.Convert.ToInt32(data[4]);
            Form_education = data[5];
        }
    }
}
