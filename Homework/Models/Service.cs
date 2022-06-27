namespace Homework.Models
{
    public class Service
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Info { get; set; }
        public DateTime CreatedDate { get; set; }
        public Price Price { get; set; }
        public int CreatorId { get; set; }
        public List<ServiceType> Types { get; set; }
    }
}
