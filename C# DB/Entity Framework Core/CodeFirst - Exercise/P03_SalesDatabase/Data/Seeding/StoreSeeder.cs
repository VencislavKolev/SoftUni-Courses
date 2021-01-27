using P03_SalesDatabase.Data.Models;
using P03_SalesDatabase.Data.Seeding.Contracts;

namespace P03_SalesDatabase.Data.Seeding
{
    public class StoreSeeder : ISeeder
    {
        private readonly SalesContext dbContext;

        public StoreSeeder(SalesContext context)
        {
            this.dbContext = context;
        }
        public void Seed()
        {
            Store[] stores = new Store[]
            {
                new Store(){Name = "Ardes"},
                new Store(){Name = "PC-World"},
                new Store(){Name = "Emag"},
                new Store(){Name = "Technopolis"},
                new Store(){Name = "Technomarket"}
            };

            this.dbContext.AddRange(stores);
            this.dbContext.SaveChanges();
        }
    }
}
