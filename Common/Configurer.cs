using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace KYRobotTool
{
    public static class Configurer
    {
        #region interface
        public static string getTagValue(string filePath, string tagName)
        {            
            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);             
            return doc.SelectSingleNode("Configure").SelectSingleNode(tagName).InnerText;
        }

        public static string getTagValue(string filePath, string tagName, string subTagName)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);
            return doc.SelectSingleNode("Configure").SelectSingleNode(tagName).SelectSingleNode(subTagName).InnerText;
        }

        #endregion interface
    }
}
