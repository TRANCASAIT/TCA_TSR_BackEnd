namespace TCA_TSR_BackEnd.Models
{
    public class OperationType
    {
        public int OperationType_Id { get; set; }
        public string OperationType_Name { get; set; }
        public bool Status { get; set; }
        public string Creation_Date { get; set; }
    }

    public class OperationTypePost
    {
        public string OperationType_Name { get; set; }
        public string User_Logged { get; set; }
    }

    public class OperationTypePut
    {
        public int OperationType_Id { get; set; }
        public string OperationType_Name { get; set; }
        public string User_Logged { get; set; }
    }

    public class OperationTypePutState
    {
        public int OperationType_Id { get; set; }
        public bool Status { get; set; }
        public string User_Logged { get; set; }
    }
}
