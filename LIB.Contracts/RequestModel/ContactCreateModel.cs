using LIB.Contracts.Shared;

namespace LIB.Contracts.RequestModel
{
    public class ContactCreateModel : ICreateModel
    {
        public string Email { get; set; }
        public string Website { get; set; }
        public string Number1 { get; set; }
        public string Number2 { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}