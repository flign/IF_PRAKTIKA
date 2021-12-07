namespace IF_PRAKTIKA
{
    partial class Panel_Lecturer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Button_Update = new System.Windows.Forms.Button();
            this.Text_Mark = new System.Windows.Forms.TextBox();
            this.Combobox_Group = new System.Windows.Forms.ListBox();
            this.Combobox_Student = new System.Windows.Forms.ListBox();
            this.Combobox_Subject = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(138, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Studentas:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(278, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Dalykas:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Pažymys:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Grupė:";
            // 
            // Button_Update
            // 
            this.Button_Update.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_Update.Location = new System.Drawing.Point(141, 136);
            this.Button_Update.Name = "Button_Update";
            this.Button_Update.Size = new System.Drawing.Size(295, 23);
            this.Button_Update.TabIndex = 8;
            this.Button_Update.Text = "Atnaujinti";
            this.Button_Update.UseVisualStyleBackColor = true;
            this.Button_Update.Click += new System.EventHandler(this.button1_Click);
            // 
            // Text_Mark
            // 
            this.Text_Mark.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Text_Mark.Location = new System.Drawing.Point(74, 137);
            this.Text_Mark.Name = "Text_Mark";
            this.Text_Mark.Size = new System.Drawing.Size(61, 22);
            this.Text_Mark.TabIndex = 9;
            // 
            // Combobox_Group
            // 
            this.Combobox_Group.FormattingEnabled = true;
            this.Combobox_Group.Location = new System.Drawing.Point(15, 28);
            this.Combobox_Group.Name = "Combobox_Group";
            this.Combobox_Group.Size = new System.Drawing.Size(120, 95);
            this.Combobox_Group.TabIndex = 10;
            this.Combobox_Group.SelectedIndexChanged += new System.EventHandler(this.Combobox_Group_SelectedIndexChanged);
            // 
            // Combobox_Student
            // 
            this.Combobox_Student.FormattingEnabled = true;
            this.Combobox_Student.Location = new System.Drawing.Point(141, 28);
            this.Combobox_Student.Name = "Combobox_Student";
            this.Combobox_Student.Size = new System.Drawing.Size(134, 95);
            this.Combobox_Student.TabIndex = 11;
            // 
            // Combobox_Subject
            // 
            this.Combobox_Subject.FormattingEnabled = true;
            this.Combobox_Subject.Location = new System.Drawing.Point(281, 28);
            this.Combobox_Subject.Name = "Combobox_Subject";
            this.Combobox_Subject.Size = new System.Drawing.Size(155, 95);
            this.Combobox_Subject.TabIndex = 12;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(141, 165);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(295, 23);
            this.button2.TabIndex = 21;
            this.button2.Text = "Atsijungti";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Panel_Lecturer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 215);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Combobox_Subject);
            this.Controls.Add(this.Combobox_Student);
            this.Controls.Add(this.Combobox_Group);
            this.Controls.Add(this.Text_Mark);
            this.Controls.Add(this.Button_Update);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Panel_Lecturer";
            this.Text = "Dėstytojas";
            this.Load += new System.EventHandler(this.panelLecturer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Button_Update;
        private System.Windows.Forms.TextBox Text_Mark;
        private System.Windows.Forms.ListBox Combobox_Group;
        private System.Windows.Forms.ListBox Combobox_Student;
        private System.Windows.Forms.ListBox Combobox_Subject;
        private System.Windows.Forms.Button button2;
    }
}