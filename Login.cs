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
        string bdd = "server=localhost;user id=Nathan;database=ppe;Pwd=azerty";
        public String level = "";
        public String nom = "";
        public String id = "";

        public string nameEchec { get; set; }

        public Login()
        {
            InitializeComponent();
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
                using (var connection = new MySqlConnection(bdd))
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
                    int echec = 0;
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
                    else 
                    {
                        echec = echec + 1;
                        nameEchec = textBox1.Text;

                    }
                    connection.Close();
                }

            }
            else 
            {
                MessageBox.Show("Champs vide !");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
