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
        public string InvMXFN { get; set; }
        public string InvMXdtm { get; set; }
        public bool InvoiceMXCompleted { get; set; }
        public bool InvoiceUSAStatus { get; set; }
        public string InvoiceUSA { get; set; }
        public string InvUSAFN { get; set; }
        public string InvUSAdtm { get; set; }
        public bool InvoiceUSACompleted { get; set; }
        public bool BOLStatus { get; set; }
        public string BOL { get; set; }
        public string BolFN { get; set; }
        public string Boldtm { get; set; }
        public bool BolCompleted { get; set; }
        public bool InwardStatus { get; set; }
        public string Inward { get; set; }
        public string InwFN { get; set; }
        public string Inwdtm { get; set; }
        public bool InwardCompleted { get; set; }
        public bool ACEStatus { get; set; }
        public string ACE { get; set; }
        public string AceFN { get; set; }
        public string Acedtm { get; set; }
        public bool AceCompleted { get; set; }
        public bool LayoutStatus { get; set; }
        public string Layout { get; set; }
        public string LayoutFN { get; set; }
        public string Layoutdtm { get; set; }
        public bool LayoutCompleted { get; set; }
        public bool Accepted_Layout { get; set; }
        public string Consigment_Note { get; set; }
        public bool XmlStatus { get; set; }
        public string XML { get; set; }
        public string XmlFN { get; set; }
        public string Xmldtm { get; set; }
        public bool XmlCompleted { get; set; }
        public bool OriginPdfStatus { get; set; }
        public string OriginalPDF { get; set; }
        public string OPdfFN { get; set; }
        public string OPdfdtm { get; set; }
        public bool OriginalPDFCompleted { get; set; }
        public bool OPStatus { get; set; }
        public string OperationsPDF { get; set; }
        public string Reference { get; set; }
        public string OpPdfFN { get; set; }
        public string OpPdfdtm { get; set; }
        public bool OperationsPDFCompleted { get; set; }
        public bool Accepted_LayoutDC { get; set; }
        public bool NotAccepted_LayoutDC { get; set; }

        public class ServiceRequestPost
        {
            public string Box_Number { get; set; }
            public string Reference { get; set; }
            public int OperationType_Id { get; set; }
            public int Stops_Id { get; set; }
            public string User_Logged { get; set; }
        }

        public class UploadFile
        {
            public int ServiceRequest_Id { get; set; }
            public int Document_Id { get; set; }
            public int Stop_Number { get; set; }
            public int Document_Type { get; set; }
            public string User_Logged { get; set; }

            public IFormFile DocumentFile { get; set; }
        }

        public class DownloadFile
        {
            public string Url { get; set; }
        }

        public class RemoveFile
        {
            public int ServiceRequest_Id { get; set; }
            public int Document_Id { get; set; }
            public int Document_Type { get; set; }
            public string Url { get; set; }
            public string FileName { get; set; }
            public string User_Logged { get; set; }
        }

        public class setTMW
        {
            public int ServiceRequest_Id { get; set; }
            public string TMWOrder { get; set; }
            public string User_Logged { get; set; }
        }

        public class setConsigmentNote
        {
            public int ServiceRequest_Id { get; set; }
            public int Document_Id { get; set; }
            public string Consigment_Note { get; set; }
            public string User_Logged { get; set; }
        }

        public class LayoutStatusDC
        {
            public int ServiceRequest_Id { get; set; }
            public int Document_Id { get; set; }
            public bool Accepted_LayoutDC { get; set; }
            public bool NotAccepted_LayoutDC { get; set; }
            public string User_Logged { get; set; }
        }
    }
}
