﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TEAM3FINAL.Services;
using TEAM3FINALVO;
using System.Linq;
using Message = TEAM3FINALVO.Message;
using log4net.Core;

namespace TEAM3FINAL
{
    public partial class FrmWorkRecord : TEAM3FINAL.baseForm, CommonBtn
    {
        CheckBox headerChk;
        CheckBox headerChk2;

        LoggingUtility _logging;
        public LoggingUtility Log
        {
            get { return _logging; }
        }

        public FrmWorkRecord()
        {
            InitializeComponent();
            _logging = new LoggingUtility(this.Name, Level.Info, 30);
        }

        #region 체크박스 포함한 그리드뷰 컬럼 생성

        private void DataGridViewColumnSet()
        {
            //데이터그리드뷰 초기설정
            DataGridViewUtil.InitSettingGridView(dgvWorkRecordList);
            //데이터그리드뷰 체크박스 컬럼 추가
            DataGridViewUtil.DataGridViewCheckBoxSet(dgvWorkRecordList, "");
            DataGridViewColumn col = dgvWorkRecordList.Columns[0];
            col.Frozen = true;
            //일반컬럼 추가
            DataGridViewUtil.AddNewColumnToDataGridView(dgvWorkRecordList, "지시일", "WO_PLAN_DATE", true, 100); //1
            DataGridViewUtil.AddNewColumnToDataGridView(dgvWorkRecordList, "생산일", "WO_PROD_DATE", true, 100); //2
            DataGridViewUtil.AddNewColumnToDataGridView(dgvWorkRecordList, "설비ID", "FCLTS_CODE", true, 100); //3
            DataGridViewUtil.AddNewColumnToDataGridView(dgvWorkRecordList, "설비명", "FCLTS_NAME", true, 100); //4
            DataGridViewUtil.AddNewColumnToDataGridView(dgvWorkRecordList, "작업순서", "WO_WORK_SEQ", true, 100, DataGridViewContentAlignment.MiddleRight); //5
            DataGridViewUtil.AddNewColumnToDataGridView(dgvWorkRecordList, "품목", "ITEM_CODE", true, 100); //6
            DataGridViewUtil.AddNewColumnToDataGridView(dgvWorkRecordList, "품명", "ITEM_NAME", true, 100); //7
            DataGridViewUtil.AddNewColumnToDataGridView(dgvWorkRecordList, "작업상태", "WO_WORK_STATE", true, 100); //8
            DataGridViewUtil.AddNewColumnToDataGridView(dgvWorkRecordList, "양품창고", "FCLTS_WRHS_GOOD", true, 100); //9
            DataGridViewUtil.AddNewColumnToDataGridView(dgvWorkRecordList, "불량창고", "FCLTS_WRHS_BAD", true, 100); //10
            DataGridViewUtil.AddNewColumnToDataGridView(dgvWorkRecordList, "지시량", "WO_PLAN_QTY", true, 90, DataGridViewContentAlignment.MiddleRight); //11
            DataGridViewUtil.AddNewColumnToDataGridView(dgvWorkRecordList, "취소수량", "SALES_NO_QTY", true, 100, DataGridViewContentAlignment.MiddleRight); //12
            DataGridViewUtil.AddNewColumnToDataGridView(dgvWorkRecordList, "양품수량", "WO_QTY_OUT", true, 100, DataGridViewContentAlignment.MiddleRight); //13
            DataGridViewUtil.AddNewColumnToDataGridView(dgvWorkRecordList, "투입수량", "WO_QTY_IN", true, 100, DataGridViewContentAlignment.MiddleRight); //14
            DataGridViewUtil.AddNewColumnToDataGridView(dgvWorkRecordList, "불량수량", "WO_QTY_BAD", true, 100, DataGridViewContentAlignment.MiddleRight); //15
            DataGridViewUtil.AddNewColumnToDataGridView(dgvWorkRecordList, "잔량", "WO_QTY", true, 80, DataGridViewContentAlignment.MiddleRight); //16
            DataGridViewUtil.AddNewColumnToDataGridView(dgvWorkRecordList, "생산량", "WO_QTY_PROD", true, 90, DataGridViewContentAlignment.MiddleRight); //17
            DataGridViewUtil.AddNewColumnToDataGridView(dgvWorkRecordList, "계획시작일", "WO_PLAN_STARTTIME", true, 110); //18
            DataGridViewUtil.AddNewColumnToDataGridView(dgvWorkRecordList, "계획종료일", "WO_PLAN_ENDTIME", true, 110); //19
            DataGridViewUtil.AddNewColumnToDataGridView(dgvWorkRecordList, "비고", "WO_REMARK", true, 80); //20
            DataGridViewUtil.AddNewColumnToDataGridView(dgvWorkRecordList, "수정자", "WO_LAST_MDFR", true, 100); //21
            DataGridViewUtil.AddNewColumnToDataGridView(dgvWorkRecordList, "수정일", "WO_LAST_MDFY", true, 200); //22
            DataGridViewUtil.AddNewColumnToDataGridView(dgvWorkRecordList, "작업지시번호", "WO_Code", true, 120); //23
            DataGridViewUtil.AddNewColumnToDataGridView(dgvWorkRecordList, "작업지시서번호", "SALES_WORK_ORDER_ID", true, 130, DataGridViewContentAlignment.MiddleRight); //24
            DataGridViewUtil.AddNewColumnToDataGridView(dgvWorkRecordList, "계획ID", "PLAN_ID", true, 90); //25
            DataGridViewUtil.AddNewColumnToDataGridView(dgvWorkRecordList, "TYPE", "ITEM_TYP", true, 90); //25
            dgvWorkRecordList.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvWorkRecordList.ColumnHeadersDefaultCellStyle.Font = new Font("맑은 고딕", 9.75F, FontStyle.Bold);
            DataGridViewUtil.DataGridViewRowNumSet(dgvWorkRecordList);
            DataGridViewCheckBoxAllCheck();


            //데이터그리드뷰 초기설정
            DataGridViewUtil.InitSettingGridView(dgvMOVEList);
            //데이터그리드뷰 체크박스 컬럼 추가
            DataGridViewUtil.DataGridViewCheckBoxSet(dgvMOVEList, "");
            DataGridViewColumn dc = dgvWorkRecordList.Columns[0];
            dc.Frozen = true;
            //일반컬럼 추가
            DataGridViewUtil.AddNewColumnToDataGridView(dgvMOVEList, "품목", "ITEM_CODE", true, 150); //1
            DataGridViewUtil.AddNewColumnToDataGridView(dgvMOVEList, "품명", "ITEM_NAME", true, 300); //2
            DataGridViewUtil.AddNewColumnToDataGridView(dgvMOVEList, "규격", "ITEM_STND", true, 200); //3
            DataGridViewUtil.AddNewColumnToDataGridView(dgvMOVEList, "창고코드", "FCLTS_CODE", true, 180); //4
            DataGridViewUtil.AddNewColumnToDataGridView(dgvMOVEList, "이동창고", "FCLTS_NAME", true, 180); //5
            DataGridViewUtil.AddNewColumnToDataGridView(dgvMOVEList, "이동수량", "WO_QTY_OUT", true, 100, DataGridViewContentAlignment.MiddleRight); //6 양품수량
            DataGridViewUtil.AddNewColumnToDataGridView(dgvMOVEList, "비고", "WO_REMARK", true, 400); //7
            DataGridViewUtil.AddNewColumnToDataGridView(dgvMOVEList, "작업지시서번호", "SALES_WORK_ORDER_ID", true, 200); //8
            DataGridViewUtil.AddNewColumnToDataGridView(dgvMOVEList, "TYPE", "ITEM_TYP", true, 100); //9
            dgvMOVEList.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvMOVEList.ColumnHeadersDefaultCellStyle.Font = new Font("맑은 고딕", 9.75F, FontStyle.Bold);
            DataGridViewUtil.DataGridViewRowNumSet(dgvMOVEList);
            DataGridViewCheckBoxAllCheck2();

        }

