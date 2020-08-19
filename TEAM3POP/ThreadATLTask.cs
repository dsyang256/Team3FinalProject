using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;
using TEAM3FINAL;

namespace TEAM3POP
{
    //별도의 쓰레드로 수신만 담당할 클래스
    public class ThreadATLTask
    {
        public delegate void ReadDataEvent(object sender, ReadDataEventAgrs e);
        public event ReadDataEvent ReadData;

        Thread m_Thread;
        ManualResetEvent m_ThreadTerminateRequest = new ManualResetEvent(false);
        readonly object m_ThreadLock = new object();

        LoggingUtility _loggingUtility;
        LoggingUtility Log { get { return _loggingUtility; } }

        TCPControl t_client;
        NetworkStream recvData;
        SqlConnection conn;
        int interval;

        readonly string STX = ((char)2).ToString();
        readonly string ETX = ((char)3).ToString();
        string RECV_TMP_DATA = string.Empty;

        public ThreadATLTask(SqlConnection _conn, LoggingUtility __loggingUtility, int timer_Read)
        {
            conn = _conn;
            _loggingUtility = __loggingUtility;
            interval = timer_Read;
        }

        public void ThreadStart()
        {
            // Thread
            m_ThreadTerminateRequest.Reset();
            
            m_Thread = new Thread(new ThreadStart(ExecuteThreadJob));
            m_Thread.Name = string.Format("ThreadATLTask");

            m_Thread.Start();
        }

        /// <summary> Thread 종료 </summary>
        public void ThreadTerminate()
        {
            //lock (m_ThreadLock)
            //{
                // Thread 종료
                m_Thread.Abort();
                this.m_ThreadTerminateRequest.Set();
            //}
        }

        /// <summary>
        /// Thread로 구동되면서 DoingSchedule 함수를 수행한다.
        /// </summary>
        private void ExecuteThreadJob()
        {
            while (!this.m_ThreadTerminateRequest.WaitOne(interval))
            {
                try
                {
                    lock (m_ThreadLock)
                    {
                        // 실제 Thread에 필요한 코드 수행                        
                        DoingSchedule();
                    }
                }
                catch (Exception ex)
                {
                    this.Log.WriteError("쓰레드 실행 중 오류 : " + ex.Message);
                }
            }
        }

        public void SettingClient(TCPControl client)
        {
            t_client = client;
            recvData = t_client.client.GetStream();
        }

        public void ClearClient()
        {
            if (t_client != null)
            {
                t_client.dataStream.Close();
                t_client.client.Close();
            }
        }

        /// <summary>
        /// 수신된 데이터를 찍어주고, DB에 전송한다.
        /// </summary>
        private void DoingSchedule()
        {
            string lsRecvData;
            int liCnt;
            string lsTmpData;
            string[] laData;

            try
            {
                if (t_client == null || !t_client.client.Connected)
                    return;

                if (t_client.client.Available > 0)
                {
                    byte[] rcvTemp = new byte[t_client.client.Available];
                    recvData.Read(rcvTemp, 0, rcvTemp.Length);
                    string readData = UTF7Encoding.UTF7.GetString(rcvTemp);

                    this.Log.WriteInfo($"[RECV] : {readData}");

                    RECV_TMP_DATA += readData;

                    liCnt = RECV_TMP_DATA.IndexOf(STX);
                    if (liCnt >= 0)
                    {
                        lsRecvData = RECV_TMP_DATA.Substring(liCnt);
                        if (lsRecvData.Substring(0, 1) == STX)
                        {
                            while (true)
                            {
                                liCnt = lsRecvData.IndexOf(ETX);
                                if (liCnt >= 0)
                                    lsTmpData = lsRecvData.Substring(0, liCnt);
                                else
                                    break;

                                // ========= 도착한 데이타 처리 ===================
                                //lsTmpData = STX|Date|TaskID|ProductID|Qty|BadQty|ETX
                                //lsTmpData = STX|x|ETX

                                laData = lsTmpData.Split('|');
                                if (laData.Length < 7) break;

                                if (ReadData != null)
                                {
                                    ReadDataEventAgrs args = new ReadDataEventAgrs();
                                    args.Data = $"[{laData[1]}] |{laData[2]}|{laData[3]}|{laData[4]}|{laData[5]}";
                                    ReadData(null, args);
                                }

                                switch (laData[1])
                                {
                                    case "X":
                                    case "x":   //KeepArrive 수신 처리
                                        //KEEP_ARRIVE_COUNT = 0;
                                        break;
                                    case "RESET":
                                    case "reset":
                                        break;
                                    default:
                                        //_SetValue($"[{laData[1]}] |{laData[2]}|{laData[3]}|{laData[4]}|{laData[5]}");
                                        break;
                                }

                                lsRecvData = lsRecvData.Substring(liCnt + 1);
                                liCnt = lsRecvData.IndexOf(STX);
                                if (liCnt >= 0)
                                {
                                    lsRecvData = lsRecvData.Substring(liCnt);
                                    RECV_TMP_DATA = lsRecvData;
                                }
                                else
                                {
                                    if (lsRecvData.Length > 0)
                                    {
                                        lsRecvData = lsRecvData.Substring(0);
                                        RECV_TMP_DATA = lsRecvData;
                                    }
                                }
                                if (string.IsNullOrEmpty(lsRecvData.Trim()))
                                {
                                    RECV_TMP_DATA = string.Empty;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception err)
            {
                Log.WriteError($"[RECV중 오류]:{err.Message}");
                if (err.Message.Contains("Connection Error") || err.Message.Contains("개체"))
                {
                    throw new Exception(err.Message);
                }
            }
            finally
            {
                Thread.Sleep(100);
            }
        }

        private void IF_SetValue(string sRecvData)
        {
            string strCALL_MSG = string.Empty;
            try
            {
                string[] arrData = sRecvData.Split('|');
                if (arrData.Length == 5)
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "insert into WorkQtyLog(ProductID, TaskID, Qty, BadQty) values (@ProductID, @TaskID, @Qty, @BadQty)";

                        cmd.Parameters.AddWithValue("@ProductID", int.Parse(arrData[2]));
                        cmd.Parameters.AddWithValue("@TaskID", int.Parse(arrData[1]));
                        cmd.Parameters.AddWithValue("@Qty", int.Parse(arrData[3]));
                        cmd.Parameters.AddWithValue("@BadQty", int.Parse(arrData[4]));

                        cmd.ExecuteNonQuery();


                    }
                }
            }
            catch (Exception err)
            {
                this.Log.WriteError($"[[RECV DB 저장중오류]]:{err.Message}");

                if (strCALL_MSG.Contains("Connection Error") || err.Message.Contains("개체"))
                {
                    throw new Exception(strCALL_MSG);
                }
            }
        }
    }

    public class ReadDataEventAgrs : EventArgs
    {
        public string Data { get; set; }
    }
}
