namespace VideoGameCharacterApi.Dtos
{
    /// <summary>
    /// Request Data Transfer Object (DTO) used to update an existing video game character.
    /// Contains the fields that can be modified.
    /// </summary>
    public class UpdateCharacterRequest
    {
        /// <summary>
        /// Unique identifier of the character to update.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Updated name of the character.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Updated video game in which the character appears.
        /// </summary>
        public string Game { get; set; } = string.Empty;

        /// <summary>
        /// Updated role or archetype of the character (e.g., hero, villain, NPC).
        /// </summary>
        public string Role { get; set; } = string.Empty;
    }
}