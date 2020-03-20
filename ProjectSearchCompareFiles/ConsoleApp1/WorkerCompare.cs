using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectSearchCompareFiles
{
    public class iWorkerCompare
    {
        public object lock_=new object();
    }

    public class WorkerCompare : iWorkerCompare
    {
        string nameWorker = "";        
        Damager dam;
        bool ready = true;
        ConcurrentQueue<WorkCompare> works;

        Thread thr;

        public WorkerCompare(string nameWorker, ConcurrentQueue<WorkCompare> works, Damager dam)
        {
            this.nameWorker = nameWorker;
            this.works = works;
            this.dam = dam;
            thr = new Thread(Run);
            thr.Start();
        }

        public void Stop()
        {
            ready = false;
        }

        void Run()
        {
            while (ready)
            {
                if (works.IsEmpty)
                {
                    Thread.Sleep(500);
                    continue;
                }

                WorkCompare work;
                works.TryDequeue(out work);
                if (work != null)
                {
                    try
                    {
                        lock (lock_)
                        {
                            InfoResultSearchFile iresult = new InfoResultSearchFile();
                            iresult.fileName = work.isearch.FileName;
                            iresult.fileNameCompare = work.isearch.Filecompare;
                            iresult.fileName_brief = work.isearch.FileName_brief;
                            iresult.Size = work.GetFileSize(work.isearch.FileName);
                            iresult.CompareCharacterize = "--fulling-- compare | ";
                            iresult.CompareCharacterize += ((work.CompareFilesWithHash(work.isearch.Filecompare, work.isearch.FileName))?"hash not equal": "hash equal") + " | ";
                            int _numByteWithBitErrors = 0;
                            bool bitErr=work.CompareFilesByte(out _numByteWithBitErrors, work.isearch.Filecompare, work.isearch.FileName);
                            iresult.CompareCharacterize += ((bitErr) ? "byte not equal" : "byte equal") + " | ";
                            iresult.BitError = (!bitErr) ? "0": _numByteWithBitErrors.ToString();
                            //iresult.BitError = "0";
                            iresult.Date = DateTime.Now;

                            //if (iresult.Size > 30000 && iresult.Size < 40000)
                            //Util.message("[" + nameWorker + "] -- " +
                            Util.message(
                            iresult.fileName_brief + " | " +
                            iresult.CompareCharacterize + " | " +
                            iresult.BitError + " | " +
                            iresult.Size.ToString());

                            //if (iresult.Size > 30000 && iresult.Size < 40000) 
                            dam.AddResponse(iresult);

                            //if (iresult.Size > 30000 && iresult.Size < 40000) 
                            work.SavetoFile(iresult);
                            //work.GetBytesFromFile();
                        }
                    }
                    catch(Exception err)
                    {
                        Util.errorMessage(err.Message, work.isearch.FileName_brief);
                    }
                }
            }
        }
    }
}
