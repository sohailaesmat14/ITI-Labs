namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            listBox1 = new ListBox();
            listBox2 = new ListBox();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            btnMoveRight = new Button();
            btnMoveLeft = new Button();
            btnBack = new Button();
            btnCopy = new Button();
            btnDelete = new Button();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(49, 73);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(302, 304);
            listBox1.TabIndex = 0;
            // 
            // listBox2
            // 
            listBox2.FormattingEnabled = true;
            listBox2.Location = new Point(459, 73);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(287, 304);
            listBox2.TabIndex = 1;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(132, 40);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(541, 40);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(125, 27);
            textBox2.TabIndex = 3;
            // 
            // btnMoveRight
            // 
            btnMoveRight.Location = new Point(357, 101);
            btnMoveRight.Name = "btnMoveRight";
            btnMoveRight.Size = new Size(94, 29);
            btnMoveRight.TabIndex = 4;
            btnMoveRight.Text = ">";
            btnMoveRight.UseVisualStyleBackColor = true;
            // 
            // btnMoveLeft
            // 
            btnMoveLeft.Location = new Point(357, 136);
            btnMoveLeft.Name = "btnMoveLeft";
            btnMoveLeft.Size = new Size(94, 29);
            btnMoveLeft.TabIndex = 5;
            btnMoveLeft.Text = "<";
            btnMoveLeft.UseVisualStyleBackColor = true;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(359, 241);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(94, 29);
            btnBack.TabIndex = 8;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            // 
            // btnCopy
            // 
            btnCopy.Location = new Point(357, 171);
            btnCopy.Name = "btnCopy";
            btnCopy.Size = new Size(94, 29);
            btnCopy.TabIndex = 9;
            btnCopy.Text = "Copy";
            btnCopy.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(359, 206);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 10;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnDelete);
            Controls.Add(btnCopy);
            Controls.Add(btnBack);
            Controls.Add(btnMoveLeft);
            Controls.Add(btnMoveRight);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(listBox2);
            Controls.Add(listBox1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBox1;
        private ListBox listBox2;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button btnMoveRight;
        private Button btnMoveLeft;
        private Button button3;
        private Button button4;
        private Button btnBack;
        private Button btnCopy;
        private Button btnDelete;
    }
}
