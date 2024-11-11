using Data.Entities;

namespace Data.Entities
{
    public class Statistics : BaseEntity
    {
        public int Id { get; set; }
        public DateTime VisitTime { get; set; }
        public int NewsId { get; set; }  
        public string IpAddress { get; set; }  
    }
}
