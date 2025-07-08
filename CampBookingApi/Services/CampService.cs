using CampBookingApi.Data;
using CampBookingApi.Models;

namespace CampBookingApi.Services
{
    public class CampService : ICampService
    {
        private readonly ApplicationDbContext _context;

        public CampService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Camp> GetAll() => _context.Camps.ToList();

        public Camp? GetById(int id) => _context.Camps.Find(id);

        public Camp Create(Camp camp)
        {
            _context.Camps.Add(camp);
            _context.SaveChanges();
            return camp;
        }

        public Camp? Update(int id, Camp camp)
        {
            var existing = _context.Camps.Find(id);
            if (existing is null) return null;

            existing.Name = camp.Name;
            existing.Location = camp.Location;
            existing.Capacity = camp.Capacity;
            _context.SaveChanges();
            return existing;
        }

        public bool Delete(int id)
        {
            var camp = _context.Camps.Find(id);
            if (camp is null) return false;
            _context.Camps.Remove(camp);
            _context.SaveChanges();
            return true;
        }
    }
}
