namespace TCA_TSR_BackEnd.Models
{
    public class UserType
    {
        public int UserType_Id { get; set; }
        public string UserType_Name { get; set; }
        public string Creation_Date { get; set; }
    }

    public class UserTypePost
    {
        public string UserType_Name { get; set; }
        public string User_Logged { get; set; }
    }

    public class UserTypePut
    {
        public int UserType_Id { get; set; }
        public string UserType_Name { get; set; }
        public string User_Logged { get; set; }
    }
}
