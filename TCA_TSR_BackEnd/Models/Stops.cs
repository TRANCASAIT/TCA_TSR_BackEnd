namespace TCA_TSR_BackEnd.Models
{
    public class Stops
    {
        public int Stop_Id { get; set; }
        public int Stop_Number { get; set; }
        public string Creation_Date { get; set; }
    }

    public class StopsPost
    {
        public string Stop_Number { get; set; }
        public string User_Logged { get; set; }
    }

    public class StopsPut
    {
        public int Stop_Id { get; set; }
        public string Stop_Number { get; set; }
        public string User_Logged { get; set; }
    }
}
