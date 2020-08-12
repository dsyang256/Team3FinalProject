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
    public class WorkOrderService
    {
        #region 작업실적등록
        public List<WORKORDER_VO> GetWorkOrderInfo()
        {
            WorkOrderDAC dac = new WorkOrderDAC();
            return dac.GetMOVEList();
        }

        public List<WORKORDER_VO> SearchWORKORDER(string dateTYP, string fromDATE, string fromTO, string state)
        {
            WorkOrderDAC dac = new WorkOrderDAC();
            return dac.SearchWORKORDER(dateTYP, fromDATE, fromTO, state);
        }

        public Message WorkCancel(string code)
        {
            WorkOrderDAC dac = new WorkOrderDAC();
            return dac.WorkCancel(code);
        }

        public List<WorkMOVE_VO> GetWorkMOVEInfo()
        {
            WorkOrderDAC dac = new WorkOrderDAC();
            return dac.GetWorkMOVEInfo();
        }

        public Message WorkMOVE(string code)
        {
            WorkOrderDAC dac = new WorkOrderDAC();
            return dac.WorkMOVE(code);
        }

        public Message InsertMoveUpdate(INSTACK_VO vo)
        {
            WorkOrderDAC dac = new WorkOrderDAC();
            return dac.InsertMoveUpdate(vo);
        }

        #endregion


        #region 공정재고현황
        public List<MOVESTATE_VO> MOVEList()
        {
            WorkOrderDAC dac = new WorkOrderDAC();
            return dac.MOVEList();
        }

        public List<MOVESTATE_VO> SearchMOVELIST(string wHouse, string type, string itemCode)
        {
            WorkOrderDAC dac = new WorkOrderDAC();
            return dac.SearchMOVELIST(wHouse, type, itemCode);
        }

        #endregion


        #region 고객주문별현황

        public List<OrderState_VO> OrderList()
        {
            WorkOrderDAC dac = new WorkOrderDAC();
            return dac.OrderList();
        }

        internal Message OrderMoveFac(OrderState_VO vo)
        {
            WorkOrderDAC dac = new WorkOrderDAC();
            return dac.OrderMoveFac(vo);
        }

        internal List<WorkMOVE_VO> SearchOrderState(string fromDATE, string fromTO, string code)
        {
            WorkOrderDAC dac = new WorkOrderDAC();
            return dac.SearchOrderState(fromDATE, fromTO, code);
        }

        #endregion
    }
}
