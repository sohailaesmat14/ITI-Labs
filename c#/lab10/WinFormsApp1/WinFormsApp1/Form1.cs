using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private ListBox activeListBox;
        private string path1 = "";
        private string path2 = "";

        public Form1()
        {
            InitializeComponent();
            LoadDrives(listBox1);
            LoadDrives(listBox2);
            activeListBox = listBox1;

            listBox1.Enter += ListBox_Enter;
            listBox2.Enter += ListBox_Enter;
            listBox1.DoubleClick += ListBox_DoubleClick;
            listBox2.DoubleClick += ListBox_DoubleClick;
            btnMoveRight.Click += BtnMoveRight_Click;
            btnMoveLeft.Click += BtnMoveLeft_Click;
            btnCopy.Click += BtnCopy_Click;
            btnDelete.Click += BtnDelete_Click;
            btnBack.Click += BtnBack_Click;
        }

        private void ListBox_Enter(object sender, EventArgs e)
        {
            activeListBox = (ListBox)sender;
        }

        private void LoadDrives(ListBox lst)
        {
            lst.Items.Clear();
            foreach (var drive in DriveInfo.GetDrives())
            {
                lst.Items.Add(drive.Name);
            }
            if (lst == listBox1) path1 = ""; else path2 = "";
            UpdateTextBox(lst);
        }

        private void LoadDirectory(ListBox lst, string path)
        {
            try
            {
                lst.Items.Clear();
                lst.Items.Add("..");
                lst.Items.Add(".");

                string[] dirs = Directory.GetDirectories(path);
                foreach (string dir in dirs)
                {
                    lst.Items.Add(Path.GetFileName(dir));
                }

                string[] files = Directory.GetFiles(path);
                foreach (string file in files)
                {
                    lst.Items.Add(Path.GetFileName(file));
                }

                if (lst == listBox1) path1 = path; else path2 = path;
                UpdateTextBox(lst);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateTextBox(ListBox lst)
        {
            if (lst == listBox1) textBox1.Text = path1;
            else textBox2.Text = path2;
        }

        private void ListBox_DoubleClick(object sender, EventArgs e)
        {
            ListBox lst = (ListBox)sender;
            if (lst.SelectedItem == null) return;

            string selected = lst.SelectedItem.ToString();
            string currentPath = (lst == listBox1) ? path1 : path2;

            if (currentPath == "")
            {
                LoadDirectory(lst, selected);
            }
            else
            {
                if (selected == "..")
                {
                    LoadDrives(lst);
                }
                else if (selected == ".")
                {
                    DirectoryInfo parent = Directory.GetParent(currentPath);
                    if (parent != null)
                        LoadDirectory(lst, parent.FullName);
                    else
                        LoadDrives(lst);
                }
                else
                {
                    string fullPath = Path.Combine(currentPath, selected);
                    if (Directory.Exists(fullPath))
                    {
                        LoadDirectory(lst, fullPath);
                    }
                    else if (File.Exists(fullPath))
                    {
                        MessageBox.Show("This is a file and cannot be opened.");
                    }
                }
            }
        }

        private void BtnMoveRight_Click(object sender, EventArgs e)
        {
            TransferItem(listBox1, listBox2, path1, path2, true);
        }

        private void BtnMoveLeft_Click(object sender, EventArgs e)
        {
            TransferItem(listBox2, listBox1, path2, path1, true);
        }

        private void BtnCopy_Click(object sender, EventArgs e)
        {
            ListBox source = activeListBox;
            ListBox dest = (source == listBox1) ? listBox2 : listBox1;
            string srcPath = (source == listBox1) ? path1 : path2;
            string destPath = (dest == listBox1) ? path1 : path2;

            TransferItem(source, dest, srcPath, destPath, false);
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (activeListBox.SelectedItem == null || activeListBox.SelectedItem.ToString() == "." || activeListBox.SelectedItem.ToString() == "..") return;

            string currentPath = (activeListBox == listBox1) ? path1 : path2;
            string selected = activeListBox.SelectedItem.ToString();
            string fullPath = Path.Combine(currentPath, selected);

            try
            {
                if (File.Exists(fullPath)) File.Delete(fullPath);
                else if (Directory.Exists(fullPath)) Directory.Delete(fullPath, true);

                LoadDirectory(activeListBox, currentPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            string currentPath = (activeListBox == listBox1) ? path1 : path2;
            if (currentPath == "") return;

            DirectoryInfo parent = Directory.GetParent(currentPath);
            if (parent != null)
                LoadDirectory(activeListBox, parent.FullName);
            else
                LoadDrives(activeListBox);
        }

        private void TransferItem(ListBox src, ListBox dest, string srcDir, string destDir, bool isMove)
        {
            if (src.SelectedItem == null || srcDir == "" || destDir == "") return;
            string item = src.SelectedItem.ToString();
            if (item == "." || item == "..") return;

            string sourcePath = Path.Combine(srcDir, item);
            string destPath = Path.Combine(destDir, item);

            try
            {
                if (File.Exists(sourcePath))
                {
                    if (isMove) File.Move(sourcePath, destPath);
                    else File.Copy(sourcePath, destPath);
                }
                else if (Directory.Exists(sourcePath))
                {
                    if (isMove) Directory.Move(sourcePath, destPath);
                    else CopyDirectory(sourcePath, destPath);
                }

                LoadDirectory(src, srcDir);
                LoadDirectory(dest, destDir);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CopyDirectory(string sourceDir, string destDir)
        {
            Directory.CreateDirectory(destDir);
            foreach (string file in Directory.GetFiles(sourceDir))
            {
                string destFile = Path.Combine(destDir, Path.GetFileName(file));
                File.Copy(file, destFile, true);
            }
            foreach (string subDir in Directory.GetDirectories(sourceDir))
            {
                string destSubDir = Path.Combine(destDir, Path.GetFileName(subDir));
                CopyDirectory(subDir, destSubDir);
            }
        }
    }
}