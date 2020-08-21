using log4net.Core;
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
        string code;
        CommonService service = new CommonService();
        LoggingUtility _logging;
        public LoggingUtility Log
        {
            get { return _logging; }
        }
        
        public FrmCOMMON()
        {
            InitializeComponent();
            _logging = new LoggingUtility(this.Name, Level.Info, 30);
        }

        private void FrmCOMMON_Load(object sender, EventArgs e)
        {
            try
            {
                DataGridViewColumnSet();
                DataGridViewBinding();
                ComboBinding();
            }
            catch(Exception err)
            {
                this.Log.WriteError($"[[RECV {this.Name}]]:{err.Message}");
            }
        }

        private void DataGridViewColumnSet()
        {
            try
            {
                DataGridViewUtil.InitSettingGridView(dgvCOMMON);
                DataGridViewUtil.AddNewColumnToDataGridView(dgvCOMMON, "No", "idx", true, 30);
                DataGridViewUtil.AddNewColumnToDataGridView(dgvCOMMON, "코드", "COMMON_CODE", true, 170);
                DataGridViewUtil.AddNewColumnToDataGridView(dgvCOMMON, "이름", "COMMON_NAME", true, 170);
                DataGridViewUtil.AddNewColumnToDataGridView(dgvCOMMON, "부모", "COMMON_PARENT", true, 80);
                DataGridViewUtil.AddNewColumnToDataGridView(dgvCOMMON, "SEQ", "COMMON_SEQ", true, 29);
            }
            catch (Exception err)
            {
                this.Log.WriteError($"[[RECV {this.Name}]]:{err.Message}");
            }

        }
        private void DataGridViewBinding()
        {
            try
            {
                dgvCOMMON.DataSource = service.GetAllCmCode();
            }
            catch (Exception err)
            {
                this.Log.WriteError($"[[RECV {this.Name}]]:{err.Message}");
            }
        }
        private void ComboBinding()
        {
            try
            {
                CommonService service = new CommonService();
                List<ComboItemVO> Commonlist = service.GetITEMCmCode();


                //코드그룹1
                var list1 = (from item in Commonlist where item.COMMON_PARENT == null select item).ToList();
                CommonUtil.ComboBinding<ComboItemVO>(cboGroup1, list1, "COMMON_CODE", "COMMON_NAME", "");

                //코드그룹2
                var list2 = (from item in Commonlist where item.COMMON_PARENT == null select item).ToList();
                CommonUtil.ComboBinding<ComboItemVO>(cboGroup2, list2, "COMMON_CODE", "COMMON_NAME", "");
            }
            catch (Exception err)
            {
                this.Log.WriteError($"[[RECV {this.Name}]]:{err.Message}");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtcode1.Text.Length < 1)
                {
                    MessageBox.Show("중복체크할 코드를 입력해주세요");
                    return;
                }
                if (service.CheckCode(txtcode1.Text))
                {
                    MessageBox.Show("중복된 항목그룹입니다.");
                }
                else
                {
                    MessageBox.Show("중복체크되었습니다.");
                    txtcode1.Enabled = false;
                }
            }
            catch (Exception err)
            {
                this.Log.WriteError($"[[RECV {this.Name}]]:{err.Message}");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtcode1.Enabled == true)
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
            catch (Exception err)
            {
                this.Log.WriteError($"[[RECV {this.Name}]]:{err.Message}");
            }
        }

        private void Reset()
        {
            try
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
            catch (Exception err)
            {
                this.Log.WriteError($"[[RECV {this.Name}]]:{err.Message}");
            }

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                Reset();
            }
            catch (Exception err)
            {
                this.Log.WriteError($"[[RECV {this.Name}]]:{err.Message}");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception err)
            {
                this.Log.WriteError($"[[RECV {this.Name}]]:{err.Message}");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboGroup2.Text.Length < 1)
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
            catch (Exception err)
            {
                this.Log.WriteError($"[[RECV {this.Name}]]:{err.Message}");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboGroup1.Text.Length < 1)
                {
                    MessageBox.Show("삭제할 코드 대그룹을 선택해주세요");
                    return;
                }
                if (MessageBox.Show($"{cboGroup1.Text} 코드 그룹을 삭제 하시겠습니까?", "삭제확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
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
            catch (Exception err)
            {
                this.Log.WriteError($"[[RECV {this.Name}]]:{err.Message}");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception err)
            {
                this.Log.WriteError($"[[RECV {this.Name}]]:{err.Message}");
            }
        }


        private void dgvCOMMON_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;
                code = dgvCOMMON.Rows[e.RowIndex].Cells[1].Value.ToString();

                dgvCOMMON.Rows[e.RowIndex].Selected = true;
                dgvCOMMON.CurrentCell = dgvCOMMON.Rows[e.RowIndex].Cells[0];
                contextMenuStrip1.Show(dgvCOMMON, e.Location);
                contextMenuStrip1.Show(Cursor.Position);
            }
            catch (Exception err)
            {
                this.Log.WriteError($"[[RECV {this.Name}]]:{err.Message}");
            }


        }

        private void 삭제ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (service.CodeDelete1(code))
                {
                    MessageBox.Show("코드가 삭제되었습니다");
                    Reset();
                }
            }
            catch (Exception err)
            {
                this.Log.WriteError($"[[RECV {this.Name}]]:{err.Message}");
            }
        }
    }
}
