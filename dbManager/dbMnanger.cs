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
            {
                List<string> FieldNames = GetFieldsMySQL(TableName);
                cmd.CommandText = $"insert into {TableName} (";//values
                foreach (string field in FieldNames)
                {
                    cmd.CommandText += field + ", ";
                }
                cmd.CommandText = cmd.CommandText.Remove(cmd.CommandText.Length - 2) + ") values (";
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
        //не ну как бы вы можете сказать как оно +- должно работать но не факт что оно будет вам удобно :)
        //а, я не про это XD 
        //мне нужно тип кажой страницы как оно должно выглядеть, ща покажу про что я 
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

        public void GetAllVar(ComboBox comboBox, string name)
        {
            try
            {
                //logger.Log("SELECT cipher FROM class");
                List<string> Fields = new List<string>();
                switch (name)
                {
                    case "Theme":
                        cmd.CommandText = "SELECT DISTINCT tName FROM Themes";
                        break;
                    case "Class":
                        cmd.CommandText = "SELECT DISTINCT cipher FROM Class";
                        break;
                    case "Course":
                        cmd.CommandText = "SELECT DISTINCT Course from Class";
                        break;
                    case "Subject":
                        cmd.CommandText = "SELECT DISTINCT sName from Subjects";
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

        public void SelectRecords(DataGridView dataGridView, string tableName, string condition)//display as ???? 
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
                r.Read();
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
                r.Read();
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

        /*
        public void Save()
        {
            logger.Save();
        }*/
    }
}
