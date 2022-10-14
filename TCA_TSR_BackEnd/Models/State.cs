namespace TCA_TSR_BackEnd.Models
{
    public class State
    {
        public int State_Id { get; set; }
        public string State_Name { get; set; }
        public string Creation_Date { get; set; }
    }

    public class StatePost
    {
        public string State_Name { get; set; }
        public string User_Logged { get; set; }
    }

    public class StatePut
    {
        public int State_Id { get; set; }
        public string State_Name { get; set; }
        public string User_Logged { get; set; }
    }
}
