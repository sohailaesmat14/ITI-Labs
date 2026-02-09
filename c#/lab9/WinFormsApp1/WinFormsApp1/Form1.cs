using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void companyNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 dlg = new Form2();

            dlg.CurrentText = lblCompany.Text;
            dlg.CurrentColor = lblCompany.ForeColor;
            dlg.CurrentFontName = lblCompany.Font.Name;
            dlg.CurrentFontSize = lblCompany.Font.Size;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                lblCompany.Text = dlg.NewText;
                lblCompany.ForeColor = dlg.NewColor;
                lblCompany.Font = new Font(dlg.NewFontName, dlg.NewFontSize);
            }
        }
    }
}