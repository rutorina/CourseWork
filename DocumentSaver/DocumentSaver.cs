using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DocumentSaver
{
    public class DocumentSaver
    {
        private static DocumentSaver instance = null;

        private DocumentSaver()
        {
        }

        public static DocumentSaver GetInstance()
        {
            if (instance == null)
                instance = new DocumentSaver();
            return instance;
        }

        public void Save(List<string> logs)
        {
            string folder = @"E:\!College\KPZ\SingletonDesignPattern\DocumentSaver\text.txt";
            File.WriteAllLines(folder, logs);
        }
    }
}
