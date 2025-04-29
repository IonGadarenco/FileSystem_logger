using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem_logger.Service
{
    internal class FileLogger
    {
        public static async Task Log(string methodName, string outcome)
        {
            string executionDate = DateTime.Now.ToString("dd-MM-yy");
            string executionDateTime = DateTime.Now.ToString("dd/MM/yy HH:mm:ss");
            string filePath = @$"C:\Users\PC\Desktop\internship_tasks\FileSystem_logger\Logs\Logs_{executionDate}.txt";

            if (!File.Exists(filePath))
                using (File.Create(filePath)) { } ;

            using (StreamWriter sw = new StreamWriter(filePath, true)) 
            {
                await sw.WriteLineAsync ($"[ {executionDateTime} ] -> {methodName} -> [ {outcome} ];");
            }
        }
    }
}
