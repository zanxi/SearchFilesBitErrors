using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ProjectSearchCompareFiles
{
    public class WorkCompare
    {
        public InfoSearch isearch;

        public WorkCompare(InfoSearch isearch)
        {
            this.isearch = isearch;
        }

        public long GetFileSize(string file1)
        {
            using (var fs1 = new FileStream(file1, FileMode.Open)) return fs1.Length;
            return (long)0;
        }


        public bool CompareFilesByte(out int numByteWithBitErrors, string file1, string file2)
        {
            lock (XmlLocker)
            {
                numByteWithBitErrors = 0;
                using (var fs1 = new FileStream(file1, FileMode.Open))
                using (var fs2 = new FileStream(file2, FileMode.Open))
                {
                    if (fs1.Length != fs2.Length) return false;
                    int b1, b2;
                    int colBytes = 0;
                    do
                    {
                        b1 = fs1.ReadByte();
                        b2 = fs2.ReadByte();
                        if (Compare2Byte((byte)b1, (byte)b2) > 1) return false;
                        else
                        {
                            numByteWithBitErrors++;
                        }
                    }
                    while (b1 >= 0);
                }
            }
            return true;
        }

        public string HashFile(string file)
        {
            using (var fs = new FileStream(file, FileMode.Open))
            using (var reader = new BinaryReader(fs))
            {
                var hash = new SHA512CryptoServiceProvider();
                hash.ComputeHash(reader.ReadBytes((int)file.Length));
                return Convert.ToBase64String(hash.Hash);
            }
        }

        public bool CompareFilesWithHash(string file1, string file2)
        {
            lock (XmlLocker) {
                var str1 = HashFile(file1);
                var str2 = HashFile(file2);
                return str1 == str2;
            }
        }

        private bool FindTextInFile(string match, string pathFile)
        {
            string text2 = new StreamReader(pathFile).ReadToEnd();             
            if(text2.ToLower().IndexOf(match.ToLower())>0) return true;            
            return false;
        }
        static object XmlLocker =new object();

        public void SavetoFile(InfoResultSearchFile iresult)
        {
            //DateTime tm = DateTime.Now;
            //string rndStr = "";//Path.GetRandomFileName();            

            lock (XmlLocker)
            {
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

        unsafe bool EqualBytesLongUnrolled(byte[] data1, byte[] data2)
        {
            if (data1 == data2)
                return true;
            if (data1.Length != data2.Length)
                return false;

            fixed (byte* bytes1 = data1, bytes2 = data2)
            {
                int len = data1.Length;
                int rem = len % (sizeof(long) * 16);
                long* b1 = (long*)bytes1;
                long* b2 = (long*)bytes2;
                long* e1 = (long*)(bytes1 + len - rem);

                while (b1 < e1)
                {
                    if (*(b1) != *(b2) || *(b1 + 1) != *(b2 + 1) ||
                        *(b1 + 2) != *(b2 + 2) || *(b1 + 3) != *(b2 + 3) ||
                        *(b1 + 4) != *(b2 + 4) || *(b1 + 5) != *(b2 + 5) ||
                        *(b1 + 6) != *(b2 + 6) || *(b1 + 7) != *(b2 + 7) ||
                        *(b1 + 8) != *(b2 + 8) || *(b1 + 9) != *(b2 + 9) ||
                        *(b1 + 10) != *(b2 + 10) || *(b1 + 11) != *(b2 + 11) ||
                        *(b1 + 12) != *(b2 + 12) || *(b1 + 13) != *(b2 + 13) ||
                        *(b1 + 14) != *(b2 + 14) || *(b1 + 15) != *(b2 + 15))
                        return false;
                    b1 += 16;
                    b2 += 16;
                }

                for (int i = 0; i < rem; i++)
                    if (data1[len - 1 - i] != data2[len - 1 - i])
                        return false;

                return true;
            }
        }

        public void BytesCompare()
        {
            MyArray ma = new MyArray();
            //ma.CompareWithArray();
        }

        public bool equals(out int numDifferBytes, byte[] a1, byte[] a2)
        {            
            numDifferBytes = 0;
            if (a1 == a2)
            {
                return true;
            }
            if ((a1 != null) && (a2 != null))
            {
                if (a1.Length != a2.Length)
                {
                    return false;
                }
                for (int i = 0; i < a1.Length; i++)
                {
                    if (Compare2Byte(a1[i], a2[i]) > 1)
                    {
                        return false; // Если ложь не считаем число битовых ошибок
                    }
                    else
                    {
                        if (numDifferBytes > 100) return true;
                        numDifferBytes++;
                    }
                }
                return true;
            }
            return false;
        }

        public bool[] GetBits(byte value)
        {
            bool[] bit = new bool[8];

            bit[0] = (value & 0b1) != 0;
            bit[1] = (value & 0b10) != 0;
            bit[2] = (value & 0b100) != 0;
            bit[3] = (value & 0b1000) != 0;
            bit[4] = (value & 0b1_0000) != 0;
            bit[5] = (value & 0b10_0000) != 0;
            bit[6] = (value & 0b100_0000) != 0;
            bit[7] = (value & 0b1000_0000) != 0;

            return bit;
        }

        public int Compare2Byte(byte value1, byte value2)
        {
            bool[] bit1 = GetBits(value1);
            bool[] bit2 = GetBits(value1);
            int k = 0;
            for (int i = 0; i < 8; i++) if (bit1[i] != bit2[i]) k++;
            return k;
        }
    }

    public class MyArray : System.Collections.ArrayList
    {
        public MyArray()
        {

        }
        public bool CompareWithArray(ArrayList b)
        {

            if (this.Count == 0 && b.Count == 0) return true;
            if (this.Count != b.Count)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < this.Count; i++)
                {
                    if (this[i].Equals(b[i]) == false) return false;
                }
            }
            return true;
        }        
    }    
}
