using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ImmerseDnD.Back.Models;

namespace ImmerseDnD.Back.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class CharacterController : ControllerBase
	{
		//add dbContext
		private readonly ImmerseDnDContext dbContext;
		public CharacterController() { }


		[HttpGet]
		public async Task<IActionResult> GetCharactersPreviews()
		{
			return Ok(null /*await dbContext.Characters.ToList.Async()*/);
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
		public async Task<IActionResult> AddCharacter(CharacterInit characterInit)
		{
			var character = new CharacterInit();


			return Ok(character);
		}
	}
}
