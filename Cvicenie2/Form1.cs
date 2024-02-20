using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cvicenie2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            otvoritToolStripMenuItem.PerformClick();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            zavrietToolStripMenuItem.PerformClick();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            ulozitToolStripMenuItem.PerformClick();
        }

        private void otvoritToolStripMenuItem_Click(object sender, EventArgs e)//open text file from PC to textbox1
        {
            DialogResult dialogResult;
            dialogResult = MessageBox.Show("Chcete zatvorit program?", "Aplikacia", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Error);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
            else if (dialogResult == DialogResult.No)
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.InitialDirectory = "c:\\";
                    openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string fileContent = System.IO.File.ReadAllText(openFileDialog.FileName);
                        textBox1.Text = fileContent;
                    }
                }
            }
            else
            {

            }
        }

        private void ulozitToolStripMenuItem_Click(object sender, EventArgs e)//save file text file from textbox1 to PC
        {
            DialogResult dialogResult;
            dialogResult = MessageBox.Show("Chcete zatvorit program?", "System", MessageBoxButtons.YesNoCancel,MessageBoxIcon.Exclamation);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
            else if(dialogResult == DialogResult.No)
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Text Files (*.txt)|*.txt";
                    saveFileDialog.DefaultExt = "txt";
                    saveFileDialog.AddExtension = true;

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        System.IO.File.WriteAllText(saveFileDialog.FileName, textBox1.Text);
                        MessageBox.Show("File saved successfully at " + saveFileDialog.FileName, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {

            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)//font tool strip dialog
        {
            FontDialog fontDialog = new FontDialog();
            fontDialog.Font = textBox1.Font;
            if(fontDialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Font = fontDialog.Font;
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)//color background tool strip dialog
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.Color = textBox1.BackColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.BackColor = colorDialog.Color;
            }
        }

        private void toolStripButton6_Click(object sender, EventArgs e)//color text tool strip dialog
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.Color = textBox1.BackColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.ForeColor = colorDialog.Color;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)//factorial calculation from textbox2 to label1
        {
            double vstup, faktorial;
            try
            {
                if (textBox2.Text != "")
                {
                    vstup = Convert.ToDouble(textBox2.Text);
                    faktorial = vstup;
                    while(vstup > 1)
                    {
                        faktorial *= --vstup;
                    }
                    label1.Text = faktorial.ToString();
                }
            }
            catch
            {
                MessageBox.Show("Zadal si kokotinu");       
            }
        }
    }
}
