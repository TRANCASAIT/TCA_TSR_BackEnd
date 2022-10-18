namespace TCA_TSR_BackEnd.Models
{
    public class User
    {
        public int User_Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Last_Name { get; set; }
        public string UserType_Name { get; set; }
        public int UserType_Id { get; set; }
        public int Customer_Id { get; set; }
        public string Customer_Name { get; set; }
        public string Email { get; set; }
        public string Creation_Date { get; set; }
        public bool Status { get; set; }

        public class UserPost
        {
            public string UserName { get; set; }
            public string Name { get; set; }
            public string Last_Name { get; set; }
            public int UserType_Id { get; set; }
            public int Customer_Id { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public string User_Logged { get; set; }
        }

        public class UserPut
        {
            public int User_Id { get; set; }
            public string UserName { get; set; }
            public string Name { get; set; }
            public string Last_Name { get; set; }
            public int UserType_Id { get; set; }
            public int Customer_Id { get; set; }
            public string Email { get; set; }
            public string User_Logged { get; set; }

        }

        public class UserPutStatus
        {
            public int User_Id { get; set; }
            public bool Status { get; set; }
            public string User_Logged { get; set; }
        }

        public class UserLogin
        {
            public string UserName { get; set; }
            public string Password { get; set; }
        }
    }
}
