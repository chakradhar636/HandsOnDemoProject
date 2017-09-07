using CDK.Data.OIP.API;
using FlatToXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Final
{


    public class NewClass
    {
        public static string ApplicationName = "TestBMW";
        public static string TransactionType = "ServiceAppointment";
        public static int ActivationCode = 48643;
        private static Timer t;
        public static Guid guid;
        private static int count;
        public static void Main(String[] args)
        {
            guid = Guid.NewGuid();
            Console.WriteLine("GUID : "+guid);
            Console.WriteLine("We are in main ()");
            try
            {
                string sourcepath = @"C:\Users\donuric\Desktop\InputFiles";
                string destinationpath = @"C:\Users\donuric\Desktop\OutputFiles\";
                string movepath = @"C:\Users\donuric\Desktop\MovedFiles\";
                string[] Filenames = Directory.GetFiles(sourcepath);
                int len = Directory.GetFiles(destinationpath).Length;
                string filepath = Filenames[0];
                string ext = Path.GetExtension(filepath);

                if (ext == ".dat")
                {
                    TimePoints.MarkFirst(ApplicationName, TransactionType, guid.ToString(), ActivationCode);

                    Console.WriteLine("We found " + ext + " file");
                    //Console.WriteLine("Count : {0}", count);
                    string text = System.IO.File.ReadAllText(filepath);
                    Test obj = new Test();
                    count++;
                    Console.WriteLine("Converting " + ext + " file" + " to .xml file");
                    //Console.WriteLine(guid.ToString());


                    obj.Convert(filepath, text, destinationpath + "New" + count + ".xml", movepath + "PO" + count + ".dat", guid.ToString(), ApplicationName);
                    Console.WriteLine(count);

                }
                
            }
            catch
            {
                Console.WriteLine("No files left in input folder");
            }
        }
    }
}