using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    // Add a parameterless constructor
    public ApplicationDbContext() : this(new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=dt191gm3;Uid=dt191gm3;Pwd=cgyrfth54456;Trusted_Connection=True;MultipleActiveResultSets=true").Options) { }

    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }

    public async Task CreateAuthorAsync(Author author)
    {
        // Add the author entity to the Authors DbSet
        Authors.Add(author);

        // Call SaveChangesAsync to persist the changes to the database
        await SaveChangesAsync();
    }
}