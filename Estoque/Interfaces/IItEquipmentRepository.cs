using Estoque.Models;

namespace Estoque.Interfaces {
    public interface IItEquipmentRepository {

        Task InsertEquipment(ItEquipment equipment);
        Task<IEnumerable<ItEquipment>> GetEquipments();
        Task<ItEquipment> GetOneEquipment(int id);
        void UpdateEquipment(ItEquipment equipment);
        void DeleteEquipment(ItEquipment equipment);
        Task<bool> SaveChanges();
    }
}
