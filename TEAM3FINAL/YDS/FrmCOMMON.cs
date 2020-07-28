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
            Util.InitSettingGridView(dgvCOMMON);
            Util.AddNewColumnToDataGridView(dgvCOMMON, "No", "idx", true, 30);
            Util.AddNewColumnToDataGridView(dgvCOMMON, "코드", "COMMON_CODE", true, 170);
            Util.AddNewColumnToDataGridView(dgvCOMMON, "이름", "COMMON_NAME", true, 170);
            Util.AddNewColumnToDataGridView(dgvCOMMON, "부모", "COMMON_PARENT", true, 80);
            Util.AddNewColumnToDataGridView(dgvCOMMON, "SEQ", "COMMON_SEQ", true, 29);

        }
        private void DataGridViewBinding()
        {
            dgvCOMMON.DataSource = service.GetAllCmCode();
        }
        private void ComboBinding()
        {
            ComboItemService service = new ComboItemService();
            List<ComboItemVO> Commonlist = service.GetITEMCmCode();


            //코드그룹1
            var list1 = (from item in Commonlist where item.COMMON_PARENT == null select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(cboGroup1, list1, "COMMON_CODE", "COMMON_NAME", "");

            //코드그룹2
            var list2 = (from item in Commonlist where item.COMMON_PARENT == null select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(cboGroup2, list2, "COMMON_CODE", "COMMON_NAME", "");

           

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
            cboGroup1.SelectedIndex = -1;
            cboGroup2.SelectedIndex = -1;
            txtcode2.Text = "";
            DataGridViewBinding();
            ComboBinding();
            txtcode1.Enabled = true;
            txtcode2.Enabled = true;
            SEQ.Value = 1;

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (cboGroup2.Text.Length < 1)
            {
                MessageBox.Show("코드 대그룹을 선택해주세요");
                return;
            }
            if (txtcode2.Text.Length < 1)
            {
                MessageBox.Show("중복체크할 코드를 입력해주세요");
                return;
            }
            if (service.CheckCodeName(txtcode2.Text))
            {
                MessageBox.Show("중복된 이름입니다.");
            }
            else
            {
                MessageBox.Show("중복체크되었습니다.");
                txtcode2.Enabled = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(cboGroup2.Text.Length <1)
            {
                MessageBox.Show("코드 대그룹을 선택해주세요");
                return;
            }
            if (txtcode2.Enabled == true)
            {
                MessageBox.Show("중복체크 먼저 해주세요");
                return;
            }
            if (service.CodeNameInsert(cboGroup2.SelectedValue.ToString(), txtcode2.Text, Convert.ToInt32(SEQ.Value)))
            {
                MessageBox.Show("정상적으로 등록 되었습니다.");
                Reset();
            }
            else
            {
                MessageBox.Show("실패하였습니다. 다시시도해주세요");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (cboGroup1.Text.Length < 1)
            {
                MessageBox.Show("삭제할 코드 대그룹을 선택해주세요");
                return;
            }
            if(MessageBox.Show($"{cboGroup1.Text} 코드 그룹을 삭제 하시겠습니까?","삭제확인",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (service.CodeDelete(cboGroup1.Text))
                {
                    MessageBox.Show("성공적으로 삭제되었습니다.");
                    Reset();
                }
                else
                {
                    MessageBox.Show("삭제에 실패 하였습니다 다시 시도해주세요.");
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
