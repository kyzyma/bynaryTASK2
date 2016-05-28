using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.SqlClient;

namespace Singleton
{


    static class Logger
    {
        public static void Info(IWriteLog s, string mes)
        {
            s.WriteTextLog(mes);
        }

        public static void Debug(string s)
        {
            Console.WriteLine(s +'\n');
        }

        public static void Warning(IWriteLog s, string mes)
        {
            s.WriteTextLog(mes);
        }

        public static void Error(IWriteLog s, string mes)
        {            
            s.WriteTextLog(mes);
        }

     /*   public void HandlerUserEvent(IWriteLog s, string mes)
        {            
            s.WriteTextLog(mes);
        }
*/
        
    }
}
