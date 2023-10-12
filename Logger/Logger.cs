using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentSaver;
using System.Windows.Forms;

namespace Logger
{
    public class Logger
    { 
        private static Logger instance = null;
        private List<string> Logs = new List<string>();
        public ListBox listBox;

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

        public void ShowLogs()
        {
            listBox.Items.Clear();
            foreach (string log in Logs)
            {
                listBox.Items.Add(log);
            }
            listBox.Items.Add("");
        }
    }
}