        private void DataGridViewCheckBoxAllCheck()
        {
            headerChk = new CheckBox();
            Point headerCell = dgvWorkRecordList.GetCellDisplayRectangle(0, -1, true).Location;
            headerChk.Location = new Point(headerCell.X + 4, headerCell.Y + 15);
            headerChk.Size = new Size(18, 18);
            headerChk.BackColor = Color.FromArgb(245, 245, 246);
            headerChk.Click += HeaderChk_Clicked;
            dgvWorkRecordList.Controls.Add(headerChk);
        }

        private void DataGridViewCheckBoxAllCheck2()
        {
            headerChk2 = new CheckBox();
            Point headerCell = dgvMOVEList.GetCellDisplayRectangle(0, -1, true).Location;
            headerChk2.Location = new Point(headerCell.X + 4, headerCell.Y + 15);
            headerChk2.Size = new Size(18, 18);
            headerChk2.BackColor = Color.FromArgb(245, 245, 246);
            headerChk2.Click += HeaderChk_Clicked;
            dgvMOVEList.Controls.Add(headerChk2);
        }

        private void HeaderChk_Clicked(object sender, EventArgs e)
        {
            dgvWorkRecordList.EndEdit();

            //데이터그리드뷰의 전체 행의 체크를 체크 or 언체크
            foreach (DataGridViewRow row in dgvWorkRecordList.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                chk.Value = headerChk.Checked;
            }
        }

