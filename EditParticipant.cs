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
    public partial class EditParticipant : Form
    {
        public string Id { get; set; }
        public string Prenom { get; set; }
        public string Nom { get; set; }
        public string Departement { get; set; }
        public string Email { get; set; }

        public EditParticipant(string idParticipant, string nomParticipant, string prenomParticipant, string departementParticipant, string emailParticipant)
        {
            InitializeComponent();
            Id = idParticipant;
            Nom = nomParticipant;
            Prenom = prenomParticipant;
            Departement = departementParticipant;
            Email = emailParticipant;

            label3.Text = "Modifier le participant : " + Prenom + " " + Nom;

            textBox1.Text = Nom;
            textBox2.Text = Prenom;
            textBox3.Text = Departement;
            textBox4.Text = Email;
    
        }

        private void button4_Click(object sender, System.EventArgs e)
        {
            if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0 || textBox3.Text.Length == 0 || textBox4.Text.Length == 0)
            {
                MessageBox.Show("Vous n'avez pas remplie tout les champs !", "Champs vide", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                using (var updateParticipant = new MySqlConnection(All.Bdd))
                {
                    updateParticipant.Open();

                    String sql = "UPDATE participant SET nom = @Nom, prenom = @Prenom, departement = @Departement, email = @Email WHERE id_participant = @Id";
                    var ParametresRequetes = new DynamicParameters();
                    ParametresRequetes.Add("Nom", textBox1.Text);
                    ParametresRequetes.Add("Prenom", textBox2.Text);
                    ParametresRequetes.Add("Departement", textBox3.Text);
                    ParametresRequetes.Add("Email", textBox4.Text);
                    ParametresRequetes.Add("Id", Id);
                    var ContexteUser = updateParticipant.Query<participant>(sql, ParametresRequetes);
                    MessageBox.Show("Participant " + Nom + " " + Prenom + " modifié !", "Participant modifié", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    updateParticipant.Close();
                }
            }

        }
    }
}
