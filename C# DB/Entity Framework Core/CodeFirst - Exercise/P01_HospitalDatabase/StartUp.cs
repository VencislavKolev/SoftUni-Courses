using P01_HospitalDatabase.Data;

namespace P01_HospitalDatabase
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var dbContext = new HospitalContext();
            //dbContext.Database.EnsureDeleted();
            // dbContext.Database.EnsureCreated();
        }
    }
}
