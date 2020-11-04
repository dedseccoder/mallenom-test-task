namespace TestTask
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.RenderButton = new System.Windows.Forms.Button();
            this.Picture = new System.Windows.Forms.PictureBox();
            this.ComboBoxObj = new System.Windows.Forms.ComboBox();
            this.LabelObj = new System.Windows.Forms.Label();
            this.RenderedPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RenderedPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // RenderButton
            // 
            this.RenderButton.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RenderButton.Location = new System.Drawing.Point(527, 342);
            this.RenderButton.Name = "RenderButton";
            this.RenderButton.Size = new System.Drawing.Size(206, 39);
            this.RenderButton.TabIndex = 0;
            this.RenderButton.Text = "Открыть изображение";
            this.RenderButton.UseVisualStyleBackColor = true;
            this.RenderButton.Click += new System.EventHandler(this.RenderButton_Click);
            // 
            // Picture
            // 
            this.Picture.InitialImage = null;
            this.Picture.Location = new System.Drawing.Point(13, 53);
            this.Picture.Name = "Picture";
            this.Picture.Size = new System.Drawing.Size(233, 275);
            this.Picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Picture.TabIndex = 1;
            this.Picture.TabStop = false;
            this.Picture.Click += new System.EventHandler(this.Picture_Click);
            // 
            // ComboBoxObj
            // 
            this.ComboBoxObj.FormattingEnabled = true;
            this.ComboBoxObj.Location = new System.Drawing.Point(569, 53);
            this.ComboBoxObj.Name = "ComboBoxObj";
            this.ComboBoxObj.Size = new System.Drawing.Size(121, 21);
            this.ComboBoxObj.TabIndex = 2;
            this.ComboBoxObj.SelectedIndexChanged += new System.EventHandler(this.ComboBoxObj_SelectedIndexChanged);
            // 
            // LabelObj
            // 
            this.LabelObj.AutoSize = true;
            this.LabelObj.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelObj.ForeColor = System.Drawing.Color.Red;
            this.LabelObj.Location = new System.Drawing.Point(566, 108);
            this.LabelObj.Name = "LabelObj";
            this.LabelObj.Size = new System.Drawing.Size(137, 17);
            this.LabelObj.TabIndex = 3;
            this.LabelObj.Text = "Что-то пошло не так";
            // 
            // RenderedPictureBox
            // 
            this.RenderedPictureBox.Location = new System.Drawing.Point(265, 53);
            this.RenderedPictureBox.Name = "RenderedPictureBox";
            this.RenderedPictureBox.Size = new System.Drawing.Size(233, 275);
            this.RenderedPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.RenderedPictureBox.TabIndex = 4;
            this.RenderedPictureBox.TabStop = false;
            this.RenderedPictureBox.Click += new System.EventHandler(this.RenderedPictureBox_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.RenderedPictureBox);
            this.Controls.Add(this.LabelObj);
            this.Controls.Add(this.ComboBoxObj);
            this.Controls.Add(this.Picture);
            this.Controls.Add(this.RenderButton);
            this.Name = "Form1";
            this.Text = "Test task";
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RenderedPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button RenderButton;
        private System.Windows.Forms.Label LabelObj;
        public System.Windows.Forms.PictureBox Picture;
        public System.Windows.Forms.PictureBox RenderedPictureBox;
        public System.Windows.Forms.ComboBox ComboBoxObj;
    }
}

