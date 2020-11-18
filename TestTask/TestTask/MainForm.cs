using System;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using TestTask.Algorithms;
using System.Dynamic;

namespace TestTask
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();

			LabelObj.Text = "";
			LabelObj.ForeColor = Color.FromArgb(32, 32, 32);

			ComboBoxObj.Items.AddRange(new string[] { "контраст", "градиент" });
		}

		public Bitmap Picture { get; set; }

		private IAlgorithm _algorithm;

		private async void RenderButton_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Filter = "Image Files (*.BMP)|*.BMP|All files (*.*)|*.*";

			if(ofd.ShowDialog() == DialogResult.OK)
			{
				if(ComboBoxObj.SelectedItem != null)
				{
					if(ComboBoxObj.SelectedItem.ToString() == "контраст")
					{
						_algorithm = new ContrastAlgorithm();
					}
					else if(ComboBoxObj.SelectedItem.ToString() == "градиент")
					{
						var alg = new GradientAlgorithm();
						alg.Grayscale = true;
						_algorithm = alg;
					}
					Picture = new Bitmap(ofd.FileName);
					PictureBox.Image = new Bitmap(ofd.FileName);

					if(ComboBoxObj.SelectedItem != null)
					{
						await Task.Run(RenderThreadHandler);
						Thread thread = new Thread(RenderThreadHandler) { Priority = ThreadPriority.AboveNormal };
						//thread.Name = "second thread";
						//thread.IsBackground = true;
						//thread.Start();
					}
				}
				else
				{
					LabelObj.Text = "Что-то пошло не так";
				}
			}
		}

		public void RenderThreadHandler()
		{
			Bitmap result = null;
			
			result = _algorithm.MathPart(Picture);

			var render = new MethodInvoker(() =>
			{
				if(!RenderedPictureBox.IsDisposed && result != null)
				{
					RenderedPictureBox.Image = result;
				}
			});

			try
			{
				if(InvokeRequired)
				{
					BeginInvoke(render);
				}
				else
				{
					render();
				}
			}
			catch(ObjectDisposedException)
			{
			}
		}

		private void Picture_Click(object sender, EventArgs e)
		{

		}

		private void ComboBoxObj_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void RenderedPictureBox_Click(object sender, EventArgs e)
		{

		}
	}
}
