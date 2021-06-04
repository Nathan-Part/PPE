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
            
            if (MonFormLogin.DialogResult == DialogResult.OK)
            {
                String NiveauUtilisateur = MonFormLogin.level;
                String NomUtilisateur = MonFormLogin.nom;
                String IdUtilisateur = MonFormLogin.id;

                using (var connection2 = new MySqlConnection(bdd))
                {
                    connection2.Open();

                    String sql2 = "INSERT INTO log_connexion(fk_user, date_connexion) VALUES(@fk_user, now())";
                    var ParametresRequetes2 = new DynamicParameters();
                    ParametresRequetes2.Add("fk_user", IdUtilisateur);
                    var InsertUser = connection2.Query<user>(sql2, ParametresRequetes2).ToList();

                    connection2.Close();
                }

                Application.Run(new Home(NiveauUtilisateur, NomUtilisateur, Int32.Parse(IdUtilisateur)));
            }

        }
    }
}

