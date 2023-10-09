using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dbManager;
using Logger;
using DocumentSaver;

namespace SingletonDesignPattern
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            db = dbMnanger.GetInstance();
            //db.GetAllGroups(comboBox3);
            //this.FormClosed += MyClosedHandler;
            // db.ExecuteMySQL("create table Subjects( Code int not null primary key, sName text, Course tinyint);create table Themes(Code int not null primary key, tName text, tSubject int FOREIGN KEY(tSubject) REFERENCES Subjects(Code), tDescription text); create table Class(Code int not null primary key, Number int, Cipher text, Course tinyint); create table Students(Code int not null primary key, FullName text, Class int foreign key references Class(Code));create table Orders(Code int not null primary key, Number int, oYear int, Subject int foreign key references Subjects(Code)); create table ThemesByOrder(Code int not null primary key, Theme int foreign key references Themes(Code), Student int foreign key references Students(Code), tOrder int references Orders(Code)); ");


            //db.ExecuteMySQL("create table Subjects( Code int not null, sName text, Course tinyint, primary key(Code));");
            //db.ExecuteMySQL("create table Themes ( Code int not null, tName text, tSubject int , tDescription text, primary key(Code), FOREIGN KEY (tSubject) REFERENCES Subjects(Code) );");
            //db.ExecuteMySQL("create table Class ( Number int not null, Cipher text, Course tinyint, primary key(Number));");
            //db.ExecuteMySQL("create table Students ( Code int not null, FullName text, Class int , primary key(Code), foreign key (Class) references Class(Number));");
            //db.ExecuteMySQL("create table Orders (Number int not null, oYear int, Subject int , primary key(Number), foreign key (Subject) references Subjects(Code));");
            //db.ExecuteMySQL("create table ThemesByOrder ( Code int not null, Theme int , Student int , tOrder int , primary key(Code), foreign key (Theme) references Themes(Code), foreign key (Student) references Students(Code), foreign key (tOrder) references Orders(Number));");
            //========================
            //db.ExecuteMySQL("create table Themes(Code int not null, tName text, tSubject int, tDescription text, primary key(Code), FOREIGN KEY(tSubject) REFERENCES Subjects(Code)); ");
            //db.ExecuteMySQL("create table Class ( Code int not null, Number int, Cipher text, Course tinyint, primary key(Code));");
            //db.ExecuteMySQL("create table Students ( Code int not null, FullName text, Class int , primary key(Code), foreign key (Class) references Class(Code));");
            //db.ExecuteMySQL("create table Orders ( Code int not null, Number int, oYear int, Subject int , primary key(Code), foreign key (Subject) references Subjects(Code));");
            //db.ExecuteMySQL("create table ThemesByOrder ( Code int not null, Theme int , Student int , tOrder int , primary key(Code), foreign key (Theme) references Themes(Code), foreign key (Student) references Students(Code), foreign key (tOrder) references Orders(Code));");

            //db.ExecuteMySQL("INSERT INTO Themes VALUES(1, 'randomTheme', 1, 'Theme description')");
            //db.ExecuteMySQL("INSERT INTO Subjects VALUES(1, 'OIPZ', '4')");
            //db.ExecuteMySQL("INSERT INTO Class VALUES(731, 'П-731-31', 4)");
            //db.ExecuteMySQL("INSERT INTO Students VALUES(1, 'Serhii Kosianchuk', 731)");
            //db.ExecuteMySQL("INSERT INTO Orders VALUES(23, 2023, 1)");
            //db.ExecuteMySQL("INSERT INTO ThemesByOrder VALUES(1, 1, 1, 23)");


            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            comboBox5.SelectedIndex = 0;
            db.GetAllVar(comboBox1, "Theme");
            db.GetAllVar(comboBox2, "Class");
            db.GetAllVar(comboBox3, "Course");
            db.GetAllVar(comboBox4, "Subject");
            db.GetAllVar(comboBox6, "Class");

            db.SelectRecords(dataGridView3, "ThemesByOrder", "join Themes on ThemesByOrder.Theme = Themes.Code " +
                "join Students on ThemesByOrder.Student = Students.Code " +
                "join Orders on ThemesByOrder.tOrder = Orders.Number");
            db.SelectRecords(dataGridView4, "Themes", "");
            db.SelectRecords(dataGridView5, "Students", "");
            db.SelectRecords(dataGridView6, "Class", "");
        }

        /*
        protected void MyClosedHandler(object sender, EventArgs e)
        {
            //db.Save();
        }*/

        dbMnanger db;
        int curRow;

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).SelectedIndex == 0)
            {
                db.SelectRecords(dataGridView1, "Themes", "");
                return;
            }
            db.SelectRecords(dataGridView1, "Themes", $"WHERE tName = '{comboBox1.SelectedItem.ToString()}'");
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 0 && comboBox3.SelectedIndex == 0 && comboBox3.SelectedIndex != -1 && comboBox2.SelectedIndex != -1)// && comboBox3.SelectedIndex != -1
            {
                db.SelectRecords(dataGridView2, "Students", "");
                return;
            }
            if (comboBox2.SelectedIndex == 0 && comboBox3.SelectedIndex != 0 && comboBox3.SelectedIndex != -1 && comboBox2.SelectedIndex != -1)
            {
                db.SelectRecords(dataGridView2, "Students", $"join Class on Students.Class = Class.number WHERE Class.Course = '{comboBox3.SelectedItem.ToString()}'");
                return;
            }
            if (comboBox2.SelectedIndex != 0 && comboBox3.SelectedIndex == 0 && comboBox3.SelectedIndex != -1 && comboBox2.SelectedIndex != -1)
            {
                db.SelectRecords(dataGridView2, "Students", $"join Class on Students.Class = Class.number WHERE Class.Cipher = '{comboBox2.SelectedItem.ToString()}'");
                return;
            }
            if (comboBox3.SelectedIndex != -1 && comboBox2.SelectedIndex != -1)
            {
                db.SelectRecords(dataGridView2, "Students", $"join Class on Students.Class = Class.number WHERE  Class.Course = '{comboBox3.SelectedItem.ToString()}' and  Class.Cipher = '{comboBox2.SelectedItem.ToString()}'");
                return;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = checkBox1.Checked ? true : false;
            textBox2.Enabled = checkBox1.Checked ? true : false;
            comboBox4.Enabled = checkBox1.Checked ? true : false;
            richTextBox1.Enabled = checkBox1.Checked ? true : false;
            button1.Enabled = checkBox1.Checked ? true : false;
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int curRow = e.RowIndex;
            int i = 1;
            List<string> currentData = new List<string>();
            foreach (DataGridViewCell s in dataGridView4.Rows[e.RowIndex].Cells)
            {
                currentData.Add(s.Value.ToString());
                i += 2;
            }
            textBox2.Text = currentData[0];
            textBox1.Text = currentData[1];
            comboBox4.SelectedItem = db.GetFieldValueByID("Subjects", "sName", currentData[2]);
            richTextBox1.Text = currentData[3];
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            textBox4.Enabled = checkBox2.Checked ? true : false;
            textBox3.Enabled = checkBox2.Checked ? true : false;
            comboBox6.Enabled = checkBox2.Checked ? true : false;
            button2.Enabled = checkBox2.Checked ? true : false;
        }

        private void dataGridView5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int curRow = e.RowIndex;
            int i = 1;
            List<string> currentData = new List<string>();
            foreach (DataGridViewCell s in dataGridView5.Rows[e.RowIndex].Cells)
            {
                currentData.Add(s.Value.ToString());
                i += 2;
            }
            textBox3.Text = currentData[0];
            textBox4.Text = currentData[1];
            comboBox6.SelectedItem = db.GetFieldValueByID("Class", "Cipher", currentData[2]);
        }

        private void dataGridView6_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int curRow = e.RowIndex;
            int i = 1;
            List<string> currentData = new List<string>();
            foreach (DataGridViewCell s in dataGridView6.Rows[e.RowIndex].Cells)
            {
                currentData.Add(s.Value.ToString());
                i += 2;
            }
            textBox5.Text = currentData[0];
            textBox6.Text = currentData[1];
            textBox7.Text = currentData[2];
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            textBox4.Enabled = checkBox3.Checked ? true : false;
            textBox5.Enabled = checkBox3.Checked ? true : false;
            textBox6.Enabled = checkBox3.Checked ? true : false;
        }



        //Tab Theme { filter, edit, submit } waiting for answer
        //Tab Students { edit, submit } waiting for answer
        //Tab Class { edit, submit } waiting for answer

    }
}
