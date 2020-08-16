using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TEAM3FINAL
{
    public partial class frmWaitAsyncForm : Form
    {
        public Action Worker { get; set; }

        public frmWaitAsyncForm(Action worker)
        {
            InitializeComponent();

            Worker = worker;
        }

        private void frmWaitAsyncForm_Load(object sender, EventArgs e)
        {
            Task.Factory.StartNew(Worker).ContinueWith(t => { this.Close(); }, TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
}
