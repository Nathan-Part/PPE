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

namespace PPE
{
    public partial class EditUser : Form
    {
        String identifiant;
        String lastName;
        String firstName;
        String type; 

        class ComboValue
        {
            public string Name { get; set; }
            public int Value { get; set; }
        }

        public EditUser(String login, String nom, String prenom, String role)
        {   
            InitializeComponent();
            identifiant = login;
            lastName = nom;
            firstName = prenom;
            type = role;

            MySqlConnection conn = new MySqlConnection(All.Bdd);
            try
            {
                conn.Open();
                string sql = "SELECT * FROM type ";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                var ComboType = new List<ComboValue>();
                while (rdr.Read())
                {
                    ComboType.Add(new ComboValue() { Name = rdr[1].ToString(), Value = int.Parse(rdr[0].ToString()) });
                }
                rdr.Close();
                comboBox1.DataSource = ComboType;
                comboBox1.DisplayMember = "Name";
                comboBox1.ValueMember = "Value";
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            conn.Close();

            textBox1.Text = identifiant;
            textBox3.Text = lastName;
            textBox4.Text = firstName;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            ComboValue MaComboValue = (ComboValue)comboBox1.SelectedItem;
            String role = MaComboValue.Name;
            int idType = MaComboValue.Value;
            if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0 || textBox3.Text.Length == 0 || textBox4.Text.Length == 0 || comboBox1.Text.Length == 0)
            {
                MessageBox.Show("Vous n'avez pas remplie tout les champs !", "Champs vide", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MySqlConnection conn = new MySqlConnection(All.Bdd);
                try
                {
                    conn.Open();
                    string hashPassword = SHA.petitsha(textBox2.Text);
                    string sql2 = "UPDATE user SET login = '" + textBox1.Text + "', mdp = '" + hashPassword + "', nom = '" + textBox3.Text + "', prenom = '" + textBox4.Text + "', type = " + idType + " WHERE login = '" + textBox1.Text + "' ";

                    MySqlCommand cmd = new MySqlCommand(sql2, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Utilisateur " + textBox1.Text + " modifié !");
                    textBox1.Clear();
                    textBox2.Clear();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                conn.Close();
            }
        }
    }
}
