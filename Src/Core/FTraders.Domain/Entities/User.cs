using FTraders.Domain.ValueObjects;

namespace FTraders.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }

        public AdAccount AdAccount { get; set; }
    }
}
