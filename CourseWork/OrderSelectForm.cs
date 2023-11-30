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

namespace SingletonDesignPattern
{
    public partial class OrderSelectForm : Form
    {
        public OrderSelectForm()
        {
            InitializeComponent();
            db = dbMnanger.GetInstance();
        }

        dbMnanger db;

        private void OrderSelectForm_Load(object sender, EventArgs e)
        {
            db.SelectRecords(dataGridView1, "Orders", "");
            db.GetAllVar(comboBox1, "Subject", "");
            bindingSource1.DataSource = dataGridView1.DataSource;
            editComponents.Add(textBox1);
            editComponents.Add(textBox2);
            editComponents.Add(comboBox1);
            
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && comboBox1.SelectedIndex != -1)
            {
                db.Insert("Orders", "", "('" + db.GetMaxCode("Orders") + "', '" + textBox2.Text + "', '" + db.GetForeignCode("Code", "Subjects", "sName", comboBox1.SelectedItem.ToString()) + "')");//textBox1.Text
                db.SelectRecords(dataGridView1, "Orders", "");
            }
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell.RowIndex != -1)
                return;            
            db.DeleteRecMySQL("Orders", "Number", dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value.ToString());
            db.SelectRecords(dataGridView1, "Orders", "");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell.RowIndex != -1)
                this.DialogResult = DialogResult.OK;
        }

        List<Control> editComponents = new List<Control>();
        List<string> values = new List<string>();

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            foreach (var item in editComponents)
            {
                item.Enabled = checkBox1.Checked;
            }

            if (((CheckBox)sender).Checked == false)
            {
                //will I get bonked if I update the record on uncheck??????????

                bool empty = false;
                foreach (var item in editComponents)
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
                    string tableName = "Orders";
                    values.Clear();
                    foreach (var item in editComponents)
                    {
                        if (!item.ToString().Contains("db"))
                        {
                            if (((Control)item).Name.Contains("combo"))
                            {
                                values.Add(db.GetForeignCode("Code", "Subjects", "sName", ((ComboBox)item).SelectedItem.ToString()));
                            }
                            else
                                values.Add(((Control)item).Text);
                        }
                    }
                    db.updateRec(tableName, values[0], values);
                    db.SelectRecords(dataGridView1, tableName, "");
                }
            }
        }
    }
}
