using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TEAM3FINAL
{
    public partial class MenuPanel : UserControl
    {

        public string TitleName
        {
            get { return lblTitle.Text; }
            set { lblTitle.Text = value; }
        }
        public Font TitleFont
        {
            get { return this.lblTitle.Font; }
            set { this.lblTitle.Font = value; }
        }

        public MenuPanel()
        {
            InitializeComponent();
        }
    }
}
