using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TEAM3FINAL
{
    public partial class baseFormPopUP : ProjectBaseForm
    {
        public baseFormPopUP()
        {
            InitializeComponent();

            //메인 패널 위치 및 크기 지정
            panel1.Location = new Point(5, 5);
            panel1.Size = new Size(this.Width-10, 56);
        }
    }
}
