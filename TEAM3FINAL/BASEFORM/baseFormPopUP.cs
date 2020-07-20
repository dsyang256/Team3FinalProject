using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TEAM3FINAL.BaseForm
{
    public partial class baseFormPopUP : TEAM3FINAL.ProjectBaseForm
    {
        public baseFormPopUP()
        {
            InitializeComponent();

            //메인 패널 위치 및 크기 지정
            panel1.Location = new Point(5, 5);
            panel1.Size = new Size(this.Width-10, 45);

            button1.Text = "버튼";


        }
    }
}
