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
    public partial class FormOperateurSalon : Form
    {
        String Niveau;
        String Nom;
        public FormOperateurSalon(String Level, String Name)
        {
            InitializeComponent();
            Niveau = Level;
            Nom = Name;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Votre niveau d'habilitation : " + Niveau + Environment.NewLine + "Votre nom : " + Nom);
        }
    }
}
