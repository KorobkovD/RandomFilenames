using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace RandomFilenames
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            labelInfo.Text = "";
        }

        private void buttonOFD_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "Выбор папки с файлами";
            if (textBoxPath.Text.Length > 0)
                fbd.SelectedPath = textBoxPath.Text;
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                textBoxPath.Text = fbd.SelectedPath;
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (textBoxPath.Text.Length == 0)
            {
                MessageBox.Show("Не указана папка для переименования файлов");
            }
            else
            {
                labelInfo.Text = "";
                string alph = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                Random rndGenerator = new Random();
                try
                {
                string path = textBoxPath.Text;
                    FileInfo[] files = new DirectoryInfo(path).GetFiles();
                    foreach (FileInfo fi in files)
                    {
                        string fullName = fi.FullName;
                        string name = fi.Name;
                        string extension = fi.Extension;
                        char[] rndFilename = new char[6];
                        for (int i = 0; i < rndFilename.Length; i++)
                            rndFilename[i] = alph[rndGenerator.Next(alph.Length)];
                        string stringFilename = new string(rndFilename);
                        File.Move(fullName, Path.Combine(path, stringFilename + extension));
                    }
                    labelInfo.Text = "Готово!";
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }
            }
        }
    }
}
