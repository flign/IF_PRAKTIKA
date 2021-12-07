using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace IF_PRAKTIKA
{
    public partial class Panel_Lecturer : Form
    {
        SQL _SQL = new SQL();

        List<Group> Group_List;
        List<Student> Student_List;
        List<Subject> Subject_List;

        int currentLecturerId = 0;

        public Panel_Lecturer(int _currentLecturerId)
        {
            InitializeComponent();

            currentLecturerId = _currentLecturerId;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int a = Subject_List[Combobox_Subject.SelectedIndex].Get_Id();

                int b = Student_List[Combobox_Student.SelectedIndex].Get_Id();
                if (int.TryParse(Text_Mark.Text, out int value))
                {
                    if (Convert.ToInt32(Text_Mark.Text) > 10 || Convert.ToInt32(Text_Mark.Text) < 1)
                        MessageBox.Show("Pažymys turi būti ribose: 1-10.");
                    else
                    {
                        int c = Convert.ToInt32(Text_Mark.Text);
                        _SQL.Update_Mark(a, b, c);
                    }
                }
                else
                    MessageBox.Show("Blogas pažymio formatas.");
            }
            catch
            {
                MessageBox.Show("Negalima priskirti pažymio, jeigu nedėstote šiam studentui.");
            }
        }

        private void panelLecturer_Load(object sender, EventArgs e)
        {
            Combobox_Group.Items.Clear();

            Group_List = _SQL.Read_Student_Group();

            for (int i = 0; i < Group_List.Count; i++)
                Combobox_Group.Items.Add(Group_List[i].Get_Name());
        }

        private void Combobox_Group_SelectedIndexChanged(object sender, EventArgs e)
        {
            Combobox_Student.Items.Clear();

            Student_List = _SQL.Read_Student_By_Group(Group_List[Combobox_Group.SelectedIndex].Get_Id());

            for (int i = 0; i < Student_List.Count; i++)
                Combobox_Student.Items.Add(Student_List[i].Get_Name() + " " + Student_List[i].Get_Surname());

            Combobox_Subject.Items.Clear();

            Subject_List = _SQL.Read_Subject_By_Group_And_Lecturer(Group_List[Combobox_Group.SelectedIndex].Get_Id(), currentLecturerId);

            for (int i = 0; i < Subject_List.Count; i++)
                Combobox_Subject.Items.Add(Subject_List[i].Get_Name());
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            new Login().Show();
            Hide();
        }
    }
}
