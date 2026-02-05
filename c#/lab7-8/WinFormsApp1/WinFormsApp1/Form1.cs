using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private Label lblCompanyName;
        private Label lblReportTitle;
        private DataGridView dgvData;
        private Chart chartRevenue;
        private int[] years;
        private int[] revenues;

        public Form1()
        {
            InitializeComponent();
            SetupForm();
            InitializeData();
            CreateControls();
            SetupChart();
            PopulateGrid();
        }

        private void SetupForm()
        {
            this.Text = "ABC Company Revenue";
            this.Size = new Size(900, 600);
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
        }

        private void InitializeData()
        {
            years = new int[10];
            years[0] = 1988;
            years[1] = 1989;
            years[2] = 1990;
            years[3] = 1991;
            years[4] = 1992;
            years[5] = 1993;
            years[6] = 1994;
            years[7] = 1995;
            years[8] = 1996;
            years[9] = 1997;

            revenues = new int[10];
            revenues[0] = 150;
            revenues[1] = 170;
            revenues[2] = 180;
            revenues[3] = 175;
            revenues[4] = 200;
            revenues[5] = 250;
            revenues[6] = 210;
            revenues[7] = 240;
            revenues[8] = 280;
            revenues[9] = 140;
        }

        private void CreateControls()
        {
            lblCompanyName = new Label();
            lblCompanyName.Text = "ABC Company";
            lblCompanyName.Font = new Font("Arial", 16, FontStyle.Bold);
            lblCompanyName.AutoSize = true;
            lblCompanyName.Location = new Point(350, 20);
            this.Controls.Add(lblCompanyName);

            lblReportTitle = new Label();
            lblReportTitle.Text = "Annual Revenue";
            lblReportTitle.Font = new Font("Arial", 12);
            lblReportTitle.AutoSize = true;
            lblReportTitle.Location = new Point(360, 50);
            this.Controls.Add(lblReportTitle);

            dgvData = new DataGridView();
            dgvData.Location = new Point(550, 100);
            dgvData.Size = new Size(300, 400);
            dgvData.ColumnCount = 2;
            dgvData.Columns[0].Name = "Year";
            dgvData.Columns[1].Name = "Revenue";
            this.Controls.Add(dgvData);

            chartRevenue = new Chart();
            chartRevenue.Location = new Point(20, 100);
            chartRevenue.Size = new Size(500, 400);
            chartRevenue.MouseClick += new MouseEventHandler(chartRevenue_MouseClick);
            this.Controls.Add(chartRevenue);
        }

        private void SetupChart()
        {
            ChartArea area;
            area = new ChartArea();
            area.AxisX.Title = "Years";
            area.AxisY.Title = "Revenue";
            chartRevenue.ChartAreas.Add(area);

            Series barSeries;
            barSeries = new Series();
            barSeries.Name = "BarSeries";
            barSeries.ChartType = SeriesChartType.Column;
            barSeries.Color = Color.Red;
            barSeries.BackHatchStyle = ChartHatchStyle.LightDownwardDiagonal;
            chartRevenue.Series.Add(barSeries);

            Series lineSeries;
            lineSeries = new Series();
            lineSeries.Name = "LineSeries";
            lineSeries.ChartType = SeriesChartType.Line;
            lineSeries.Color = Color.Blue;
            lineSeries.BorderWidth = 3;
            lineSeries.BorderDashStyle = ChartDashStyle.Solid;
            chartRevenue.Series.Add(lineSeries);

            for (int i = 0; i < years.Length; i++)
            {
                barSeries.Points.AddXY(years[i], revenues[i]);
                lineSeries.Points.AddXY(years[i], revenues[i]);
            }
        }

        private void PopulateGrid()
        {
            for (int i = 0; i < years.Length; i++)
            {
                dgvData.Rows.Add(years[i], revenues[i]);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Series lineSeries;
            lineSeries = chartRevenue.Series["LineSeries"];

            if (e.Control && e.KeyCode == Keys.R)
            {
                lineSeries.Color = Color.Red;
            }
            else if (e.Control && e.KeyCode == Keys.G)
            {
                lineSeries.Color = Color.Green;
            }
            else if (e.Control && e.KeyCode == Keys.B)
            {
                lineSeries.Color = Color.Blue;
            }
        }

        private void chartRevenue_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                HitTestResult result;
                result = chartRevenue.HitTest(e.X, e.Y);

                if (result.ChartElementType == ChartElementType.DataPoint)
                {
                    double xValue;
                    xValue = result.Series.Points[result.PointIndex].XValue;

                    double yValue;
                    yValue = result.Series.Points[result.PointIndex].YValues[0];

                    MessageBox.Show("Revenue: " + yValue + "\nYear: " + xValue);
                }
            }
        }
    }
}