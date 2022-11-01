using System.IO;
using System.Xml.Linq;

namespace TCA_TSR_BackEnd.Models
{
    public class Customer
    {
        public int Customer_Id       {get; set;}
        public string Name              {get; set;}
        public string RFC               {get; set;}
        public string Street            {get; set;}
        public string StreetExt         {get; set;}
        public string StreetInt         {get; set;}
        public string ZipCode           {get; set;}
        public string Suburb            {get; set;}
        public string City_Name           {get; set;}
        public string State_Name          {get; set;}
        public string CustomerType_Name   {get; set;}
        public string PhoneNumber       {get; set;}
        public string Email             {get; set;}
        public int City_Id { get; set; }
        public int State_Id { get; set; }
        public string Creation_Date          {get; set;}
        public bool Status { get; set; }

        public class CustomerPost
        {
            public string Name { get; set; }
            public string RFC { get; set; }
            public string Street { get; set; }
            public string StreetExt { get; set; }
            public string StreetInt { get; set; }
            public string ZipCode { get; set; }
            public string Suburb { get; set; }
            public int City_Id { get; set; }
            public int State_Id { get; set; }
            public string PhoneNumber { get; set; }
            public string Email { get; set; }
            public string User_Logged { get; set; }
        }

        public class CustomerPut
        {
            public int Customer_Id { get; set; }
            public string Name { get; set; }
            public string RFC { get; set; }
            public string Street { get; set; }
            public string StreetExt { get; set; }
            public string StreetInt { get; set; }
            public string ZipCode { get; set; }
            public string Suburb { get; set; }
            public int City_Id { get; set; }
            public int State_Id { get; set; }
            public string PhoneNumber { get; set; }
            public string Email { get; set; }
            public string User_Logged { get; set; }

        }

        public class CustomerPutStatus
        {
            public int Customer_Id { get; set; }
            public bool Status { get; set; }
            public string User_Logged { get; set; }
        }
    }
}
