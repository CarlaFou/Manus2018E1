using System;
using System.Windows.Forms;
using Google.Cloud.Vision.V1;
using System.IO;
using System.Drawing;
using ImageProcessor.Imaging.Formats;
using ImageProcessor;


namespace WindowsFormsManus
{


	public partial class Form1 : Form 
	{
		public string ImagePath { get; set; }
		


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
			
			using (OpenFileDialog dlg = new OpenFileDialog())
			{
			   dlg.Filter = "jpeg files|*.jpg;*.JPG;*.png;*.PNG;";
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					FileInfo fileInfo = new FileInfo(dlg.FileName);
					if (fileInfo.Length > 1024 * 1024 * 4)
					{
						MessageBox.Show("El tamaño de la imagen no puede ser mayor a 4MB");
						return;
					}
					else
					{
						picImagen.Image = System.Drawing.Image.FromFile(dlg.FileName);
						ImagePath = dlg.FileName;
						lblInfo.Text = "Imagen cargada: " + fileInfo.Name;
						lblInfo.BackColor = Color.LightGreen;

						btnConvertirImagen.Enabled = true;
					}
				}
			}         

		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}


		//**Método que convierte a texto la imagen a cargada**//
		private void btnConvertirImagen_Click(object sender, EventArgs e)
		{
			
			string selectedFile = ImagePath;
			var photoBytes = File.ReadAllBytes(selectedFile);
		  
				//**Realiza procesamiento de imagen previo a la conversion**//
				using (var inStream = new MemoryStream(photoBytes))
				{
				 using (var outStream = new MemoryStream())
				 {
					using (ImageFactory imageFactory = new ImageFactory(false))
					{
						//Filtros 
						var img = imageFactory.Load(inStream)
								
								   .Brightness(10)
								   .Format(new PngFormat { Quality = 100 })
								   .Resolution(1024, 1024)
							  
							   //Se guarda en memoria los cambios
							   .Save(outStream);
					}

				//Realiza la conversión con la imagen a texto a pertir de los cambios realizados  
				var image = Google.Cloud.Vision.V1.Image.FromStream(outStream);
				var client = ImageAnnotatorClient.Create();
				var response = client.DetectDocumentText(image);//MODIFICADO*/
				txtResultado.Text = response.Text;

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
	  }
}

