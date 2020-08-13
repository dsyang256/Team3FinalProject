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
    }
}
