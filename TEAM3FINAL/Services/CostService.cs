using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEAM3FINALDAC;
using TEAM3FINALVO;


namespace TEAM3FINAL
{
   public class CostService
    {
        public MaterialCostList_VO GetMaterialCostInfo(string mcCode)
        {
            CostDAC dac = new CostDAC();
            return dac.GetMaterialCostInfo(mcCode);
        }
        public List<MaterialCostList_VO> GetMaterialCostList()
        {
            CostDAC dac = new CostDAC();
            return dac.GetMaterialCostList();
        }
        public Message InsertOrUpdateMaterialCost(MaterialCost_VO vo)
        {
           CostDAC dac = new CostDAC();
            return dac.InsertOrUpdateMaterialCost(vo);
        }
        public bool DeleteMaterialCostList(string list, string gubun)
        {
            CostDAC dac = new CostDAC();
            return dac.DeleteMaterialCostList(list, gubun);

        }
        public SalesCostList_VO GetSalesCostInfo(string scCode)
        {
            CostDAC dac = new CostDAC();
            return dac.GetSalesCostInfo(scCode);
        }
        public List<SalesCostList_VO> SalesCostList()
        {
            CostDAC dac = new CostDAC();
            return dac.GetSalesCostList();
        }
        public Message InsertOrUpdateSalesCost(SalesCost_VO vo)
        {

            CostDAC dac = new CostDAC();
            return dac.InsertOrUpdateSalesCost(vo);
        }
        public bool DeleteSalesCostList(string list, string gubun)
        {
            CostDAC dac = new CostDAC();
            return dac.DeleteSalesCostList(list, gubun);
        }
    }
}
