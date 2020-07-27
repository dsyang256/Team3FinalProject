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
    public partial class FrmCOMMON : TEAM3FINAL.BaseForm.baseFormPopUP
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
            Util.AddNewColumnToDataGridView(dvgcommon, "SEQ", "COMMON_SEQ", true, 30);

        }
        private void DataGridViewBinding()
        {
            dvgcommon.DataSource = service.GetCmCode();
        }
        private void ComboBinding()
        {
            ComboItemService service = new ComboItemService();
            List<ComboItemVO> Commonlist = service.GetITEMCmCode();


            //발주업체
            var list1 = (from item in Commonlist where item.COMMON_PARENT == null select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(comboBox1, list1, "COMMON_CODE", "COMMON_NAME", "");

            //납품유형
            var list2 = (from item in Commonlist where item.COMMON_PARENT == null select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(comboBox3, list2, "COMMON_CODE", "COMMON_NAME", "");

            




        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

    }
}
