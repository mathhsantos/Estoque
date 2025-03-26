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

        public void InsertEquipment(ItEquipment equipment) {

            _db.ItEquipments.Add(equipment);
            _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<ItEquipment>> GetEquipments() {

            var equipaments = await _db.ItEquipments.AsNoTracking().ToListAsync();

            return equipaments;
        }

        public async Task<ItEquipment> GetOneEquipment(int id) {
            var equipament = await _db.ItEquipments.FirstOrDefaultAsync(x => x.Id == id);

            if(equipament == null) {
                return null;
            }

            return equipament;
        }

        public void UpdateEquipment(ItEquipment equipment) {

            _db.ItEquipments.Update(equipment);
            _db.SaveChangesAsync();
        }

        public void DeleteEquipment(ItEquipment equipment) {

            _db.ItEquipments.Remove(equipment);
            _db.SaveChangesAsync();
        }

        Task IItEquipmentRepository.InsertEquipment(ItEquipment equipment) {
            throw new NotImplementedException();
        }

        public async Task<bool> SaveChanges() {

           return await _db.SaveChangesAsync() > 0;
        }
    }
}
