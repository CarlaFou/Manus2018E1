using System;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using Google.Cloud.Vision.V1;
using ImageProcessor;
using ImageProcessor.Imaging.Filters.Photo;
namespace ManusE1
{
    public partial class Form1 : Form
    {
        string fotoPath;
        string txtPath;
        string directory;
        Stream fotoStream;
        //Creo instancia de cliente API
        ImageAnnotatorClient client = ImageAnnotatorClient.Create();
        public Form1()
        {
            InitializeComponent();
        }

            private void processButton_Click(object sender, EventArgs e) {
                textBox1.Text = "Procesando...";
                //Pido a la API Vision
                var image = Image.FromFile(fotoPath);
                var response = client.DetectText(image);
                //Creo archivo txt
                CreateTXT(directory);
                string text = "";
                //Escribo lo devuelto por Vision 
                text = response.ElementAt(0).Description;
                writeTXT(txtPath, text);
                textBox1.Text = "Se creó un txt con el resultado.";
                processButton.Enabled = false;
                //Elimino imagen creada por improveImage en directorio
                File.Delete(string.Concat(directory, "\\improvedImg.jpg"));
            }

            private void openButton_Click(object sender, EventArgs e) {
                // Consigo path de imagen 
                fotoStream = null;
                openFileDialog1.InitialDirectory = "c:\\" ;
                openFileDialog1.Filter = "Archivos jpg (*.jpg)|*.jpg*|Todos los archivos (*.*)|*.*" ;
                openFileDialog1.FilterIndex = 2 ;
                openFileDialog1.RestoreDirectory = true ;

                if(openFileDialog1.ShowDialog() == DialogResult.OK) {
                    fotoStream = openFileDialog1.OpenFile();
                    fotoPath = openFileDialog1.FileName;
                    directory = Path.GetDirectoryName(fotoPath);
                }
                textBox1.Text = ("Cargando imagen...");
                improveImage(fotoStream, directory);
                textBox1.Text = ("Imagen cargada. Listo para procesar.");
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

            public void improveImage(Stream img, string directory) {
                var imageFactory = new ImageFactory(false);
                var improvedImg = imageFactory.Load(img);
                //Aplico mejoras
                improvedImg.Contrast(65);
                improvedImg.Filter(MatrixFilters.BlackWhite);
                improvedImg.AutoRotate();

                //Guardo imagen mejorada
                improvedImg.Save(string.Concat(directory, "\\improvedImg.jpg"));
            }

        }
    }
