namespace PaymentContext.Domain.Repositories
{
  public interface IStudentRepository
  {
    bool DocumentExists(string document);
    bool EmailExists(string email);
  }
}