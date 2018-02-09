namespace SF.App.Models.ViewModels
{
    public class HomeIndexViewModel
    {
        public bool IsModelEmpty { get;set;}
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string HiredDate { get; set; }
        public string Department { get; set; }
        public string DirectManager { get; set; }
        public string Email { get; set; }
    }
}