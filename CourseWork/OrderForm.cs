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
    public partial class OrderForm : Form
    {
        public OrderForm()
        {
            InitializeComponent();
            db = dbMnanger.GetInstance();
            db.GetAllVar(comboBox1, "Course", "");
        }

        dbMnanger db;

        private void button3_Click(object sender, EventArgs e)
        {
            if (!listBox1.Items.Contains(comboBox2.SelectedItem.ToString()) && comboBox2.SelectedIndex != -1)
                listBox1.Items.Add(comboBox2.SelectedItem.ToString());
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
            comboBox2.Items.Clear();
            db.GetAllVar(comboBox3, "Subject", $"WHERE Course = '{comboBox1.SelectedItem}'");
            db.GetAllVar(comboBox2, "Class", $"WHERE Course = '{comboBox1.SelectedItem}'");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!listBox1.Items.Contains(textBox2.Text) && textBox2.Text != "")
                listBox1.Items.Add(textBox2.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            else if (comboBox2.SelectedIndex != -1 && listBox1.Items.Contains(comboBox2.SelectedItem))
                listBox1.Items.RemoveAt(comboBox2.SelectedIndex);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex != -1)
                listBox2.Items.RemoveAt(listBox2.SelectedIndex);
        }
    }
}
