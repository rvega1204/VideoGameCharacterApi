using VideoGameCharacterApi.Data;
using VideoGameCharacterApi.Models;
using Microsoft.EntityFrameworkCore;
using VideoGameCharacterApi.Dtos;

namespace VideoGameCharacterApi.Services
{
    /// <summary>
    /// Service implementation for managing video game characters.
    /// Provides asynchronous CRUD operations using Entity Framework Core.
    /// </summary>
    public class VideoGameCharacterService(AppDbContext context) : IVideoGameCharacterService
    {
        /// <summary>
        /// Adds a new character to the database.
        /// </summary>
        /// <param name="request">The request object containing character details.</param>
        /// <returns>The newly created <see cref="CharacterResponse"/>.</returns>
        public async Task<CharacterResponse> AddCharacterAsync(CreateCharacterRequest request)
        {
            ArgumentNullException.ThrowIfNull(request);

            var newCharacter = new Character
            {
                Name = request.Name,
                Game = request.Game,
                Role = request.Role
            };

            context.Characters.Add(newCharacter);
            await context.SaveChangesAsync();

            // Map entity to response DTO
            return MapToResponse(newCharacter);
        }

        /// <summary>
        /// Deletes a character by its ID.
        /// </summary>
        /// <param name="id">The unique identifier of the character to delete.</param>
        public async Task DeleteCharacterAsync(int id)
        {
            var character = await context.Characters.FindAsync(id);

            if (character is null)
                throw new KeyNotFoundException($"Character with id {id} not found.");

            context.Characters.Remove(character);
            await context.SaveChangesAsync();
        }

        /// <summary>
        /// Retrieves all characters from the database.
        /// </summary>
        /// <returns>A list of <see cref="CharacterResponse"/> objects.</returns>
        public async Task<List<CharacterResponse>> GetAllCharactersAsync()
            // Projects each entity to a response DTO
            => await context.Characters
                .Select(c => MapToResponse(c))
                .ToListAsync();

        /// <summary>
        /// Retrieves a character by its ID.
        /// </summary>
        /// <param name="id">The unique identifier of the character.</param>
        /// <returns>A <see cref="CharacterResponse"/> if found, otherwise throws KeyNotFoundException.</returns>
        public async Task<CharacterResponse?> GetCharacterByIdAsync(int id)
        {
            var character = await context.Characters.FindAsync(id);

            if (character is null)
                throw new KeyNotFoundException($"Character with id {id} not found.");

            return MapToResponse(character);
        }

        /// <summary>
        /// Updates an existing character in the database.
        /// </summary>
        /// <param name="id">The unique identifier of the character to update.</param>
        /// <param name="request">The request object containing updated character details.</param>
        public async Task UpdateCharacterAsync(int id, UpdateCharacterRequest request)
        {
            var character = await context.Characters.FindAsync(id);

            if (character is null)
                throw new KeyNotFoundException($"Character with id {id} not found.");

            character.Name = request.Name;
            character.Game = request.Game;
            character.Role = request.Role;

            await context.SaveChangesAsync();
        }

        /// <summary>
        /// Maps a <see cref="Character"/> entity to a <see cref="CharacterResponse"/> DTO.
        /// </summary>
        /// <param name="character">The character entity.</param>
        /// <returns>A <see cref="CharacterResponse"/> object.</returns>
        private static CharacterResponse MapToResponse(Character character) => new()
        {
            Id = character.Id,
            Name = character.Name,
            Game = character.Game,
            Role = character.Role
        };
    }
}

