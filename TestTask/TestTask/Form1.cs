using System;
using System.Threading.Tasks;
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
        public Bitmap picture, rendered_picture;
        private void RenderButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files (*.BMP)|*.BMP|All files (*.*)|*.*";

            if(ofd.ShowDialog() == DialogResult.OK)
            {
              //  IRender renderer = new CanvasRender();
                picture = new Bitmap (ofd.FileName);
                Picture.Image = new Bitmap(ofd.FileName);

                if(ComboBoxObj.SelectedItem != null)
                {
                    if(ComboBoxObj.SelectedItem.ToString() == "контраст")
                    {
                        ContrastAlgorithm contrast = new ContrastAlgorithm();
                        RenderedPictureBox.Image = contrast.MathPart(new Bitmap(ofd.FileName));
                    }
                    else if(ComboBoxObj.SelectedItem.ToString() == "градиент")
                    {
                        GradientAlgorithm gradient = new GradientAlgorithm();
                        gradient.grayscale = true;
                        RenderedPictureBox.Image = gradient.MathPart(new Bitmap(ofd.FileName));
                    }
                }
                else
                {
                    LabelObj.Text = "Что-то пошло не так";
                }
            }
        }
        private void Picture_Click(object sender, EventArgs e)
        {

        }

        private void ComboBoxObj_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
