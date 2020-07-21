using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TEAM3FINAL
{
    public partial class FrmItem : TEAM3FINAL.baseForm2
    {
        CheckBox headerChk;
        public FrmItem()
        {
            InitializeComponent();
        }

        private void FrmItem_Load(object sender, EventArgs e)
        {
            DataGridViewColumnSet();

        }
        private void DataGridViewColumnSet()
        {
            //데이터그리드뷰 컬럼 + 버튼 + 이벤트 만들기
            Util.InitSettingGridView(dgvitem);
            Util.AddNewColumnToDataGridView(dgvitem, "no", "CLIENT_CODE", true, 30);
            Util.DataGridViewCheckBoxSet(dgvitem,"all");
            Util.AddNewColumnToDataGridView(dgvitem, "회사명", "CLIENT_NAME", true, 200);
            Util.AddNewColumnToDataGridView(dgvitem, "전화번호", "CLIENT_PHN_NBR", true, 200);
            Util.AddNewColumnToDataGridView(dgvitem, "우편번호", "CLIENT_PSTL_CODE", true, 200);
            Util.AddNewColumnToDataGridView(dgvitem, "주소", "CLIENT_ADR1", true, 200);
            Util.AddNewColumnToDataGridView(dgvitem, "상세주소", "CLIENT_ADR2", true, 200);
            Util.AddNewColumnToDataGridView(dgvitem, "홈페이지", "CLIENT_URL", true, 200);
            Util.AddNewColumnToDataGridView(dgvitem, "비고", "", true, 550);
            DataGridViewCheckBoxAllCheck();

        }

        private void DataGridViewCheckBoxAllCheck()
        {
            headerChk = new CheckBox();
            Point headerCell = dgvitem.GetCellDisplayRectangle(1, -1, true).Location;
            headerChk.Location = new Point(headerCell.X + 8, headerCell.Y + 15);
            headerChk.Size = new Size(18, 18);
            headerChk.BackColor = Color.FromArgb(52, 52, 52);
            headerChk.Click += HeaderChk_Clicked;
            dgvitem.Controls.Add(headerChk);
        }

        private void HeaderChk_Clicked(object sender, EventArgs e)
        {
            dgvitem.EndEdit();

            //데이터그리드뷰의 전체 행의 체크를 체크 or 언체크
            foreach (DataGridViewRow row in dgvitem.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells["all"];
                chk.Value = headerChk.Checked;
            }
        }
    }
}
