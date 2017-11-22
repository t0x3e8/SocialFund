using Newtonsoft.Json;

namespace SF.App.Models.Data
{
    public class Employee
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        [JsonProperty("AppliedDate")]
        public string SubmissionDate { get; set; }
        
        [JsonProperty("Departament")]
        public string Department { get; set; }
        public string Manager { get; set; }

        [JsonProperty("Hired")]
        public string HiredDate { get; set; }

        [JsonProperty("Level")]
        public string IncomeLevel { get; set; }
    }
}