using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testGZipUnPack
{
    public class GZip
    {
        public static string directoryPath = "D:\\_V2020_\\_src__\\ReadByteFileGzip\\";

        public static void Compress(string filePath)
        {
            using (FileStream inputStream =
                new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                using (FileStream outputStream =
                    new FileStream("D:\\_V2020_\\_src__\\ReadByteFileGzip\\outgzip.gz",
                        FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    using (GZipStream gzip = new GZipStream(outputStream, CompressionMode.Compress))
                    {
                        inputStream.CopyTo(gzip);
                    }
                }
            }
        }

        public static void Compress2(DirectoryInfo directorySelected)
        {
            foreach (FileInfo fileToCompress in directorySelected.GetFiles())
            {
                using (FileStream originalFileStream = fileToCompress.OpenRead())
                {
                    if ((File.GetAttributes(fileToCompress.FullName) &
                       FileAttributes.Hidden) != FileAttributes.Hidden & fileToCompress.Extension != ".gz")
                    {
                        using (FileStream compressedFileStream = File.Create(fileToCompress.FullName + ".gz"))
                        {
                            using (GZipStream compressionStream = new GZipStream(compressedFileStream,
                               CompressionMode.Compress))
                            {
                                originalFileStream.CopyTo(compressionStream);
                            }
                        }
                        FileInfo info = new FileInfo(directoryPath + Path.DirectorySeparatorChar + fileToCompress.Name + ".gz");
                        Logger.LogArcGzip($"Compressed {fileToCompress.Name} from {fileToCompress.Length.ToString()} to {info.Length.ToString()} bytes.");
                    }
                }
            }
        }

        public static void Decompress(FileInfo fileToDecompress)
        {
            using (FileStream originalFileStream = fileToDecompress.OpenRead())
            {
                string currentFileName = fileToDecompress.FullName;
                string newFileName = currentFileName.Remove(currentFileName.Length - fileToDecompress.Extension.Length);

                using (FileStream decompressedFileStream = File.Create(newFileName))
                {
                    using (GZipStream decompressionStream = new GZipStream(originalFileStream, CompressionMode.Decompress))
                    {
                        decompressionStream.CopyTo(decompressedFileStream);
                        Logger.LogArcGzip($"Decompressed: {fileToDecompress.Name}");
                    }
                }
            }
        }



        // 3 март 2020
        // https://csharp.hotexamples.com/ru/examples/System.IO.Compression/GZipStream/CopyTo/php-gzipstream-copyto-method-examples.html


        public static void DecompressFile(string file)
        {
            byte[] buffer;
            using (var fileStream = File.OpenRead(file))
            {
                using (var compressedStream = new GZipStream(fileStream, CompressionMode.Decompress))
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        try
                        {
                            compressedStream.CopyTo(memoryStream);
                            memoryStream.Seek(0, SeekOrigin.Begin);
                            buffer = new byte[memoryStream.Length];
                            memoryStream.Read(buffer, 0, (int)memoryStream.Length);
                        }
                        catch (Exception e)
                        {
                            throw;
                        }
                    }
                }
            }

            File.Create(file+".txt").Close();
            File.WriteAllBytes(file, buffer);
        }

        private void PartBufferArcivate(string filePath, byte[] buffer)
        {
            using (FileStream inputStream =
                new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                using (MemoryStream memStream = new MemoryStream())
                {
                    using (GZipStream gz = new GZipStream(memStream, CompressionMode.Compress))
                    {
                        gz.Write(buffer, 0, buffer.Length);
                        inputStream.CopyTo(gz);
                    }
                    byte[] compressData = memStream.ToArray();
                    memStream.Flush();




                    using (FileStream outputStream =
                        new FileStream("D:\\_V2020_\\_src__\\ReadByteFileGzip\\outgzip.gz",
                            FileMode.OpenOrCreate, FileAccess.ReadWrite))
                    using (GZipStream gzip = new GZipStream(outputStream, CompressionMode.Compress))
                    {
                        
                    }

                }
            }

        }

        public static void CompressBlockByteToFile(string filePath, byte[] bytesToCompress)
        {
            FileInfo fileInfo = new FileInfo(filePath);
            //fileInfo.                      

            using (FileStream fileToCompress = File.Create(filePath))
            {
                //if ((File.GetAttributes(fileInfo.FullName) & FileAttributes.Hidden) 
                //    != FileAttributes.Hidden & fileInfo.Extension != ".gz")
                //if (fileInfo.Extension != ".gz")
                {
                    using (GZipStream compressionStream = new GZipStream(fileToCompress, CompressionMode.Compress))
                    {
                        compressionStream.Write(bytesToCompress, 0, bytesToCompress.Length);
                    }
                }
            }
                                             
            //using (FileStream outputStream =
            //    new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            //{

            //    using (GZipStream gz = new GZipStream(outputStream, CompressionMode.Compress))
            //    {
            //        gz.Write(buffer, 0, buffer.Length);
            //        //inputStream.CopyTo(gz);
            //    }
            //}                            

        }

        public static byte[] Decompress(string path,int lengthBytesToCompress)
        {
            byte[] decompressedBytes = new byte[lengthBytesToCompress];
            using (FileStream fileToDecompress = File.Open(path, FileMode.Open))
            {
                using (GZipStream decompressionStream = new GZipStream(fileToDecompress, CompressionMode.Decompress))
                {
                    decompressionStream.Read(decompressedBytes, 0, lengthBytesToCompress);
                    return decompressedBytes;
                }
            }
        }


    }
}
