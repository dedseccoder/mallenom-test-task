using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace TestTask
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void RenderButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "Image Files (*.BMP;*.PNG)|*.BMP;*.PNG|All files (*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Picture.Image = new Bitmap(ofd.FileName);
                //do some render
            }
        }

        private void Picture_Click(object sender, EventArgs e)
        {

        }
    }
}
