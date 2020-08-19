using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TEAM3FINALWEB.Models
{
    public class Order
    {
        public string COMNAME { get; set; }
        public int TotalPrice { get; set; }

        List<Order> orders = new List<Order>();

        public List<Order> Orders
        {
            get { return orders; }
            set { orders = value; }
        }
    }

    public class OrderList
    {
      public string SALES_Work_Order_ID     {get;set;}
      public string PLAN_ID                 {get;set;}
      public string ITEM_NAME               {get;set;}
      public string SALES_QTY               {get;set;}
      public string SALES_ORDER_STATE       {get;set;}
      public string SALES_DUEDATE { get; set; }
    }
}