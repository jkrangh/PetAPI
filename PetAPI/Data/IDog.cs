using PetAPI.Model;

namespace PetAPI.Data
{
    public interface IDog
    {        
        Task<IEnumerable<Dog>> GetAllAsync();
        Task<Dog> GetByIdAsync(int id);
    }
}

