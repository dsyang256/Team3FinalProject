using System;
using System.Net.Sockets;
using System.Reflection;

namespace TEAM3POP
{
    public class TCPControl
    {
        public TcpClient client;
        public NetworkStream dataStream;

        public TCPControl(string host, int port)
        {
            client = new TcpClient(host, port);
            dataStream = client.GetStream();
        }

        /// <summary>
        /// 메세지 전송
        /// </summary>
        /// <param name="data"></param>
        public bool Send(byte[] data)
        {
            try
            {
                dataStream.Write(data, 0, data.Length);
                dataStream.Flush();
                return true;
            }
            catch
            {
                //Program.Log.WriteError($"[{MethodBase.GetCurrentMethod().Name}]:{err.Message}", err);
                return false;
            }
        }


        /// <summary>
        /// 접속상태 체크
        /// </summary>
        /// <returns></returns>
        public bool CheckClientConnection()
        {
            bool bClientStatus = false;
            try
            {
                if (client != null && client.Client != null && client.Client.Connected)
                {
                    if (client.Client.Available == 0 && client.Client.Poll(1000, SelectMode.SelectError))
                        bClientStatus = false;
                    else
                        bClientStatus = true;
                }

                return bClientStatus;
            }
            catch
            {
                return false;
            }
        }
    }
}
