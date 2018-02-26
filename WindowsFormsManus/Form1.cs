using System;
using System.Windows.Forms;
using Google.Cloud.Vision.V1;
using System.IO;
using System.Linq;
using System.Drawing;
using ImageProcessor.Imaging.Formats;
using ImageProcessor;

namespace WindowsFormsManus
{


    public partial class Form1 : Form
    {
        public string ImagePath { get; set; }
        OpenFileDialog fileDlg = new OpenFileDialog();

        public Form1()
        {
            InitializeComponent();
            btnConvertirImagen.Enabled = false;
        }

        //**Método que carga la imagen a convertir**//
        private void btnCargarImagen_Click(object sender, EventArgs e)
        {
            btnConvertirImagen.Enabled = false;
            txtResultado.Text = "";
            ImagePath = "";
            fileDlg.Filter = "jpeg files|*.jpg;*.JPG;*.png;*.PNG;";
            if (fileDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                
                ImagePath = fileDlg.FileName;
                picImagen.ImageLocation = ImagePath;
                FileInfo fileInfo = new FileInfo(fileDlg.FileName);
                lblInfo.Text = "Imagen cargada: " + fileInfo.Name;
                lblInfo.BackColor = Color.LightGreen;

                btnConvertirImagen.Enabled = true;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        //**Método que convierte a texto la imagen a cargada**//
        private void btnConvertirImagen_Click(object sender, EventArgs e)
        {
            var client = ImageAnnotatorClient.Create();
            var image = Google.Cloud.Vision.V1.Image.FromFile(fileDlg.FileName);
            var response = client.DetectText(image);

            txtResultado.Text = response.ElementAt(0).Description;
            string[] renglones = txtResultado.Text.Split('\n');
            txtResultado.Text = "";
            foreach (var renglon in renglones)
            {
                txtResultado.Text = string.Concat(txtResultado.Text, renglon);
                txtResultado.Text = string.Concat(txtResultado.Text, Environment.NewLine);
            }
        }
    }
 }
 

