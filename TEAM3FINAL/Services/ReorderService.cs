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

        internal object GetReorder(string v1, string v2)
        {
            REORDERDAC dac = new REORDERDAC();
            return dac.GetReorder(v1,v2);
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

        internal bool insertREORDERDETATILS(REORDERDETATILS_VO vo ,ITEM_VO vo2,string id)
        {
            REORDERDAC dac = new REORDERDAC();
            return dac.insertREORDERDETATILS(vo,vo2,id);
        }

        public DataTable GetWarehousingWait2()
        {
            REORDERDAC dac = new REORDERDAC();
            return dac.GetWarehousingWait2();
        }

        internal DataTable SPGetWarehousingWait(string day1, string day2, string code1, string name, string reorder, string cod2)
        {
            REORDERDAC dac = new REORDERDAC();
            return dac.SPGetWarehousingWait(day1, day2, code1, name, reorder, cod2);
        }

        internal DataTable Inspection2()
        {
            REORDERDAC dac = new REORDERDAC();
            return dac.Inspection2();
        }

        internal bool insertInspection(int gqty, int bqty, int reorder, int reorderD,string code,string id)
        {
            REORDERDAC dac = new REORDERDAC();
            return dac.insertInspection(gqty, bqty, reorder, reorderD,code,id);
        }

        internal DataTable Inspection1()
        {
            REORDERDAC dac = new REORDERDAC();
            return dac.Inspection1();
        }
        public DataTable SP_Inspection(string day1, string day2, string com, string name, string inspect, string code)
        {
            REORDERDAC dac = new REORDERDAC();
            return dac.SP_Inspection(day1, day2, com, name, inspect, code);
        }
    }
}
