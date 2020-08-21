using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient; //add
using System.Web.Configuration; //add
using TEAM3FINALWEB.Models;
using System.Security.AccessControl;
using System.Web.UI.WebControls;
using System.Drawing.Printing;
using System.Data;


namespace TEAM3FINALWEB.DAC
{
    public class WorkDAC : ConnectionAccess
    {
        string connStr = string.Empty;
        public WorkDAC()
        {
            connStr = this.ConnectionString;
        }

        public System.Data.DataTable GetProductQTYBYFclt()
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = $@"
                        -- 제품별 월별 매출액
with A AS
(
 select 
                        isnull( case Month(convert(nvarchar(10),SALES_ENDDATE,23)) when 1 THEN SUM(SALES_QTY*SALES_TTL) END,0) AS M01
		                        ,isnull( case Month(convert(nvarchar(10),SALES_ENDDATE,23)) when 2 THEN SUM(SALES_QTY*SALES_TTL) END,0) AS M02				
		                        ,isnull( case Month(convert(nvarchar(10),SALES_ENDDATE,23)) when 3 THEN SUM(SALES_QTY*SALES_TTL) END,0) AS M03					
		                        ,isnull( case Month(convert(nvarchar(10),SALES_ENDDATE,23)) when 4 THEN SUM(SALES_QTY*SALES_TTL) END,0) AS M04			
		                        ,isnull( case Month(convert(nvarchar(10),SALES_ENDDATE,23)) when 5 THEN SUM(SALES_QTY*SALES_TTL) END,0) AS M05			
		                        ,isnull( case Month(convert(nvarchar(10),SALES_ENDDATE,23)) when 6 THEN SUM(SALES_QTY*SALES_TTL) END,0) AS M06			
		                        ,isnull( case Month(convert(nvarchar(10),SALES_ENDDATE,23)) when 7 THEN SUM(SALES_QTY*SALES_TTL) END,0) AS M07			
		                        ,isnull( case Month(convert(nvarchar(10),SALES_ENDDATE,23)) when 8 THEN SUM(SALES_QTY*SALES_TTL) END,0) AS M08			
		                        ,isnull( case Month(convert(nvarchar(10),SALES_ENDDATE,23)) when 9 THEN SUM(SALES_QTY*SALES_TTL) END,0) AS M09			
		                        ,isnull( case Month(convert(nvarchar(10),SALES_ENDDATE,23)) when 10 THEN SUM( SALES_QTY*SALES_TTL) END,0) AS M10			
		                        ,isnull( case Month(convert(nvarchar(10),SALES_ENDDATE,23)) when 11 THEN SUM( SALES_QTY*SALES_TTL) END,0) AS M11			
		                        ,isnull( case Month(convert(nvarchar(10),SALES_ENDDATE,23)) when 12 THEN SUM( SALES_QTY*SALES_TTL) END,0) AS M12
                        ,ITEM_NAME
                        from SALES_RECORD s inner join ITEM i on s.ITEM_CODE = i.ITEM_CODE
                        where 1=1
                        AND YEAR(CONVERT(nvarchar(10),SALES_ENDDATE,23)) = YEAR(getdate())
                        group by Month(convert(nvarchar(10),SALES_ENDDATE,23)),ITEM_NAME
)

select sum(A.M01) M01, sum(A.M02) M02, sum(A.M03) M03, sum(A.M04) M04, sum(A.M05) M05, sum(A.M06) M06, sum(A.M07) M07, sum(A.M08) M08, sum(A.M09) M09, sum(A.M10) M10, sum(A.M11) M11, sum(A.M12) M12, A.ITEM_NAME ITEM_NAME
from A
group by A.ITEM_NAME
                        ";

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.Fill(dt);
            }
            return dt;
        }

    }
}