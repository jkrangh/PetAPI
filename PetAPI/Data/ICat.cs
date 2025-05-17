using PetAPI.Model;

namespace PetAPI.Data
{
    public interface ICat
    {
        Task<IEnumerable<Cat>> GetAllAsync();
        Task<Cat> GetByIdAsync(int id);
    }
}
