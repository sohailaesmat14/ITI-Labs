using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form2 : Form
    {
        public string NewText;
        public Color NewColor;
        public string NewFontName;
        public float NewFontSize;
        public string CurrentText;
        public Color CurrentColor;
        public string CurrentFontName;
        public float CurrentFontSize;

        public Form2()
        {
            InitializeComponent();
        }

        private void FormatDialog_Load(object sender, EventArgs e)
        {
            txtOld.Text = CurrentText;
            txtOld.Enabled = false;

            NewColor = CurrentColor;

            if (CurrentFontName == "Times New Roman") rbTimes.Checked = true;
            else if (CurrentFontName == "Arial") rbArial.Checked = true;
            else if (CurrentFontName == "Courier New") rbCourier.Checked = true;

            if (CurrentFontSize == 16) rb16.Checked = true;
            else if (CurrentFontSize == 20) rb20.Checked = true;
            else if (CurrentFontSize == 24) rb24.Checked = true;
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                NewColor = colorDialog1.Color;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNew.Text))
                NewText = txtNew.Text;
            else
                NewText = CurrentText;

            if (rbTimes.Checked) NewFontName = "Times New Roman";
            else if (rbArial.Checked) NewFontName = "Arial";
            else if (rbCourier.Checked) NewFontName = "Courier New";

            if (rb16.Checked) NewFontSize = 16;
            else if (rb20.Checked) NewFontSize = 20;
            else if (rb24.Checked) NewFontSize = 24;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}