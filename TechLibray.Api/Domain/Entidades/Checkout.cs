namespace TechLibray.Api.Domain.Entidades;

public class Checkout
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime CheckoutDate { get; set; } = DateTime.Now;
    public Guid UserId { get; set; }
    public Guid BookId { get; set; }
    public DateTime ExpectedReturnDate { get; set; }
    public DateTime? ReturnedDate { get; set; }
}
