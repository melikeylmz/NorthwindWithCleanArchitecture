using Core.Persistence.Repositories;

namespace Domain.Entities
{
    public class Customer : Entity
    {

        public string CustomerId { get; set; }
   

        public List<Order> Orders { get; set; }
    } 
}