        private void HeaderChk_Clicked2(object sender, EventArgs e)
        {
            dgvMOVEList.EndEdit();

            //데이터그리드뷰의 전체 행의 체크를 체크 or 언체크
            foreach (DataGridViewRow row in dgvMOVEList.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                chk.Value = headerChk2.Checked;
            }
        }

        #endregion

        private void FrmWorkRecord_Load(object sender, EventArgs e)
        {
            ComboBinding();
            btnset();
            DataGridViewColumnSet();
            GetWorkOrderInfo(); //작업실적등록 뷰
            GetWorkMOVEInfo(); //공정이동 뷰
        }

        private void GetWorkOrderInfo()
        {
            WorkOrderService service = new WorkOrderService();
            dgvWorkRecordList.DataSource = null;
            dgvWorkRecordList.DataSource = service.GetWorkOrderInfo();
        }
        private void GetWorkMOVEInfo()
        {
            WorkOrderService service = new WorkOrderService();
            dgvMOVEList.DataSource = null;
            dgvMOVEList.DataSource = service.GetWorkMOVEInfo();
        }
        // 버튼 이벤트 추가 메서드
        private void btnset()
        {
            FrmMAIN frm = (FrmMAIN)this.MdiParent;
            frm.eSearch += Search;
            frm.eInsert += Insert;
            frm.eDelete += Delete;
            frm.eUpdate += Update;
            frm.eReset += Reset; //입력필요
            frm.ePrint += Print; //입력필요
        }

