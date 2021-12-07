using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace IF_PRAKTIKA
{
    public partial class Panel_Admin : Form
    {
        SQL _SQL = new SQL();

        List<Group> Group_List;
        List<Student> Student_List;
        List<Subject> Subject_List;
        List<Lecturer> lecturerList;

        public Panel_Admin()
        {
            InitializeComponent();
        }

        private void panelAdmin_Load(object sender, EventArgs e)
        {
            try
            {
                updateGroup_List();
                updateStudent_List();
                updateLecturerList();
                updateSubject_List();
            }
            catch
            {

            }
        }

        #region Student Group

        private void bCreateGroup_Click(object sender, EventArgs e)
        {
            try
            {
                if (_SQL.Bool_Student_Group_Exists(TextBox_New_Group.Text))
                {
                    MessageBox.Show("Tokia grupė jau egzistuoja!");
                    return;
                }
                else
                {
                    Combobox_sGroup.Items.Clear();
                    _SQL.Insert_Student_Group(TextBox_New_Group.Text);
                    updateGroup_List();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nepavyko įterpti grupės: " + ex.ToString());
            }
        }

        private void bDeleteGroup_Click(object sender, EventArgs e)
        {
            _SQL.Delete_Student_Group(Group_List[Combobox_sGroup.SelectedIndex].Get_Id());

            updateGroup_List();
        }

        private void updateGroup_List()
        {
            Combobox_sGroup.Items.Clear();
            Combobox_Group.Items.Clear();
            Current_Student_Group.Items.Clear();

            Group_List = _SQL.Read_Student_Group();

            for (int i = 0; i < Group_List.Count; i++)
                Combobox_sGroup.Items.Add(Group_List[i].Get_Name());

            for (int i = 0; i < Group_List.Count; i++)
                Combobox_Group.Items.Add(Group_List[i].Get_Name());

            for (int i = 0; i < Group_List.Count; i++)
                Current_Student_Group.Items.Add(Group_List[i].Get_Name());
        }

        #endregion

        #region Student

        private void bCreateStudent_Click(object sender, EventArgs e)
        {
            try
            {
                if (!TextBox_New_Student.Text.Contains(" "))
                {
                    MessageBox.Show("Neteisingas vardo pavardės formatas. Formatas: Vardas Pavardė");
                }
                else
                {
                    string Name = TextBox_New_Student.Text.Split(' ')[0];
                    string Surname = TextBox_New_Student.Text.Split(' ')[1];

                    if (_SQL.Bool_Student_Exists(Name, Surname))
                    {
                        MessageBox.Show("Toks studentas jau egzistuoja!");
                        return;
                    }
                    else
                    {
                        Combobox_Student.Items.Clear();
                        _SQL.Insert_User(Name, Surname, 1, Name, Surname, 0);
                        updateStudent_List();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Nepavyko įterpti studento: " + ex.ToString());
            }
        }

        private void bDeleteStudent_Click(object sender, EventArgs e)
        {
            _SQL.Delete_User(Student_List[Combobox_Student.SelectedIndex].Get_Id());

            updateStudent_List();
        }

        private void updateStudent_List()
        {
            Combobox_Student.Items.Clear();
            Current_Student.Items.Clear();

            Student_List = _SQL.Read_Student();

            for (int i = 0; i < Student_List.Count; i++)
                Combobox_Student.Items.Add(Student_List[i].Get_Name() + " " + Student_List[i].Get_Surname());

            for (int i = 0; i < Student_List.Count; i++)
                Current_Student.Items.Add(Student_List[i].Get_Name() + " " + Student_List[i].Get_Surname());
        }

        #endregion

        #region Lecturer

        private void bCreateLecturer_Click(object sender, EventArgs e)
        {
            try
            {
                if (TextBox_New_Lecturer.Text.Contains(" "))
                {
                    if (string.IsNullOrWhiteSpace(TextBox_New_Lecturer.Text) || Regex.IsMatch(TextBox_New_Lecturer.Text, "^[0-9 ]+$"))
                        MessageBox.Show("Neteisingas vardo pavardės formatas. Formatas: Vardas Pavardė");
                    else
                    {
                        string Name = TextBox_New_Lecturer.Text.Split(' ')[0];
                        string Surname = TextBox_New_Lecturer.Text.Split(' ')[1];

                        if (_SQL.Bool_Lecturer_Exists(Name, Surname))
                        {
                            MessageBox.Show("Toks dėstytojas jau egzistuoja!");
                            return;
                        }
                        else
                        {
                            Combobox_Lecturer.Items.Clear();
                            _SQL.Insert_User(Name, Surname, 2, Name, Surname, 0);
                            updateLecturerList();
                        }
                    }
                }
                else
                    MessageBox.Show("Neteisingas vardo pavardės formatas. Formatas: Vardas Pavardė");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nepavyko įterpti dėstytojo: " + ex.ToString());
            }
        }

        private void bDeleteLecturer_Click(object sender, EventArgs e)
        {
            _SQL.Delete_User(lecturerList[Combobox_Lecturer.SelectedIndex].Get_Id());

            updateLecturerList();
        }

        private void updateLecturerList()
        {
            Combobox_Lecturer.Items.Clear();
            Combobox_Lecturer2.Items.Clear();
            Combobox_Lecturer1.Items.Clear();

            lecturerList = _SQL.Read_Lecturer();

            for (int i = 0; i < lecturerList.Count; i++)
                Combobox_Lecturer.Items.Add(lecturerList[i].Get_Name() + " " + lecturerList[i].Get_Surname());

            for (int i = 0; i < lecturerList.Count; i++)
                Combobox_Lecturer2.Items.Add(lecturerList[i].Get_Name() + " " + lecturerList[i].Get_Surname());

            for (int i = 0; i < lecturerList.Count; i++)
                Combobox_Lecturer1.Items.Add(lecturerList[i].Get_Name() + " " + lecturerList[i].Get_Surname());
        }

        #endregion

        #region Subject

        private void bCreateSubject_Click(object sender, EventArgs e)
        {
            try
            {
                if (_SQL.Bool_Subject_Exists(TextBox_New_Subject.Text))
                {
                    MessageBox.Show("Toks dalykas jau egzistuoja!");
                    return;
                }
                else
                {
                    Combobox_Subject.Items.Clear();
                    _SQL.Insert_Subject(TextBox_New_Subject.Text, lecturerList[Combobox_Lecturer2.SelectedIndex].Get_Id());
                    updateSubject_List();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nepavyko įterpti dalyko: " + ex.ToString());
            }
        }

        private void bDelete_Subject_Click(object sender, EventArgs e)
        {
            _SQL.Delete_Subject(Subject_List[Combobox_Subject.SelectedIndex].Get_Id());

            updateSubject_List();
        }

        private void updateSubject_List()
        {
            Combobox_Subject.Items.Clear();
            Current_Subject.Items.Clear();
            Current_Subject1.Items.Clear();

            Subject_List = _SQL.Read_Subject();

            for (int i = 0; i < Subject_List.Count; i++)
                Combobox_Subject.Items.Add(Subject_List[i].Get_Name());

            for (int i = 0; i < Subject_List.Count; i++)
                Current_Subject.Items.Add(Subject_List[i].Get_Name());

            for (int i = 0; i < Subject_List.Count; i++)
                Current_Subject1.Items.Add(Subject_List[i].Get_Name());
        }


        #endregion

        private void bLecturerToGroup_Click(object sender, EventArgs e)
        {
            _SQL.Update_Subject_Group(Group_List[Combobox_Group.SelectedIndex].Get_Id(), Subject_List[Current_Subject.SelectedIndex].Get_Id());

            updateSubject_List();
        }

        private void bSubjectToLecturer_Click(object sender, EventArgs e)
        {
            _SQL.Update_Subject_Lecturer(lecturerList[Combobox_Lecturer1.SelectedIndex].Get_Id(), Subject_List[Current_Subject1.SelectedIndex].Get_Id());

            updateSubject_List();
        }

        private void bStudentToGroup_Click(object sender, EventArgs e)
        {
            _SQL.Update_Student_Group(Group_List[Current_Student_Group.SelectedIndex].Get_Id(), Student_List[Current_Student.SelectedIndex].Get_Id());

            updateSubject_List();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Login().Show();
            Hide();
        }
    }
}
