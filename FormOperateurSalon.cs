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
    public partial class FormOperateurSalon : Form
    {
        string bdd = "server=localhost;user id=Nathan;database=ppe;Pwd=azerty";

        String Niveau;
        String Nom;
        public FormOperateurSalon(String Level, String Name)
        {
            InitializeComponent();
            Niveau = Level;
            Nom = Name;
            label1.Text = "Bienvenue " + Nom;

                MySqlConnection connParticipant = new MySqlConnection(bdd);
                try
                {
                    connParticipant.Open();
                    string sqlSalon = "SELECT * FROM participant";
                    MySqlCommand cmd = new MySqlCommand(sqlSalon, connParticipant);
                    MySqlDataReader compte = cmd.ExecuteReader();
                    while (compte.Read())
                    {
                        if (dataGridView1.Columns.Count == 0)
                        {
                            dataGridView1.Columns.Add("id_participant", "ID");
                            dataGridView1.Columns.Add("prenom", "Prenom");
                            dataGridView1.Columns.Add("nom", "Nom");
                            dataGridView1.Columns.Add("departement", "Departement");
                            dataGridView1.Columns.Add("email", "Email");
                        }
                        dataGridView1.Rows.Add(compte[0].ToString(), compte[1].ToString(), compte[2].ToString(), compte[3].ToString(), compte[4].ToString());

                    }
                    compte.Close();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                connParticipant.Close();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Votre niveau d'habilitation : " + Niveau + Environment.NewLine + "Votre nom : " + Nom, "Mes informations", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void textBox5_KeyUp(object sender, KeyEventArgs e)
        {
            using (var connection = new MySqlConnection(bdd))
            {
                connection.Open();
                dataGridView1.Columns.Clear();
                String search = textBox5.Text + "%";
                String sql = "SELECT id_participant AS ID, prenom, nom, departement, email FROM participant WHERE email LIKE @Email";
                var ParametresRequetes = new DynamicParameters();
                ParametresRequetes.Add("Email", search);
                var ContexteUser = connection.Query<participant>(sql, ParametresRequetes).ToList();
                dataGridView1.DataSource = ContexteUser;
                connection.Close();
            }
        }
    }
}
