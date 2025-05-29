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
            //context.Cats.AddRange(CatData());
            context.SaveChanges();
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

        //private List<Cat> CatData()
        //{
        //    return new List<Cat>()
        //    {
        //        new Cat() { Id = 1, Name = "Missan" },
        //        new Cat() { Id = 2, Name = "Nissan" },
        //        new Cat() { Id = 3, Name = "Dr. Zjivago" }
        //    };
        //}
    }
}
