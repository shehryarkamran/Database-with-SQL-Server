using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DB_SQL_Server
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection connect = new SqlConnection("Data Source=ASIF-PC;Initial Catalog=StudentDB;Integrated Security=True");
        SqlCommand command = new SqlCommand();
        private void button1_Click(object sender, EventArgs e)
        {
            connect.Open();
            MessageBox.Show("DB connected....");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
           
            connect.Open();

            command.Connection = connect;
            command.CommandText = "SELECT * FROM Stdtable";// Students is the name of table

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                listBox1.Items.Add(reader[0].ToString());
                listBox2.Items.Add(reader[1]);
                listBox3.Items.Add(reader[2]);
            }
            connect.Close();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            connect.Open();

            command = new SqlCommand("Insert Into Stdtable (stdid, stdname, stddept) values  ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "')", connect);
            command.ExecuteReader();
            MessageBox.Show("inserted ....");

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();

            connect.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            connect.Open();
            command = new SqlCommand("DELETE FROM Stdtable where (stdid = '" + textBox1.Text + "')", connect);
            //  command = new SqlCommand("DELETE FROM Stdtable where (stdid = '" + listBox1.SelectedItem + "')", connect);

            command.ExecuteReader();
            MessageBox.Show("Deleted ....");
            connect.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            connect.Open();       
            command = new SqlCommand("select * from Stdtable", connect);
           
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {

                dataGridView1.Rows.Add();

                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["stdid"].Value = reader[0].ToString();
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["stdname"].Value = reader[1].ToString();
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["stddetp"].Value = reader[2].ToString();
                //dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["empdept"].Value = reader[3].ToString();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;

            dataGridView1.Columns.Add("stdid", "Student ID");
            dataGridView1.Columns.Add("stdname", "Student Name");
            dataGridView1.Columns.Add("stddetp", "Student Dept");
        }
    }
}
