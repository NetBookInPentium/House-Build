using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HouseBuild
{
    public partial class Menu : Form
    {
        Call_DB Call_DB = new Call_DB();
        DateTime thisDay = DateTime.Today;
        public Menu()
        {
            InitializeComponent();
            textBox3.Text = thisDay.ToString("d");
            DataSet dataSet = Call_DB.Request("SELECT * FROM objects");
            for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
            {
                comboBox1.Items.Add(dataSet.Tables[0].Rows[i][0]);
                comboBox4.Items.Add(dataSet.Tables[0].Rows[i][1]);
            }
            dataSet = Call_DB.Request("SELECT * FROM roofs");
            for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
            {
                comboBox2.Items.Add(dataSet.Tables[0].Rows[i][1]);
                comboBox8.Items.Add(dataSet.Tables[0].Rows[i][1]);

            }
            dataSet = Call_DB.Request("SELECT * FROM materials");
            for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
            {
                comboBox3.Items.Add(dataSet.Tables[0].Rows[i][1]);
                comboBox9.Items.Add(dataSet.Tables[0].Rows[i][1]);
            }
            dataSet = Call_DB.Request("SELECT * FROM housetop");
            for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
            {
                comboBox6.Items.Add(dataSet.Tables[0].Rows[i][0]);
                comboBox5.Items.Add(dataSet.Tables[0].Rows[i][0]);
            }
            dataSet = Call_DB.Request("SELECT * FROM saless");
            for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
            {
                comboBox7.Items.Add(dataSet.Tables[0].Rows[i][0]);
            }

        }

        public void Open_tables(string table)
        {
            Call_DB.Open();
            DataSet ds = Call_DB.Request($"SELECT * FROM {table}");
            dataGridView1.DataSource = ds.Tables[0];
            Call_DB.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {Open_tables("objects");}
        private void button2_Click(object sender, EventArgs e)
        {Open_tables("housetop");}
        private void button3_Click(object sender, EventArgs e)
        {Open_tables("saless");}
        private void button4_Click(object sender, EventArgs e)
        {Open_tables("roofs");}
        private void button5_Click(object sender, EventArgs e)
        {Open_tables("materials");}

        private void button10_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0 && textBox2.Text.Length > 0)
            {
                Call_DB.Open();
                Call_DB.Request($"INSERT INTO objects(namess,details) VALUES('{textBox1.Text}','{textBox2.Text}')");
                Call_DB.Close();
                Open_tables("objects");
                textBox1.Text = "";
                textBox2.Text = "";
            }
            else
            {
                MessageBox.Show("Не все поля заполнены!");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text.Length > 0 && comboBox2.Text.Length > 0 && comboBox3.Text.Length > 0)
            {
                Call_DB.Open();
                Call_DB.Request($"INSERT INTO housetop(id_obj,roof,material) VALUES('{comboBox1.Text}','{comboBox2.Text}','{comboBox3.Text}')");
                Call_DB.Close();
                Open_tables("housetop");
                comboBox1.Text = "";
                comboBox2.Text = "";
                comboBox3.Text = "";
            }
            else
            {
                MessageBox.Show("Не все поля заполнены!");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (comboBox6.Text.Length > 0 && textBox3.Text.Length > 0 && textBox4.Text.Length > 0)
            {
                Call_DB.Open();
                Call_DB.Request($"INSERT INTO saless(id_housetop,date_s,sale_s) VALUES('{comboBox6.Text}','{textBox3.Text}','{textBox4.Text}')");
                Call_DB.Close();
                Open_tables("saless");
                comboBox6.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
            }
            else
            {
                MessageBox.Show("Не все поля заполнены!");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox5.Text.Length > 0)
            {
                Call_DB.Open();
                Call_DB.Request($"INSERT INTO roofs(namess) VALUES('{textBox5.Text}')");
                Call_DB.Close();
                Open_tables("roofs");
                textBox5.Text = "";
            }
            else
            {
                MessageBox.Show("Не все поля заполнены!");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox6.Text.Length > 0)
            {
                Call_DB.Open();
                Call_DB.Request($"INSERT INTO materials(namess) VALUES('{textBox6.Text}')");
                Call_DB.Close();
                Open_tables("materials");
                textBox6.Text = "";
            }
            else
            {
                MessageBox.Show("Не все поля заполнены!");
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (comboBox4.Text.Length > 0)
            {
                Call_DB.Open();
                Call_DB.Request($"DELETE FROM objects WHERE namess = '{comboBox4.Text}'");
                Call_DB.Close();
                Open_tables("objects");
                comboBox4.Text = "";
            }
            else
            {
                MessageBox.Show("Значение не выбрано!");
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (comboBox5.Text.Length > 0)
            {
                Call_DB.Open();
                Call_DB.Request($"DELETE FROM housetop WHERE id = {comboBox5.Text}");
                Call_DB.Close();
                Open_tables("housetop");
                comboBox5.Text = "";
            }
            else
            {
                MessageBox.Show("Значение не выбрано!");
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (comboBox7.Text.Length > 0)
            {
                Call_DB.Open();
                Call_DB.Request($"DELETE FROM saless WHERE id = {comboBox7.Text}");
                Call_DB.Close();
                Open_tables("saless");
                comboBox7.Text = "";
            }
            else
            {
                MessageBox.Show("Значение не выбрано!");
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (comboBox8.Text.Length > 0)
            {
                Call_DB.Open();
                Call_DB.Request($"DELETE FROM roofs WHERE namess = '{comboBox8.Text}'");
                Call_DB.Close();
                Open_tables("roofs");
                comboBox8.Text = "";
            }
            else
            {
                MessageBox.Show("Значение не выбрано!");
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (comboBox9.Text.Length > 0)
            {
                Call_DB.Open();
                Call_DB.Request($"DELETE FROM materials WHERE namess = '{comboBox9.Text}'");
                Call_DB.Close();
                Open_tables("materials");
                comboBox9.Text = "";
            }
            else
            {
                MessageBox.Show("Значение не выбрано!");
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
