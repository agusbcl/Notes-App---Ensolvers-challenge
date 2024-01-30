namespace Ensolvers_Challenge.Backend.Models
{
    public abstract class BaseEntity<TId>
    {
        public TId Id { get; set; }
    }
}
