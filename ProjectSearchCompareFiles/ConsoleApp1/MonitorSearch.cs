using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectSearchCompareFiles
{
    public class MonitorSearch
    {
        public List<InfoSearch> qe_path = new List<InfoSearch>();
        public ConcurrentQueue<InfoSearch> qe_path2 = new ConcurrentQueue<InfoSearch>();
        private InfoSearch isearch=null;
        private long numFolder=0;
        Thread thr;
        bool ready = true;
        bool stop = false;

        public List<InfoSearch> GetPathFiles()
        {
            return qe_path;
        }

        public long GetCountFiles()
        {
            return qe_path.Count;
        }

        public bool GetReady()
        {
            return ready;
        }

        public void StopSearchInFolders()
        {
            stop=true;
        }


        public MonitorSearch(InfoSearch isearch)
        {
            this.isearch = isearch;

            thr = new Thread(Run);
            thr.Start();
        }

        InfoSearch Copy(InfoSearch isearch)
        {
            InfoSearch iss=new InfoSearch();

            iss.Filecompare = isearch.Filecompare;
            iss.FilecompareSize = isearch.FilecompareSize;
            iss.FlagSearchInSubFolders = isearch.FlagSearchInSubFolders;
            iss.Maskfile = isearch.Maskfile;
            iss.Foldersearch = isearch.Foldersearch;
            iss.Textsearchinfile = isearch.Textsearchinfile;
            //isearch.algorithm = checkBox_Bytes.Checked || checkBox_Hash.Checked;
            iss.MaxSizeSearch = isearch.MaxSizeSearch;

            return iss;
        }

        public void FindInDir(DirectoryInfo dir, string pattern, bool recursive)
        {                       
            foreach (FileInfo file in dir.GetFiles(pattern))
            {
                InfoSearch iss= Copy(isearch);
                iss.FileName = file.FullName;
                iss.FileName_dir = file.DirectoryName;
                iss.FileName_brief = file.Name;
                qe_path.Add(iss);
                qe_path2.Enqueue(iss);
                ProjectSearchCompareFiles.Data.isearch.Add(iss);
                //Util.message(file.FullName);
                numFolder++;
                if (stop) return;
                
            }
            if (recursive)
            {
                foreach (DirectoryInfo subdir in dir.GetDirectories())
                {
                    if (stop) return;
                    this.FindInDir(subdir, pattern, recursive);
                }
            }            
        }

        void Run()
        {
            numFolder = 0;
            ready = true;
            ProjectSearchCompareFiles.Data.isearch.Clear();
            DirectoryInfo dir = new DirectoryInfo(isearch.Foldersearch);
            FindInDir(dir, isearch.Maskfile, isearch.FlagSearchInSubFolders);//если нажат чекбокс, то поиск будет идти только в заданной папке
            ready = false;
        }        
    }
}
