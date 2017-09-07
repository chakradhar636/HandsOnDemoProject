using System;
using System.IO;
using System.Timers;
using XMLTOFLAT;
using CDK.Data.OIP.API;
using FlatToXml;

namespace Fina
{
    public class MyClass
    {
        public static string ApplicationName = "TestBMW";
        public static string TransactionType = "ServiceAppointment";
        public static int ActivationCode = 48643;
        private static Timer t;
        public static Guid guid;
        private static int count;

        //public static void Main(String[] args)
        //{
        public static void a() { 

            guid = Guid.NewGuid();
            Console.WriteLine(guid);
            
            t = new System.Timers.Timer();
            t.Elapsed += OnProcess;
            t.Enabled = true;
            t.Interval = 3000;
           
            Console.WriteLine("Timer has Started");
            Console.ReadLine();

        }

        private static void OnProcess(object sender, ElapsedEventArgs e)
        {

            try {
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
                    Console.WriteLine("Count : {0}", count);
                    string text = System.IO.File.ReadAllText(filepath);
                    Test obj = new Test();
                    count++;
                    Console.WriteLine("Converting " + ext + " file" + " to .xml file");
                    //Console.WriteLine(guid.ToString());
                    

                    obj.Convert(filepath, text, destinationpath + "New" + count + ".xml", movepath + "PO" + count + ".dat",guid.ToString(),ApplicationName);
                    Console.WriteLine(count);

                }
                //if (ext == ".xml")
                //{
                //    Console.WriteLine("We found " + ext + " file");
                //    Console.WriteLine("Count : {0}", count);
                //    XMLTOFLAT.Class1 obj1 = new XMLTOFLAT.Class1();
                //    //Class1 obj1 = new Class1();
                //    count1++;
                //    Console.WriteLine("Converting " + ext + " file" + " to .dat file");
                //    XMLTOFLAT.Class1.convert2(filepath, destinationpath + "PD" + count1 + ".dat", movepath + "PD" + count1 + ".xml");
                //    Console.WriteLine(count1);
                //}

                //Console.WriteLine("Converting PO.dat file to fresh.xml");

                Console.WriteLine(e.SignalTime);
            }
            catch
            {
                Console.WriteLine("No files left in input folder");
            }
            }


    }
}
