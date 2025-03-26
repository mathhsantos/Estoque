using Estoque.Data;
using Estoque.Interfaces;
using Estoque.Models;
using Microsoft.EntityFrameworkCore;

namespace Estoque.Repositories {
    public class ItEquipmentRepository : IItEquipmentRepository {

        private readonly EstoqueDbContext _db;

        public ItEquipmentRepository(EstoqueDbContext db) {
            _db = db;
        }

        public async Task InsertEquipment(ItEquipment equipment) {

            await _db.ItEquipments.AddAsync(equipment);
        }

        public async Task<IEnumerable<ItEquipment>> GetEquipments() {

            var equipaments = await _db.ItEquipments
                .AsNoTracking()
                .Include(x => x.Employee)
                .ToListAsync();

            return equipaments;
        }

        public async Task<ItEquipment> GetOneEquipment(int id) {

            var equipament = await _db.ItEquipments
                .Include(x => x.Employee)
                .FirstOrDefaultAsync(x => x.Id == id);

            if(equipament == null) {
                return null;
            }

            return equipament;
        }

        public void UpdateEquipment(ItEquipment equipment) {

            _db.ItEquipments.Update(equipment);
        }

        public void DeleteEquipment(ItEquipment equipment) {

            _db.ItEquipments.Remove(equipment);
        }

        public async Task<bool> SaveChanges() {

           return await _db.SaveChangesAsync() > 0;
        }
    }
}
