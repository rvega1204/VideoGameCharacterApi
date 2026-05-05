using Microsoft.AspNetCore.Mvc;
using VideoGameCharacterApi.Dtos;
using VideoGameCharacterApi.Services;

namespace VideoGameCharacterApi.Controllers
{
    /// <summary>
    /// API Controller for managing video game characters.
    /// Provides CRUD endpoints to retrieve, create, update, and delete characters.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class VideoGameCharactersController(IVideoGameCharacterService service) : ControllerBase
    {
        /// <summary>
        /// Retrieves the full list of characters.
        /// </summary>
        /// <returns>A list of <see cref="CharacterResponse"/> objects representing all characters.</returns>
        [HttpGet]
        public async Task<ActionResult<List<CharacterResponse>>> GetCharacters()
            // Returns 200 OK with the list of characters
            => Ok(await service.GetAllCharactersAsync());

        /// <summary>
        /// Retrieves a specific character by its ID.
        /// </summary>
        /// <param name="id">Unique identifier of the character.</param>
        /// <returns>A <see cref="CharacterResponse"/> if found, or 404 Not Found if not.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<CharacterResponse>> GetCharacter(int id)
        {
            var character = await service.GetCharacterByIdAsync(id);
            // Returns 404 Not Found if the character does not exist, otherwise 200 OK with the character
            return character is null ? NotFound($"Character with ID {id} not found") : Ok(character);
        }

        /// <summary>
        /// Creates a new character in the system.
        /// </summary>
        /// <param name="character">Object containing the data required to create the character.</param>
        /// <returns>The created character with its assigned ID.</returns>
        [HttpPost]
        public async Task<ActionResult<CharacterResponse>> AddCharacter(CreateCharacterRequest character)
        {
            var createdCharacter = await service.AddCharacterAsync(character);
            // Returns 201 Created with the route to the newly created resource
            return CreatedAtAction(nameof(GetCharacter), new { id = createdCharacter.Id }, createdCharacter);
        }

        /// <summary>
        /// Updates an existing character.
        /// </summary>
        /// <param name="id">Identifier of the character to update.</param>
        /// <param name="character">Object containing the updated data.</param>
        /// <returns>NoContent if the update was successful.</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCharacter(int id, UpdateCharacterRequest character)
        {
            await service.UpdateCharacterAsync(id, character);
            // Returns 204 No Content indicating success without a response body
            return NoContent();
        }

        /// <summary>
        /// Deletes a character by its ID.
        /// </summary>
        /// <param name="id">Identifier of the character to delete.</param>
        /// <returns>NoContent if the deletion was successful.</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCharacter(int id)
        {
            await service.DeleteCharacterAsync(id);
            // Returns 204 No Content indicating the resource was deleted
            return NoContent();
        }
    }
}
