using cryptography;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TEAM3POP
{
    /// <summary>
    /// XML에서 configuration key를 읽어와서 connection을 만드는 클래스
    /// </summary>
    public class ConnectionAccess //명시적으로 new 방지 // 추상클래스
    {
        /// <summary>
        /// XML 파일을 읽어오는 프로퍼티
        /// </summary>
       public string ConnectionString
        {
            get
            {
                string connStr = string.Empty;

                XmlDocument configXml = new XmlDocument();
                configXml.Load(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "/LibraryConfig.xml"); //전체 풀경로 Assembly.GetExecutingAssembly().Location) 로 디렉토리까지 가져옴
                XmlNodeList addNodes = configXml.SelectNodes("configuration/settings/add"); //노드의 리스트를 반환 (등록된 여러개의 경로)
                foreach (XmlNode xmlNode in addNodes)
                {
                    if (xmlNode.Attributes["key"].InnerText == "MyDB1") //XML의 attribute중 key를 가져옴  <add key="MyDB" ... > //MyDB 가져옴
                    {
                        connStr = ((XmlCDataSection)xmlNode.ChildNodes[0]).InnerText; //< add> ~~ </ add > 0번째 childNode의 innerText를 가져옴
                        break;
                    }
                }
                 AESSalt salt = new AESSalt();
                return  salt.Decrypt(connStr);
            }
        }

    }
}
