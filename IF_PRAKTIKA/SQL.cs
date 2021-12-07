using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Windows.Forms;

namespace IF_PRAKTIKA
{
    public class SQL
    {
        private static SQLiteConnection Sqlite_Connection;

        public SQL()
        {
            Sqlite_Connection = Create_Connection();

            Create_Table();

            if (!User_Exists("student", "student"))
                Insert_User("student", "student", 1, "student", "student", 0);

            if (!User_Exists("lecturer", "lecturer"))
                Insert_User("lecturer", "lecturer", 2, "lecturer", "lecturer", 0);

            if (!User_Exists("admin", "admin"))
                Insert_User("admin", "admin", 3, "admin", "admin", 0);
        }

        static SQLiteConnection Create_Connection()
        {
            Sqlite_Connection = new SQLiteConnection("Data Source=database.db; Version = 3; New = True; Compress = True; ");

            try
            {
                Sqlite_Connection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.ToString());
            }

            return Sqlite_Connection;
        }

        private static void Create_Table()
        {
            using (SQLiteCommand sqlite_cmd = Sqlite_Connection.CreateCommand())
            {
                sqlite_cmd.CommandText = "CREATE TABLE IF NOT EXISTS Mark (id INTEGER PRIMARY KEY AUTOINCREMENT, Subject INT, Student INT, Mark INT, " +
                    "FOREIGN KEY (Student) REFERENCES User (id), FOREIGN KEY (Subject) REFERENCES Subject (id))";
                sqlite_cmd.ExecuteNonQuery();

                sqlite_cmd.CommandText = "CREATE TABLE IF NOT EXISTS sGroup (id INTEGER PRIMARY KEY AUTOINCREMENT, Name VARCHAR(32))";
                sqlite_cmd.ExecuteNonQuery();

                sqlite_cmd.CommandText = "CREATE TABLE IF NOT EXISTS Subject (id INTEGER PRIMARY KEY AUTOINCREMENT, Name VARCHAR(32), Lecturer INT, sGroup INT, FOREIGN KEY (sGroup) REFERENCES sGroup (id))";
                sqlite_cmd.ExecuteNonQuery();

                sqlite_cmd.CommandText = "CREATE TABLE IF NOT EXISTS User (id INTEGER PRIMARY KEY AUTOINCREMENT, Username VARCHAR(32), Password VARCHAR(32), Role INT, Name VARCHAR(32), " +
                    "Surname VARCHAR(32), sGroup INT, FOREIGN KEY (sGroup) REFERENCES sGroup (id))";

                sqlite_cmd.ExecuteNonQuery();
            }
        }

        public void Insert_User(string Username, string Password, int Role, string Name, string Surname, int sGroup)
        {
            using (SQLiteCommand sqlite_cmd = Sqlite_Connection.CreateCommand())
            {
                sqlite_cmd.CommandText = String.Format("INSERT INTO User (Username, Password, Role, Name, Surname, sGroup) " +
                    "VALUES('{0}', '{1}', '{2}','{3}','{4}','{5}');", Username, Password, Role, Name, Surname, sGroup);

                sqlite_cmd.ExecuteNonQuery();
            }
        }

        public bool User_Exists(string Username, string Password)
        {
            bool Result = false;

            using (SQLiteCommand sqlite_cmd = Sqlite_Connection.CreateCommand())
            {
                sqlite_cmd.CommandText = string.Format("SELECT * FROM User WHERE Username='{0}' AND Password='{1}'", Username, Password);

                using (SQLiteDataReader sqlite_datareader = sqlite_cmd.ExecuteReader())
                    while (sqlite_datareader.Read())
                        Result = sqlite_datareader.HasRows;
            }
            return Result;
        }

        public int Get_User_Role(string Username, string Password)
        {
            int Result = 0;

            using (SQLiteCommand sqlite_cmd = Sqlite_Connection.CreateCommand())
            {
                sqlite_cmd.CommandText = string.Format("SELECT * FROM User WHERE Username='{0}' AND Password='{1}'", Username, Password);

                using (SQLiteDataReader sqlite_datareader = sqlite_cmd.ExecuteReader())
                    while (sqlite_datareader.Read())
                        Result = sqlite_datareader.GetInt32(3);
            }
            return Result;
        }

        public void Insert_Subject(string Name, int Lecturer)
        {
            using (SQLiteCommand sqlite_cmd = Sqlite_Connection.CreateCommand())
            {
                sqlite_cmd.CommandText = String.Format("INSERT INTO Subject (Name, Lecturer) VALUES('{0}', '{1}');", Name, Lecturer);
                sqlite_cmd.ExecuteNonQuery();
            }
        }