        //콤보박스 바인딩
        private void ComboBinding()
        {
            CommonService service = new CommonService();
            List<ComboItemVO> commonlist = service.GetITEMCmCode();

            var listCOMPANY_TYP = (from item in commonlist where item.COMMON_PARENT == "WO_STATE" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(cboSTATE, listCOMPANY_TYP, "COMMON_CODE", "COMMON_NAME", "");
        }


        #region ****메인 버튼 이벤트****

        public void Insert(object sender, EventArgs e)
        {
            
        }

        public void Search(object sender, EventArgs e)
        {
            try
            {
                string fromDATE;
                string fromTO;
                WorkOrderService service = new WorkOrderService();
                dgvWorkRecordList.DataSource = null;
                if (dtpFROM.Checked)
                    fromDATE = dtpFROM.Value.ToString("yyyy-MM-dd");
                else
                    fromDATE = string.Empty;
                if (dtpTO.Checked)
                    fromTO = dtpTO.Value.ToString("yyyy-MM-dd");
                else
                    fromTO = string.Empty;
                dgvWorkRecordList.DataSource = service.SearchWORKORDER(cboDATEtype.Text, fromDATE, fromTO, cboSTATE.Text);
            }
            catch(Exception err)
            {
                _logging = new LoggingUtility(this.Name, Level.Info, 30);
            }
        }

        public void Reset(object sender, EventArgs e)
        {
            cboDATEtype.SelectedIndex = -1;
            ComboBinding();
            GetWorkOrderInfo(); //작업실적등록 뷰
            GetWorkMOVEInfo(); //공정이동 뷰
        }

        public void Update(object sender, EventArgs e)
        {
            
        }

        public void Delete(object sender, EventArgs e)
        {
            
        }

        public void Print(object sender, EventArgs e)
        {
            
        }

        #endregion


        #region cboDATE 검색조건
        //날짜제외 선택시 자동 null값 입력
        private void cboDATE_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDATEtype.SelectedIndex == 0)
            {
                dtpFROM.Checked = false;
                dtpFROM_ValueChanged(null, null);
                dtpTO.Checked = false;
                dtpTO_ValueChanged(null, null);
            }
            else
            {
                dtpFROM.Checked = true;
                dtpFROM_ValueChanged(null, null);
                dtpTO.Checked = true;
                dtpTO_ValueChanged(null, null);
            }
        }

        private void dtpFROM_ValueChanged(object sender, EventArgs e)
        {
            if (!dtpFROM.Checked)
            {
                dtpFROM.CustomFormat = " ";
                dtpFROM.Format = DateTimePickerFormat.Custom;
            }
            else
            {
                dtpFROM.CustomFormat = null;
                dtpFROM.Format = DateTimePickerFormat.Long;
            }
        }

        private void dtpTO_ValueChanged(object sender, EventArgs e)
        {
            if (!dtpTO.Checked)
            {
                dtpTO.CustomFormat = " ";
                dtpTO.Format = DateTimePickerFormat.Custom;
            }
            else
            {
                dtpTO.CustomFormat = null;
                dtpTO.Format = DateTimePickerFormat.Long;
            }
        }

        #endregion


        private void FrmWorkRecord_FormClosing(object sender, FormClosingEventArgs e)
        {
            FrmMAIN frm = (FrmMAIN)this.MdiParent;
            frm.eSearch -= Search;
            frm.eInsert -= Insert;
            frm.eDelete -= Delete;
            frm.eUpdate -= Update;
            frm.eReset -= Reset; //입력필요
            frm.ePrint -= Print; //입력필요
        }

