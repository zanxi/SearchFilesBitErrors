using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSearchCompareFiles
{
    public class Util
    {
        public static List<string> messageLine = new List<string>();
        public static string fn = AppDomain.CurrentDomain.BaseDirectory + "saveSataticticsSearch.xml";
        public static string fn_CheckSearck = AppDomain.CurrentDomain.BaseDirectory + "saveCheckSearch.xml";
        public static bool debug = false;
        public static string name;
        public static string description;
        public static string path;
        //public static Project project = null;

        static public void errorMessage(string message1, string message2)
        {
            DateTime tm = DateTime.Now;

            lock (messageLine)
            {
                messageLine.Add(item: tm.GetDateTimeFormats()[12] + ":" + tm.Second + "." + tm.Millisecond + " ---- Ошибка " + message1 + " --> " + message2 + "\n");
            }
        }
        static public void message(string message)
        {
            DateTime tm = DateTime.Now;
            lock (messageLine)
            {
                messageLine.Add(tm.GetDateTimeFormats()[12] + ":"+tm.Second+"."+tm.Millisecond+"  ----- " + message + "\n");
            }
        }

    }
}
