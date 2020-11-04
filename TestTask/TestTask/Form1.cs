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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LabelObj.Text = "";
            ComboBoxObj.Items.AddRange(new string[] { "контраст", "градиент" });
        }
        public Bitmap picture;
        private void RenderButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files (*.BMP)|*.BMP|All files (*.*)|*.*";

            if(ofd.ShowDialog() == DialogResult.OK)
            {
                picture = new Bitmap(ofd.FileName);

                Picture.Image = picture;

                if(ComboBoxObj.SelectedItem != null)
                {

                    Thread thread = new Thread(RenderThreadHandler) { Priority = ThreadPriority.AboveNormal };
                    thread.Name = "second thread";
                    thread.Start();
                    Thread.Sleep(500);
                    thread.Abort();
                }
                else
                {
                    LabelObj.Text = "Что-то пошло не так";
                }
            }
        }

        public void RenderThreadHandler()
        {
            Action action = () =>
            {
                if(ComboBoxObj.SelectedItem.ToString() == "контраст")
                {
                    ContrastAlgorithm contrast = new ContrastAlgorithm();
                    RenderedPictureBox.Image = contrast.MathPart(picture);
                }
                else if(ComboBoxObj.SelectedItem.ToString() == "градиент")
                {
                    GradientAlgorithm gradient = new GradientAlgorithm();
                    gradient.grayscale = true;
                    RenderedPictureBox.Image = gradient.MathPart(picture);
                }
            };
            if(InvokeRequired)
            {
                Invoke(action);
            }
            else
            {
                action();
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
