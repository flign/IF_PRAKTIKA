namespace IF_PRAKTIKA
{
    public class User
    {
        private int Id;
        private string Name, Surname;

        public int Get_Id()
        {
            return Id;
        }

        public void Set_Id(int _Id)
        {
            Id = _Id;
        }

        public string Get_Name()
        {
            return Name;
        }

        public void Set_Name(string _Name)
        {
            Name = _Name;
        }

        public string Get_Surname()
        {
            return Surname;
        }

        public void Set_Surname(string _Surname)
        {
            Surname = _Surname;
        }
    }
}
