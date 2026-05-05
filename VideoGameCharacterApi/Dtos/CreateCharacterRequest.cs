namespace VideoGameCharacterApi.Dtos
{
    /// <summary>
    /// Request Data Transfer Object (DTO) used to create a new video game character.
    /// Contains the required fields for character creation.
    /// </summary>
    public class CreateCharacterRequest
    {
        /// <summary>
        /// Name of the character to be created.
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
