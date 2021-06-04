using System;
using System.IO;
using System.Diagnostics;
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
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

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

            pictureBox1.ImageLocation = "https://qrickit.com/api/qr.php?d=" + Email + "&addtext=Email de " + Prenom + " " + Nom + "&txtcolor=007bff&fgdcolor=000000&bgdcolor=FFFFFF&qrsize=300&t=p&e=m";

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

        private void button1_Click(object sender, EventArgs e)
        {
            /*Pdf pdfForm = new Pdf(Id, Nom, Prenom, Departement, Email);
            pdfForm.ShowDialog();*/

            PdfDocument document = new PdfDocument();
            document.Info.Title = "Badge d'identification de " + Prenom + " " + Nom; // permet de nommer l'onglet du PDF
            // La page 
            PdfPage page = document.AddPage(); // crée la page ? 

            // une instance de dessin 
            XGraphics gfx = XGraphics.FromPdfPage(page);

            // la police 
            XFont font = new XFont("Verdana", 20, XFontStyle.BoldItalic); // definie la police
            XFont fontbarcode = new XFont("c39hrp24dhtt", 60);

            // On dessine le texte
            gfx.DrawString(Prenom + " " +Nom, font, XBrushes.Black, new XRect(0, 0, page.Width, page.Height), XStringFormats.Center);
            gfx.DrawString(Departement, font, XBrushes.Black, new XRect(0, 50, page.Width, page.Height), XStringFormats.Center);
/*            gfx.DrawString(Nom, fontbarcode, XBrushes.Black, new XRect(50, 50, page.Width, page.Height), XStringFormats.Center);*/

            XImage image = XImage.FromGdiPlusImage(pictureBox1.Image);

            // left position in point
/*             double x = (250 - image.PixelWidth * 72 / image.HorizontalResolution) / 2;
*/
            gfx.DrawImage(image, 175, 175);

            // on enregistre le document 
            string filename = "Badge d'identification de " + Prenom + " " + Nom;
            document.Save(filename);
            // on regarde le resultat 
            Process.Start(filename);

        }
    }
}
