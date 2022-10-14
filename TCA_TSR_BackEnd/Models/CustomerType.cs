namespace TCA_TSR_BackEnd.Models
{
    public class CustomerType
    {
        public int CustomerType_Id { get; set; }
        public string CustomerType_Name { get; set; }
        public string Creation_Date { get; set; }
    }

    public class CustomerTypePost
    {
        public string CustomerType_Name { get; set; }
        public string User_Logged { get; set; }
    }

    public class CustomerTypePut
    {
        public int CustomerType_Id { get; set; }
        public string CustomerType_Name { get; set; }
        public string User_Logged { get; set; }
    }
}
