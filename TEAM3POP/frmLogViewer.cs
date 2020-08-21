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

namespace TEAM3POP
{
    public partial class frmLogViewer : Form
    {
        string editingFileName = string.Empty;
        bool dirty = false;
        string notDirtyCaption = "{0} - Log Viewer";
        string dirtyCaption = "*{0} - Log Viewer";

        public string OpenFileName
        { 
            get { return editingFileName; }
            set { editingFileName = value; }
        }

        public frmLogViewer()
        {
            InitializeComponent();
        }

        private void frmLogViewer_Load(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(editingFileName))
                {
                    if (File.Exists(editingFileName))
                    {
                        textBox1.TextChanged -= TextBox1_TextChanged;

                        StreamReader sr = new StreamReader(editingFileName, Encoding.Default);
                        textBox1.Text = sr.ReadToEnd();
                        sr.Close();

                        dirty = false;
                        UpdateFormText();
                    }
                }
            }
            catch(Exception err)
            {

            }
            finally
            {
                textBox1.TextChanged += TextBox1_TextChanged;
                textBox1.Select(0, 0);
            }
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {            
            if (!dirty)
            {
                dirty = true;
                UpdateFormText();
            }
        }

        private void UpdateFormText()
        {
            string filename;

            if (editingFileName.Length > 1)
                filename = editingFileName.Substring(editingFileName.LastIndexOf("\\") + 1);
            else
                filename = "제목없음";

            if (dirty)
                this.Text = string.Format(dirtyCaption, filename);
            else
                this.Text = string.Format(notDirtyCaption, filename);

        }
    }
}
