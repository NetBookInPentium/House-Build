using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HouseBuild
{
    public partial class Menu : Form
    {
        Call_DB Call_DB = new Call_DB();
        public Menu()
        {
            InitializeComponent();
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
    }
}
