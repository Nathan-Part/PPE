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
    public partial class EditSalon : Form
    {

        public string id { get; set; }
        public string nom { get; set; }
        public string date { get; set; }
        public string lieu { get; set; }

        public EditSalon(String id_salon, String nomSalon, String dateSalon, String lieuSalon)
        {
            InitializeComponent();
            id = id_salon;
            nom = nomSalon;
            date = dateSalon;
            lieu = lieuSalon;

            label1.Text = "Modifier le salon " + nom;
            textBox5.Text = nom;
            dateTimePicker1.Text = date;
            textBox6.Text = lieu;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox5.Text.Length == 0 || textBox6.Text.Length == 0 || dateTimePicker1.Text.Length == 0)
            {
                MessageBox.Show("Vous n'avez pas remplie tout les champs !", "Champs vide", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                using (var insertSalon = new MySqlConnection(All.Bdd))
                {
                    insertSalon.Open();

                    String sql = "UPDATE salons SET nom = @nomSalon, date_salon = @dateSalon, lieu = @lieuSalon WHERE id_salon = @idSalon";
                    var ParametresRequetes = new DynamicParameters();
                    ParametresRequetes.Add("nomSalon", textBox5.Text);
                    ParametresRequetes.Add("dateSalon", dateTimePicker1.Text);
                    ParametresRequetes.Add("lieuSalon", textBox6.Text);
                    ParametresRequetes.Add("idSalon", id);
                    var ContexteUser = insertSalon.Query<salon>(sql, ParametresRequetes);
                    MessageBox.Show("Salon " + textBox5.Text + " modifié !", "Salon modifié", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    insertSalon.Close();
                }
            }
        }
    }
}
