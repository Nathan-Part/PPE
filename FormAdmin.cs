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
    public partial class FormAdmin : Form
    {
        string bdd = "server=localhost;user id=Nathan;database=ppe;Pwd=azerty";

        class ComboValue
        {
            public string Name { get; set; }
            public int Value { get; set; }
        }
        public void save(string id, string leNom, string lePrenom, string leLogin, string leMdp, string leType)
        {
            
            if (id != null)
            {
                MessageBox.Show("UPDATE");
            }
            else
            {
                MessageBox.Show("INSERT");
            }
        }

        public String Niveau;
        public String Nom;
        public FormAdmin(String Level, String Name)
        {
            InitializeComponent();
            Niveau = Level;
            Nom = Name;
            label1.Text = "Bienvenue " + Nom;
            MySqlConnection conn = new MySqlConnection(bdd);
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

            MySqlConnection conn2 = new MySqlConnection(bdd);
            try
            {
                conn2.Open();
                string sql2 = "SELECT * FROM user INNER JOIN type ON type = id_type";
                MySqlCommand cmd = new MySqlCommand(sql2, conn2);
                MySqlDataReader compte = cmd.ExecuteReader();
                while (compte.Read())
                {
                    if (dataGridView1.Columns.Count == 0)
                    {
                        dataGridView1.Columns.Add("id", "ID");
                        dataGridView1.Columns.Add("prenom", "Prénom");
                        dataGridView1.Columns.Add("nom", "Nom");
                        dataGridView1.Columns.Add("login", "Login");
                        dataGridView1.Columns.Add("role", "Role");
                    }
                    dataGridView1.Rows.Add(compte[0].ToString(), compte[1].ToString(), compte[2].ToString(), compte[3].ToString(), compte[7].ToString());

                }
                compte.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            conn2.Close();

            MySqlConnection conn3 = new MySqlConnection(bdd);
            try
            {
                conn3.Open();
                string sql3 = "SELECT nom, prenom, login, count(*) FROM `log_connexion` INNER JOIN user ON id = fk_user WHERE DATE_FORMAT(date_connexion, '%Y-%m-%d') = DATE_FORMAT(now(), '%Y-%m-%d') GROUP BY id";
                MySqlCommand cmd2 = new MySqlCommand(sql3, conn3);
                MySqlDataReader log = cmd2.ExecuteReader();
                while (log.Read())
                {
                    if (dataGridView2.Columns.Count == 0)
                    {
                        dataGridView2.Columns.Add("nom", "Nom");
                        dataGridView2.Columns.Add("prenom", "Prénom");
                        dataGridView2.Columns.Add("login", "Login");
                        dataGridView2.Columns.Add("nb_connexion", "Nombre de connexions du jour");
                    }
                    dataGridView2.Rows.Add(log[0].ToString(), log[1].ToString(), log[2].ToString(), log[3].ToString());

                }
                log.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            conn3.Close();

            MySqlConnection conn4= new MySqlConnection(bdd);
            try
            {
                conn4.Open();
                string sql4 = "SELECT * FROM `log_echec_connexion`";
                MySqlCommand cmd2 = new MySqlCommand(sql4, conn4);
                MySqlDataReader log = cmd2.ExecuteReader();
                while (log.Read())
                {
                    if (dataGridView3.Columns.Count == 0)
                    {
                        dataGridView3.Columns.Add("login", "Login");
                        dataGridView3.Columns.Add("heure_tentative", "Date et heure de la tentative de connexion");
                    }
                    dataGridView3.Rows.Add(log[1].ToString(), log[2].ToString());

                }
                log.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            conn4.Close();

            MySqlConnection connSalon = new MySqlConnection(bdd);
            try
            {
                connSalon.Open();
                string sqlSalon = "SELECT * FROM salons";
                MySqlCommand cmd = new MySqlCommand(sqlSalon, connSalon);
                MySqlDataReader compte = cmd.ExecuteReader();
                while (compte.Read())
                {
                    if (dataGridView6.Columns.Count == 0)
                    {
                        dataGridView6.Columns.Add("id_salon", "ID");
                        dataGridView6.Columns.Add("nom", "Nom");
                        dataGridView6.Columns.Add("date_salon", "Date");
                        dataGridView6.Columns.Add("lieu", "Lieu");
                    }
                    dataGridView6.Rows.Add(compte[0].ToString(), compte[1].ToString(), compte[2].ToString(), compte[3].ToString());

                }
                compte.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            connSalon.Close();

            MySqlConnection remarque = new MySqlConnection(bdd);
            try
            {
                remarque.Open();
                string sql5 = "SELECT prenom, nom, commentaire, date_redaction FROM remarque INNER JOIN type_aide INNER JOIN user ON id_aide = fk_type AND remarque.fk_user = user.id WHERE fk_type = 1 ";
                MySqlCommand cmd = new MySqlCommand(sql5, remarque);
                MySqlDataReader compte = cmd.ExecuteReader();
                while (compte.Read())
                {
                    if (dataGridView4.Columns.Count == 0)
                    {
                        dataGridView4.Columns.Add("prenom", "Prénom");
                        dataGridView4.Columns.Add("nom", "Nom");
                        dataGridView4.Columns.Add("commentaire", "Commentaire");
                        dataGridView4.Columns.Add("date_redaction", "Date de redaction");
                    }
                    dataGridView4.Rows.Add(compte[0].ToString(), compte[1].ToString(), compte[2].ToString(), compte[3].ToString());

                }
                compte.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            remarque.Close();

            MySqlConnection remarque2 = new MySqlConnection(bdd);
            try
            {
                remarque2.Open();
                string sql6 = "SELECT prenom, nom, commentaire, date_redaction FROM remarque INNER JOIN type_aide INNER JOIN user ON id_aide = fk_type AND remarque.fk_user = user.id WHERE fk_type = 2";
                MySqlCommand cmd = new MySqlCommand(sql6, remarque2);
                MySqlDataReader compte = cmd.ExecuteReader();
                while (compte.Read())
                {
                    if (dataGridView5.Columns.Count == 0)
                    {
                        dataGridView5.Columns.Add("prenom", "Prénom");
                        dataGridView5.Columns.Add("nom", "Nom");
                        dataGridView5.Columns.Add("commentaire", "Commentaire");
                        dataGridView5.Columns.Add("date_redaction", "Date");
                    }
                    dataGridView5.Rows.Add(compte[0].ToString(), compte[1].ToString(), compte[2].ToString(), compte[3].ToString());

                }
                compte.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            remarque2.Close();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Votre niveau d'habilitation : " + Niveau + Environment.NewLine + "Votre login : " + Nom, "Mes informations", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int Index = comboBox1.SelectedIndex;
            if (Index > 0)
            {
                ComboValue MaComboValue = (ComboValue)comboBox1.SelectedItem;
            }
        }
       
        private void button4_Click(object sender, EventArgs e)
        {
            int Index = comboBox1.SelectedIndex;

            ComboValue MaComboValue = (ComboValue)comboBox1.SelectedItem;
            String role = MaComboValue.Name;
            int idType = MaComboValue.Value;
            if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0 || textBox3.Text.Length == 0 || textBox4.Text.Length == 0 || comboBox1.Text.Length == 0) 
            {
                MessageBox.Show("Vous n'avez pas remplie tout les champs !", "Champs vide", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else 
            {
                using (var connection = new MySqlConnection(bdd))
                {
                    connection.Open();

                    string hashPassword = SHA.petitsha(textBox2.Text);
                    String sql = "INSERT INTO user(nom, prenom, login, mdp, type) VALUES(@name, @fName,@login, @mdp, @type)";
                    var ParametresRequetes = new DynamicParameters();
                    ParametresRequetes.Add("name", textBox3.Text);
                    ParametresRequetes.Add("fName", textBox4.Text);
                    ParametresRequetes.Add("Login", textBox1.Text);
                    ParametresRequetes.Add("Mdp", hashPassword);
                    ParametresRequetes.Add("Type", idType);
                    var ContexteUser = connection.Query<user>(sql, ParametresRequetes).ToList();
                    MessageBox.Show("Utilisateur " + textBox1.Text + " ajouté !");

                    connection.Close();
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var login = dataGridView1.CurrentRow.Cells["login"].Value.ToString();
            var nom = dataGridView1.CurrentRow.Cells["nom"].Value.ToString();
            var prenom = dataGridView1.CurrentRow.Cells["prenom"].Value.ToString();
            var role = dataGridView1.CurrentRow.Cells["role"].Value.ToString();
            EditUser userEdit = new EditUser(login, nom, prenom, role);
            userEdit.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox5.Text.Length == 0 || textBox6.Text.Length == 0 || dateTimePicker1.Text.Length == 0)
            {
                MessageBox.Show("Vous n'avez pas remplie tout les champs !", "Champs vide", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                using (var insertSalon = new MySqlConnection(bdd))
                {
                    insertSalon.Open();

                    String sql = "INSERT INTO salons(nom, date_salon, lieu) VALUES(@nom, @date, @lieu)";
                    var ParametresRequetes = new DynamicParameters();
                    ParametresRequetes.Add("nom", textBox5.Text);
                    ParametresRequetes.Add("date", dateTimePicker1.Text);
                    ParametresRequetes.Add("lieu", textBox6.Text);
                    var ContexteUser = insertSalon.Query<salon>(sql, ParametresRequetes);
                    MessageBox.Show("Salon " + textBox5.Text + " ajouté !");

                    insertSalon.Close();
                }
            }
        }

        private void dataGridView6_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var id = dataGridView6.CurrentRow.Cells["id_salon"].Value.ToString();
            var nom = dataGridView6.CurrentRow.Cells["nom"].Value.ToString();
            var date = dataGridView6.CurrentRow.Cells["date_salon"].Value.ToString();
            var lieu = dataGridView6.CurrentRow.Cells["lieu"].Value.ToString();
            EditSalon salonEdit = new EditSalon(id, nom, date, lieu);
            salonEdit.Show();
        }

        private void tabControl3_Click(object sender, EventArgs e)
        {
            MySqlConnection connSalon = new MySqlConnection(bdd);
            try
            {
                connSalon.Open();
                string sqlSalon = "SELECT * FROM salons";
                MySqlCommand cmd = new MySqlCommand(sqlSalon, connSalon);
                MySqlDataReader compte = cmd.ExecuteReader();
                while (compte.Read())
                {
                    if (dataGridView6.Columns.Count == 0)
                    {
                        dataGridView6.Columns.Add("id_salon", "ID");
                        dataGridView6.Columns.Add("nom", "Nom");
                        dataGridView6.Columns.Add("date_salon", "Date");
                        dataGridView6.Columns.Add("lieu", "Lieu");
                    }
                    dataGridView6.Rows.Add(compte[0].ToString(), compte[1].ToString(), compte[2].ToString(), compte[3].ToString());

                }
                compte.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            connSalon.Close(); 
        }
    }
}
