using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEAM3FINAL
{
    interface CommonBtn
    {
       void Insert(object sender, EventArgs e);
       void Search(object sender, EventArgs e);
       void Reset(object sender, EventArgs e);

       void Update(object sender, EventArgs e);
       void Delete(object sender, EventArgs e);
       void Print(object sender, EventArgs e);
       
    }
}
