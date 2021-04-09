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
    public partial class Remarque : Form
    {
        string bdd = "server=localhost;user id=Nathan;database=ppe;Pwd=azerty";
        public string Nom { get; set; }
        public int Id { get; set; }
        public Remarque(String Role, String User, int IdUtilisateur)
        {
            InitializeComponent();
            Nom = User;
            Id = IdUtilisateur;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var connection = new MySqlConnection(bdd))
            {
                connection.Open();

                String sql = "INSERT INTO remarque(fk_user, commentaire, date_redaction, fk_type) VALUES(@user, @comment, now(), @type)";
                var ParametresRequetes = new DynamicParameters();
                ParametresRequetes.Add("user", Id);
                ParametresRequetes.Add("comment", richTextBox1.Text);
                if (radioButton1.Checked) 
                {
                    ParametresRequetes.Add("type", 1);
                }
                else if (radioButton2.Checked)
                {
                    ParametresRequetes.Add("type", 2);
                }
                var ContexteUser = connection.Query<user>(sql, ParametresRequetes).ToList();
                MessageBox.Show("Votre commentaire a bien été ajouté !");

                connection.Close();
            }
        }
    }
}
