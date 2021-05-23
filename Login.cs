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
    public partial class Login : Form
    {
        public String level = "";
        public String nom = "";
        public String id = "";
     
        public string nameEchec { get; set; }
        public int countEchec { get; set; }

        public Login()
        {
            InitializeComponent();
            textBox1.Text = "Nathan";
            textBox2.Text = "mdp";
        }
        public bool IsNull(string champ)
        {
            if (String.IsNullOrEmpty(champ))
                return false;
            else
                return true;
        }
            
        private void button2_Click(object sender, EventArgs e)
        {
            if (IsNull(textBox1.Text))
            {
                //On verifie la coherence de login/pass
                using (var connection = new MySqlConnection(All.Bdd))
                {
                    connection.Open();
                    String leLogin = textBox1.Text;
                    String hashPassword = SHA.petitsha(textBox2.Text);
                    String sql = "SELECT * FROM user INNER JOIN type ON type = id_type WHERE login =@Login and mdp =@Mdp";
                    var ParametresRequetes = new DynamicParameters(); 
                    ParametresRequetes.Add("Login", leLogin); 
                    ParametresRequetes.Add("Mdp", hashPassword);
                    var ContexteUser = connection.Query<user>(sql, ParametresRequetes).ToList();
                    bool userExist = false;
                    foreach (var item in ContexteUser)
                    {
                        userExist = true;
                        this.nom = item.login;
                        this.level = item.libelle;
                        this.id = item.id.ToString();
                    }
                    if(userExist == true)
                    {
                        // Si c'est ok, on positionne DialogResult à OK 
                        this.DialogResult = DialogResult.OK;
                    }
                    else if(userExist == false) 
                    {
                        countEchec = countEchec + 1 ;
                        int nbEssai = 5 - countEchec;
                        nameEchec = textBox1.Text;

                        using (var connection2 = new MySqlConnection(All.Bdd))
                        {
                            connection2.Open();
                            String sql2 = "INSERT INTO log_echec_connexion(login, heure_tentative) VALUES(@login, now())";
                            var ParametresRequetes2 = new DynamicParameters();
                            ParametresRequetes2.Add("login", nameEchec);
                            var InsertUser = connection2.Query<user>(sql2, ParametresRequetes2).ToList();

                            connection2.Close();
                        }

                        if(countEchec != 5) 
                        {
                            var result = MessageBox.Show("Erreur d'authentification. Essai :" + countEchec + Environment.NewLine + nbEssai + " essai restant", "Mauvais identifiant", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                            if (result == DialogResult.Cancel)
                            {
                                this.DialogResult = DialogResult.Cancel;
                            }
                        }
                        else if (countEchec == 5)
                        {
                            this.DialogResult = DialogResult.Cancel;
                            MessageBox.Show("Erreur d'authentification. Essai :" + countEchec + Environment.NewLine + nbEssai + " essai restant" + Environment.NewLine + "Trop de tentative ! fermeture de l'application", "Trop de tentative", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    connection.Close();
                }

            }
            else 
            {
                MessageBox.Show("Champs vide !", "Champs nom remplie", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
