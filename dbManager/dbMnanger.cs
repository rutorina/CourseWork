using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using Logger;
using System.IO;

namespace dbManager
{
    public class orderData
    {
        public List<string> fullName = new List<string>();
        public List<string> theme = new List<string>();
        public List<string> clas = new List<string>();
    }

    public class dbMnanger
    {
        private string GetConnectionSrt()
        {
            try
            {
                string cSrt = null;
                using (StreamReader sr = new StreamReader(@"E:\!College\KPZ\ConSrting.txt"))
                {
                    cSrt = sr.ReadLine();
                }
                return cSrt;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                throw;
            }
        }

        MySqlConnection connection;
        MySqlCommand cmd;
        private static dbMnanger instance = null;
        Logger.Logger logger = Logger.Logger.GetInstance();

        private dbMnanger()
        {
            connection = new MySqlConnection(GetConnectionSrt());

            cmd = new MySqlCommand();
            cmd.Connection = connection;            
        }

        public static dbMnanger GetInstance()
        {
            if (instance == null)
                instance = new dbMnanger();
            return instance;
        }

        public void TableRecordsMySql(string tableName, DataGridView grid)
        {
            try
            {
                connection.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter($"SELECT * FROM {tableName}", connection);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, tableName);
                grid.DataSource = dataSet.Tables[tableName];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            connection.Close();
        }

        public List<string> GetFieldsMySQL(string TableName)
        {
            try
            {
                List<string> Fields = new List<string>();
                cmd.CommandText = $"select * from INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{TableName}';";
                connection.Open();
                MySqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    Fields.Add(r.GetString(3));
                }
                connection.Close();
                r.Close();
                return Fields;
            }
            catch (Exception ex)
            {
                connection.Close();
                MessageBox.Show(ex.ToString());
                throw ex;
            }
        }

        public void InsertMySQL(List<string> Fields, string TableName)
        {
            try
            {/*
                List<string> FieldNames = GetFieldsMySQL(TableName);
                cmd.CommandText = $"insert into {TableName} (";//values
                foreach (string field in FieldNames)
                {
                    cmd.CommandText += field + ", ";
                }*/
                //cmd.CommandText = cmd.CommandText.Remove(cmd.CommandText.Length - 2) + " VALUES (";
                cmd.CommandText = $"insert into {TableName} VALUES (";
                foreach (string field in Fields)
                {
                    cmd.CommandText += "'" + field + "', ";
                }
                cmd.CommandText = cmd.CommandText.Remove(cmd.CommandText.Length - 2) + ");";
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                connection.Close();
                //throw;
            }
        }

        public void UpdateMySQL(List<string> Fields, List<string> FieldNames, string TableName)
        {
            try
            {
                cmd.CommandText = $"UPDATE {TableName} SET ";
                for (int i = 1; i < FieldNames.Count; i++)
                {
                    cmd.CommandText += $"{FieldNames[i]} = '{Fields[i]}', ";
                }
                cmd.CommandText = cmd.CommandText.Remove(cmd.CommandText.Length - 2) + $"WHERE {FieldNames[0]} = '{Fields[0]}';";
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                connection.Close();
                MessageBox.Show(ex.ToString());
                throw;
            }
        }
        public void DeleteRecMySQL(string TableName,string codeName, string Code)
        {
            try
            {
                cmd.CommandText = $"delete from {TableName} where {codeName} = '{Code}'";
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                connection.Close();
                MessageBox.Show(ex.ToString());
            }
        }

        //select themes and thgemes.types
        //select classes and classes.courses

