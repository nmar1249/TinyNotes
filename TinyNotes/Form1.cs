/*****************************
 * Programmer:      Nick Marine
 * Program:         Tiny Notes
 * Version:         0.2
 * Date:            1/14/2019
 * 
 * 0.2 Changes:
 * - Added the ability to change the foreground and background colors
 * - Added the ability to change the notepad font.
 * - Added an About window which gives a little bit of background into the program
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

        //allows user to change the color of the foreground text and
        //background
        private void bgColor_Click(object sender, EventArgs e)
        {
            color(false);
        }

        private void fgColor_Click(object sender, EventArgs e)
        {
            color(true);
        }

        //sets color for variable specified by the boolean
        //true = foreground : false = background
        private void color(bool foreground)
        {
            ColorDialog cd = new ColorDialog();
            cd.AllowFullOpen = true;               //allow custom colors
            cd.ShowHelp = true;

            if(foreground == true)
            {
                cd.Color = richTextBox1.ForeColor;

                if (cd.ShowDialog() == DialogResult.OK)
                    richTextBox1.ForeColor = cd.Color;
            }
            else
            {
                cd.Color = richTextBox1.BackColor;

                if(cd.ShowDialog() == DialogResult.OK)
                    richTextBox1.BackColor = cd.Color;
            }
            
        }

        private void fontMenu_Click(object sender, EventArgs e)
        {
            fontDialog.ShowColor = false;           //color is handled by a diff menu

            fontDialog.Font = richTextBox1.Font;

            if (fontDialog.ShowDialog() != DialogResult.Cancel)
                richTextBox1.Font = fontDialog.Font;
        }

        private void aboutWindow_Click(object sender, EventArgs e)
        {
            about ab = new TinyNotes.about();
            ab.Show();
        }
    }
}
