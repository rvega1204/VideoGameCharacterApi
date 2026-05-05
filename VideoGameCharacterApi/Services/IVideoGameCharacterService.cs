using VideoGameCharacterApi.Dtos;
using VideoGameCharacterApi.Models;
namespace VideoGameCharacterApi.Services
{
    /// <summary>
    /// Defines the contract for managing video game characters.
    /// Provides asynchronous CRUD operations for character data.
    /// </summary>
    public interface IVideoGameCharacterService
    {
        /// <summary>
        /// Retrieves all characters from the system.
        /// </summary>
        /// <returns>A list of <see cref="CharacterResponse"/> objects representing all characters.</returns>
        Task<List<CharacterResponse>> GetAllCharactersAsync();

        /// <summary>
        /// Retrieves a specific character by its unique ID.
        /// </summary>
        /// <param name="id">The unique identifier of the character.</param>
        /// <returns>
        /// A <see cref="CharacterResponse"/> if found, or <c>null</c> if the character does not exist.
        /// </returns>
        Task<CharacterResponse?> GetCharacterByIdAsync(int id);

        /// <summary>
        /// Adds a new character to the system.
        /// </summary>
        /// <param name="character">The request object containing the data required to create the character.</param>
        /// <returns>The newly created <see cref="CharacterResponse"/> with its assigned ID.</returns>
        Task<CharacterResponse> AddCharacterAsync(CreateCharacterRequest character);

        /// <summary>
        /// Updates an existing character in the system.
        /// </summary>
        /// <param name="id">The unique identifier of the character to update.</param>
        /// <param name="character">The request object containing the updated character data.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task UpdateCharacterAsync(int id, UpdateCharacterRequest character);

        /// <summary>
        /// Deletes a character from the system by its unique ID.
        /// </summary>
        /// <param name="id">The unique identifier of the character to delete.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task DeleteCharacterAsync(int id);
    }
}

