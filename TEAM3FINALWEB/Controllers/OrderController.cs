using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TEAM3FINALWEB.DAC;

namespace TEAM3FINALWEB.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            OrderDAC dac = new OrderDAC();
            DataTable dt = dac.GetOrderSalesByMonth();

            string data1 = default; //제품1 y축 데이터
            List<string> prodNM = new List<string>(); // 제품명

            string labels = "1월,2월,3월,4월,5월,6월,7월,8월,9월,10월,11월,12월";

            ViewBag.Labels = labels;
            DataView dv = new DataView(dt);
            ViewBag.Label1 = dv.ToTable().Rows[0][12];
            ViewBag.data1 = data1;

            List<int> qtys = new List<int>();

            for (int i = 0; i < dv.ToTable().Columns.Count-1; i++)
            {
                data1 = "[" + string.Join(",", Convert.ToInt32(dv.ToTable().Rows[0][i])) + "]";
            }

            string a = data1;

            return View();
        }
    }
}