        public void Insert_Student_Group(string Name)
        {
            using (SQLiteCommand sqlite_cmd = Sqlite_Connection.CreateCommand())
            {
                sqlite_cmd.CommandText = String.Format("INSERT INTO sGroup (Name) VALUES('{0}');", Name);
                sqlite_cmd.ExecuteNonQuery();
            }
        }

        public void Delete_Student_Group(int id)
        {
            using (SQLiteCommand sqlite_cmd = Sqlite_Connection.CreateCommand())
            {
                sqlite_cmd.CommandText = String.Format("DELETE FROM sGroup WHERE rowid = '{0}';", id);
                sqlite_cmd.ExecuteNonQuery();
            }
        }

        public bool Bool_Student_Group_Exists(string Name)
        {
            bool Result = false;

            using (SQLiteCommand sqlite_cmd = Sqlite_Connection.CreateCommand())
            {
                sqlite_cmd.CommandText = String.Format("SELECT * FROM sGroup WHERE Name = '{0}'", Name);

                using (SQLiteDataReader sqlite_datareader = sqlite_cmd.ExecuteReader())
                    while (sqlite_datareader.Read())
                        Result = sqlite_datareader.HasRows;
            }
            return Result;
        }

        public List<Group> Read_Student_Group()
        {
            List<Group> Result = new List<Group>();

            using (SQLiteCommand sqlite_cmd = Sqlite_Connection.CreateCommand())
            {
                sqlite_cmd.CommandText = "SELECT id, Name FROM sGroup";

                using (SQLiteDataReader sqlite_datareader = sqlite_cmd.ExecuteReader())
                {
                    while (sqlite_datareader.Read())
                    {
                        Group G = new Group();

                        G.Set_Id(sqlite_datareader.GetInt32(0));
                        G.Set_Name(sqlite_datareader.GetString(1));

                        Result.Add(G);
                    }
                }
            }
            return Result;
        }

        public bool Bool_Student_Exists(string Name, string Surname)
        {
            bool Result = false;

            using (SQLiteCommand sqlite_cmd = Sqlite_Connection.CreateCommand())
            {
                sqlite_cmd.CommandText = String.Format("SELECT * FROM User WHERE Name = '{0}' AND Surname = '{1}' AND Role = '1'", Name, Surname);

                using (SQLiteDataReader sqlite_datareader = sqlite_cmd.ExecuteReader())
                    while (sqlite_datareader.Read())
                        Result = sqlite_datareader.HasRows;
            }
            return Result;
        }

        public List<Student> Read_Student()
        {
            List<Student> Result = new List<Student>();

            using (SQLiteCommand sqlite_cmd = Sqlite_Connection.CreateCommand())
            {
                sqlite_cmd.CommandText = "SELECT * FROM User";

                using (SQLiteDataReader sqlite_datareader = sqlite_cmd.ExecuteReader())
                {
                    while (sqlite_datareader.Read())
                    {
                        if (sqlite_datareader.GetInt32(3) == 1)
                        {
                            Student S = new Student();

                            S.Set_Id(sqlite_datareader.GetInt32(0));
                            S.Set_Name(sqlite_datareader.GetString(1));
                            S.Set_Surname(sqlite_datareader.GetString(2));

                            Result.Add(S);
                        }
                    }
                }
            }
            return Result;
        }

        public void Delete_User(int id)
        {
            using (SQLiteCommand sqlite_cmd = Sqlite_Connection.CreateCommand())
            {
                sqlite_cmd.CommandText = String.Format("DELETE FROM User WHERE id = '{0}';", id);
                sqlite_cmd.ExecuteNonQuery();
            }
        }




        public bool Bool_Subject_Exists(string Name)
        {
            bool Result = false;

            using (SQLiteCommand sqlite_cmd = Sqlite_Connection.CreateCommand())
            {
                sqlite_cmd.CommandText = String.Format("SELECT * FROM Subject WHERE Name = '{0}'", Name);

                using (SQLiteDataReader sqlite_datareader = sqlite_cmd.ExecuteReader())
                    while (sqlite_datareader.Read())
                        Result = sqlite_datareader.HasRows;
            }
            return Result;
        }

