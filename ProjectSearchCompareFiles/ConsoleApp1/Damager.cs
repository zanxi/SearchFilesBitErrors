using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Concurrent;
using System.Xml.Linq;
using System.IO;

namespace ProjectSearchCompareFiles
{
    public class Damager
    {        
        public ConcurrentQueue<InfoResultSearchFile> responses = new ConcurrentQueue<InfoResultSearchFile>();
        //public ConcurrentDictionary<int, string> data = new ConcurrentDictionary<int, string>();                
        String name;
        Thread thr;
        bool ready = true;


        public Damager(string name)
        {
            this.name = name;
            responses = new ConcurrentQueue<InfoResultSearchFile>();
            thr = new Thread(Run);
            thr.Start();
        }

        void Run()
        {
            while(ready)
            {
                if(responses.IsEmpty)
                {
                    Thread.Sleep(1000);
                    continue;
                }
                InfoResultSearchFile iresult;
                responses.TryDequeue(out iresult);
                if(iresult != null)
                {
                    try
                    {
                        //if (iresult.Size > 3000 && iresult.Size < 4000) ;
                        //SavetoFile(iresult);
                    }
                    catch (Exception err)
                    {
                        Util.errorMessage(err.Message, iresult.fileName_brief);
                    }
                }

            }
        }

        public void StopIt()
        {
            ready = false;
        }

        public void AddResponse(InfoResultSearchFile iresult)
        {
            responses.Enqueue(iresult);
        }


        public void SavetoFile(InfoResultSearchFile iresult)
        {
            //DateTime tm = DateTime.Now;
            //string rndStr = "";//Path.GetRandomFileName();            
            string fileNameData = Util.fn;
            XDocument xd = File.Exists(fileNameData) ? XDocument.Load(fileNameData) :
                                                new XDocument(new XElement("table"));
            xd.Root.Add(new XElement("records",
                // измерение оcновным блоком                 
                new XElement("data", "data", new XAttribute("fileName", iresult.fileName),
                                             new XAttribute("fileNameCompare", iresult.fileNameCompare),
                                             new XAttribute("CompareCharacterize", iresult.CompareCharacterize),
                                             new XAttribute("Size", iresult.Size.ToString()),
                                             new XAttribute("Date", iresult.Date.ToString()),
                                             new XAttribute("BitError", iresult.BitError))
                ));
            xd.Save(fileNameData);
        }
    }
}
