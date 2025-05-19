Demo-project for showcasing source generation.

App auto-generates files for repository, api-endpoints, dependency injection-registration and mapendpoints-wrapper.

Whats needed for auto-generating for new models is:
1. model-class with property int Id
2. interface in PetAPI called 'I[model] (e.g. IGoat), containg 'Task<IEnumerable<[model]>> GetAllAsync()' and 'Task<[model]>GetByIdAsync(int id)', mirroring 'IDog'.
3. DbSet in PetAPIContext called '[model]s'
4. interfacename added to entityInterfaces in PetAPISourceGenerator

This will generate mentiond files automatically

Dataseeder in Data.DataSeeder for spicing up demoing
