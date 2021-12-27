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

namespace text
{
    public partial class Form1 : Form
    {
        ///////////////////////////////////////////////////////////////////////////////////                         STATUS STRIP VE TIMER EKLENECEK !!!         
        public Form1()
        {
            InitializeComponent();
        }
        
        private System.Drawing.Printing.PrintDocument print = new System.Drawing.Printing.PrintDocument();

        bool degisim = false;

        DialogResult dialog;

       

        private void yazıTipiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog font = new FontDialog();
            font.ShowDialog();
            richTextBox1.Font = font.Font;
        }

        private void yazıRengiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog color = new ColorDialog();
            color.ShowDialog();
            richTextBox1.SelectionColor = color.Color;
        }

        private void yeniPencereCTRLSHIFTNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.richTextBox1.Text = "";
            frm.ShowDialog();
        }

        private void yeniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] args = System.Environment.GetCommandLineArgs();
            string filePath = args[0];
            for (int i = 0; i <= args.Length - 1; i++)
            {
                if (args[i].EndsWith(".exe") == false)
                {
                    richTextBox1.Text = System.IO.File.ReadAllText(args[i],
                    Encoding.Default);
                }
            }
        }
        private void Application_Startup(object sender, EventArgs e)
        {
            string[] args = System.Environment.GetCommandLineArgs();
            string filePath = args[0];
        }

        private void açToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Metin dosyaları (*.txt)|*.txt|Tüm dosyalar (*.*)|*.*";
            openFile.FilterIndex = 2;
            openFile.RestoreDirectory = true;
            openFile.CheckFileExists = false;

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(openFile.FileName);
                string text = sr.ReadToEnd();
                richTextBox1.Text = text;
            }
        }

        private void yardımıGörüntüleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.bing.com/search?q=windows+10’da+not+defteriyle+ilgili+yardım+alma&filters=guid:4466414");
        }

        private void geriAlCTRLZToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void ileriAlCTRLtoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

        private void kesCTRLXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void kopyalaCTRLCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void yapıştırCTRLVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void silDELToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectedText = "";
        }

        private void tümünüSeçCTRLAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void kaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.DefaultExt = "*txt";
            save.Filter = "Metin dosyaları (*.txt)|*.txt";
            if (save.ShowDialog() == DialogResult.OK && save.FileName.Length > 0)
            {
                richTextBox1.SaveFile(save.FileName, RichTextBoxStreamType.PlainText);
                DialogResult kaydet = MessageBox.Show("Dosya kaydedildi.", "Dosya adresi : " + save.FileName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (kaydet == DialogResult.OK || kaydet == DialogResult.Cancel)
                {
                    this.Close();
                }
            }
        }

        private void farklıKaydetCTRLSHIFTSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.DefaultExt = "*txt";
            save.Filter = "Metin dosyaları (*.txt)|*.txt|Tüm dosyalar (*.*)|*.*";
            if (save.ShowDialog() == DialogResult.OK && save.FileName.Length > 0)
            {
                richTextBox1.SaveFile(save.FileName, RichTextBoxStreamType.PlainText);
                DialogResult farkli_kaydet = MessageBox.Show("Dosya kaydedildi.", "Dosya adresi : " + save.FileName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (farkli_kaydet == DialogResult.OK || farkli_kaydet == DialogResult.Cancel)
                {
                    this.Close();
                }
            }
        }

        private void yazdırCTRLPToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PrintDialog pd = new PrintDialog();
            print.DocumentName = "Dosyayı Yazdır";
            pd.PrinterSettings = print.PrinterSettings;

            pd.Document = print;
            pd.ShowHelp = true;
            
            
            if (pd.ShowDialog() == DialogResult.OK)
            {
                print.PrinterSettings = pd.PrinterSettings;
                print.Print();
            }
        }



        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (degisim)
            {
                dialog = MessageBox.Show("Değişiklikleri kaydetmek ister misiniz ?", "Çıkış", MessageBoxButtons.OKCancel);

                if (dialog == DialogResult.OK)
                {
                    ////////////////////////////////////////////////////////////////////                Overwrite fonksiyonu
                }
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            degisim = true;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
