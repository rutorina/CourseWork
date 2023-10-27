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
            //db.ExecuteMySQL("create table Themes ( Code int not null, tName text, tType text, tSubject int , tDescription text, primary key(Code), FOREIGN KEY (tSubject) REFERENCES Subjects(Code) );");
            //db.ExecuteMySQL("create table Class ( Number int not null, Cipher text, Course tinyint, primary key(Number));");
            //db.ExecuteMySQL("create table Students ( Code int not null, FullName text, Class int , primary key(Code), foreign key (Class) references Class(Number));");
            //db.ExecuteMySQL("create table Orders (Number int not null, oYear int, Subject int , primary key(Number), foreign key (Subject) references Subjects(Code));");
            //db.ExecuteMySQL("create table ThemesByOrder ( Code int not null, Theme int , Student int , tOrder int , primary key(Code), foreign key (Theme) references Themes(Code), foreign key (Student) references Students(Code), foreign key (tOrder) references Orders(Number));");

            //db.ExecuteMySQL("INSERT INTO Themes VALUES(1, 'randomTheme', 'randomThemeType', 1, 'Theme description')");
            //db.ExecuteMySQL("INSERT INTO Subjects VALUES(1, 'OIPZ', '4')");
            //db.ExecuteMySQL("INSERT INTO Class VALUES(731, 'П-731-31', 4)");
            //db.ExecuteMySQL("INSERT INTO Students VALUES(1, 'Serhii Kosianchuk', 731)");
            //db.ExecuteMySQL("INSERT INTO Orders VALUES(23, 2023, 1)");
            //db.ExecuteMySQL("INSERT INTO ThemesByOrder VALUES(1, 1, 1, 23)");

            List<object> tabEditComp0 = new List<object>();
            tabEditComp0.Add("Themesdb");
            tabEditComp0.Add(textBox2);//code
            tabEditComp0.Add(textBox1);
            tabEditComp0.Add(textBox11);
            tabEditComp0.Add(comboBox4);
            tabEditComp0.Add(richTextBox1);
            editComponents.Add(tabEditComp0);

            List<object> tabEditComp1 = new List<object>();
            tabEditComp1.Add("Studentsdb");
            tabEditComp1.Add(textBox3);
            tabEditComp1.Add(textBox4);
            tabEditComp1.Add(comboBox6);
            editComponents.Add(tabEditComp1);

            List<object> tabEditComp2 = new List<object>();
            tabEditComp2.Add("Classdb");
            tabEditComp2.Add(textBox5);
            tabEditComp2.Add(textBox4);
            tabEditComp2.Add(textBox6);
            editComponents.Add(tabEditComp2);

            List<object> tabEditComp3 = new List<object>();
            tabEditComp3.Add("Subjectsdb");
            tabEditComp3.Add(textBox9);
            tabEditComp3.Add(textBox8);
            tabEditComp3.Add(textBox10);
            editComponents.Add(tabEditComp3);

            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            comboBox5.SelectedIndex = 0;
            comboBox10.SelectedIndex = 0;
            db.GetAllVar(comboBox1, "Theme");
            db.GetAllVar(comboBox2, "Class");
            db.GetAllVar(comboBox3, "Course");
            db.GetAllVar(comboBox7, "Course");
            db.GetAllVar(comboBox8, "Course");
            db.GetAllVar(comboBox4, "Subject");
            db.GetAllVar(comboBox5, "Subject");
            db.GetAllVar(comboBox10, "Class");
            db.GetAllVar(comboBox6, "Class");

            db.SelectRecords(dataGridView3, "ThemesByOrder", "join Themes on ThemesByOrder.Theme = Themes.Code " +
                "join Students on ThemesByOrder.Student = Students.Code " +
                "join Orders on ThemesByOrder.tOrder = Orders.Number");
            db.SelectRecords(dataGridView4, "Themes", "");
            db.SelectRecords(dataGridView5, "Students", "");
            db.SelectRecords(dataGridView6, "Class", "");
            db.SelectRecords(dataGridView7, "Subjects", "");
            
            table.Add("Themes", dataGridView4);
            table.Add("Students", dataGridView5);
            table.Add("Class", dataGridView6);
            table.Add("Subjects", dataGridView7);
        }

        List<List<object>> editComponents = new List<List<object>>();
        Dictionary<string, DataGridView> table = new Dictionary<string, DataGridView>();
        dbMnanger db;
        int curRow;
        string curTable = null;
        DataGridView dataGridView;
        List<string> values = new List<string>();

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).SelectedIndex == 0)
            {
                db.SelectRecords(dataGridView1, "Themes", "");
                return;
            }
            db.SelectRecords(dataGridView1, "Themes", $"WHERE tType = '{comboBox1.SelectedItem.ToString()}'");
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
            foreach (var item in editComponents[Convert.ToInt32(((CheckBox)sender).Tag)])
            {
                if(item != editComponents[Convert.ToInt32(((CheckBox)sender).Tag)][0])
                    ((Control)item).Enabled = ((CheckBox)sender).Checked ? true : false;
            }

            if (((CheckBox)sender).Checked == false)
            {
                //will I get bonked if I update the record on uncheck??????????
                
                bool empty = false;
                foreach (var item in editComponents[Convert.ToInt32(((CheckBox)sender).Tag)])
                {
                    if (!item.ToString().Contains("db"))
                    {
                        if (((Control)item).Name.Contains("combo"))
                        {
                            if (((ComboBox)item).SelectedIndex == -1)
                                empty = true;
                        }
                        else
                        if (((Control)item).Text == "")
                            empty = true;
                    }
                }
                if (!empty)
                {
                    string tableName = editComponents[Convert.ToInt32(((CheckBox)sender).Tag)][0].ToString().Remove(editComponents[Convert.ToInt32(((CheckBox)sender).Tag)][0].ToString().Length - 2);
                    values.Clear();
                    foreach (var item in editComponents[Convert.ToInt32(((CheckBox)sender).Tag)])
                    {
                        if (!item.ToString().Contains("db"))
                        {
                            if (((Control)item).Name.Contains("combo"))
                            {
                                if(tableName == "Themes")
                                    values.Add(db.GetForeignCode("Code", "Subjects", "sName", ((ComboBox)item).SelectedItem.ToString()));
                                else
                                    values.Add(db.GetForeignCode("Number", "Class", "Cipher", ((ComboBox)item).SelectedItem.ToString()));
                            }
                            else
                                values.Add(((Control)item).Text);
                        }
                    }
                    db.updateRec(tableName, values[0], values);
                    db.SelectRecords(table[tableName], tableName, "");
                }
            }
        }

        private void setTable(string table, DataGridView dataGrid, int row)
        {
            curTable = table;
            bindingSource1.DataSource = dataGrid.DataSource;
            curRow = row;
            dataGridView = dataGrid;
            bindingNavigatorAddNewItem.Enabled = true;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            setTable("Themes", (DataGridView)sender, e.RowIndex);
            bindingNavigatorAddNewItem.Enabled = false;
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            setTable("Students", (DataGridView)sender, e.RowIndex);
            bindingNavigatorAddNewItem.Enabled = false;
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            setTable("ThemesByOrder", (DataGridView)sender, e.RowIndex);
            bindingNavigatorAddNewItem.Enabled = false;
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            curRow = e.RowIndex;
            List<string> currentData = new List<string>();
            foreach (DataGridViewCell s in dataGridView4.Rows[e.RowIndex].Cells)
            {
                currentData.Add(s.Value.ToString());
            }
            textBox2.Text = currentData[0];
            textBox1.Text = currentData[1];
            textBox11.Text = currentData[2];
            comboBox4.SelectedItem = db.GetFieldValueByID("Subjects", "sName", currentData[3]);//2
            richTextBox1.Text = currentData[4];
            setTable("Themes", (DataGridView)sender, e.RowIndex);
        }

        private void dataGridView5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            curRow = e.RowIndex;
            List<string> currentData = new List<string>();
            foreach (DataGridViewCell s in dataGridView5.Rows[e.RowIndex].Cells)
            {
                currentData.Add(s.Value.ToString());
            }
            textBox3.Text = currentData[0];
            textBox4.Text = currentData[1];
            comboBox6.SelectedItem = db.GetFieldValueByID("Class", "Cipher", currentData[2]);//2
            setTable("Students", (DataGridView)sender, e.RowIndex);
        }

        private void dataGridView6_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            curRow = e.RowIndex;
            List<string> currentData = new List<string>();
            foreach (DataGridViewCell s in dataGridView6.Rows[e.RowIndex].Cells)
            {
                currentData.Add(s.Value.ToString());
            }
            textBox5.Text = currentData[0];
            textBox6.Text = currentData[1];
            textBox7.Text = currentData[2];
            setTable("Class", (DataGridView)sender, e.RowIndex);
        }

        private void dataGridView7_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            curRow = e.RowIndex;
            List<string> currentData = new List<string>();
            foreach (DataGridViewCell s in dataGridView7.Rows[e.RowIndex].Cells)
            {
                currentData.Add(s.Value.ToString());
            }
            textBox9.Text = currentData[0];
            textBox10.Text = currentData[1];
            textBox8.Text = currentData[2];
            setTable("Subjects", (DataGridView)sender, e.RowIndex);
        }

        private void bindingNavigatorDeleteItem_Click_1(object sender, EventArgs e)
        {
            if (curTable == null || curRow == -1)
                return;
            if (curTable == "Class" || curTable == "Orders")
                db.DeleteRecMySQL(curTable, "Number", dataGridView[0, curRow].ToString());
            else
                db.DeleteRecMySQL(curTable, "Code", dataGridView[0, curRow].ToString());
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            values.Clear();
            switch (tabControl1.SelectedTab.Text)
            {
                case "Теми":
                    {
                        if (textBox1.Text == "" || textBox2.Text == "" || comboBox4.SelectedIndex == -1 || richTextBox1.Text == "")
                            return;
                        values.Add(textBox2.Text);
                        values.Add(textBox1.Text);
                        values.Add(db.GetForeignCode("Code", "Subjects", "sName", comboBox4.SelectedItem.ToString()));
                        values.Add(richTextBox1.Text);
                    }
                    break;
                case "Список студентів":
                    {
                        if (textBox3.Text == "" || textBox4.Text == "" || comboBox6.SelectedIndex == -1)
                            return;
                        values.Add(textBox3.Text);
                        values.Add(textBox4.Text);
                        values.Add(db.GetForeignCode("Number", "Class", "Chipher", comboBox6.SelectedItem.ToString()));
                    }
                    break;
                case "Групи":
                    {
                        if (textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "")
                            return;
                        values.Add(textBox5.Text);
                        values.Add(textBox6.Text);
                        values.Add(textBox7.Text);
                    }
                    break;
                case "Предмети":
                    {
                        if (textBox9.Text == "" || textBox10.Text == "" || textBox8.Text == "")
                            return;
                        values.Add(textBox9.Text);
                        values.Add(textBox10.Text);
                        values.Add(textBox8.Text);
                    }
                    break;
                default:
                    break;
            }
            db.InsertMySQL(values, curTable);
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {/*
            if (comboBox5.SelectedIndex == 0 && comboBox9.SelectedIndex == 0 && comboBox5.SelectedIndex != -1 && comboBox9.SelectedIndex != -1)// && comboBox3.SelectedIndex != -1
            {
                db.SelectRecords(dataGridView2, "Themes", "");
                return;
            }
            if (comboBox9.SelectedIndex == 0 && comboBox5.SelectedIndex != 0 && comboBox5.SelectedIndex != -1 && comboBox9.SelectedIndex != -1)
            {
                db.SelectRecords(dataGridView2, "Themes", $"join Subjects on Themes.Subject = Subjects.Code WHERE Themes.Subject = '{db.GetForeignCode("Code", "Subjects", "sname", comboBox5.SelectedItem.ToString())}'");
                return;
            }
            if (comboBox9.SelectedIndex != 0 && comboBox5.SelectedIndex == 0 && comboBox5.SelectedIndex != -1 && comboBox9.SelectedIndex != -1)
            {
                db.SelectRecords(dataGridView2, "Themes", $"join Class on Students.Class = Class.number WHERE Class.Cipher = '{comboBox9.SelectedItem.ToString()}'");
                return;
            }
            if (comboBox5.SelectedIndex != -1 && comboBox9.SelectedIndex != -1)
            {
                db.SelectRecords(dataGridView2, "Themes", $"join Class on Students.Class = Class.number WHERE  Class.Course = '{comboBox5.SelectedItem.ToString()}' and  Class.Cipher = '{comboBox9.SelectedItem.ToString()}'");
                return;
            }*/
            if(comboBox5.SelectedIndex != -1 && comboBox5.SelectedIndex != 0)
                db.SelectRecords(dataGridView4, "Themes", $"join Subjects on Themes.Subject = Subjects.Code WHERE Themes.Subject = '{db.GetForeignCode("Code", "Subjects", "sname", comboBox5.SelectedItem.ToString())}'");
        }

        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {
            //db.SelectRecords(dataGridView5, "Students", $"join Class on Students.Class = Class.number WHERE Class.Cipher = '{comboBox9.SelectedItem.ToString()}'");
            if (comboBox10.SelectedIndex != -1 && comboBox10.SelectedIndex != 0)
                db.SelectRecords(dataGridView5, "Students", $"join Class on Students.Class = Class.number WHERE Class.Cipher = '{comboBox10.SelectedItem.ToString()}'");
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox7.SelectedIndex != -1 && comboBox7.SelectedIndex != 0)
                db.SelectRecords(dataGridView6, "Class", $"WHERE Course = '{comboBox7.SelectedItem.ToString()}'");
        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox8.SelectedIndex != -1 && comboBox8.SelectedIndex != 0)
                db.SelectRecords(dataGridView7, "Subjects", $"WHERE Course = '{comboBox8.SelectedItem.ToString()}'");
        }

        //fix fields that Krush wants
        //fix menu bar
    }
}
