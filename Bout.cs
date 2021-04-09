using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Dapper;

namespace PPE
{
    public partial class Bout : Form
    {
        string bdd = "server=localhost;user id=Nathan;database=ppe;Pwd=azerty";

        public Bout()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Pdf pdfForm = new Pdf();
            pdfForm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var connection = new MySqlConnection(bdd))
            {
                connection.Open();
                String leLogin = textBox1.Text + "%";
                String sql = "SELECT * FROM user INNER JOIN type ON type = id_type WHERE login LIKE @Login";
                var ParametresRequetes = new DynamicParameters();
                ParametresRequetes.Add("Login", leLogin);
                var ContexteUser = connection.Query<user>(sql, ParametresRequetes).ToList();
                dataGridView1.DataSource = ContexteUser;
                connection.Close();
            }
        }
    }
}
