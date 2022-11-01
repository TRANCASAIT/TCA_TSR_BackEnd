namespace TCA_TSR_BackEnd.Models
{
    public class ServiceRequest
    {
        public int ServiceRequest_Id { get; set; }
        public int Document_Id { get; set; }
        public bool Priority { get; set; }
        public int InvoiceNumber { get; set; }
        public int Customer_Id { get; set; }
        public string CustomerName { get; set; }
        public string Box_Number { get; set; }
        public int OperationType_Id { get; set; }
        public string OperationType_Name { get; set; }
        public int Stop_Id { get; set; }
        public int Stop_Number { get; set; }
        public string Creation_Date { get; set; }
        public string TMWOrder { get; set; }
        public int Status_Id { get; set; }
        public string Status_Description { get; set; }
        public bool InvoiceMXStatus { get; set; }
        public string InvoiceMX { get; set; }
        public bool InvoiceUSAStatus { get; set; }
        public string InvoiceUSA { get; set; }
        public bool BOLStatus { get; set; }
        public string BOL { get; set; }
        public bool InwardStatus { get; set; }
        public string Inward { get; set; }
        public bool ACEStatus { get; set; }
        public string ACE { get; set; }
        public bool LayoutStatus { get; set; }
        public string Layout { get; set; }
        public bool Accepted_Layout { get; set; }
        public string Consigment_Note { get; set; }
        public bool XmlStatus { get; set; }
        public string XML { get; set; }
        public bool OriginPdfStatus { get; set; }
        public string OriginalPDF { get; set; }
        public bool OPStatus { get; set; }
        public string OperationsPDF { get; set; }
        public string Reference { get; set; }

        public class ServiceRequestPost
        {
            public string Box_Number { get; set; }
            public string Reference { get; set; }
            public int OperationType_Id { get; set; }
            public int Stops_Id { get; set; }
            public string User_Logged { get; set; }
        }

        public class UploadFiles
        {
            public int ServiceRequest_Id { get; set; }
            public int Document_Id { get; set; }
            public int Stop_Number { get; set; }
            public int Document_Type { get; set; }
            public string User_Logged { get; set; }

            public IFormFile DocumentFile { get; set; }
        }

        public class setTMW
        {
            public int ServiceRequest_Id { get; set; }
            public string TMWOrder { get; set; }
            public string User_Logged { get; set; }
        }
    }
}
