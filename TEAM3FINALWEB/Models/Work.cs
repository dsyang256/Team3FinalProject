using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TEAM3FINALWEB.Models
{
    public class Work
    {
        public string FCLTS_NAME { get; set; }
        public string ITEM_CODE { get; set; }
        public int TaskLogQTYGOOD { get; set; }
        public int TaskLogQTYBAD { get; set; }
        public float Prate { get; set; }
        public float Frate { get; set; }
        public int QTY { get; set; }

    }

    public class Instack
    {
        public int CountIN { get; set; }
        public int CountOUT { get; set; }

    }
}