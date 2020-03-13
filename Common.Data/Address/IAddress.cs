
namespace EGMS.Common.Data.Address
{
    public interface IAddress
    {
        public int Id { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string Street3 { get; set; }
        public string Street4 { get; set; }
        public string City { get; set; }
        public State State { get; set; }
        public int Zip { get; set; }
        
    }
}