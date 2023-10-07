using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentSaver;

namespace Logger
{
    public class Logger
    { 
        private static Logger instance = null;
        private List<string> Logs = new List<string>();

        private Logger()
        {
        }

        public static Logger GetInstance()
        {
            if (instance == null)
                instance = new Logger();
            return instance;
        }

        public void Log(string str)
        {
            Logs.Add(str);
        }

        public void Save()
        {
            DocumentSaver.DocumentSaver f = DocumentSaver.DocumentSaver.GetInstance();
            f.Save(Logs);

        }

    }
}