        public List<Subject> Read_Subject()
        {
            List<Subject> Result = new List<Subject>();

            using (SQLiteCommand sqlite_cmd = Sqlite_Connection.CreateCommand())
            {
                sqlite_cmd.CommandText = "SELECT * FROM Subject";

                using (SQLiteDataReader sqlite_datareader = sqlite_cmd.ExecuteReader())
                {
                    while (sqlite_datareader.Read())
                    {
                        Subject S = new Subject();

                        S.Set_Id(sqlite_datareader.GetInt32(0));
                        S.Set_Name(sqlite_datareader.GetString(1));
                        S.setLecturer(sqlite_datareader.GetInt32(2));

                        Result.Add(S);
                    }
                }
            }
            return Result;
        }

        public void Delete_Subject(int id)
        {
            using (SQLiteCommand sqlite_cmd = Sqlite_Connection.CreateCommand())
            {
                sqlite_cmd.CommandText = String.Format("DELETE FROM Subject WHERE id = '{0}'", id);
                sqlite_cmd.ExecuteNonQuery();
            }
        }



        public bool Bool_Lecturer_Exists(string Name, string Surname)
        {
            bool Result = false;

            using (SQLiteCommand sqlite_cmd = Sqlite_Connection.CreateCommand())
            {
                sqlite_cmd.CommandText = String.Format("SELECT * FROM User WHERE Name = '{0}' AND Surname = '{1}' AND Role = '2'", Name, Surname);

                using (SQLiteDataReader sqlite_datareader = sqlite_cmd.ExecuteReader())
                    while (sqlite_datareader.Read())
                        Result = sqlite_datareader.HasRows;
            }
            return Result;
        }

        public List<Lecturer> Read_Lecturer()
        {
            List<Lecturer> Result = new List<Lecturer>();

            using (SQLiteCommand sqlite_cmd = Sqlite_Connection.CreateCommand())
            {
                sqlite_cmd.CommandText = "SELECT * FROM User";

                using (SQLiteDataReader sqlite_datareader = sqlite_cmd.ExecuteReader())
                {
                    while (sqlite_datareader.Read())
                    {
                        if (sqlite_datareader.GetInt32(3) == 2)
                        {
                            Lecturer L = new Lecturer();

                            L.Set_Id(sqlite_datareader.GetInt32(0));
                            L.Set_Name(sqlite_datareader.GetString(1));
                            L.Set_Surname(sqlite_datareader.GetString(2));

                            Result.Add(L);
                        }
                    }
                }
            }
            return Result;
        }

        public void Update_Subject_Group(int sGroup, int id)
        {
            using (SQLiteCommand sqlite_cmd = Sqlite_Connection.CreateCommand())
            {
                sqlite_cmd.CommandText = String.Format("UPDATE Subject SET sGroup = '{0}' WHERE id = '{1}'", sGroup, id);
                sqlite_cmd.ExecuteNonQuery();
            }
        }

        public void Update_Subject_Lecturer(int Lecturer, int id)
        {
            using (SQLiteCommand sqlite_cmd = Sqlite_Connection.CreateCommand())
            {
                sqlite_cmd.CommandText = String.Format("UPDATE Subject SET Lecturer = '{0}' WHERE id='{1}'", Lecturer, id);
                sqlite_cmd.ExecuteNonQuery();
            }
        }

        public void Update_Student_Group(int Group, int id)
        {
            using (SQLiteCommand sqlite_cmd = Sqlite_Connection.CreateCommand())
            {
                sqlite_cmd.CommandText = String.Format("UPDATE User SET sGroup = '{0}' WHERE id='{1}'", Group, id);
                sqlite_cmd.ExecuteNonQuery();
            }
        }

        public List<Student> Read_Student_By_Group(int group)
        {
            List<Student> Result = new List<Student>();

            using (SQLiteCommand sqlite_cmd = Sqlite_Connection.CreateCommand())
            {
                sqlite_cmd.CommandText = String.Format("SELECT * FROM User WHERE sGroup = {0}", group);

                using (SQLiteDataReader sqlite_datareader = sqlite_cmd.ExecuteReader())
                {
                    while (sqlite_datareader.Read())
                    {
                        if (sqlite_datareader.GetInt32(3) == 1)
                        {
                            Student S = new Student();

                            S.Set_Id(sqlite_datareader.GetInt32(0));
                            S.Set_Name(sqlite_datareader.GetString(1));
                            S.Set_Surname(sqlite_datareader.GetString(2));


                            Result.Add(S);
                        }
                    }
                }
            }
            return Result;
        }

