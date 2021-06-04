using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PPE
{
    public partial class Home : Form
    {
        public string Niveau { get; set; }
        public string Nom { get; set; }
        public int Id { get; set; }
        public Home(String Role, String User, int IdUtilisateur)
        {
            InitializeComponent();
            Niveau = Role;
            Nom = User;
            Id = IdUtilisateur;

            if (Role == "Opérateur de salon")
            {
                button2.Visible = true;
            }
            else if (Role == "Administrateur")
            {
                button2.Visible = true;
                button3.Visible = true;
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormOperateurSalon utilisateur = new FormOperateurSalon(Niveau, Nom);
            utilisateur.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormAdmin admin = new FormAdmin(Niveau, Nom);
            admin.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Remarque formRemarque = new Remarque(Niveau, Nom, Id);
            formRemarque.Show();
        }

    }
}
