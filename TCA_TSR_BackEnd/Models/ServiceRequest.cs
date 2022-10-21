namespace TCA_TSR_BackEnd.Models
{
    public class ServiceRequest
    {
        public int ServiceRequest_Id { get; set; }
        public bool Priority { get; set; }
        public int Invoice { get; set; }
        public string Box_Number { get; set; }
        public string Reference { get; set; }
        public string TMWOrder { get; set; }
        public bool FacturaMX { get; set; }
        public bool FacturaUS { get; set; }
        public bool BOL { get; set; }
        public bool Inward { get; set; }
        public bool ACE { get; set; }
        public bool Layout { get; set; }
        public bool Accepted_Layout { get; set; }
        public string CP_Number { get; set; }
        public bool XML { get; set; }
        public bool Original_PDF { get; set; }
        public bool Operations_PDF { get; set; }
        public int Customer_Id { get; set; }
        public int OperationType_Id { get; set; }
        public int Status_Id { get; set; }
        public int Stops_Id { get; set; }
        public string Creation_Date { get; set; }
    }
}
