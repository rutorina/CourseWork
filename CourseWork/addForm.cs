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
using System.IO;

namespace SingletonDesignPattern
{
    public partial class addForm : Form
    {
        public addForm()
        {
            InitializeComponent();
            db = dbMnanger.GetInstance();
        }

        dbMnanger db;

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    db.GetAllVar(comboBox2, "Class", "");
                    break;
                case 1:
                    db.GetAllVar(comboBox2, "ThemeType", "");
                    break;
                case 2:
                    db.GetAllVar(comboBox2, "Course", "");
                    break;
                /*case 3:
                    db.GetAllVar(comboBox2, "Class", "");
                    break;*/
                default:
                    break;
            }
        }

        List<string> res = new List<string>();

        private void вибратиФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                string[] format = openFileDialog1.FileName.Split('.');
                res.Clear();

                switch (format[format.Length - 1])
                {
                    case "doc":
                    case "docm":
                    case "docx":
                    case "dot":
                    case "dotx":
                    case "wbk":
                        Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();
                        object miss = System.Reflection.Missing.Value;
                        object path = openFileDialog1.FileName;
                        object readOnly = true;
                        Microsoft.Office.Interop.Word.Document docs = word.Documents.Open(ref path, ref miss, ref readOnly, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss);
                        numericUpDown2.Maximum = docs.Paragraphs.Count;
                        numericUpDown1.Maximum = docs.Paragraphs.Count;

                        for (int i = 0; i < docs.Paragraphs.Count; i++)
                        {
                            res.Add(docs.Paragraphs[i + 1].Range.Text.ToString());
                        }
                        docs.Close();
                        word.Quit();
                        break;
                    case "txt":
                        int lineCount = 0;
                        const Int32 BufferSize = 128;
                        using (var fileStream = File.OpenRead(openFileDialog1.FileName))
                        using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
                        {
                            string line;
                            while ((line = streamReader.ReadLine()) != null)
                            {
                                lineCount++;
                                res.Add(line);
                            }
                        }
                        numericUpDown2.Maximum = lineCount;
                        numericUpDown1.Maximum = lineCount;
                        break;
                    case "xla":
                    case "xlam":
                    case "xll":
                    case "xlm":
                    case "xls":
                    case "xlsm":
                    case "xlsx":
                    case "xlt":
                    case "xltm":
                    case "xltx":
                        Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
                        Microsoft.Office.Interop.Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(openFileDialog1.FileName);
                        Microsoft.Office.Interop.Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
                        Microsoft.Office.Interop.Excel.Range xlRange = xlWorksheet.UsedRange;

                        int rowCount = xlRange.Rows.Count;

                        for (int i = 1; i <= rowCount; i++)
                        {
                            if (xlRange.Cells[i, 1].Value2 != null)
                                res.Add(xlRange.Cells[i, 1].Value2.ToString());

                        }
                        numericUpDown2.Maximum = xlRange.Rows.Count;
                        numericUpDown1.Maximum = xlRange.Rows.Count;
                        break;
                    default:
                        break;
                }
                for (int i = 0; i < res.Count; i++)
                {
                    listBox1.Items.Add(res[i]);
                }
                numericUpDown2.Value = numericUpDown2.Maximum;
                /*
                Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();
                object miss = System.Reflection.Missing.Value;
                object path = openFileDialog1.FileName;
                object readOnly = true;
                Microsoft.Office.Interop.Word.Document docs = word.Documents.Open(ref path, ref miss, ref readOnly, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss);

                numericUpDown2.Maximum = docs.Paragraphs.Count;
                numericUpDown2.Value = docs.Paragraphs.Count;

                List<string> res = new List<string>();

                for (int i = (int)numericUpDown1.Value; i < (int)numericUpDown2.Value; i++)
                {
                    res.Add(docs.Paragraphs[i + 1].Range.Text.ToString());
                }
                
                for (int i = 0; i < res.Count; i++)
                {
                    listBox1.Items.Add(res[i]);
                }
                docs.Close();
                word.Quit();*/
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            string tableName = "";
            string fields = "";
            string values = "";
            string comboField = "";

            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    tableName = "Students";
                    fields = "(Code, FullName";
                    if (comboBox2.SelectedIndex != -1)
                    {
                        fields += ", Class";
                        comboField = db.GetForeignCode("Number", "Class", "Cipher", comboBox2.SelectedItem.ToString());
                    }
                    else
                        fields += ")";
                    break;
                case 1:
                    tableName = "Themes";
                    fields = "(Code, tName";
                    if (comboBox2.SelectedIndex != -1)
                    {
                        fields += ", tType";
                        comboField = comboBox2.SelectedItem.ToString();
                    }
                    else
                        fields += ")";
                    break;
                case 2:
                    tableName = "Subjects";
                    fields = "(Code, sName";
                    if (comboBox2.SelectedIndex != -1)
                    {
                        fields += ", Course";
                        comboField = comboBox2.SelectedItem.ToString();
                    }
                    else
                        fields += ")";
                    break;
                case 3:
                    tableName = "Teachers";
                    fields = "(Code, FullName)";
                    break;
                default:
                    break;
            }

            int code = db.GetMaxCode(tableName) + 1;

            if (numericUpDown1.Value != numericUpDown2.Value)
                for (int i = (int)numericUpDown1.Value; i <= numericUpDown2.Value - 1; i++)
                {
                    values += "('" + (code + i) + "', '" + res[i] + "'";
                    if (comboBox2.SelectedIndex != -1)
                        values += ", '" + comboField + "'), ";
                    else
                        values += "),";
                }
            else
            {
                values += "('" + (code) + "', '" + res[(int)(numericUpDown1.Value - 1)] + "'";
                if (comboBox2.SelectedIndex != -1)
                    values += ", '" + comboField + "'), ";
                else
                    values += "),";
            }
            values = values.Remove(values.Length - 1);

            db.Insert(tableName, fields, values);
        }
    }
}
