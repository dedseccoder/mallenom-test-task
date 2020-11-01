using System;
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
        private bool can_see = false;
        private void RenderButton_Click(object sender, EventArgs e)
        {
            Picture.Visible = can_see;
            can_see = !can_see;
        }

        private void Picture_Click(object sender, EventArgs e)
        {

        }
    }
}