        public List<Subject> Read_Subject_By_Group_And_Lecturer(int Group, int Lecturer)
        {
            List<Subject> Result = new List<Subject>();

            using (SQLiteCommand sqlite_cmd = Sqlite_Connection.CreateCommand())
            {
                sqlite_cmd.CommandText = String.Format("SELECT * FROM Subject WHERE sGroup = '{0}' AND Lecturer = '{1}'", Group, Lecturer);

                using (SQLiteDataReader sqlite_datareader = sqlite_cmd.ExecuteReader())
                {
                    while (sqlite_datareader.Read())
                    {
                        Subject S = new Subject();

                        S.Set_Id(sqlite_datareader.GetInt32(0));
                        S.Set_Name(sqlite_datareader.GetString(1));
                        S.setLecturer(sqlite_datareader.GetInt32(2));
                        S.setGroup(sqlite_datareader.GetInt32(3));

                        Result.Add(S);
                    }
                }
            }
            return Result;
        }

        public List<Subject> Read_Subject_By_Group(int Group)
        {
            List<Subject> Result = new List<Subject>();

            using (SQLiteCommand sqlite_cmd = Sqlite_Connection.CreateCommand())
            {
                sqlite_cmd.CommandText = String.Format("SELECT * FROM Subject WHERE sGroup = '{0}'", Group);

                using (SQLiteDataReader sqlite_datareader = sqlite_cmd.ExecuteReader())
                {
                    while (sqlite_datareader.Read())
                    {
                        Subject S = new Subject();

                        S.Set_Id(sqlite_datareader.GetInt32(0));
                        S.Set_Name(sqlite_datareader.GetString(1));
                        S.setLecturer(sqlite_datareader.GetInt32(2));
                        S.setGroup(sqlite_datareader.GetInt32(3));

                        Result.Add(S);
                    }
                }
            }
            return Result;
        }

        public int Get_User_Id_By_Credentials(string Username, string Password)
        {
            int Result = 0;

            using (SQLiteCommand sqlite_cmd = Sqlite_Connection.CreateCommand())
            {
                sqlite_cmd.CommandText = String.Format("SELECT * FROM User WHERE Username = '{0}' AND Password = '{1}'", Username, Password);

                using (SQLiteDataReader sqlite_datareader = sqlite_cmd.ExecuteReader())
                    while (sqlite_datareader.Read())
                        Result = sqlite_datareader.GetInt32(0);
            }
            return Result;
        }

        public int Get_Mark_Exists(int Subject, int Student)
        {
            int Result = -1;

            using (SQLiteCommand sqlite_cmd = Sqlite_Connection.CreateCommand())
            {
                sqlite_cmd.CommandText = String.Format("SELECT * FROM Mark WHERE Subject = '{0}' AND Student = '{1}'", Subject, Student);

                using (SQLiteDataReader sqlite_datareader = sqlite_cmd.ExecuteReader())
                    while (sqlite_datareader.Read())
                        Result = sqlite_datareader.GetInt32(0);
            }
            return Result;
        }

        public void Update_Mark(int Subject, int Student, int Mark)
        {
            int Row_Id = Get_Mark_Exists(Subject, Student);

            string cmd = "";

            if (Row_Id != -1)
                cmd = String.Format("UPDATE Mark SET Subject = '{0}', Student = '{1}', Mark = '{2}' WHERE id='{3}'", Subject, Student, Mark, Row_Id);
            else
                cmd = String.Format("INSERT INTO Mark (Subject, Student, Mark) VALUES ('{0}', '{1}', '{2}') ", Subject, Student, Mark);

            using (SQLiteCommand sqlite_cmd = Sqlite_Connection.CreateCommand())
            {
                sqlite_cmd.CommandText = cmd;
                sqlite_cmd.ExecuteNonQuery();
            }
        }

        public int Get_Group_Of_Student(string Username, string Password)
        {
            int Result = -1;

            using (SQLiteCommand sqlite_cmd = Sqlite_Connection.CreateCommand())
            {
                sqlite_cmd.CommandText = String.Format("SELECT * FROM User WHERE Username = '{0}' AND Password = '{1}'", Username, Password);

                using (SQLiteDataReader sqlite_datareader = sqlite_cmd.ExecuteReader())
                    while (sqlite_datareader.Read())
                        Result = sqlite_datareader.GetInt32(6);
            }
            return Result;
        }

        public int Get_Mark(int Student, int Subject)
        {
            int Result = -1;

            using (SQLiteCommand sqlite_cmd = Sqlite_Connection.CreateCommand())
            {
                sqlite_cmd.CommandText = String.Format("SELECT * FROM Mark WHERE Subject = '{0}' AND Student = '{1}'", Subject, Student);

                using (SQLiteDataReader sqlite_datareader = sqlite_cmd.ExecuteReader())
                    while (sqlite_datareader.Read())
                        Result = sqlite_datareader.GetInt32(3);
            }
            return Result;
        }
    }
}
