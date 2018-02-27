using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Google.Cloud.Vision.V1;

namespace ManusE1
{
    public partial class Form1 : Form
    {
        string fotoPath;
        string txtPath;
        //Creo instancia de cliente API
        ImageAnnotatorClient client = ImageAnnotatorClient.Create();
        public Form1()
        {
            InitializeComponent();
        }

            private void processButton_Click(object sender, EventArgs e) {
                textBox1.Text = "Procesando...";
                //API Vision
                var image = Image.FromFile(fotoPath);
                var response = client.DetectText(image);
                //Creo archivo txt
                string directory = Path.GetDirectoryName(fotoPath);
                CreateTXT(directory);
                string text = "";
                //Escribo lo devuelto por Vision 
                text = response.ElementAt(0).Description;
                writeTXT(txtPath, text);
                textBox1.Text = "Se creó un txt con el resultado.";
                processButton.Enabled = false;
            }

            private void openButton_Click(object sender, EventArgs e) {
                // Consigo path de imagen 
                Stream myStream = null;
                openFileDialog1.InitialDirectory = "c:\\" ;
                openFileDialog1.Filter = "Archivos jpg (*.jpg)|*.jpg*|Todos los archivos (*.*)|*.*" ;
                openFileDialog1.FilterIndex = 2 ;
                openFileDialog1.RestoreDirectory = true ;

                if(openFileDialog1.ShowDialog() == DialogResult.OK) {
                    if ((myStream = openFileDialog1.OpenFile()) != null) {
                        fotoPath = openFileDialog1.FileName;
                    }
                }
                processButton.Enabled = true;
            }

            public void CreateTXT(string directory) {
                txtPath = string.Concat(directory, "\\Texto Resultado.txt"); //Creo el archivo con nombre "Texto Resultado"
                if (File.Exists(txtPath)) {
                    textBox1.Text = "Ya existía otro archivo de texto resultado. Se reemplazó.";
                }
                FileStream file = File.Create(txtPath);
                file.Dispose(); //Elimino el objeto para que writeTXT pueda usar el archivo creado sin que este proceso lo tenga abierto.
            }

            public void writeTXT(string txtFilePath, string text) {
                StreamWriter file = new StreamWriter(txtFilePath);
                file.Write(text);
                file.Dispose();
            }
        }
    }
