namespace TCA_TSR_BackEnd.Models
{
    public class Status
    {
        public int Status_Id { get; set; }
        public string Status_Description { get; set; }
        public string User_Logged { get; set; }
    }

    public class StatusPost
    {
        public string Status_Description { get; set; }
        public string User_Logged { get; set; }
    }

    public class StatusPut
    {
        public int Status_Id { get; set; }
        public string Status_Description { get; set; }
        public string User_Logged { get; set; }
    }
}
