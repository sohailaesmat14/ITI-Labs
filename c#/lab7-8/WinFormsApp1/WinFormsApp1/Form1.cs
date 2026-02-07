using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private int[] years;
        private int[] revenues;
        private Color lineColor;
        private Point[] chartPoints;

        public Form1()
        {
            InitializeComponent();
            this.Text = "ABC Company Revenue";
            this.Size = new Size(900, 600);
            this.DoubleBuffered = true;
            this.Paint += new PaintEventHandler(Form1_Paint);
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
            this.MouseClick += new MouseEventHandler(Form1_MouseClick);

            years = new int[] { 1988, 1989, 1990, 1991, 1992, 1993, 1994, 1995, 1996, 1997 };
            revenues = new int[] { 150, 170, 180, 175, 200, 250, 210, 240, 280, 140 };
            lineColor = Color.Blue;
            chartPoints = new Point[10];
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            string title = "ABC Company";
            Font titleFont = new Font("Arial", 16, FontStyle.Bold);
            SizeF titleSize = g.MeasureString(title, titleFont);
            g.DrawString(title, titleFont, Brushes.Black, (this.ClientSize.Width - titleSize.Width) / 2, 20);

            string subtitle = "Annual Revenue";
            Font subFont = new Font("Arial", 12);
            SizeF subSize = g.MeasureString(subtitle, subFont);
            g.DrawString(subtitle, subFont, Brushes.Black, (this.ClientSize.Width - subSize.Width) / 2, 50);

            DrawChart(g);
            DrawTable(g);
        }

        private void DrawChart(Graphics g)
        {
            int chartX = 50;
            int chartY = 450;
            int chartWidth = 500;
            int chartHeight = 300;
            int barWidth = 30;
            int gap = 15;

            g.DrawLine(Pens.Black, chartX, chartY, chartX + chartWidth, chartY);
            g.DrawLine(Pens.Black, chartX, chartY, chartX, chartY - chartHeight);

            g.DrawString("Revenue", SystemFonts.DefaultFont, Brushes.Black, chartX, chartY - chartHeight - 20);
            g.DrawString("Years", SystemFonts.DefaultFont, Brushes.Black, chartX + chartWidth + 10, chartY);

            HatchBrush barBrush = new HatchBrush(HatchStyle.LightDownwardDiagonal, Color.Red, Color.White);
            Pen linePen = new Pen(lineColor, 3);

            for (int i = 0; i < years.Length; i++)
            {
                int xVal = chartX + 20 + i * (barWidth + gap);
                int barHeight = revenues[i];
                int yVal = chartY - barHeight;

                g.FillRectangle(barBrush, xVal, yVal, barWidth, barHeight);
                g.DrawRectangle(Pens.Black, xVal, yVal, barWidth, barHeight);

                chartPoints[i] = new Point(xVal + barWidth / 2, yVal);

                g.DrawString(years[i].ToString(), SystemFonts.DefaultFont, Brushes.Black, xVal, chartY + 5);
            }

            g.DrawLines(linePen, chartPoints);
        }

        private void DrawTable(Graphics g)
        {
            int tableX = 600;
            int tableY = 100;
            int rowHeight = 30;
            int colWidth = 80;

            g.DrawRectangle(Pens.Black, tableX, tableY, colWidth * 2, rowHeight * (years.Length + 1));

            g.DrawString("Year", SystemFonts.DefaultFont, Brushes.Black, tableX + 5, tableY + 8);
            g.DrawString("Revenue", SystemFonts.DefaultFont, Brushes.Black, tableX + colWidth + 5, tableY + 8);
            g.DrawLine(Pens.Black, tableX, tableY + rowHeight, tableX + colWidth * 2, tableY + rowHeight);
            g.DrawLine(Pens.Black, tableX + colWidth, tableY, tableX + colWidth, tableY + rowHeight * (years.Length + 1));

            for (int i = 0; i < years.Length; i++)
            {
                int currentY = tableY + (i + 1) * rowHeight;
                g.DrawString(years[i].ToString(), SystemFonts.DefaultFont, Brushes.Black, tableX + 5, currentY + 8);
                g.DrawString(revenues[i].ToString(), SystemFonts.DefaultFont, Brushes.Black, tableX + colWidth + 5, currentY + 8);
                g.DrawLine(Pens.Black, tableX, currentY + rowHeight, tableX + colWidth * 2, currentY + rowHeight);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.R)
                lineColor = Color.Red;
            else if (e.Control && e.KeyCode == Keys.G)
                lineColor = Color.Green;
            else if (e.Control && e.KeyCode == Keys.B)
                lineColor = Color.Blue;

            this.Invalidate();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                for (int i = 0; i < chartPoints.Length; i++)
                {
                    if (Math.Abs(e.X - chartPoints[i].X) < 15 && Math.Abs(e.Y - chartPoints[i].Y) < 15)
                    {
                        MessageBox.Show("Year: " + years[i] + "\nRevenue: " + revenues[i]);
                        return;
                    }
                }
            }
        }
    }
}
