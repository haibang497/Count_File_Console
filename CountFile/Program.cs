using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountFile
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                String file1Path = @"D:\WorkTGDD\A\C";
                DirectoryInfo directory1 = new DirectoryInfo(file1Path);
                FileInfo[] file1 = directory1.GetFiles("*", SearchOption.AllDirectories);
                Console.Write("Total file in {0}: ", file1Path);
                Console.WriteLine(file1.Length.ToString());

                String file2Path = @"D:\WorkTGDD\B\C";
                DirectoryInfo directory2 = new DirectoryInfo(file2Path);
                FileInfo[] file2 = directory2.GetFiles("*", SearchOption.AllDirectories);
                Console.Write("Total file in {0}: ", file2Path);
                Console.WriteLine(file2.Length.ToString());

                FileCompare fileCompare = new FileCompare();
                bool areIndentical = file1.SequenceEqual(file2, fileCompare);

                if (areIndentical == true)
                {
                    Console.WriteLine("=> Two folders are the same");
                }
                else
                {
                    Console.WriteLine("=> Two folders are not the same");
                }

                //var queryCommonfiles = file1.Intersect(file2, fileCompare);

                //if (queryCommonfiles.Any())
                //{
                //    Console.WriteLine("The following files are in both folders:");
                //    foreach (var v in queryCommonfiles)
                //    {
                //        Console.WriteLine(v.FullName);
                //    }
                //}


                string file_name = "D:\\WorkTGDD\\CountFile\\text.txt";
                StreamWriter streamWriter = new StreamWriter(file_name);
                streamWriter.WriteLine("Total file in {0}: {1}", file1Path, file1.Length);
                streamWriter.WriteLine("Total file in {0}: {1}", file2Path, file2.Length);
                streamWriter.WriteLine("The following files are in folder 1 but not in folder 2:");

                var queryFile1Only = (from file in file1
                                      select file).Except(file2, fileCompare);
                foreach (var v in queryFile1Only)
                {
                    streamWriter.WriteLine(v.FullName);
                }
                streamWriter.Close();
                Console.WriteLine("Success");
            }
            catch
            {
                Console.WriteLine("WARNING!!!!!!!!!: The path is not correct");
            }
            Console.ReadKey();
        }
    }
}
