namespace IF_PRAKTIKA
{
    public class Group
    {
        private int Id;
        private string Name;

        public void Set_Id(int _Id)
        {
            Id = _Id;
        }

        public void Set_Name(string _Name)
        {
            Name = _Name;
        }

        public int Get_Id()
        {
            return Id;
        }

        public string Get_Name()
        {
            return Name;
        }
    }
}
