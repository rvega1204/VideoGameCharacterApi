namespace VideoGameCharacterApi.Models
{
    /// <summary>
    /// Entity model representing a video game character.
    /// This class is mapped to the database via Entity Framework Core.
    /// </summary>
    public class Character
    {
        /// <summary>
        /// Unique identifier of the character (primary key).
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of the character.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The video game in which the character appears.
        /// </summary>
        public string Game { get; set; } = string.Empty;

        /// <summary>
        /// The role or archetype of the character (e.g., hero, villain, NPC).
        /// </summary>
        public string Role { get; set; } = string.Empty;
    }
}