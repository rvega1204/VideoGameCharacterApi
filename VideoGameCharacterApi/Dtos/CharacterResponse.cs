namespace VideoGameCharacterApi.Dtos
{
    /// <summary>
    /// Response Data Transfer Object (DTO) representing a video game character.
    /// Used to return character information to API clients.
    /// </summary>
    public class CharacterResponse
    {
        /// <summary>
        /// Unique identifier of the character.
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
