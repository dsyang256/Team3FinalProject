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
using System.Diagnostics;

namespace TEAM3FINALWEB.DAC
{
    public class WorkDAC : ConnectionAccess
    {
        string connStr = string.Empty;
        public WorkDAC()
        {
            connStr = this.ConnectionString;
        }

        public List<Work> GetProductQTYBYFclt()
        {
            List<Work> list = new List<Work>();
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = $@"
                    WITH Dates AS(
SELECT CONVERT(nvarchar(10), DATEADD(d, NUMBER, 2020-01-01),120) AS DT
FROM MASTER..SPT_VALUES WITH(NOLOCK)
WHERE TYPE ='P' AND CONVERT(nvarchar(10), DATEADD(D, NUMBER, 2020-01-01), 120) <= DATEADD( MONTH,1,Getdate())
) , A AS
  (SELECT T1.BOM_CODE,   T1.ITEM_CODE  , T1.BOM_PARENT_CODE  , T1.BOM_QTY  , 0 AS Lvl
     FROM BOM T1 INNER JOIN ITEM i ON T1.ITEM_CODE = i.ITEM_CODE
	 WHERE i.ITEM_CODE = 'CHAIR_01'
   UNION ALL 
    SELECT T.BOM_CODE,  T.ITEM_CODE,   T.BOM_PARENT_CODE,   T.BOM_QTY   , A.Lvl+1 as Lvl
    FROM A INNER JOIN BOM T ON T.BOM_PARENT_CODE = A.ITEM_CODE
), A2 AS
  (	SELECT  T1.BOM_CODE,   T1.ITEM_CODE  , T1.BOM_PARENT_CODE  , T1.BOM_QTY QTY
     FROM BOM T1 INNER JOIN ITEM i ON T1.ITEM_CODE = i.ITEM_CODE
   UNION ALL 
	SELECT  i.BOM_CODE,   i.ITEM_CODE  , i.BOM_PARENT_CODE  , A2.QTY*i.BOM_QTY QTY
     FROM A2 INNER JOIN BOM i ON  i.BOM_PARENT_CODE = A2.ITEM_CODE
), A3 AS
(
SELECT b.FCLTS_CODE, f.FCLTS_NAME, g.FACG_NAME, A.ITEM_CODE, i.ITEM_NAME, i.ITEM_STND,BOM_CODE,BOM_QTY,BOM_PARENT_CODE, b.BOR_CODE
FROM A inner join ITEM i ON A.ITEM_CODE = i.ITEM_CODE
					inner join dbo.BOR b on b.ITEM_CODE = i.ITEM_CODE
					inner join dbo.FACILITY f on f.FCLTS_CODE = b.FCLTS_CODE
					inner join dbo.FACILITY_GROP g on g.FACG_CODE = f.FACG_CODE
where 1=1
AND ITEM_TYP <> '원자재'
)

select Distinct FCLTS_NAME,SUM(SUM_QTY) QTY,ITEM_CODE ,TaskLogQTYGOOD,TaskLogQTYBAD,  round( (( Convert(float,TaskLogQTYGOOD)/ Convert(float,SUM(SUM_QTY)))*100),1) 'Prate',  round((( Convert(float,TaskLogQTYBAD)/ Convert(float,SUM(SUM_QTY*1.0)))*100),1) 'Frate'
from(
select DISTINCT f.FCLTS_CODE,f.FCLTS_NAME,g.FACG_NAME,Q.ITEM_CODE,i.ITEM_NAME, i.ITEM_STND ,SALES_Work_Order_ID,TaskLogQTYGOOD,TaskLogQTYBAD
, isnull(SALES_QTY * A_QTY,0) AS SUM_QTY 
from
(
select d.PLAN_ID, s.SALES_DUEDATE, s.SALES_QTY , A3.BOM_CODE, A3.BOM_QTY, A3.ITEM_CODE,A3.BOM_PARENT_CODE,s.SALES_Work_Order_ID  , b.BOR_PROCS_LEADTIME , b.FCLTS_CODE,A3.BOR_CODE
from A3  , ITEM i , SALES_WORK s, DEMAND_PLANNING d,BOR b
WHERE  b.ITEM_CODE = A3.ITEM_CODE
AND s.SALES_ORDER_STATE = '주문확정'
AND s.SALES_Work_Order_ID = d.PLAN_Work_Order_ID
) Q				
					inner join BOR bb on bb.BOR_CODE = Q.BOR_CODE
					 inner join item i on i.ITEM_CODE = Q.ITEM_CODE
					 inner join dbo.FACILITY f on f.FCLTS_CODE = q.FCLTS_CODE
					inner join dbo.FACILITY_GROP g on g.FACG_CODE = f.FACG_CODE
					 left outer join ( select distinct ITEM_CODE, MAX(QTY) A_QTY from A2 Group by ITEM_CODE) C on c.ITEM_CODE = Q.ITEM_CODE
					 left outer join (select distinct t.ITEM_CODE ITEM_CODE, sum(isnull(TaskLogQTYGOOD,0)) TaskLogQTYGOOD, sum(isnull(TaskLogQTYBAD,0)) TaskLogQTYBAD
						from TASKLOG t inner join WORKORDER w on w.WO_Code = t.TaskLogWOCODE
							group by t.ITEM_CODE) DD on Q.ITEM_CODE = DD.ITEM_CODE
) BB
group by FCLTS_NAME,ITEM_CODE,TaskLogQTYGOOD,TaskLogQTYBAD
                        ";

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.Fill(dt);
                list = Helper.ConvertDataTableToList<Work>(dt);
            }
            return list;
        }


        public int GetCountFcltWork()
        {
            int count = 0;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = $@"
                            select  count(*) CountTask
                            from TASKLOG t
                        ";

                SqlCommand cmd = new SqlCommand(sql,conn);
                conn.Open();
                     count =(int)  cmd.ExecuteScalar();
                conn.Close();
            }
            return count;
        }

        public int GetCountITEM()
        {
            int count = 0;  

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = $@"
                select count(*)
                from ITEM
                        ";

                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                count = (int)cmd.ExecuteScalar();
                conn.Close();
            }
            return count;
        }

        public Instack GetCountInstack()
        {
            List<Instack> instack = new List<Instack>();

            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = $@"
select 
(select count (i.INS_TYP) CountIN from INSTACK i where i.INS_TYP = '입고')  CountIN
,(select count (i.INS_TYP) CountOUT  from INSTACK i where i.INS_TYP = '출고') CountOUT
                        ";


                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.Fill(dt);
                instack = Helper.ConvertDataTableToList<Instack>(dt);
            }
            return instack[0];
        }

    }
}