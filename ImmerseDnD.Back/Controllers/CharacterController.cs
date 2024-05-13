using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ImmerseDnD.Back.Repository;
using ImmerseDnD.Back.Repository.Models;

namespace ImmerseDnD.Back.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class CharacterController : ControllerBase
	{
		//add dbContext
		private readonly immerse_dndDbContext dbContext = new immerse_dndDbContext();

		[HttpGet]
		public async Task<IActionResult> GetCharactersPreviews()
		{
			var characters = await dbContext.Characters.ToArrayAsync();

			if (characters.Length == 0) return NotFound();

			return Ok(await dbContext.Characters.ToArrayAsync());
		}

		[HttpGet]
		[Route("id:guid")]
		public async Task<IActionResult> GetCharacter([FromRoute] Guid id)
		{
			var character = await dbContext.Characters.FindAsync(id);

			if (character == null) return NotFound();

			return Ok(character);
		}


		[HttpPost]
		public async Task<IActionResult> AddCharacter(Character characterInit)
		{
			var character = new Character();

			return Ok(character);
		}
	}
}
