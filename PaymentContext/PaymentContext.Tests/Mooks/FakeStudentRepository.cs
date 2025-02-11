using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Repositories;

namespace PaymentContext.Tests.Mooks
{
    public class FakeStudentRepository : IStudentRepository
    {
        public void CreatSubscription(Student student)
        {
        }

        public bool DocumentExists(string document)
        {
            if(document == "00000000000")
              return true;

            return false;
        }

        public bool EmailExists(string email)
        {
            if(email == "hello@teste.com")
              return true;
             return false;
        }
    }
}