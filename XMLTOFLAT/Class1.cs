using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XMLTOFLAT
{
    public class Class1
    {
        public static void convert2(string sourcepath,string destinationpath,string movedpath)
        {


            //string values = "";
            StringBuilder str = new StringBuilder("");
            using (XmlReader reader = XmlReader.Create(sourcepath))
            {
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        //string s = reader.ReadString().ToString();
                        //string h = reader.Name.ToString();
                        StringBuilder s1 = new StringBuilder(reader.Name);
                        StringBuilder s2 = new StringBuilder(reader.ReadString());
                        str = str.Append(s1 + " : " + s2 + "/n");
                        //values += (h.Trim() + " : " + s.Trim() + "/n");

                    }
                }
            }

            //values = values.Replace("/n", Environment.NewLine);
            //File.WriteAllText(@"C:\Users\donuric\Desktop\Output2.txt", values);
            //Console.WriteLine(values);
            str = str.Replace("/n", Environment.NewLine);
            File.WriteAllText(destinationpath, str.ToString());
            Console.WriteLine("Converted Successfully");
            File.Move(sourcepath, movedpath);
            //Console.WriteLine(str);
            Console.ReadLine();
        }
    }
}