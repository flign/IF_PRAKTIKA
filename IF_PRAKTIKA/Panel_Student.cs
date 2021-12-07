using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace IF_PRAKTIKA
{
    public partial class Panel_Student : Form
    {
        SQL _SQL = new SQL();

        List<Subject> Subject_List;

        int Current_Student_Group = -1;
        int Current_Student_Id = -1;

        public Panel_Student(int _Current_Student_Group, int _Current_Student_Id)
        {
            InitializeComponent();

            Current_Student_Group = _Current_Student_Group;
            Current_Student_Id = _Current_Student_Id;
        }

        private void panelStudent_Load(object sender, EventArgs e)
        {
            listView1.Items.Clear();

            Subject_List = _SQL.Read_Subject_By_Group(Current_Student_Group);

            for (int i = 0; i < Subject_List.Count; i++)
            {
                string asd = "";
                int Current_Mark = _SQL.Get_Mark(Current_Student_Id, Subject_List[i].Get_Id());
                
                string Current_Subject_Name = Subject_List[i].Get_Name();
                if (Current_Mark == -1)
                { 
                    ListViewItem LVI = new ListViewItem(new[] { Current_Subject_Name, asd });
                    listView1.Items.Add(LVI); 
                }
                else
                { 
                    ListViewItem LVI = new ListViewItem(new[] { Current_Subject_Name, Current_Mark.ToString() });
                    listView1.Items.Add(LVI);
                }
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Login().Show();
            Hide();
        }
    }
}
