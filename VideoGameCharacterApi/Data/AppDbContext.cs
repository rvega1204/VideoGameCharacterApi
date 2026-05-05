using Microsoft.EntityFrameworkCore;
using VideoGameCharacterApi.Models;

namespace VideoGameCharacterApi.Data
{
    /// <summary>
    /// Application database context for the VideoGameCharacter API.
    /// Inherits from <see cref="DbContext"/> and provides access to entity sets.
    /// </summary>
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        /// <summary>
        /// Represents the collection of <see cref="Character"/> entities in the database.
        /// </summary>
        public DbSet<Character> Characters => Set<Character>();
    }
}
