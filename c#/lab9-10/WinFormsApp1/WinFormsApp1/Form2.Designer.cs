namespace WinFormsApp1
{
    partial class Form2
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
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            rbArial = new RadioButton();
            rbTimes = new RadioButton();
            rbCourier = new RadioButton();
            tabPage2 = new TabPage();
            rb24 = new RadioButton();
            rb20 = new RadioButton();
            rb16 = new RadioButton();
            tabPage3 = new TabPage();
            btnColor = new Button();
            tabPage4 = new TabPage();
            txtNew = new TextBox();
            txtOld = new TextBox();
            colorDialog1 = new ColorDialog();
            btnOK = new Button();
            btnCancel = new Button();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
            tabPage4.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Location = new Point(218, 81);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(395, 215);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(rbArial);
            tabPage1.Controls.Add(rbTimes);
            tabPage1.Controls.Add(rbCourier);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(387, 182);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Font";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // rbArial
            // 
            rbArial.AutoSize = true;
            rbArial.Location = new Point(22, 49);
            rbArial.Name = "rbArial";
            rbArial.Size = new Size(61, 24);
            rbArial.TabIndex = 3;
            rbArial.TabStop = true;
            rbArial.Text = "Arial";
            rbArial.UseVisualStyleBackColor = true;
            // 
            // rbTimes
            // 
            rbTimes.AutoSize = true;
            rbTimes.Location = new Point(22, 19);
            rbTimes.Name = "rbTimes";
            rbTimes.Size = new Size(154, 24);
            rbTimes.TabIndex = 2;
            rbTimes.TabStop = true;
            rbTimes.Text = "Times New Roman";
            rbTimes.UseVisualStyleBackColor = true;
            // 
            // rbCourier
            // 
            rbCourier.AutoSize = true;
            rbCourier.Location = new Point(22, 79);
            rbCourier.Name = "rbCourier";
            rbCourier.Size = new Size(112, 24);
            rbCourier.TabIndex = 0;
            rbCourier.TabStop = true;
            rbCourier.Text = "Courier New";
            rbCourier.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(rb24);
            tabPage2.Controls.Add(rb20);
            tabPage2.Controls.Add(rb16);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(387, 182);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Size";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // rb24
            // 
            rb24.AutoSize = true;
            rb24.Location = new Point(30, 102);
            rb24.Name = "rb24";
            rb24.Size = new Size(46, 24);
            rb24.TabIndex = 2;
            rb24.TabStop = true;
            rb24.Text = "24";
            rb24.UseVisualStyleBackColor = true;
            // 
            // rb20
            // 
            rb20.AutoSize = true;
            rb20.Location = new Point(30, 72);
            rb20.Name = "rb20";
            rb20.Size = new Size(46, 24);
            rb20.TabIndex = 1;
            rb20.TabStop = true;
            rb20.Text = "20";
            rb20.UseVisualStyleBackColor = true;
            // 
            // rb16
            // 
            rb16.AutoSize = true;
            rb16.Location = new Point(30, 42);
            rb16.Name = "rb16";
            rb16.Size = new Size(46, 24);
            rb16.TabIndex = 0;
            rb16.TabStop = true;
            rb16.Text = "16";
            rb16.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(btnColor);
            tabPage3.Location = new Point(4, 29);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(387, 182);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Color";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnColor
            // 
            btnColor.Location = new Point(95, 76);
            btnColor.Name = "btnColor";
            btnColor.Size = new Size(181, 29);
            btnColor.TabIndex = 0;
            btnColor.Text = "Choose Color";
            btnColor.UseVisualStyleBackColor = true;
            btnColor.Click += btnColor_Click;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(txtNew);
            tabPage4.Controls.Add(txtOld);
            tabPage4.Location = new Point(4, 29);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(387, 182);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Text";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // txtNew
            // 
            txtNew.Location = new Point(107, 114);
            txtNew.Name = "txtNew";
            txtNew.Size = new Size(125, 27);
            txtNew.TabIndex = 1;
            // 
            // txtOld
            // 
            txtOld.Location = new Point(107, 53);
            txtOld.Name = "txtOld";
            txtOld.Size = new Size(125, 27);
            txtOld.TabIndex = 0;
            // 
            // btnOK
            // 
            btnOK.Location = new Point(419, 298);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(94, 29);
            btnOK.TabIndex = 1;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(519, 298);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCancel);
            Controls.Add(btnOK);
            Controls.Add(tabControl1);
            Name = "Form2";
            Text = "Form2";
            Load += FormatDialog_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            tabPage3.ResumeLayout(false);
            tabPage4.ResumeLayout(false);
            tabPage4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private RadioButton rbTimes;
        private RadioButton radioButton3;
        private RadioButton radioButton2;
        private RadioButton rbCourier;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private RadioButton radioButton6;
        private RadioButton rb20;
        private RadioButton rb16;
        private RadioButton rbArial;
        private RadioButton rb24;
        private ColorDialog colorDialog1;
        private Button btnColor;
        private TextBox txtNew;
        private TextBox txtOld;
        private Button btnOK;
        private Button btnCancel;
    }
}