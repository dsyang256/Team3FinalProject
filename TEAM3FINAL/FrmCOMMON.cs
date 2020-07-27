using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TEAM3FINALVO;

namespace TEAM3FINAL
{
    public partial class FrmCOMMON : TEAM3FINAL.baseFormPopUP
    {
        ComboItemService service = new ComboItemService();
        public FrmCOMMON()
        {
            InitializeComponent();
        }

        private void FrmCOMMON_Load(object sender, EventArgs e)
        {
            DataGridViewColumnSet();
            DataGridViewBinding();
            ComboBinding();
        }

        private void DataGridViewColumnSet()
        {
            Util.InitSettingGridView(dvgcommon);
            Util.AddNewColumnToDataGridView(dvgcommon, "코드", "COMMON_CODE", true, 170);
            Util.AddNewColumnToDataGridView(dvgcommon, "이름", "COMMON_NAME", true, 100);
            Util.AddNewColumnToDataGridView(dvgcommon, "부모", "COMMON_PARENT", true, 80);
            Util.AddNewColumnToDataGridView(dvgcommon, "SEQ", "COMMON_SEQ", true, 35);

        }
        private void DataGridViewBinding()
        {
            dvgcommon.DataSource = service.GetCmCode();
        }
        private void ComboBinding()
        {
            ComboItemService service = new ComboItemService();
            List<ComboItemVO> Commonlist = service.GetITEMCmCode();


            //코드그룹1
            var list1 = (from item in Commonlist where item.COMMON_PARENT == null select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(cobGroup1, list1, "COMMON_CODE", "COMMON_NAME", "");

            //코드그룹2
            var list2 = (from item in Commonlist where item.COMMON_PARENT == null select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(cobGroup2, list2, "COMMON_CODE", "COMMON_NAME", "");

           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtcode1.Text.Length <1)
            {
                MessageBox.Show("중복체크할 코드를 입력해주세요");
                return;
            }
            if(service.CheckCode(txtcode1.Text))
            {
                MessageBox.Show("중복된 항목그룹입니다.");
            }
            else
            {
                MessageBox.Show("중복체크되었습니다.");
                txtcode1.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(txtcode1.Enabled == true)
            {
                MessageBox.Show("중복체크 먼저 해주세요");
                return;
            }
            if (service.CodeInsert(txtcode1.Text))
            {
                MessageBox.Show("정상적으로 등록 되었습니다.");
                Reset();
            }
            else
            {
                MessageBox.Show("실패하였습니다. 다시시도해주세요");
            }
        }

        private void Reset()
        {
            txtcode1.Text = "";
            cobGroup1.SelectedIndex = -1;
            cobGroup2.SelectedIndex = -1;
            txtcode2.Text = "";
            DataGridViewBinding();
            ComboBinding();

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Reset();
        }
    }
}
