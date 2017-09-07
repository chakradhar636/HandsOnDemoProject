using FileHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatToXml
{
    class Data
    {

        [DelimitedRecord(",")]
        public class POHEADER
        {
            [FieldOptional]
            public string PartOrderNumnber;
            [FieldOptional]
            public string PartsOrderType;
            [FieldOptional]
            public string Item;
            [FieldOptional]
            public string PartsOrderAllowback;
            [FieldOptional]
            public string PartsOrderAllowShipment;
            [FieldOptional]
            public string PartsOrderPriority;
        }

        [DelimitedRecord(",")]
        public class POBILLTO
        {
            [FieldOptional]
            public string CompanyName;
            [FieldOptional]
            public string Address;
            [FieldOptional]
            public string City;
            [FieldOptional]
            public string State;
            [FieldOptional]
            public string ZIP;
        }
        [DelimitedRecord(",")]
        public class POSHIPTO
        {
            [FieldOptional]
            public string CompanyName;
            [FieldOptional]
            public string Address;
            [FieldOptional]
            public string City;
            [FieldOptional]
            public string State;
            [FieldOptional]
            public string ZIP;
        }

        [DelimitedRecord(",")]
        public class POLINEITEM
        {

            [FieldOptional]
            public string PartsNumber;
            [FieldOptional]
            public string Quantity;
            [FieldOptional]
            public string BinLocation;
            [FieldOptional]
            public string Item4;
            [FieldOptional]
            [FieldQuoted('"', QuoteMode.OptionalForBoth)]
            public string CustomerName;
            [FieldOptional]
            public string Item6;
            [FieldOptional]
            public string Item7;
            [FieldOptional]
            public string Item8;
            [FieldOptional]
            public string Item9;
            [FieldOptional]
            public string Item10;
            [FieldOptional]
            public string ID;
            [FieldOptional]
            public string Item12;
            [FieldOptional]
            public string Item13;
            [FieldOptional]
            public string Item14;
            [FieldOptional]
            [FieldQuoted('"', QuoteMode.OptionalForBoth)]
            public string InternalReference;

        }

        [DelimitedRecord(",")]
        public class POIDENT
        {


            [FieldOptional]
            public string CreatorNameCode;
            [FieldOptional]
            public string CreatorSoftwareCode;
            [FieldOptional]
            public string InterfaceVersion;
            [FieldOptional]
            public string TransactionCreateDate;
            [FieldOptional]
            public string TransactionCreateTime;
            [FieldOptional]
            public string DealerNumber;
            [FieldOptional]
            public string StoreNumber;
            [FieldOptional]
            public string AreaNumber;
            [FieldOptional]
            public string DestinationNameCode;
            [FieldOptional]
            public string DestinationSoftware;
            [FieldOptional]
            public string TransactionTypeCode;
            [FieldOptional]
            public string DealerCountry;
            [FieldOptional]
            public string ReferenceID;
            [FieldOptional]
            public string SenderPartyID;
            [FieldOptional]
            public string SenderLocationID;

        }
    }
}


