using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSearchCompareFiles
{
    public class Data
    {
        public static List<InfoSearch> isearch = new List<InfoSearch>();
        public static List<InfoResultSearchFile> iresult = new List<InfoResultSearchFile>();
    }

    public class InfoSearch
    {
        public string Maskfile { get; set; } // маска поиска
        public string Foldersearch { get; set; } // папка поиска
        public bool FlagSearchInSubFolders { get; set; } // папка поиска
        public string Filecompare{ get; set; } // адрес файла для сравнения
        public long FilecompareSize { get; set; } // адрес файла для сравнения
        public string FileName { get; set; } // адрес файла для сравнения
        public string FileName_dir { get; set; } // адрес файла для сравнения
        public string FileName_brief { get; set; } // адрес файла для сравнения
        public string Textsearchinfile { get; set; } // текст для поиска в файлах
        public byte algorithm { get; set; } // номер выбранного алгоритма сранения
        public long MaxSizeSearch { get; set; } // максимальный размер файла для поиска 10b...10Mb
    }

    public class OptionsCompare
    {
        public string Maskfile { get; set; } // маска поиска
        public string Foldersearch { get; set; } // папка поиска
        public bool FlagSearchInSubFolders { get; set; } // папка поиска
        public string Filecompare { get; set; } // адрес файла для сравнения
        public string Textsearchinfile { get; set; } // текст для поиска в файлах
        public byte algorithm { get; set; } // номер выбранного алгоритма сранения
        public long MaxSizeSearch { get; set; } // максимальный размер файла для поиска 10b...10Mb
    }
}
