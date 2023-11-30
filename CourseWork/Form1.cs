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
//using Logger;
//using DocumentSaver;
using Word = Microsoft.Office.Interop.Word;

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
            // db.ExecuteMySQL("create table Subjects( Code int not null primary key, sName text, Course tinyint);create table Themes(Code int not null primary key, tName text, tSubject int FOREIGN KEY(tSubject) REFERENCES Subjects(Code), tDescription text); create table Class.Number int not null primary key, Number int, Cipher text, Course tinyint); create table Students(Code int not null primary key, FullName text, Class int foreign key references Class.Number));create table Orders(Code int not null primary key, Number int, oYear int, Subject int foreign key references Subjects(Code)); create table ThemesByOrder(Code int not null primary key, Theme int foreign key references Themes(Code), Student int foreign key references Students(Code), tOrder int references Orders(Code)); ");


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

            /*db.ExecuteMySQL("create table Subjects( Code int not null, sName text, Course tinyint, primary key(Code));");
            db.ExecuteMySQL("create table Themes ( Code int not null, tName text, tType text, tSubject int , tDescription text, primary key(Code), FOREIGN KEY (tSubject) REFERENCES Subjects(Code) );");
            db.ExecuteMySQL("create table Class ( Number int not null, Cipher text, Course tinyint, primary key(Number));");
            db.ExecuteMySQL("create table Students ( Code int not null, FullName text, Class int , primary key(Code), foreign key (Class) references Class(Number));");
            db.ExecuteMySQL("create table Orders (Number int not null, oYear int, Subject int , primary key(Number), foreign key (Subject) references Subjects(Code));");
            db.ExecuteMySQL("CREATE TABLE Teachers (Code int not null, FullName text, Position text,  PRIMARY KEY(Code));");
            db.ExecuteMySQL("create table ThemesByOrder ( Code int not null, Theme int , Student int , tOrder int , Teacher int , primary key(Code), foreign key (Theme) references Themes(Code), foreign key (Student) references Students(Code), " +
                "foreign key (tOrder) references Orders(Number), foreign key (Teacher) references Teachers(Code));");*/

            //db.ExecuteMySQL("DROP TABLE Themes");
            //db.ExecuteMySQL("DROP TABLE Class");
            //db.ExecuteMySQL("DROP TABLE Subjects");
            //db.ExecuteMySQL("DROP TABLE Students");
            //db.ExecuteMySQL("DROP TABLE Teachers");
            //db.ExecuteMySQL("DROP TABLE ThemesByOrder");
            //db.ExecuteMySQL("DROP TABLE Orders");

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
            tabEditComp2.Add(textBox7);
            tabEditComp2.Add(textBox6);
            editComponents.Add(tabEditComp2);

            List<object> tabEditComp3 = new List<object>();
            tabEditComp3.Add("Subjectsdb");
            tabEditComp3.Add(textBox9);
            tabEditComp3.Add(textBox8);
            tabEditComp3.Add(textBox10);
            editComponents.Add(tabEditComp3);

            List<object> tabEditComp4 = new List<object>();
            tabEditComp4.Add("Teachersdb");
            tabEditComp4.Add(textBox13);
            tabEditComp4.Add(textBox14);
            tabEditComp4.Add(textBox15);
            editComponents.Add(tabEditComp4);
            /*
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            comboBox5.SelectedIndex = 0;
            comboBox10.SelectedIndex = 0;*/
            /*db.GetAllVar(comboBox1, "Theme");
            db.GetAllVar(comboBox2, "Class");
            db.GetAllVar(comboBox3, "Course");
            db.GetAllVar(comboBox7, "Course");
            db.GetAllVar(comboBox8, "Course");
            db.GetAllVar(comboBox4, "Subject");
            db.GetAllVar(comboBox5, "Subject");
            db.GetAllVar(comboBox10, "Class");
            db.GetAllVar(comboBox6, "Class");*/
            RefreshCombos();
            /*
            db.SelectRecords(dataGridView3, "ThemesByOrder.Code, tOrder, Themes.tName, Themes.tType, Themes.tDescription, oYear, Students.FullName ", "ThemesByOrder", "join Themes on ThemesByOrder.Theme = Themes.Code " +
                "join Students on ThemesByOrder.Student = Students.Code " +
                "join Orders on ThemesByOrder.tOrder = Orders.Number");
            db.SelectRecords(dataGridView4, "Themes", "");
            db.SelectRecords(dataGridView5, "Students", "");
            db.SelectRecords(dataGridView6, "Class", "");
            db.SelectRecords(dataGridView7, "Subjects", "");*/
            RefreshGrids();

            table.Add("Themes", dataGridView4);
            table.Add("Students", dataGridView5);
            table.Add("Class", dataGridView6);
            table.Add("Subjects", dataGridView7);
            table.Add("Teachers", dataGridView8);
            
        }

        List<List<object>> editComponents = new List<List<object>>();
        Dictionary<string, DataGridView> table = new Dictionary<string, DataGridView>();
        dbMnanger db;
        int curRow;
        string curTable = null;
        DataGridView dataGridView;
        List<string> values = new List<string>();

        Word.Application word;
        Word.Document doc;
        Word.Range r;

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (curOrder == "")
            {
                if (((ComboBox)sender).SelectedIndex == 0)
                {
                    db.SelectRecords(dataGridView1, "Themes.Code, Themes.tName as 'Тема', Themes.tType  as 'Тип теми', Themes.tSubject as 'Предмет', Themes.tDescription as 'Опис'", "Themes", "");//JOIN Subjects on Themes.tSubject = Subjects.Code
                    return;
                }
                db.SelectRecords(dataGridView1, "Themes.Code, Themes.tName as 'Тема', Themes.tType  as 'Тип теми', Themes.tSubject as 'Предмет', Themes.tDescription as 'Опис'", "Themes", $"WHERE tType = '{comboBox1.SelectedItem.ToString()}'");//Themes
            }
            else
            {
                if (((ComboBox)sender).SelectedIndex == 0)
                {
                    db.SelectRecords(dataGridView1, "Themes.Code, Themes.tName as 'Тема', Themes.tType  as 'Тип теми', Themes.tSubject as 'Предмет', Themes.tDescription as 'Опис'", "Themes", "WHERE Code NOT IN (SELECT Theme FROM ThemesByOrder JOIN Orders on ThemesByOrder.tOrder = Orders.Number WHERE Orders.oYear >=" +
                        $"((SELECT oYear FROM Orders WHERE Number = '{curOrder}') - 5))");
                    return;
                }
                db.SelectRecords(dataGridView1, "Themes.Code, Themes.tName as 'Тема', Themes.tType  as 'Тип теми', Themes.tSubject as 'Предмет', Themes.tDescription as 'Опис'", "Themes", $"WHERE tType = '{comboBox1.SelectedItem.ToString()}' AND Code NOT IN (SELECT Theme FROM ThemesByOrder JOIN Orders on ThemesByOrder.tOrder = Orders.Number WHERE Orders.oYear >=" +
                        $"((SELECT oYear FROM Orders WHERE Number = '{curOrder}') - 5))");
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 0 && comboBox3.SelectedIndex == 0 && comboBox3.SelectedIndex != -1 && comboBox2.SelectedIndex != -1)// && comboBox3.SelectedIndex != -1
            {
                db.SelectRecords(dataGridView2, "Students.Code, Students.FullName as 'Повне ім’я', Students.Class as 'Група'", "Students", "");//Class.Cipher as 'Група'
                return;
            }
            if (comboBox2.SelectedIndex == 0 && comboBox3.SelectedIndex != 0 && comboBox3.SelectedIndex != -1 && comboBox2.SelectedIndex != -1)
            {
                db.SelectRecords(dataGridView2, "Students.Code, Students.FullName as 'Повне ім’я', Students.Class as 'Група'", "Students", $"JOIN Class ON Students.Class = Class.Number WHERE Class.Course = '{comboBox3.SelectedItem.ToString()}'");
                return;
            }
            if (comboBox2.SelectedIndex != 0 && comboBox3.SelectedIndex == 0 && comboBox3.SelectedIndex != -1 && comboBox2.SelectedIndex != -1)
            {
                db.SelectRecords(dataGridView2, "Students.Code, Students.FullName as 'Повне ім’я', Students.Class as 'Група'", "Students", $"JOIN Class ON Students.Class = Class.Number WHERE Class.Cipher = '{comboBox2.SelectedItem.ToString()}'");
                return;
            }
            if (comboBox3.SelectedIndex != -1 && comboBox2.SelectedIndex != -1)
            {
                db.SelectRecords(dataGridView2, "Students.Code, Students.FullName as 'Повне ім’я', Students.Class as 'Група'", "Students", $"JOIN Class ON Students.Class = Class.Number WHERE  Class.Course = '{comboBox3.SelectedItem.ToString()}' and  Class.Cipher = '{comboBox2.SelectedItem.ToString()}'");
                return;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            foreach (var item in editComponents[Convert.ToInt32(((CheckBox)sender).Tag)])
            {
                if(item != editComponents[Convert.ToInt32(((CheckBox)sender).Tag)][0])
                    ((Control)item).Enabled = ((CheckBox)sender).Checked;//? true : false
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
                                if(tableName == "Themes" || tableName == "Teachers")
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
                    RefreshGrids();
                    RefreshCombos();
                }
            }
        }

        private void setTable(string table, DataGridView dataGrid, int row)
        {
            curTable = table;
            bindingSource1.DataSource = dataGrid.DataSource;
            curRow = row;
            dataGridView = dataGrid;
            //bindingNavigatorAddNewItem.Enabled = true;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            setTable("Themes", (DataGridView)sender, e.RowIndex);
            //bindingNavigatorAddNewItem.Enabled = false;
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            setTable("Students", (DataGridView)sender, e.RowIndex);
            //bindingNavigatorAddNewItem.Enabled = false;
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            setTable("ThemesByOrder", (DataGridView)sender, e.RowIndex);
            //bindingNavigatorAddNewItem.Enabled = false;
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

        private void dataGridView8_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            curRow = e.RowIndex;
            List<string> currentData = new List<string>();
            foreach (DataGridViewCell s in dataGridView8.Rows[e.RowIndex].Cells)
            {
                currentData.Add(s.Value.ToString());
            }
            textBox13.Text = currentData[0];
            textBox14.Text = currentData[1];
            textBox15.Text = currentData[2];
            setTable("Teachers", (DataGridView)sender, e.RowIndex);
        }

        private void bindingNavigatorDeleteItem_Click_1(object sender, EventArgs e)
        {
            if (curTable == null || curRow == -1)
                return;
            if (curTable == "Class" || curTable == "Orders")
                db.DeleteRecMySQL(curTable, "Number", dataGridView[0, dataGridView.CurrentCell.RowIndex].Value.ToString());
            else
                db.DeleteRecMySQL(curTable, "Code", dataGridView[0, dataGridView.CurrentCell.RowIndex].Value.ToString());

            RefreshGrids();
            RefreshCombos();
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            values.Clear();
            switch (tabControl1.SelectedTab.Text)
            {
                case "Розподіл тем по студентам":
                    if (dataGridView1.CurrentCell != null && dataGridView2.CurrentCell != null)
                    {
                        if (curOrder != "")
                        {
                            //string values = "('" + (db.GetMaxCode("ThemesByOrder") + 1) + "', '" + dataGridView1[0, dataGridView1.CurrentCell.RowIndex] + "', '" + dataGridView2[0, dataGridView2.CurrentCell.RowIndex] + "', '" + curOrder + "')";
                            curTable = "ThemesByOrder";
                            values.Add((db.GetMaxCode("ThemesByOrder") + 1).ToString());
                            values.Add(dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value.ToString());
                            values.Add(dataGridView2[0, dataGridView2.CurrentCell.RowIndex].Value.ToString());
                            values.Add(curOrder);
                            if (comboBox9.SelectedIndex != -1)
                                values.Add(db.GetForeignCode("Code","Teachers","FullName", comboBox9.SelectedItem.ToString()));
                            else
                                values.Add("");
                            //db.Insert("ThemesByOrder", "", values);
                        }
                        else
                            MessageBox.Show("Оберіть наказ!");
                    }
                    break;
                case "Теми":
                    {
                        if (textBox1.Text == "" || comboBox4.SelectedIndex == -1)// textBox2.Text == "" ||
                            return;
                        curTable = "Themes";
                        //values.Add(textBox2.Text);
                        values.Add(db.GetMaxCode(curTable).ToString());
                        values.Add(textBox1.Text);
                        values.Add(textBox11.Text);
                        values.Add(db.GetForeignCode("Code", "Subjects", "sName", comboBox4.SelectedItem.ToString()));
                        values.Add(richTextBox1.Text + " ");
                    }
                    break;
                case "Список студентів":
                    {
                        if ( textBox4.Text == "" || comboBox6.SelectedIndex == -1)//textBox3.Text == "" ||
                            return;
                        curTable = "Students";
                        //values.Add(textBox3.Text);
                        values.Add(db.GetMaxCode(curTable).ToString());
                        values.Add(textBox4.Text);
                        values.Add(db.GetForeignCode("Number", "Class", "Cipher", comboBox6.SelectedItem.ToString()));
                    }
                    break;
                case "Групи":
                    {
                        if ( textBox6.Text == "" || textBox7.Text == "")//textBox5.Text == "" ||
                            return;
                        curTable = "Class";
                        values.Add(textBox5.Text);
                        //values.Add(db.GetMaxCode(curTable).ToString());
                        values.Add(textBox6.Text);
                        values.Add(textBox7.Text);
                    }
                    break;
                case "Предмети":
                    {
                        if ( textBox10.Text == "" || textBox8.Text == "")//textBox9.Text == "" ||
                            return;
                        curTable = "Subjects";
                        //values.Add(textBox9.Text);
                        values.Add(db.GetMaxCode(curTable).ToString());
                        values.Add(textBox10.Text);
                        values.Add(textBox8.Text);
                    }
                    break;
                case "Викладачі":
                    {
                        if (textBox14.Text == "" || textBox8.Text == "")//textBox13.Text == "" ||
                            return;
                        curTable = "Teachers";
                        //values.Add(textBox9.Text);
                        values.Add(db.GetMaxCode(curTable).ToString());
                        values.Add(textBox14.Text);
                        if (textBox15.Text != "")
                            values.Add(textBox15.Text);
                        else
                            values.Add("");
                    }
                    break;
                default:
                    break;
            }
            if (values.Count != 0)
            {
                db.Insert(values, curTable);
                RefreshGrids();
                RefreshCombos();
            }
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
            if(comboBox5.SelectedIndex == 0)            
                db.SelectRecords(dataGridView4, "Themes.Code, Themes.tName as 'Тема', Themes.tType  as 'Тип теми', Themes.tSubject as 'Предмет', Themes.tDescription as 'Опис'", "Themes", "");            
            else if(comboBox5.SelectedIndex != -1 && comboBox5.SelectedIndex != 0)
                db.SelectRecords(dataGridView4, "Themes.Code, Themes.tName as 'Тема', Themes.tType  as 'Тип теми', Themes.tSubject as 'Предмет', Themes.tDescription as 'Опис'", "Themes", $"join Subjects on Themes.tSubject = Subjects.Code WHERE Themes.tSubject = '{db.GetForeignCode("Code", "Subjects", "sName", comboBox5.SelectedItem.ToString())}'");
        }

        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {
            //db.SelectRecords(dataGridView5, "Students", $"join Class on Students.Class = Class.number WHERE Class.Cipher = '{comboBox9.SelectedItem.ToString()}'");
            if (comboBox10.SelectedIndex == 0)
                db.SelectRecords(dataGridView5, "Students.Code, Students.FullName as 'Повне ім’я', Students.Class as 'Група'", "Students", "");
            else if (comboBox10.SelectedIndex != -1 && comboBox10.SelectedIndex != 0)
                db.SelectRecords(dataGridView5, "Students.Code, Students.FullName as 'Повне ім’я', Students.Class as 'Група'", "Students", $"join Class on Students.Class = Class.number WHERE Class.Cipher = '{comboBox10.SelectedItem.ToString()}'");
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox7.SelectedIndex == 0)
                db.SelectRecords(dataGridView6, "Class.Number, Class.Cipher as 'Група', Class.Course as 'Курс'", "Class", "");
            else if (comboBox7.SelectedIndex != -1 && comboBox7.SelectedIndex != 0)
                db.SelectRecords(dataGridView6, "Class.Number, Class.Cipher as 'Група', Class.Course as 'Курс'", "Class", $"WHERE Course = '{comboBox7.SelectedItem.ToString()}'");
        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox8.SelectedIndex == 0)
                db.SelectRecords(dataGridView7, "Subjects.Code, Subjects.sName as 'Назва', Subjects.Course as 'Курс'", "Subjects", "");
            else if(comboBox8.SelectedIndex != -1 && comboBox8.SelectedIndex != 0)
                db.SelectRecords(dataGridView7, "Subjects.Code, Subjects.sName as 'Назва', Subjects.Course as 'Курс'", "Subjects", $"WHERE Course = '{comboBox8.SelectedItem.ToString()}'");
        }

        private void студентиБезТемиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (студентиБезТемиToolStripMenuItem.Checked)
            {
                студентиБезТемиToolStripMenuItem.BackColor = Color.Gray;
                db.SelectRecords(dataGridView2, "Students.Code, Students.FullName as 'Повне ім’я', Students.Class as 'Група'", "Students", "WHERE NOT Code IN (SELECT Student FROM ThemesByOrder)");
            }
            else
            {
                студентиБезТемиToolStripMenuItem.BackColor = друкНаказуToolStripMenuItem.BackColor;
                comboBox2_SelectedIndexChanged(comboBox2, e);
            }
        }

        private void вільніТемиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (вільніТемиToolStripMenuItem.Checked)
            {
                вільніТемиToolStripMenuItem.BackColor = Color.Gray;
                db.SelectRecords(dataGridView1, "Themes.Code, Themes.tName as 'Тема', Themes.tType  as 'Тип теми', Themes.tSubject as 'Предмет', Themes.tDescription as 'Опис'", "Themes", "WHERE NOT Code IN (SELECT Theme FROM ThemesByOrder)");
            }
            else
            {
                вільніТемиToolStripMenuItem.BackColor = друкНаказуToolStripMenuItem.BackColor;
                comboBox1_SelectedIndexChanged(comboBox1, e);
            }
        }

        public void RefreshGrids()
        {
            comboBox1_SelectedIndexChanged(comboBox1, EventArgs.Empty);
            comboBox2_SelectedIndexChanged(comboBox2, EventArgs.Empty);
            string themesByOrderSelCon = "join Themes on ThemesByOrder.Theme = Themes.Code " +
                "join Students on ThemesByOrder.Student = Students.Code " +
                "join Orders on ThemesByOrder.tOrder = Orders.Number " +
                "JOIN Teachers ON ThemesByOrder.Teacher = Teachers.Code";
            if(curOrder != "")
                themesByOrderSelCon += $" WHERE tOrder = {curOrder}";
            db.SelectRecords(dataGridView3, "ThemesByOrder.Code, tOrder as 'Наказ', Themes.tName as 'Тема', Themes.tType as 'Тип теми', Themes.tDescription as 'Опис', oYear as 'Рік', Students.FullName as 'Студент', Teachers.FullName as 'Викладач'", "ThemesByOrder", themesByOrderSelCon);
            db.SelectRecords(dataGridView4, "Themes.Code, Themes.tName as 'Тема', Themes.tType  as 'Тип теми', Themes.tSubject as 'Предмет', Themes.tDescription as 'Опис'", "Themes", "");
            db.SelectRecords(dataGridView5, "Students.Code, Students.FullName as 'Повне ім’я', Students.Class as 'Група'", "Students", "");
            db.SelectRecords(dataGridView6, "Class.Number, Class.Cipher as 'Група', Class.Course as 'Курс'", "Class", "");
            db.SelectRecords(dataGridView7, "Subjects.Code, Subjects.sName as 'Назва', Subjects.Course as 'Курс'", "Subjects", "");
            db.SelectRecords(dataGridView8, "Teachers.Code, Teachers.FullName as 'Повне ім’я', Teachers.Position as 'Посада'", "Teachers", "");
        }

        public void RefreshCombos()//need to get all comboboxes
        {

            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            comboBox4.Items.Clear();
            comboBox5.Items.Clear();
            comboBox6.Items.Clear();
            comboBox7.Items.Clear();
            comboBox8.Items.Clear();
            comboBox10.Items.Clear();
            comboBox9.Items.Clear();
            comboBox1.Items.Add("Усі типи");
            comboBox2.Items.Add("Всі групи");
            comboBox3.Items.Add("Усі курси");
            comboBox5.Items.Add("Усі предмети");
            comboBox7.Items.Add("Усі курси");
            comboBox8.Items.Add("Усі курси");
           comboBox10.Items.Add("Усі группи");
            db.GetAllVar(comboBox1, "ThemeType", "");
            db.GetAllVar(comboBox2, "Class", "");
            db.GetAllVar(comboBox3, "Course", "");
            db.GetAllVar(comboBox4, "Subject", "");
            db.GetAllVar(comboBox5, "Subject", "");
            db.GetAllVar(comboBox6, "Class", "");
            db.GetAllVar(comboBox7, "Course", "");
            db.GetAllVar(comboBox8, "Course", "");
            db.GetAllVar(comboBox10, "Class", "");
            db.GetAllVar(comboBox9, "Teachers", "");
            
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            comboBox5.SelectedIndex = 0;
            comboBox7.SelectedIndex = 0;
            comboBox8.SelectedIndex = 0;
            comboBox10.SelectedIndex = 0;
        }


        private void друкНаказуToolStripMenuItem_Click(object sender, EventArgs e)
        {/*
            try
            {

                word = new Word.Application();
                word.Visible = true;
                doc = word.Documents.Add();
                Word.Selection currentSelection = word.Application.Selection;
                string s = "Затверджую \vЗаступник директора з НР  \v___________ А.В.Майдан \v“___”______ " + DateTime.Now.Year + " р.\n";

                currentSelection.TypeText(s);
                int cur_pos = s.Length;
                r = doc.Range(0, cur_pos);
                r.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                r.ParagraphFormat.IndentCharWidth(26);

                currentSelection.TypeParagraph();

                s = "РОЗПОРЯДЖЕННЯ\vвід «     »                   ";//2023р. № ________ м. Київ\vпро закріплення тем курсових проєктів за студентами спеціальності\v121 «Інженерія програмного забезпечення»\vгалузь знань «Інформаційні технології», з дисципліни\v«Об’єктно - орієнтоване програмування»\vдля груп П-731-31, П-732-32    на 2022 / 2023 н.р.\n";
                s += DateTime.Now.Year + "р № ________ м. Київ" +
                    "\vпро закріплення тем курсових проєктів за студентами спеціальності\v" +
                    "121 «Інженерія програмного забезпечення»\v" +
                    "галузь знань «Інформаційні технології», з дисципліни\v" +
                    "«Об’єктно - орієнтоване програмування»\v" +
                    "для груп П-731-31, П-732-32    на "; //2022 / 2023 н.р.\n";
                s += (DateTime.Now.Year - 1) + " / " + DateTime.Now.Year + " н.р.\n";


                currentSelection.TypeText(s);
                r = doc.Range(cur_pos + 1, cur_pos + s.Length + 1);
                cur_pos += s.Length;
                r.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                currentSelection.MoveRight();//move down
                

                List<string> classes = new List<string>();
                classes.Add("П-731-31");
                orderData data = db.GetDateForOder(classes);

                r = doc.Range(cur_pos + 1, cur_pos + 1);
                Word.Table t = doc.Tables.Add(r, data.fullName.Count + 1, 3);
                t.Borders.InsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
                t.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;


                t.AllowPageBreaks = false;
                t.Rows.AllowBreakAcrossPages = 0;
                t.Rows[1].HeadingFormat = -1;

                int tableCharCount = 19 + 22 + 8;
                currentSelection.TypeText("Прізвище, імя та ПБ");
                currentSelection.MoveRight();
                currentSelection.TypeText("Тема курсового проекту");
                currentSelection.MoveRight();
                currentSelection.TypeText("Примітка");
                currentSelection.MoveRight();

                for (int i = 0; i < data.fullName.Count; i++)
                {
                    currentSelection.TypeText((i+1) + ". " + data.fullName[i]);
                    currentSelection.MoveRight();
                    currentSelection.TypeText(data.theme[i]);
                    currentSelection.MoveRight();
                    currentSelection.TypeText(data.clas[i]);
                    currentSelection.MoveRight();
                    tableCharCount += data.fullName[i].Length + data.theme[i].Length + data.clas[i].Length;
                }


                currentSelection.TypeParagraph();
                currentSelection.TypeText("\n");

                cur_pos += tableCharCount;

                s = "Голова комісії						О.Висоцька ";
                currentSelection.TypeText(s);
                r = doc.Range(cur_pos + 1, cur_pos + s.Length + 1);
                cur_pos += s.Length;
                r.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                r.ParagraphFormat.IndentFirstLineCharWidth(2);

                currentSelection.TypeParagraph();

                s = "\nВикладачі							О.Круш";
                currentSelection.TypeText(s);
                r = doc.Range(cur_pos + 1, cur_pos + s.Length + 1);
                cur_pos += s.Length;
                r.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                r.ParagraphFormat.IndentFirstLineCharWidth(2);

                currentSelection.TypeParagraph();

                s = "\n 							           С.Терентьєва";
                currentSelection.TypeText(s);
                r = doc.Range(cur_pos + 10, cur_pos + s.Length + 8);
                cur_pos += s.Length;
                r.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                //r.ParagraphFormat.IndentFirstLineCharWidth(25);

                r = doc.Range(0, doc.Content.Characters.Count);
                r.Font.Name = "Times New Roman";
                r.Font.Size = 13;

                word.Documents.Save(false);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                word.Quit();
            }*/
            
            OrderForm oForm = new OrderForm();
            if (oForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (curOrder != "")
                    {
                        int orderYear = db.GetOrderYear(curOrder);

                        word = new Word.Application();
                        word.Visible = true;
                        doc = word.Documents.Add();
                        Word.Selection currentSelection = word.Application.Selection;
                        string s = "Затверджую \vЗаступник директора з НР  \v___________ А.В.Майдан \v“___”______ " + orderYear + " р.\n"; // change year DateTime.Now.Year

                        currentSelection.TypeText(s);
                        int cur_pos = s.Length;
                        r = doc.Range(0, cur_pos);
                        r.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                        r.ParagraphFormat.IndentCharWidth(26);

                        currentSelection.TypeParagraph();

                        s = "РОЗПОРЯДЖЕННЯ\vвід «     »                   ";//2023р. № ________ м. Київ\vпро закріплення тем курсових проєктів за студентами спеціальності\v121 «Інженерія програмного забезпечення»\vгалузь знань «Інформаційні технології», з дисципліни\v«Об’єктно - орієнтоване програмування»\vдля груп П-731-31, П-732-32    на 2022 / 2023 н.р.\n";
                        s += orderYear + "р № ________ м. Київ" +
                            "\vпро закріплення тем курсових проєктів за студентами спеціальності\v" +
                            oForm.textBox3.Text + "\v" +
                            //"121 «Інженерія програмного забезпечення»\v" +
                            $"галузь знань «{oForm.textBox4.Text}», з дисципліни\v" +
                            $"«{oForm.comboBox3.SelectedItem}»\v" +
                            "для груп";
                        List<string> classes = db.GetClassesForOrder(curOrder);
                       /* for (int i = 0; i < classes.Count; i++)
                        {
                            s += " " + oForm.listBox1.Items[i];
                        }*/
                        foreach (var item in classes)
                        {
                            s += " " + item + ", ";
                        }
                        s = s.Remove(s.Length - 2);
                        s += " на ";
                        //"   на ";
                        // "для груп П-731-31, П-732-32    на "; //2022 / 2023 н.р.\n";
                        s += (orderYear - 1) + "/" + orderYear + " н.р.\n";


                        currentSelection.TypeText(s);
                        r = doc.Range(cur_pos + 1, cur_pos + s.Length + 1);
                        cur_pos += s.Length;
                        r.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                        currentSelection.MoveRight();//move down

                        orderData data = db.GetDateForOder(classes, curOrder);

                        r = doc.Range(cur_pos + 1, cur_pos + 1);
                        Word.Table t = doc.Tables.Add(r, data.fullName.Count + 1, 3);
                        t.Borders.InsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
                        t.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;


                        t.AllowPageBreaks = false;
                        t.Rows.AllowBreakAcrossPages = 0;
                        t.Rows[1].HeadingFormat = -1;

                        int tableCharCount = 19 + 22 + 8;
                        currentSelection.TypeText("Прізвище, імя та ПБ");
                        currentSelection.MoveRight();
                        currentSelection.TypeText("Тема курсового проекту");
                        currentSelection.MoveRight();
                        currentSelection.TypeText("Примітка");
                        currentSelection.MoveRight();

                        for (int i = 0; i < data.fullName.Count; i++)
                        {
                            currentSelection.TypeText((i + 1) + ". " + data.fullName[i]);
                            currentSelection.MoveRight();
                            currentSelection.TypeText(data.theme[i]);
                            currentSelection.MoveRight();
                            currentSelection.TypeText(data.clas[i]);
                            currentSelection.MoveRight();
                            tableCharCount += data.fullName[i].Length + data.theme[i].Length + data.clas[i].Length;
                        }


                        currentSelection.TypeParagraph();
                        currentSelection.TypeText("\n");

                        cur_pos += tableCharCount;

                        s = $"Голова комісії						{oForm.textBox1.Text} ";
                        currentSelection.TypeText(s);
                        r = doc.Range(cur_pos + 1, cur_pos + s.Length + 1);
                        cur_pos += s.Length;
                        r.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                        r.ParagraphFormat.IndentFirstLineCharWidth(2);

                        currentSelection.TypeParagraph();


                        s = "\nВикладачі						";

                        for (int i = 0; i < oForm.listBox2.Items.Count; i++)
                        {
                            if (i == 0)
                                s += oForm.listBox2.Items[i];
                            else
                                s = "\n 							           " + oForm.listBox2.Items[i];


                            currentSelection.TypeText(s);
                            r = doc.Range(cur_pos + 1, cur_pos + s.Length + 1);
                            cur_pos += s.Length;
                            r.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                            //r.ParagraphFormat.IndentFirstLineCharWidth(2);

                            currentSelection.TypeParagraph();
                        }

                        /*
                        s = "\n 							           С.Терентьєва";
                        currentSelection.TypeText(s);
                        r = doc.Range(cur_pos + 10, cur_pos + s.Length + 8);
                        cur_pos += s.Length;
                        r.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;*/
                        //r.ParagraphFormat.IndentFirstLineCharWidth(25);

                        r = doc.Range(0, doc.Content.Characters.Count);
                        r.Font.Name = "Times New Roman";
                        r.Font.Size = 13;

                        word.Documents.Save(false);

                    }
                    else
                        MessageBox.Show("Оберіть наказ!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    word.Quit();
                }
            }
        }

        private void додатиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addForm aForm = new addForm();
            if (aForm.ShowDialog() == DialogResult.OK)
            {
                RefreshGrids();
                RefreshCombos();
            }
        }

        string curOrder = "";

        private void вибірНаказуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OrderSelectForm oSForm = new OrderSelectForm();
            if (oSForm.ShowDialog() == DialogResult.OK)
            {
                curOrder = oSForm.dataGridView1[0, oSForm.dataGridView1.CurrentCell.RowIndex].Value.ToString();
                RefreshGrids();
                label22.Text = "Поточний наказ №" + curOrder;
            }
        }

        private void друкНаказуДляДипломниківToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DiplomaOrderForm dOForm = new DiplomaOrderForm();
            if (dOForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (curOrder != "")
                    {
                        string[] date = dOForm.textBox5.Text.Split('.');

                        word = new Word.Application();
                        word.Visible = true;
                        doc = word.Documents.Add();
                        Word.Selection currentSelection = word.Application.Selection;

                        string s = "Додаток 1";

                        currentSelection.TypeText(s);
                        int cur_pos = s.Length;
                        r = doc.Range(0, cur_pos);
                        r.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight;
                        //r.ParagraphFormat.IndentCharWidth(26);
                        currentSelection.TypeParagraph();

                        s = $"\vдо наказу директора ККТЕ НАУ\vвід«____»_________{date[2]}р.№ ____\v\n"; // change year DateTime.Now.Year

                        currentSelection.TypeText(s);
                        r = doc.Range(cur_pos + 1, cur_pos + s.Length);
                        cur_pos += s.Length;
                        r.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphJustify;
                        r.ParagraphFormat.IndentCharWidth(26);


                        s = $"ТЕМИ\vта керівники дипломних робіт студентів 4-го курсу коледжу,\vОКР «Молодший спеціаліст» спеціальність\v{dOForm.textBox4.Text} {dOForm.textBox1.Text}\n";                   

                        currentSelection.TypeText(s);
                        r = doc.Range(cur_pos + 2, cur_pos + s.Length + 1);
                        cur_pos += s.Length;
                        r.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                        //r.ParagraphFormat.IndentCharWidth(6);

                        currentSelection.MoveRight();//move down

                        r = doc.Range(0, cur_pos);
                        r.Font.Size = 14;

                        int tableStartPos = cur_pos;

                        List<string> classes = db.GetClassesForOrder(curOrder);
                        diplomaOrderData data = db.GetDateForDiplomaOder(classes, curOrder);
                        string curClass = "";

                        r = doc.Range(cur_pos + 1, cur_pos + 1);
                        Word.Table t = doc.Tables.Add(r, data.fullName.Count + 2 + classes.Count, 5);
                        t.Borders.InsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
                        t.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;

                        
                        t.AllowPageBreaks = false;
                        t.Rows.AllowBreakAcrossPages = 0;

                        int row = 3;

                        int tableCharCount = 0;
                        s = "№ пор.";
                        currentSelection.TypeText(s);
                        currentSelection.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                        tableCharCount += s.Length;
                        currentSelection.MoveRight();
                        s = "Прізвище, ім’я, по батькові студента";
                        currentSelection.TypeText(s);
                        currentSelection.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                        tableCharCount += s.Length;
                        currentSelection.MoveRight();
                        s = "Тема дипломної роботи";
                        currentSelection.TypeText(s);
                        currentSelection.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                        tableCharCount += s.Length;
                        currentSelection.MoveRight();
                        s = "Прізвище, ім’я, по батькові керівника";
                        currentSelection.TypeText(s);
                        currentSelection.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                        tableCharCount += s.Length;
                        currentSelection.MoveRight();
                        s = "Посада";
                        currentSelection.TypeText(s);
                        currentSelection.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                        tableCharCount += s.Length;
                        currentSelection.MoveRight();

                        currentSelection.TypeText("1");
                        currentSelection.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                        currentSelection.MoveRight();
                        currentSelection.TypeText("2");
                        currentSelection.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                        currentSelection.MoveRight();
                        currentSelection.TypeText("3");
                        currentSelection.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                        currentSelection.MoveRight();
                        currentSelection.TypeText("4");
                        currentSelection.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                        currentSelection.MoveRight();
                        currentSelection.TypeText("5");
                        currentSelection.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                        currentSelection.MoveRight();

                        tableCharCount += 5;

                        for (int i = 0; i < data.fullName.Count; i++)
                        {
                            if (data.clas[i] != curClass)
                            {
                                t.Rows[row].Cells[1].Merge(t.Rows[row].Cells[5]);
                                s = $"Група {data.clas[i]}";
                                currentSelection.TypeText(s);
                                currentSelection.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                                curClass = data.clas[i];
                                currentSelection.MoveRight();
                                tableCharCount += s.Length;
                                row++;
                            }
                            currentSelection.TypeText((i + 1).ToString());
                            currentSelection.MoveRight();
                            currentSelection.TypeText(data.fullName[i]);
                            currentSelection.MoveRight();
                            currentSelection.TypeText(data.theme[i]);
                            currentSelection.MoveRight();
                            currentSelection.TypeText(data.teacher[i]);
                            currentSelection.MoveRight();
                            currentSelection.TypeText(data.position[i]);
                            currentSelection.MoveRight();

                            tableCharCount += (i + 1).ToString().Length + data.fullName[i].Length + data.theme[i].Length + data.teacher[i].Length + data.position[i].Length;
                            row++;
                        }

                        currentSelection.MoveRight();

                        currentSelection.TypeParagraph();
                        currentSelection.TypeText("\n");

                        cur_pos += tableCharCount;

                        s = $"\vРозглянуто та схвалено\vна засіданні випускової комісії спеціальності\v{dOForm.textBox1.Text}\vПротокол № {dOForm.textBox2.Text} від {dOForm.textBox5.Text} року\vГолова ВК ________________{dOForm.textBox3.Text}.";
                        currentSelection.TypeText(s);
                        r = doc.Range(cur_pos + 1, cur_pos + s.Length + 1);
                        cur_pos += s.Length;
                        
                        r.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                        r.ParagraphFormat.IndentFirstLineCharWidth(2);                  

                        /*
                        s = "\n 							           С.Терентьєва";
                        currentSelection.TypeText(s);
                        r = doc.Range(cur_pos + 10, cur_pos + s.Length + 8);
                        cur_pos += s.Length;
                        r.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;*/
                        //r.ParagraphFormat.IndentFirstLineCharWidth(25);

                        r = doc.Range(tableStartPos, doc.Content.Characters.Count);
                        r.Font.Name = "Times New Roman";
                        r.Font.Size = 12;

                        word.Documents.Save(false);

                    }
                    else
                        MessageBox.Show("Оберіть наказ!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    word.Quit();
                }

            }
        }





        //fix fields that Krush wants
        //fix menu bar

        //fix bindingNavigatorAddNewItem_Click
        //fix combobox 1 if there is something
        //themes filtering fix

        //select all in fillering combos

        //fix selects where you join tables
        //orders table??? it just exist and we don't do enything with it 

        //how we define what goes in order
        //do I need to change 121 «Інженерія програмного забезпечення»\vгалузь знань «Інформаційні технології», з дисципліни\v«Об’єктно - орієнтоване програмування»\\


        //need to make form for order settings


        //add button 
    }
}
