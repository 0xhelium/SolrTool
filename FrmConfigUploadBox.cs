using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SolrTool
{
    public partial class FrmConfigUploadBox : Form
    {
        public FrmConfigUploadBox()
        {
            InitializeComponent();
            BindEvents();
        }

        public string ConfigName{ get; private set; }
        public string ConfigFolder { get; private set; }


        private void BindEvents()
        {
            BtnCancel.Click += (s, e) => this.Close();
            BtnOk.Click += (s, e) =>
            {
                ConfigName = TextBoxConfName.Text;
                ConfigFolder = TextBoxFolder.Text;
                Close();
            };

            LinkLblSelectFolder.Click += (s, e) =>
            {
                var fbd = new FolderBrowserDialog();
                var dr = fbd.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    TextBoxFolder.Text = fbd.SelectedPath;
                }
            };
        }
    }
}