        public void GetAllVar(ComboBox comboBox, string name, string condition)
        {
            try
            {
                //logger.Log("SELECT cipher FROM class");
                switch (name)
                {
                    case "Theme":
                        cmd.CommandText = $"SELECT DISTINCT tType FROM Themes {condition}";
                        break;
                    case "Class":
                        cmd.CommandText = $"SELECT DISTINCT cipher FROM Class {condition}";
                        break;
                    case "Course":
                        cmd.CommandText = $"SELECT DISTINCT Course from Class {condition}";
                        break;
                    case "Subject":
                        cmd.CommandText = $"SELECT DISTINCT sName from Subjects {condition}";
                        break;
                    default:
                        break;
                }
                connection.Open();
                MySqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    comboBox.Items.Add(r.GetString(0));
                }
                connection.Close();
                r.Close();
            }
            catch (Exception ex)
            {
                //logger.Log(ex.Message.ToString());
                connection.Close();
                MessageBox.Show(ex.ToString());
                throw ex;
            }            
        }

        public void ExecuteMySQL(string command)
        {
            try
            {
                cmd.CommandText = command;
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                connection.Close();
                MessageBox.Show(ex.ToString());
            }
        }



        public string GetFieldValueByID(string tableName, string fieldName, string id)
        {
            try
            {
                string res = null;
                connection.Open();
                if (tableName == "Class" || tableName == "Orders")
                    cmd.CommandText = $"SELECT {fieldName} FROM {tableName} WHERE Number = '{id}'";
                else
                    cmd.CommandText = $"SELECT {fieldName} FROM {tableName} WHERE Code = '{id}'";
                MySqlDataReader r = cmd.ExecuteReader();
                
                if (r.Read())
                    res = r.GetString(0);
                connection.Close();
                return res;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        public string GetForeignCode(string codeName, string table, string fieldName, string condition)
        {
            try
            {
                string res = null;
                connection.Open();
                cmd.CommandText = $"SELECT {codeName} FROM {table} WHERE {fieldName} = '{condition}'";
                MySqlDataReader r = cmd.ExecuteReader();
                if (r.Read())
                    res = r.GetString(0);
                connection.Close();
                return res;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public void updateRec(string tableName, string codeValue, List<string> values)
        {
            try
            {                
                List<string> fields = GetFieldsMySQL(tableName);
                cmd.CommandText = $"UPDATE {tableName} SET ";
                for (int i = 1; i < values.Count; i++)
                {
                    cmd.CommandText += $"{fields[i]} = '{values[i]}', ";
                }
                cmd.CommandText = cmd.CommandText.Remove(cmd.CommandText.Length - 2) + $" WHERE {fields[0]} = '{codeValue}'";
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        public void SelectRecords(DataGridView dataGridView, string columns, string tableName, string condition)//display as ???? 
        {
            try
            {
                connection.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter($"SELECT {columns} FROM {tableName} {condition}", connection);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, tableName);
                dataGridView.DataSource = dataSet.Tables[tableName];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            connection.Close();
        }

        public void SelectRecords(DataGridView dataGridView, string tableName, string condition)
        {
            try
            {
                connection.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter($"SELECT * FROM {tableName} {condition}", connection);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, tableName);
                dataGridView.DataSource = dataSet.Tables[tableName];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            connection.Close();
        }
        /*
        public List<string> oSelectCipher()
        {

        }*/

        /*
        public void Save()
        {
            logger.Save();
        }*/

        public orderData GetDateForOder(List<string> Classes)
        {
            orderData data = new orderData();

            try
            {/*
                    cmd.CommandText = $"SELECT COUNT(Code) FORM ThemesByOrder INNER JOIN Students on ThemesByOrder.Student = Students.Code WHERE Students.Class = " +
                        $"(SELECT Code FROM Class WHERE Cipher = {item})";*/
                foreach (var item in Classes)
                {
                    cmd.CommandText = $"SELECT FullName FROM Students WHERE Class = (SELECT Number FROM Class WHERE Cipher = '{item}')";
                    if (connection.State != ConnectionState.Open)
                        connection.Open();
                    MySqlDataReader r = cmd.ExecuteReader();
                    if (r.Read())
                    {
                        data.fullName.Add(r.GetString(0));
                        data.clas.Add(item);
                    }
                    connection.Close();
                }

                foreach (var name in data.fullName)
                {
                    cmd.CommandText = $"SELECT Themes.tName FROM ThemesByOrder JOIN Students on ThemesByOrder.Student = Students.Code JOIN Themes on ThemesByOrder.Theme = Themes.Code WHERE Students.FullName = '{name}' ";
                    if (connection.State != ConnectionState.Open)
                        connection.Open();
                    MySqlDataReader r = cmd.ExecuteReader();
                    if (r.Read())
                        data.theme.Add(r.GetString(0));
                }
                /*
                cmd.CommandText = $"SELECT FullName FROM Students where Class = (SELECT Code FROM Class WHERE Cipher = {item})";
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                MySqlDataReader r = cmd.ExecuteReader();
                if (r.Read())
                    data.clas.Add(r.GetString(0));*/


                //count += cmd.ExecuteNonQuery();
                connection.Close();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                throw;
            }
            return data;
        }
        //return class and take all info from the user???


        // select subject 
        // classes 
        // get from user teaches names | speciality | galuz' znan'
    }
}
