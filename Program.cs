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
    static class Program
    {   
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string bdd = "server=localhost;user id=Nathan;database=ppe;Pwd=azerty";
            Login MonFormLogin = new Login();
            MonFormLogin.ShowDialog();
            int i = 0;
            if (MonFormLogin.DialogResult == DialogResult.OK)
            {
                String NiveauUtilisateur = MonFormLogin.level;
                String NomUtilisateur = MonFormLogin.nom;
                String IdUtilisateur = MonFormLogin.id;

                if (NiveauUtilisateur == "Administrateur" || NiveauUtilisateur == "Opérateur de salon")
                {
                    using (var connection2 = new MySqlConnection(bdd))
                    {
                        connection2.Open();

                        String sql2 = "INSERT INTO log_connexion(fk_user, date_connexion) VALUES(@fk_user, now())";
                        var ParametresRequetes2 = new DynamicParameters();
                        ParametresRequetes2.Add("fk_user", IdUtilisateur);
                        var InsertUser = connection2.Query<user>(sql2, ParametresRequetes2).ToList();

                        connection2.Close();
                    }
                    MessageBox.Show("Bienvenue");
                    Application.Run(new Home(NiveauUtilisateur, NomUtilisateur, Int32.Parse(IdUtilisateur)));
                }
                else
                {
                    i++;
                    using (var connection2 = new MySqlConnection(bdd))
                    {
                        connection2.Open();
                        NomUtilisateur = MonFormLogin.nameEchec;
                        String sql2 = "INSERT INTO log_echec_connexion(login, heure_tentative) VALUES(@login, now())";
                        var ParametresRequetes2 = new DynamicParameters();
                        ParametresRequetes2.Add("login", NomUtilisateur);
                        var InsertUser = connection2.Query<user>(sql2, ParametresRequetes2).ToList();

                        connection2.Close();
                    }
                    MessageBox.Show("Erreur d'authentification. Essai :" + i);
                }

            }
            else
            {
                MonFormLogin.Close();
                MessageBox.Show("Au revoir");
            }

        }
    }
}

