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
    public partial class Form1 : Form
    {
        public Form1()
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
    }
}
