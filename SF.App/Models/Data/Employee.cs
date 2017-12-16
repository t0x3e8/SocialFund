using System;
using Newtonsoft.Json;

namespace SF.App.Models.Data
{
    public class Employee
    {
        public Employee()
        {
            this.RoleName = "User";
        }
        public string ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Surname { get; set; }
        
        [JsonProperty("Departament")]
        public string Department { get; set; }
        public string Manager { get; set; }

        [JsonProperty("Zatrudniony")]
        public DateTime HiredDate { get; set; }
        public string RoleName { get; set; }
    }
}