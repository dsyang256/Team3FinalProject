using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TEAM3FINAL
{
    public class Util
    {/*
        // 로드 할때 콤보박스 체크여부를 저장된 값을 확인하여 변경
        // 아이디 ,패스워드 텍스트 박스에 저장된 값을 조건문으로 확인하여 보여줌
        private void LoginLoad(CheckBox checkBox, TextBox tXTID, TextBox txtPWD)
        {
            checkBox.Checked = false;
            if (Properties.Settings.Default.LoginSave == "Y")
            {
                checkBox.Checked = true;
                tXTID.Text = Properties.Settings.Default.ID;
                txtPWD.Text = Properties.Settings.Default.PWD;

            }
        }
        // 로그인 버튼을 눌렀을때 체크박스의 체크여부를 확인하여 
        // 아이디,패스워드 텍스트 박스의 값을 조건문을 사용해 저장여부 체크
        private void LoginSave(CheckBox checkBox, TextBox tXTID, TextBox txtPWD)
        {
            if (checkBox.Checked == false)
            {
                Properties.Settings.Default.ID = "";
                Properties.Settings.Default.PWD = "";
                Properties.Settings.Default.LoginSave = "N";
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.ID = tXTID.Text;
                Properties.Settings.Default.PWD = txtPWD.Text;
                Properties.Settings.Default.LoginSave = "Y";
                Properties.Settings.Default.Save();
            }
        }
        //그리드뷰 컴럼 추가 함수
        public static void AddNewColumnToDataGridView(DataGridView dgv, string headerText, string dataPropertyName, bool visibility, int colWidth = 100, DataGridViewContentAlignment textAlign = DataGridViewContentAlignment.MiddleLeft, bool readOnly = true)
        {
            DataGridViewTextBoxColumn gridCol = new DataGridViewTextBoxColumn();
            gridCol.HeaderText = headerText;
            gridCol.DataPropertyName = dataPropertyName;
            gridCol.Width = colWidth;
            gridCol.Visible = visibility;
            gridCol.ValueType = typeof(string);
            gridCol.ReadOnly = readOnly;
            gridCol.DefaultCellStyle.Alignment = textAlign;
            dgv.Columns.Add(gridCol);
        }
        //그리드뷰 바인드 함수
        public static void InitSettingGridView(DataGridView dgv)
        {
            dgv.AutoGenerateColumns = false;
            dgv.AllowUserToAddRows = false;
            dgv.MultiSelect = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        //그리드뷰 버튼 추가
        public static int DataGridViewBtnSet(string headerText, DataGridView dgv, int topMargin=37, int bottomMargin=37)
        {
            DataGridViewButtonColumn btn1 = new DataGridViewButtonColumn();
            btn1.HeaderText = headerText;
            btn1.Text = headerText;
            btn1.Width = 200;
            btn1.DefaultCellStyle.Padding = new Padding(5, topMargin, 5, bottomMargin);
            btn1.UseColumnTextForButtonValue = true;
            return dgv.Columns.Add(btn1);

          
        }
        public static void DataGridViewImageSet(string headerText,string propertyName, int width, DataGridView dgv)
        {
            DataGridViewImageColumn img = new DataGridViewImageColumn();
            img.HeaderText = headerText;
            img.DataPropertyName = propertyName;
            img.ImageLayout = DataGridViewImageCellLayout.Zoom;
            img.Width = width;
            dgv.Columns.Add(img);
        }

        //체크박스 버튼 추가
        public static int DataGridViewCheckBoxSet(string headerText, DataGridView dgv)
        {
            DataGridViewCheckBoxColumn chb1 = new DataGridViewCheckBoxColumn();
            chb1.HeaderText = headerText;
            chb1.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            chb1.DefaultCellStyle.Padding = new Padding(0, 0, 0, 0);
            chb1.FlatStyle = FlatStyle.Flat;
            return dgv.Columns.Add(chb1);
        }
        */
    }
}
