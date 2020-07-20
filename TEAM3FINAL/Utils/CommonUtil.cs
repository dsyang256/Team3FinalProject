using TEAM3FINALVO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TEAM3FINAL
{
    public class CommonUtil
    {
        #region comboBox 바인딩 관련
        public static void ComboBinding(ComboBox combo, List<ComboItemVO> list)
        {            
            combo.ValueMember = "COMMON_CODE";
            combo.DisplayMember = "COMMON_CODE_NAME";
            combo.DataSource = list;
        }

        public static void ComboBinding(ComboBox combo, List<ComboItemVO> list, string blankText)
        {
            if (list == null)
                list = new List<ComboItemVO>();

            list.Insert(0, new ComboItemVO(blankText));
            combo.ValueMember = "COMMON_CODE";
            combo.DisplayMember = "COMMON_CODE_NAME";
            combo.DataSource = list;
        }

        public static void ComboBinding<T>(ComboBox combo, List<T> list, string Code, string CodeNm)
        {
            if (list == null)
                list = new List<T>();
            
            combo.DataSource = list;
            combo.DisplayMember = CodeNm;
            combo.ValueMember = Code;
        }

        public static void ComboBinding<T>(ComboBox combo, List<T> list, string Code, string CodeNm, string blankText) where T : class, new()
        {
            if (list == null)
                list = new List<T>();

            T blankItem = new T();
            blankItem.GetType().GetProperty(CodeNm).SetValue(blankItem, blankText);
            list.Insert(0, blankItem);

            combo.DataSource = list;
            combo.DisplayMember = CodeNm;
            combo.ValueMember = Code;
        }

        //public static List<ComboItemVO> Copy(List<ComboItemVO> org)
        //{
        //    //List<ComboItemVO> cloneList = new List<ComboItemVO>();
        //    //foreach (var item in org)
        //    //{
        //    //    cloneList.Add(new ComboItemVO {
        //    //            Code = item.Code,
        //    //            CodeNm = item.CodeNm  });
        //    //}
        //    //return cloneList;
        //}
        #endregion

        public static void AddNewColumnToDataGridView(DataGridView dgv, string headerText, string dataPropertyName, bool visibility, int colWidth = 100, DataGridViewContentAlignment textAlign = DataGridViewContentAlignment.MiddleLeft)
        {
            DataGridViewTextBoxColumn gridCol = new DataGridViewTextBoxColumn();
            gridCol.HeaderText = headerText;
            gridCol.DataPropertyName = dataPropertyName;
            gridCol.Width = colWidth;
            gridCol.Visible = visibility;
            gridCol.ValueType = typeof(string);
            gridCol.ReadOnly = true;
            gridCol.DefaultCellStyle.Alignment = textAlign;
            dgv.Columns.Add(gridCol);
        }

        public static void InitSettingGridView(DataGridView dgv)
        {
            dgv.AutoGenerateColumns = false;
            dgv.AllowUserToAddRows = false;
            dgv.MultiSelect = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
    }
}
