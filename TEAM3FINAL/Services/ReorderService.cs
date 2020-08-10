using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEAM3FINALDAC;
using TEAM3FINALVO;

namespace TEAM3FINAL
{
    public class ReorderService
    {
        public DataTable SelectREORDER()
        {
            REORDERDAC dac = new REORDERDAC();
            return dac.SelectREORDER();
        }

        public DataTable GetSearchREORDER(string sday, string eday, string comcodeout, string item, string state, string order, string comcodein)
        {
            REORDERDAC dac = new REORDERDAC();
            return dac.GetSearchREORDER(sday, eday, comcodeout, item, state, order, comcodein);
        }
        public DataTable GetCOM()
        {
            REORDERDAC dac = new REORDERDAC();
            return dac.GetCOM();
        }

        public DataTable GetReorderItem()
        {
            REORDERDAC dac = new REORDERDAC();
            return dac.GetReorderItem();
        }
        public DataTable GetReorderItem2(string com)
        {
            REORDERDAC dac = new REORDERDAC();
            return dac.GetReorderItem2(com);
        }

        internal bool insertREORDER(REORDER_VO vo)
        {
            REORDERDAC dac = new REORDERDAC();
            return dac.insertREORDER(vo);
        }
        public bool UpDateREORDER(string day, string manager, string code)
        {
            REORDERDAC dac = new REORDERDAC();
            return dac.UpDateREORDER(day, manager, code);
        }

        internal bool DeleteREORDER(string v)
        {
            REORDERDAC dac = new REORDERDAC();
            return dac.DeleteREORDER(v);
        }

        public DataTable GetSearchReorder2(string reorder, string name)
        {
            REORDERDAC dac = new REORDERDAC();
            return dac.GetSearchReorder2(reorder, name);
        }

        public DataTable GetWarehousingWait()
        {
            REORDERDAC dac = new REORDERDAC();
            return dac.GetWarehousingWait();
        }

        internal bool insertREORDERDETATILS(REORDERDETATILS_VO vo ,ITEM_VO vo2)
        {
            REORDERDAC dac = new REORDERDAC();
            return dac.insertREORDERDETATILS(vo,vo2);
        }
    }
}
