/*****************************
 * Programmer:      Nick Marine
 * Program:         Tiny Notes
 * Version:         0.1
 * Date:            1/14/2019
 * 
 * Description:
 * Another wheel in my series of reinventions known as the Tiny Utility Suite. This time
 * I decided to create a small notepad that could possibly support text formatting like a word
 * processor. 
 * 
 **********************/


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TinyNotes
{
    public partial class FormWindow : Form
    {
        public FormWindow()
        {
            InitializeComponent();
        }

        private void menuQuit_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Do you want to exit the program?", "Quit", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void menuCut_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void menuUndo_Click(object sender, EventArgs e)
        {
            if (richTextBox1.CanUndo == true)
            {
                richTextBox1.Undo();
                richTextBox1.ClearUndo();
            }
        }

        private void menuCopy_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void menuPaste_Click(object sender, EventArgs e)
        {
            if(Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                richTextBox1.Paste();
                Clipboard.Clear();
            }
        }

        private void menuOpen_Click(object sender, EventArgs e)
        {
            string file = "";

            openDialog.Title = "Select a File";
            openDialog.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openDialog.FileName = "";
            openDialog.Filter = "TXT Files|*.txt|Word Documents|*.doc";

            openDialog.ShowDialog();

            file = openDialog.FileName;
            richTextBox1.LoadFile(file, RichTextBoxStreamType.PlainText);
            
        }

        private void menuSave_Click(object sender, EventArgs e)
        {
            string file = "";

            saveDialog.InitialDirectory = "C:";
            saveDialog.Title = "Saving Text File";
            saveDialog.FileName = "";

            saveDialog.Filter = "Text File|*.txt|All Files|*.*";

            if(saveDialog.ShowDialog() != DialogResult.Cancel)
            {
                file = saveDialog.FileName;
                richTextBox1.SaveFile(file, RichTextBoxStreamType.PlainText);
            }
        }

        //resize the window based on the main window size
        //always maintains the same ratio
        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            richTextBox1.Height = Height - 78;
            richTextBox1.Width = Width - 40;
        }
    }
}
