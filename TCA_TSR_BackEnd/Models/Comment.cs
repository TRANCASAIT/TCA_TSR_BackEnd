namespace TCA_TSR_BackEnd.Models
{
    public class Comment
    {
        public int Comment_Id { get; set; } 
        public string Comment_Body { get; set; }
        public int Customer_Id { get; set; }
        public int ServiceRequest_Id { get; set; }
        public int Document_Id { get; set; }
        public string UserName { get; set; }
        public int User_Id { get; set; }
        public string  Creation_Date { get; set; } 

        public class CommentPost
        {
            public string User_Logged { get; set; }
            public string Comment_Body { get; set; }
            public int Customer_Id { get; set; }
            public int ServiceRequest_Id { get; set; }
            public int Document_Id { get; set; }
        }
        
    }
}
