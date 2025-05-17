using PetAPI.Model;

namespace PetAPI.Data
{
    public class DataSeeder
    {
        private readonly PetAPIContext context;

        public DataSeeder(PetAPIContext context)
        {
            this.context = context;
        }

        public void SeedData()
        {
            context.Dogs.AddRange(DogData());
        }

        private List<Dog> DogData()
        {
            return new List<Dog>()
            {
                new Dog() { Id = 1, Name = "Bintje" },
                new Dog() { Id = 2, Name = "Cannelloni" },
                new Dog() { Id = 3, Name = "Åsa-Nietsche" }
            };
        }
    }
}
