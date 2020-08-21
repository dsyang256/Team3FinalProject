using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TEAM3FINALWEB.DAC;
using TEAM3FINALWEB.Models;

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

            DataView dv = new DataView(dt);
            List<int> qtys = new List<int>();

            for (int i = 0; i < dv.ToTable().Columns.Count-1; i++)
            {
                qtys.Add(Convert.ToInt32(dv.ToTable().Rows[0][i]));
            }
                data1 = "[" + string.Join(",", qtys.ToArray()) + "]";

                qtys.Clear();

            ViewBag.Labels = labels;
            ViewBag.Label1 = dv.ToTable().Rows[0][12];
            ViewBag.data1 = data1;


            OrderDAC dac1 = new OrderDAC();
            var list = dac1.GetTotalPrieByCom();
            ViewBag.C1 = list[0].TotalPrice;
            ViewBag.C2 = list[1].TotalPrice;
            ViewBag.C3 = list[2].TotalPrice;
            ViewBag.C4 = list[3].TotalPrice;
            ViewBag.C5 = list[4].TotalPrice;
            ViewBag.C6 = list[5].TotalPrice;
            ViewBag.C7 = list[6].TotalPrice;
            ViewBag.C8 = list[7].TotalPrice;
            ViewBag.C9 = list[8].TotalPrice;
            ViewBag.B1 = list[0].COMNAME;
            ViewBag.B2 = list[1].COMNAME;
            ViewBag.B3 = list[2].COMNAME;
            ViewBag.B4 = list[3].COMNAME;
            ViewBag.B5 = list[4].COMNAME;
            ViewBag.B6 = list[5].COMNAME;
            ViewBag.B7 = list[6].COMNAME;
            ViewBag.B8 = list[7].COMNAME;
            ViewBag.B9 = list[8].COMNAME;

            Order orders = new Order() { Orders = list };

            OrderDAC dac2 = new OrderDAC();
            ViewBag.OrderList = dac2.GetOrderList();

            return View(orders);
        }
    }
}