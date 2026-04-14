using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Windows.Forms;

namespace CourseClient
{
    public partial class Form1 : Form
    {
        private readonly HttpClient _client;

        public Form1()
        {
            InitializeComponent();

            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://localhost:7165/api/");
        }

        private async void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                var courses = await _client.GetFromJsonAsync<List<Course>>("Courses");

                dataGridViewCourses.DataSource = courses;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Loading Courses: " + ex.Message);
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            var newCourse = new Course
            {
                Crs_name = txtName.Text,
                crs_desc = txtDesc.Text,
                Duration = int.Parse(txtDuration.Text) 
            };

            try
            {
                var response = await _client.PostAsJsonAsync("Courses", newCourse);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Course added successfully!");

                    txtName.Clear();
                    txtDesc.Clear();
                    txtDuration.Clear();

                    btnLoad_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Adding Course: " + ex.Message);
            }
        }
    }
}