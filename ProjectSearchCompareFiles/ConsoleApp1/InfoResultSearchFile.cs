using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSearchCompareFiles
{
    public class InfoResultSearchFile
    {
        public string fileName { get; set; } // 
        public string fileNameCompare { get; set; } // 
        public string fileName_brief { get; set; } // 
        public string fileName_dir { get; set; } // 
        public long Size  { get; set; } // 
        public bool Equal { get; set; } // 
        public string CompareCharacterize { get; set; } // 
        public string AlgorithmResult { get; set; } // 
        public string BitError { get; set; } // 

        public DateTime Date { get; set; } // 
                
    }
}
