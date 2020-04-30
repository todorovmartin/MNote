namespace MNote.Data.Seeding
{
    using System;
    using System.Threading.Tasks;

    public interface ISeeder
    {
        Task SeedAsync(MNoteDbContext dbContext, IServiceProvider serviceProvider);
    }
}
