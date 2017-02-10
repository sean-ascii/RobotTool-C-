using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.Diagnostics;

namespace KYRobotTool
{
    public static class Logger
    {
        #region field
        private static StreamWriter textWriter;
        private static object syncObject = new object();
        #endregion field


        #region interface
        public static void Logging(string logConent, LogLevel logLevel = LogLevel.INFO)
        {
            lock(syncObject)
            {
                string logText = String.Format("Time:{0} Level:{1} Message:{2}：{3}",
                                                System.DateTime.Now.ToString("y-m-d_h:m:s"),
                                                Enum.GetName(typeof(LogLevel), logLevel),
                                                (new StackTrace()).GetFrame(1).GetMethod().ReflectedType.Name,
                                                logConent);
                textWriter.WriteLine(logText);
                textWriter.Flush();
            }
        }        
        
        #endregion interface


        #region base method
        static Logger()
        {
            string currentDate = System.DateTime.Now.ToLocalTime().ToString("yy-MM-dd_hh-mm-ss");
            textWriter = new StreamWriter(@"Solution\Trace\" + currentDate + ".log", true);
        }
        #endregion base method

        #region datatype
        public enum LogLevel
        {
            DEBUG = 0,
            INFO = 1,
            WARN = 2,
            ERROR = 3            
        }
        #endregion datetype
    }
}