        private void btnWorkCancel_Click(object sender, EventArgs e)
        {
            try
            {
                dgvWorkRecordList.EndEdit();
                string state = dgvWorkRecordList.CurrentRow.Cells[8].Value.ToString();
                if (state == "작업완료" || state == "")
                {
                    MessageBox.Show("이미 완료 상태입니다.");
                    return;
                }
                else
                {
                    StringBuilder sb = new StringBuilder();
                    int cnt = 0;
                    //품목 선택후 List를 전달
                    foreach (DataGridViewRow item in dgvWorkRecordList.Rows)
                    {
                        if (Convert.ToBoolean(item.Cells[0].Value))
                        {
                            sb.Append(item.Cells[23].Value.ToString() + "@");
                            cnt++;
                        }
                    }
                    if (sb.Length < 1)
                    {
                        MessageBox.Show("작업 취소할 항목을 선택하여 주십시오.");
                        return;
                    }
                    sb.Remove(sb.Length - 1, 1);
                    if (MessageBox.Show($"총 {cnt}개의 항목을 작업취소 하시겠습니까?", "작업취소", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        WorkOrderService service = new WorkOrderService();
                        Message msg = service.WorkCancel(sb.ToString());
                        if (msg.IsSuccess)
                        {
                            MessageBox.Show(msg.ResultMessage);
                            GetWorkOrderInfo();
                        }
                        else
                        {
                            MessageBox.Show(msg.ResultMessage);
                            return;
                        }
                    }
                }
            }
            catch(Exception err)
            {
                _logging = new LoggingUtility(this.Name, Level.Info, 30);
            }
        }

        private void btnMOVE_Click(object sender, EventArgs e)
        {
            try
            {
                dgvMOVEList.EndEdit();
                string state = dgvWorkRecordList.CurrentRow.Cells[8].Value.ToString();
                if (state == "작업완료")
                {
                    StringBuilder sb = new StringBuilder();
                    int cnt = 0;
                    //품목 선택후 List를 전달
                    foreach (DataGridViewRow item in dgvWorkRecordList.Rows)
                    {
                        if (Convert.ToBoolean(item.Cells[0].Value))
                        {
                            sb.Append(item.Cells[23].Value.ToString() + "@");
                            cnt++;
                        }
                    }
                    if (sb.Length < 1)
                    {
                        MessageBox.Show("실적등록할 항목을 선택하여 주십시오.");
                        return;
                    }
                    sb.Remove(sb.Length - 1, 1);
                    if (MessageBox.Show($"총 {cnt}개의 항목을 실적등록 하시겠습니까?", "실적등록", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        WorkOrderService service = new WorkOrderService();
                        Message msg = service.WorkMOVE(sb.ToString());
                        if (msg.IsSuccess)
                        {
                            MessageBox.Show(msg.ResultMessage);
                            GetWorkOrderInfo();
                            GetWorkMOVEInfo();
                        }
                        else
                        {
                            MessageBox.Show(msg.ResultMessage);
                            return;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("작업완료 상태만 실적등록이 가능합니다.");
                    return;
                }
            }
            catch(Exception err)
            {
                _logging = new LoggingUtility(this.Name, Level.Info, 30);
            }
        }

        private void btnFinalWork_Click(object sender, EventArgs e)
        {
            try
            {
                //수정 시 여러개의 체크박스를 선택하는것을 막음
                dgvMOVEList.EndEdit();
                //string sb = string.Empty;
                int cnt = 0;
                //체크가 되었는지 확인
                foreach (DataGridViewRow item in dgvMOVEList.Rows)
                {
                    if (Convert.ToBoolean(item.Cells[0].Value))
                    {
                        cnt++;
                    }
                }
                if (cnt == 1) //하나일 경우 PopUp창 띄움
                {
                    INSTACK_VO vo = new INSTACK_VO();
                    vo.SALES_WORK_ORDER_ID = dgvMOVEList.CurrentRow.Cells[8].Value.ToString();
                    vo.INS_QTY = Convert.ToInt32(dgvMOVEList.CurrentRow.Cells[6].Value);
                    vo.ITEM_CODE = dgvMOVEList.CurrentRow.Cells[1].Value.ToString();

                    if (MessageBox.Show("공정이동 하시겠습니까?", "공정이동", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {

                        if (dgvMOVEList.CurrentRow.Cells[4].Value.ToString() == "OS")
                        {
                            vo.INS_WRHS = "OS";
                            WorkOrderService service = new WorkOrderService();
                            Message msg = service.InsertMoveUpdate(vo);
                            if (msg.IsSuccess)
                            {
                                MessageBox.Show(msg.ResultMessage);
                                GetWorkMOVEInfo();
                            }
                            else
                            {
                                MessageBox.Show(msg.ResultMessage);
                                return;
                            }
                        }
                        else
                        {
                            vo.INS_WRHS = "H_01";
                            WorkOrderService service = new WorkOrderService();
                            Message msg = service.InsertMoveUpdate(vo);
                            if (msg.IsSuccess)
                            {
                                MessageBox.Show(msg.ResultMessage);
                                GetWorkMOVEInfo();
                            }
                            else
                            {
                                MessageBox.Show(msg.ResultMessage);
                                return;
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("하나의 항목씩만 공정이동 가능");
                    return;
                }
            }
            catch(Exception err)
            {
                _logging = new LoggingUtility(this.Name, Level.Info, 30);
            }
        }
    }
}
