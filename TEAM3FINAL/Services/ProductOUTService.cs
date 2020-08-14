using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEAM3FINALDAC;
using TEAM3FINALVO;

namespace TEAM3FINAL.HHW
{
    public class ProductOUTService
    {
        public List<ProductOUT_VO> GetProductOUTList()
        {
            ProductOUTDAC dac = new ProductOUTDAC();
            return dac.GetProductOUTList();
        }

        public Message ProductOUT(ProductOUT_VO vo, string id)
        {
            ProductOUTDAC dac = new ProductOUTDAC();
            return dac.ProductOUT(vo, id);
        }

        public List<ProductOUT_VO> SearchProductOUT(string id, string item, string company)
        {
            ProductOUTDAC dac = new ProductOUTDAC();
            return dac.SearchProductOUT(id, item, company);
        }

        public List<ProductOUT_VO> GetProductOUTStateList()
        {
            ProductOUTDAC dac = new ProductOUTDAC();
            return dac.GetProductOUTStateList();
        }

        public Message ProductOUTCancel(ProductOUT_VO vo, string id)
        {
            ProductOUTDAC dac = new ProductOUTDAC();
            return dac.ProductOUTCancel(vo, id);
        }

        public List<ProductOUT_VO> SearchProductOUTState(string id, string item, string company)
        {
            ProductOUTDAC dac = new ProductOUTDAC();
            return dac.SearchProductOUTState(id, item, company);
        }
    }
}
