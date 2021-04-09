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
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;


namespace PPE
{
    // pour garder de coté le code pour crée un pdf
    public partial class Pdf : Form
    {
        public Pdf()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PdfDocument document = new PdfDocument();
            document.Info.Title = "Mon premier PDF"; // permet de nommer l'onglet du PDF
            // La page 
            PdfPage page = document.AddPage(); // crée la page ? 

            // une instance de dessin 
            XGraphics gfx = XGraphics.FromPdfPage(page);

            // la police 
            XFont font = new XFont("Verdana", 20, XFontStyle.BoldItalic); // definie la police
            XFont fontbarcode = new XFont("c39hrp24dhtt", 60);

            // On dessine le texte
            gfx.DrawString("SIO2", font, XBrushes.Black, new XRect(0, 0, page.Width, page.Height), XStringFormats.Center);
            gfx.DrawString("SIO3", fontbarcode, XBrushes.Black, new XRect(50, 50, page.Width, page.Height), XStringFormats.Center);

            XImage image = XImage.FromGdiPlusImage(pictureBox1.Image);

            // left position in point
            double x = (250 - image.PixelWidth * 72 / image.HorizontalResolution) / 2;
            gfx.DrawImage(image, x, 0);


            // on enregistre le document 
            const string filename = "monPremierPdf.pdf";
            document.Save(filename);
            // on regarde le resultat 
            Process.Start(filename);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = "https://qrickit.com/api/qr.php?d=https://pnathan.dev&addtext=Monportfolio&txtcolor=007bff&fgdcolor=000000&bgdcolor=FFFFFF&qrsize=150&t=p&e=m";
        }
    }
}
