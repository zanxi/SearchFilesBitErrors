using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectSearchCompareFiles
{
    public class MonitorCompareFiles
    {
        List<InfoSearch> qe_path = new List<InfoSearch>();
        public ConcurrentQueue<WorkCompare> works = new ConcurrentQueue<WorkCompare>();        
        public List<WorkerCompare> tasks = new List<WorkerCompare>();
        Damager dam;        

        public MonitorCompareFiles()
        {            
            dam = new Damager("AllStatistics");
            for(int i=0; i<6;i++)
            {
                tasks.Add(new WorkerCompare("StatWorker["+i+"]", works,dam));
            }
        }

        public MonitorCompareFiles(List<InfoSearch> qe_path)
        {
            this.qe_path = qe_path;
            dam = new Damager("AllStatistics");
            for (int i = 0; i < 6; i++)
            {
                tasks.Add(new WorkerCompare("StatWorker[" + i + "]", works, dam));
            }

            for (int i = 0; i < qe_path.Count; i++)
            {
                works.Enqueue(new WorkCompare(qe_path[i]));
            }
        }

        void GetNameFile(ConcurrentQueue<string> qe)
        {
            //qe_path = qe;
        }

        public void SetTasks(List<InfoSearch> qe_path)
        {
            for (int i = 0; i < qe_path.Count; i++)
            {
                works.Enqueue(new WorkCompare(qe_path[i]));
            }
        }

        public void StopAll()
        {
            foreach (WorkerCompare wc in tasks) wc.Stop();
            dam.StopIt();

        }

    }
}
