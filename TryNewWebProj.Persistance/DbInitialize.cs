namespace TryNewWebProj.Persistance
{
    public class DbInitialize
    {
        public static void Initialize(WordDbContext WordDbContext)
        {
            WordDbContext.Database.EnsureCreated();
        }
    }
}
