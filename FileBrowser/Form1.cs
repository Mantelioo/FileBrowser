using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace FileBrowser
{
    public partial class Form1 : Form
    {
        //Kintamasis disko informacijai sugoti. ji apsirasysime globaliai
        string CurrentDrive = string.Empty;
        string PathCopy = "";
        string PathPaste = "";
        string ItenName = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void BtnGetDrives_Click(object sender, EventArgs e)
        {
            //Pirmiausia ka reikia padadaryti tai gauti informacija apie kompiuteryje esancias duomenu laikmenas.

            LstDrives.Items.Clear();
            string[] Drives = Environment.GetLogicalDrives();

            foreach (var item in Drives)
            {
                LstDrives.Items.Add(item);
            }
        }

        private void LstDrives_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Sioje funkcijoje mes pasirinksime norima diska ant jo paspaude
            CurrentDrive = LstDrives.SelectedItem.ToString();
            DriveInfo Drive = new DriveInfo(CurrentDrive);
            if (Drive.IsReady)
            {
                 LblDriveStatus.Text = ("Free: " + (Drive.AvailableFreeSpace / 1024f / 1024 / 1024).ToString("0.00") + "Gb");
            }
            //kadangi informacija rodo baitais, tai mes ja turime dar konvertuoti i gigabaitus

        }

        private void LstDrives_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //sioje vietoje mes isgausime iar surasysime failu pavadinimus kurie yra direktorijoje i list boxa.

            //Scan selected drive
            LstFolderAndFiles.Items.Clear();
            DirectoryInfo Dir = new DirectoryInfo(CurrentDrive);
            LblPath.Text = CurrentDrive;

            //Isgauname direktorijas ir surasome jas
            foreach (var item in Dir.GetDirectories())
            {
                if (!item.Attributes.HasFlag(FileAttributes.Hidden))
                {
                    LstFolderAndFiles.Items.Add(item.Name);
                }
            }

            //Isgauname visus failus ir juos surasome i listboxa
            foreach (var item in Dir.GetFiles())
            {
                if (!item.Attributes.HasFlag(FileAttributes.Hidden))
                {
                    LstFolderAndFiles.Items.Add(item.Name);
                }
            }

        }

        private void LstFolderAndFiles_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //funkcija katalogo informacijai gauti. sudes visus failus ir aplankalus esancius pasrinktoje direktorijoje
        void ScanFolder(string path)
        {

            LstFolderAndFiles.Items.Clear();
            DirectoryInfo Dir = new DirectoryInfo(LblPath.Text);

            //Check if file selected
            foreach (var item in Dir.GetDirectories())
            {
                if (!item.Attributes.HasFlag(FileAttributes.Hidden))
                {
                    LstFolderAndFiles.Items.Add(item.Name);
                }
            }

            //Get files
            foreach (var item in Dir.GetFiles())
            {
                if (!item.Attributes.HasFlag(FileAttributes.Hidden))
                {
                    LstFolderAndFiles.Items.Add(item.Name);
                }
            }

        }

        private void LstFolderAndFiles_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            try
            {
                var temp = new DirectoryInfo(LblPath.Text + @"\" + LstFolderAndFiles.SelectedItem.ToString());

                //bandant atidaryti faila mes gauname klaida. Failas juk NERA KELIAS IKI KAZKOKIO OBJEKTO
                //patikriname ar vartotojas tikrai pasirinko direktorija
                if (!temp.Attributes.HasFlag(FileAttributes.Directory))
                {
                    return;
                }

                LblPath.Text += LstFolderAndFiles.SelectedItem.ToString() + @"\";
                //iskvieciam funkcija failams atvaizduoti
                ScanFolder(LblPath.Text);
            }

            catch (Exception)
            {


            }

        }

        private void LstFolderAndFiles_KeyDown(object sender, KeyEventArgs e)
        {

            //jeigu paspaudziama backspace tai griztame atgal. pirmiausia istriname simboli \
            //tuomet istriname viska iki pries tai buvusio simboli \
            if (e.KeyCode == Keys.Back)
            {

                //kad nemestu klaidos jeigu spamintume backspace
                if (Environment.GetLogicalDrives().Contains(LblPath.Text) || LblPath.Text == "NA")
                {
                    return;
                }
                else
                {
                    LblPath.Text = LblPath.Text.Remove(LblPath.Text.LastIndexOf(@"\"));
                    LblPath.Text = LblPath.Text.Remove(LblPath.Text.LastIndexOf(@"\") + 1);
                    ScanFolder(LblPath.Text);
                }

            }

            //COPY PASTE FUNKCIJA PRIMITYVI. Jei liks laiko, Uzduotis

            if (e.Control && e.KeyCode == Keys.C)
            {
                if (LstFolderAndFiles.SelectedItem != null)
                {
                    ItenName = LstFolderAndFiles.SelectedItem.ToString();
                    PathCopy = LblPath.Text + ItenName;
                    MessageBox.Show(PathCopy);
                }

            }
            if (e.Control && e.KeyCode == Keys.V)
            {
                PathPaste = LblPath.Text + ItenName;
                MessageBox.Show(PathPaste);
                if (PathCopy != "")
                {
                    if (!File.Exists(PathPaste) && !(File.GetAttributes(PathCopy) == FileAttributes.Directory))
                    {
                        File.Copy(PathCopy, PathPaste);

                    }
                    else
                    {
                        MessageBox.Show("FIle already exists");
                    }
                }
                PathCopy = "";
                PathPaste = "";
                ScanFolder(LblPath.Text);
            }

            //Istrinimo funkcija
            if (e.KeyCode == Keys.Delete)
            {
                DialogResult rez = MessageBox.Show("Ar tikrai norite istrinti faila", "ISTRINTI?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (rez == DialogResult.Yes)
                {
                    File.Delete(LblPath.Text + LstFolderAndFiles.SelectedItem);
                }
                ScanFolder(LblPath.Text);
            }

            //OPEN PROGRAM
            if (e.KeyCode == Keys.Enter)
            {
                if (!(File.GetAttributes(LblPath.Text + LstFolderAndFiles.SelectedItem.ToString()) == FileAttributes.Directory))
                {
                    Process.Start(LblPath.Text + LstFolderAndFiles.SelectedItem.ToString());

                }
            }

        }

        private void LstFolderAndFiles_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void LstFolderAndFiles_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
