using CampBookingApi.Models;

namespace CampBookingApi.Services
{
    public interface ICampService
    {
        IEnumerable<Camp> GetAll();
        Camp? GetById(int id);
        Camp Create(Camp camp);
        Camp? Update(int id, Camp camp);
        bool Delete(int id);
    }
}
