using System;
using System.IO;
namespace ConsoleApp8Task2
{
    public static class DirExtension
    {
        public static long DirSize(string URL)
        {
            DirectoryInfo dir = new DirectoryInfo(URL);
            long size = 0;
            FileInfo[] fis = dir.GetFiles();
            foreach (FileInfo fi in fis)
            { size += fi.Length; }


            DirectoryInfo[] dis = dir.GetDirectories();
            foreach (DirectoryInfo di in dis)
            { size += DirSize(di.FullName); }
            return size;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            string path = @"/Semenkina/task1"; //Зададим папку

            try
            {
                if (Directory.Exists(path))
                {
                    Console.WriteLine();
                    Console.WriteLine("Размер папки {0} вместе со всеми вложенными папками и файлами: {1} байт.", path, DirExtension.DirSize(path));

                }
                else
                {
                    Console.WriteLine($"Папка c адресом  {path} - не существует.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}