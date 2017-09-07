using FileHelpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using CDK.Data.OIP.API;
using static FlatToXml.Data;

namespace FlatToXml
{
    public class Test
    {
        public void Convert(string sourcepath, string text, string destinationpath, string movedpath,string guid,string ApplicationName)
        {
            TimePoints.MarkNext(ApplicationName, guid.ToString(), 2);

            //string[] str1 = text.Split(':');
            //int val1 = text.IndexOf("PO.IDENT");
            //int val2 = text.IndexOf("PO.HEADER");

            //string x = text.Substring(val1+9,val2-10);
            //Console.WriteLine(val1);
            //Console.WriteLine(val2);
            // Console.WriteLine(x);
            XElement ApplicationArea = new XElement("Application_Area");
            foreach (String ln in File.ReadAllLines(sourcepath))
            {//<-- read lines
                string[] str2 = ln.Split(':');
                if (str2[0].Equals("PO.IDENT"))
                {
                    var engine = new FileHelperEngine<POIDENT>();
                    //Console.WriteLine(str1[0]);
                    var records = engine.ReadString(str2[1]);
                    //Console.WriteLine(records);

                    foreach (var record in records)
                    {
                        XElement PO_IDENT = new XElement("PO.IDENT", record.CreatorNameCode == "" ? null : new XElement("CreatorNameCode", record.CreatorNameCode),
                            record.CreatorSoftwareCode == "" ? null : new XElement("CreatorSoftwareCode", record.CreatorSoftwareCode),
                            record.InterfaceVersion == "" ? null : new XElement("InterfaceVersion", record.InterfaceVersion),
                            record.TransactionCreateDate == "" ? null : new XElement("TransactionCreateDate", record.TransactionCreateDate),
                            record.TransactionCreateTime == "" ? null : new XElement("TransactionCreateTime", record.TransactionCreateTime),
                            record.DealerNumber == "" ? null : new XElement("DealerNumber", record.DealerNumber),
                            record.StoreNumber == "" ? null : new XElement("StoreNumber", record.StoreNumber),
                            record.AreaNumber == "" ? null : new XElement("AreaNumber", record.AreaNumber),
                            record.DestinationNameCode == "" ? null : new XElement("DestinationNameCode", record.DestinationNameCode),
                            record.DestinationSoftware == "" ? null : new XElement("DestinationSoftware", record.DestinationSoftware),
                            record.TransactionTypeCode == "" ? null : new XElement("TransactionTypeCode", record.TransactionTypeCode),
                            record.DealerCountry == "" ? null : new XElement("DealerCountry", record.DealerCountry),
                            record.ReferenceID == "" ? null : new XElement("ReferenceID", record.ReferenceID),
                            record.SenderPartyID == "" ? null : new XElement("SenderPartyID", record.SenderPartyID),
                            record.SenderLocationID == "" ? null : new XElement("SenderLocationID", record.SenderLocationID));
                        //Console.WriteLine(PO_IDENT);
                        ApplicationArea.Add(PO_IDENT);
                    }
                }
                if (str2[0].Equals("PO.HEADER"))
                {
                    var engine = new FileHelperEngine<POHEADER>();
                    //Console.WriteLine(str1[0]);
                    var records = engine.ReadString(str2[1]);
                    //Console.WriteLine(records);

                    foreach (var record in records)
                    {

                        XElement PO_HEADER = new XElement("PO.HEADER", record.PartOrderNumnber == "" ? null : new XElement("Part_Order_Number", record.PartOrderNumnber),
                            record.PartsOrderType == "" ? null : new XElement("Parts_Order_Type", record.PartsOrderType),
                            record.Item == "" ? null : new XElement("Item", record.Item),
                            record.PartsOrderAllowShipment == "" ? null : new XElement("Parts_Order_Allowback", record.PartsOrderAllowback),
                            record.PartsOrderAllowShipment == "" ? null : new XElement("Parts_Order_AllowShipment", record.PartsOrderAllowShipment),

                            record.PartsOrderPriority == "" ? null : new XElement("Parts_Order_Priority", record.PartsOrderPriority));
                        //Console.WriteLine(PO_HEADER);
                        ApplicationArea.Add(PO_HEADER);

                    }
                }
                if (str2[0].Equals("PO.BILLTO"))
                {
                    var engine = new FileHelperEngine<POBILLTO>();
                    //Console.WriteLine(str1[0]);
                    var records = engine.ReadString(str2[1]);
                    //Console.WriteLine(records);

                    foreach (var record in records)
                    {
                        XElement PO_BILLTO = new XElement("PO.BILLTO", record.CompanyName == "" ? null : new XElement("Company_Name", record.CompanyName),
                            record.Address == "" ? null : new XElement("Address", record.Address),
                            record.City == "" ? null : new XElement("City", record.City),
                            record.State == "" ? null : new XElement("State", record.State),
                            record.ZIP == "" ? null : new XElement("ZIP", record.ZIP));
                        //Console.WriteLine(PO_BILLTO);
                        ApplicationArea.Add(PO_BILLTO);

                    }
                }
                if (str2[0].Equals("PO.SHIPTO"))
                {
                    var engine = new FileHelperEngine<POSHIPTO>();
                    //Console.WriteLine(str1[0]);
                    var records = engine.ReadString(str2[1]);
                    //Console.WriteLine(records);

                    foreach (var record in records)
                    {
                        XElement PO_SHIPTO = new XElement("PO.SHIPTO", record.CompanyName == "" ? null : new XElement("Company_Name", record.CompanyName),
                            record.Address == "" ? null : new XElement("Address", record.Address),
                            record.City == "" ? null : new XElement("City", record.City),
                            record.State == "" ? null : new XElement("State", record.State),
                            record.ZIP == "" ? null : new XElement("ZIP", record.ZIP));
                        //Console.WriteLine(PO_SHIPTO);
                        ApplicationArea.Add(PO_SHIPTO);

                    }
                }
                if (str2[0].Equals("PO.LINEITEM"))
                {
                    var engine = new FileHelperEngine<POLINEITEM>();
                    //Console.WriteLine(str1[0]);
                    var records = engine.ReadString(str2[1]);
                    //Console.WriteLine(records);

                    foreach (var record in records)
                    {
                        string[] lineitem = {"Part_Number","Quantity","Bin_location","Item_4","Customer_name","Item_6","Item_7","Item_8",
                "Item_9","Item_10","ID","Item_12","Item_13","Item_14","Internal_reference"};
                        XElement PO_LINEITEM = new XElement("PO.LINEITEM", record.PartsNumber == "" ? null : new XElement("Part_Number", record.PartsNumber),
                            record.Quantity == "" ? null : new XElement("Quantity", record.Quantity),
                            record.BinLocation == "" ? null : new XElement("Bin_Location", record.BinLocation),
                            record.Item4 == "" ? null : new XElement("Item4", record.Item4),
                            record.CustomerName == "" ? null : new XElement("Customer_Name", record.CustomerName),
                            record.Item6 == "" ? null : new XElement("Item6", record.Item6),
                            record.Item7 == "" ? null : new XElement("Item7", record.Item7),
                            record.Item8 == "" ? null : new XElement("Item8", record.Item8),
                            record.Item9 == "" ? null : new XElement("Item9", record.Item9),
                            record.Item10 == "" ? null : new XElement("Item10", record.Item10),
                            record.ID == "" ? null : new XElement("ID", record.ID),
                            record.Item12 == "" ? null : new XElement("Item12", record.Item12),
                            record.Item13 == "" ? null : new XElement("Item13", record.Item13),
                            record.Item14 == "" ? null : new XElement("Item14", record.Item14),
                            record.InternalReference == "" ? null : new XElement("Internal_Reference", record.InternalReference));
                        //Console.WriteLine(PO_LINEITEM);
                        ApplicationArea.Add(PO_LINEITEM);

                    }
                }

            }
            //Console.WriteLine(ApplicationArea.ToString());
            // XmlWriter w=XmlWriter.Create(destinationpath + "NEW.xml");
            TimePoints.MarkNext(ApplicationName, guid.ToString(), 3);
           
            File.WriteAllText(destinationpath, ApplicationArea.ToString());
            Console.WriteLine("Converted Successfully");
            TimePoints.MarkNext(ApplicationName, guid.ToString(), 4);
            File.Move(sourcepath, movedpath);
            Console.ReadLine();
        }
    }
}



