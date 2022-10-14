namespace TCA_TSR_BackEnd.Models
{
    public class City
    {
        public int City_Id { get; set; }
        public string City_Name { get; set; }
        public int State_Id { get; set; }
        public string State_Name { get; set; }
        public string Creation_Date { get; set; }
    }

    public class CityPost
    {
        public string City_Name { get; set; }
        public int State_Id { get; set; }
        public string User_Logged { get; set; }
    }

    public class CityPut
    {
        public int City_Id { get; set; }
        public string City_Name { get; set; }
        public int State_Id { get; set; }
        public string User_Logged { get; set; }
    }
}
