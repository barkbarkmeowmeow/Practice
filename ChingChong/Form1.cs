using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace ChingChong
{
    public partial class Form1 : Form
    {
        private SqlConnection sqlConnection = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Database1"].ConnectionString);

            sqlConnection.Open();
            if (sqlConnection.State == ConnectionState.Open)
            {
                MessageBox.Show("Подклечено!");
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand(
                $"INSERT INTO [Table] (DateTimeAction, UserB, ActionType, ActionName, ActionResult, ActionDetails) VALUES (@DateTimeAction, @UserB, @ActionType, @ActionName, @ActionResult, @ActionDetails)",
                sqlConnection);

             command.Parameters.AddWithValue("DateTimeAction", textBox1.Text);
             command.Parameters.AddWithValue("UserB", textBox2.Text);
             command.Parameters.AddWithValue("ActionType", textBox3.Text);
             command.Parameters.AddWithValue("ActionName", textBox4.Text);
             command.Parameters.AddWithValue("ActionResult", textBox5.Text);
             command.Parameters.AddWithValue("ActionDetails", textBox6.Text);

             MessageBox.Show(command.ExecuteNonQuery().ToString());
}
}
}
