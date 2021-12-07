namespace IF_PRAKTIKA
{
    public class Subject
    {
        private int Id, Lecturer, Group;
        private string Name;

        public int Get_Id()
        {
            return Id;
        }

        public int getLecturer()
        {
            return Lecturer;
        }

        public int getGroup()
        {
            return Group;
        }

        public string Get_Name()
        {
            return Name;
        }

        public void Set_Id(int _Id)
        {
            Id = _Id;
        }

        public void setLecturer(int _Lecturer)
        {
            Lecturer = _Lecturer;
        }

        public void setGroup(int _Group)
        {
            Group = _Group;
        }

        public void Set_Name(string _Name)
        {
            Name = _Name;
        }
    }
}
