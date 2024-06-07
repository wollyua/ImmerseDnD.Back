using ImmerseDnD.Back.Repository;
using ImmerseDnD.Back.Repository.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ImmerseDnD.Back.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class CharacterController : ControllerBase
	{
		private readonly immerse_dndDbContext dbContext;

		public CharacterController(immerse_dndDbContext context)
		{
			dbContext = context;
		}

		//Get requests
		#region GetRequests
		[HttpGet]
		[Route("/Character/GetPreviews/{UserId}")]
		public async Task<IActionResult> GetCharactersPreviews([FromRoute] Guid UserId)
		{
			var characters = await dbContext.Characters.Where(c => c.UserId == UserId).Select(c => new CharacterPreviewDto
			{
				CharacterId = c.CharacterId,
				UserId = c.UserId,
				CharacterName = c.CharacterName,
				CharacterRace = c.CharacterRace,
				CharacterClass = c.CharacterClass,
				CharacterLevel = c.CharacterLevel,
				Strength = c.Strength,
				Dexterity = c.Dexterity,
				Constitution = c.Constitution,
				Intelligence = c.Intelligence,
				Wisdom = c.Wisdom,
				Charisma = c.Charisma,
			}).OrderBy(x=>x.CharacterName).ToArrayAsync();

			if (characters.Length == 0) return NotFound("No characters associated with user.");

			return Ok(characters);
		}

		[HttpGet]
		[Route("/Character/Get/{CharacterId}")]
		public async Task<IActionResult> GetCharacter([FromRoute] Guid CharacterId)
		{
			/*var character = await dbContext.Characters
				.Include(c => c.InventoryItems)
				.Include(c => c.Attacks)
				.FirstOrDefaultAsync(c => c.CharacterId == CharacterId);*/
			var character = await dbContext.Characters.Select(c => new CharacterDto
			{
                CharacterId = c.CharacterId,
                CharacterName = c.CharacterName,
                CharacterRace = c.CharacterRace,
                CharacterClass = c.CharacterClass,
                CharacterLevel = c.CharacterLevel,
                Strength = c.Strength,
                Dexterity = c.Dexterity,
                Constitution = c.Constitution,
                Intelligence = c.Intelligence,
                Wisdom = c.Wisdom,
                Charisma = c.Charisma,
				BonStr = c.BonStr,
				BonCon = c.BonCon,
				BonDex = c.BonDex,
				BonInt = c.BonInt,
				BonWis = c.BonWis,
				BonCha = c.BonCha,
				Inspiration = c.Inspiration,
				ProficiencyBonus = c.ProficiencyBonus,
				Armor = c.Armor,
				Speed = c.Speed,
				CurrentHp = c.CurrentHp,
				MaxHp = c.MaxHp,
				TempHp = c.TempHp,
				Copper = c.Copper,
				Silver = c.Silver,
				Gold = c.Gold,
				Platinum = c.Platinum,
				Languages = c.Languages,
				PersonalityTraits = c.PersonalityTraits,
				Ideals = c.Ideals,
				Bonds = c.Bonds,
				Flaws = c.Flaws,
				OtherTraits = c.OtherTraits
            }).FirstOrDefaultAsync(c => c.CharacterId == CharacterId);

			if (character == null) return NotFound("Character not found.");

			//character.InventoryItems = [.. character.InventoryItems.OrderBy(i => i.ItemName)];
			//character.Attacks = [.. character.Attacks.OrderBy(a => a.AttackName)];

			return Ok(character);
		}

		[HttpGet]
		[Route("/InventoryItem/Get/{CharacterID}")]
		public async Task<IActionResult> GetInventoryItems([FromRoute] Guid CharacterID)
		{
			//var inventoryItem = await dbContext.InventoryItems.Where(i => i.CharacterId == CharacterID).ToArrayAsync();

			var inventoryItem = await dbContext.InventoryItems.Select(i => new InventoryItemDto
			{
                ItemId = i.ItemId,
                CharacterId = i.CharacterId,
                ItemName = i.ItemName,
                ItemDescription = i.ItemDescription
            })
			.Where(i => i.CharacterId == CharacterID)
			.OrderBy(i => i.ItemName)
			.ToArrayAsync();

			if (inventoryItem == null) return NotFound();

			return Ok(inventoryItem);
		}

		[HttpGet]
		[Route("/InventoryItem/GetAll")]
		public async Task<IActionResult> GetAllInventoryItems()
		{
			var inventoryItems = await dbContext.InventoryItems.ToArrayAsync();

			if (inventoryItems.Length == 0) return NotFound();

			return Ok(inventoryItems);
		}

		[HttpGet]
		[Route("/Attack/Get/{CharacterID}")]
		public async Task<IActionResult> GetAttacks([FromRoute] Guid CharacterID)
		{
			//var attack = await dbContext.Attacks.Where(c => c.CharacterId == CharacterID).ToArrayAsync();

			var attack = await dbContext.Attacks.Select(a => new AttackDto
			{
                AttackId = a.AttackId,
                CharacterId = a.CharacterId,
                AttackName = a.AttackName,
                AttackRange = a.AttackRange,
                DiceNumber = a.DiceNumber,
                DiceType = a.DiceType,
                DamageType = a.DamageType
            })
			.Where(a => a.CharacterId == CharacterID)
			.OrderBy(a => a.AttackName)
			.ToArrayAsync();

			if (attack == null) return NotFound();

			return Ok(attack);
		}

		[HttpGet]
		[Route("/Attack/GetAll")]
		public async Task<IActionResult> GetAllAttacks()
		{
			var attacks = await dbContext.Attacks.ToArrayAsync();

			if (attacks.Length == 0) return NotFound();

			return Ok(attacks);
		}

		[HttpGet]
		[Route("/User/Get/{UserName}")]
		public async Task<IActionResult> GetUser([FromRoute] string UserName)
		{
			//var user = await dbContext.Users.Include(u => u.Characters).ThenInclude(c=>c.InventoryItems)
			//	.Include(u => u.Characters).ThenInclude(c => c.Attacks)
			//	.FirstOrDefaultAsync(u => u.UserName == UserName);

			var user = await dbContext.Users.Select(u => new UserDto
			{
                UserId = u.UserId,
                UserName = u.UserName,
                UserEmail = u.UserEmail,
                UserPassword = u.UserPassword
            }).FirstOrDefaultAsync(u => u.UserName == UserName);

			if (user == null) return NotFound();

			return Ok(user);
		}
		#endregion

		//Post requests
		#region PostRequests
		[HttpPost]
		[Route("/Character/Create/{UserID}")]
		public async Task<IActionResult> CreateCharacter([FromRoute] Guid UserID)
		{
			var user = await dbContext.Users.FindAsync(UserID);
			if (user == null) return NotFound("User not found.");

			var character = new Character
			{
				UserId = UserID,
				CharacterName = "Name",
				CharacterRace = "Race",
				CharacterClass = "Class",
				CharacterLevel = 1,
				Strength = 10,
				Dexterity = 10,
				Constitution = 10,
				Intelligence = 10,
				Wisdom = 10,
				Charisma = 10,
				BonStr = false,
				BonCon = false,
				BonDex = false,
				BonInt = false,
				BonWis = false,
				BonCha = false,
				Inspiration = false,
				ProficiencyBonus = 1,
				Armor = 10,
				Speed = 30,
				CurrentHp = 20,
				MaxHp = 20,
				TempHp = 0,
				Copper = 0,
				Silver = 0,
				Gold = 0,
				Platinum = 0,
				Languages = "Common",
				PersonalityTraits = "Trait",
				Ideals = "Ideal",
				Bonds = "Bond",
				Flaws = "Flaw",
				OtherTraits = "Other trait"
			};
			await dbContext.Characters.AddAsync(character);
			await dbContext.SaveChangesAsync();

			return Ok(character);
		}

		[HttpPost]
		[Route("/InventoryItem/Add")]
		public async Task<IActionResult> AddInventoryItem(InventoryItemDto inventoryItemDto)
		{
			var character = await dbContext.Characters.FindAsync(inventoryItemDto.CharacterId);

			if (character == null) return NotFound("Character not found.");

			var inventoryItem = new InventoryItem
			{
				CharacterId = inventoryItemDto.CharacterId,
				ItemName = inventoryItemDto.ItemName,
				ItemDescription = inventoryItemDto.ItemDescription
			};

			await dbContext.InventoryItems.AddAsync(inventoryItem);
			await dbContext.SaveChangesAsync();

			return Ok(inventoryItem);
		}

		[HttpPost]
		[Route("/Attack/Add")]
		public async Task<IActionResult> AddAttack(AttackDto attackDto)
		{
			var character = await dbContext.Characters.FindAsync(attackDto.CharacterId);

			if (character == null) return NotFound("Character not found.");

			var attack = new Attack
			{
				CharacterId = attackDto.CharacterId,
				AttackName = attackDto.AttackName,
				AttackRange = attackDto.AttackRange,
				DiceNumber = attackDto.DiceNumber,
				DiceType = attackDto.DiceType,
				DamageType = attackDto.DamageType
			};
			await dbContext.Attacks.AddAsync(attack);
			await dbContext.SaveChangesAsync();

			return Ok(attack);
		}

		[HttpPost]
		[Route("/User/Create")]
		public async Task<IActionResult> CreateUser(UserDto userDto)
		{
			var user = new User
			{
				UserName = userDto.UserName,
				UserEmail = userDto.UserEmail,
				UserPassword = userDto.UserPassword
			};
			await dbContext.Users.AddAsync(user);
			await dbContext.SaveChangesAsync();

			return Ok(user);
		}
		#endregion

		//Put requests
		#region PutRequests
		[HttpPut]
		[Route("/Character/Edit/{CharacterID}")]
		public async Task<IActionResult> UpdateCharacter([FromRoute] Guid CharacterID, [FromBody] CharacterDto characterDto)
		{
			var character = await dbContext.Characters.FindAsync(CharacterID);

			if (character == null) return NotFound("Couldn`t find character by specified id.");

			character.CharacterName = characterDto.CharacterName;
			character.CharacterRace = characterDto.CharacterRace;
			character.CharacterClass = characterDto.CharacterClass;
			character.CharacterLevel = characterDto.CharacterLevel;
			character.Strength = characterDto.Strength;
			character.Dexterity = characterDto.Dexterity;
			character.Constitution = characterDto.Constitution;
			character.Intelligence = characterDto.Intelligence;
			character.Wisdom = characterDto.Wisdom;
			character.Charisma = characterDto.Charisma;
			character.BonStr = characterDto.BonStr;
			character.BonCon = characterDto.BonCon;
			character.BonDex = characterDto.BonDex;
			character.BonInt = characterDto.BonInt;
			character.BonWis = characterDto.BonWis;
			character.BonCha = characterDto.BonCha;
			character.Inspiration = characterDto.Inspiration;
			character.ProficiencyBonus = characterDto.ProficiencyBonus;
			character.Armor = characterDto.Armor;
			character.Speed = characterDto.Speed;
			character.MaxHp = characterDto.MaxHp;
			character.TempHp = characterDto.TempHp;
			character.Copper = characterDto.Copper;
			character.Silver = characterDto.Silver;
			character.Gold = characterDto.Gold;
			character.Platinum = characterDto.Platinum;
			character.Languages = characterDto.Languages;
			character.PersonalityTraits = characterDto.PersonalityTraits;
			character.Ideals = characterDto.Ideals;
			character.Bonds = characterDto.Bonds;
			character.Flaws = characterDto.Flaws;
			character.OtherTraits = characterDto.OtherTraits;

			await dbContext.SaveChangesAsync();

			return Ok(character);
		}

		[HttpPut]
		[Route("/CurrentHp/Edit/{CharacterID}")]
		public async Task<IActionResult> UpdateCurrentHp([FromRoute] Guid CharacterID, [FromBody] UpdateHealthDto updateHealthDto)
		{
			var character = await dbContext.Characters.FindAsync(CharacterID);

			if (character == null) return NotFound("Couldn`t find character by specified id.");

			character.CurrentHp = updateHealthDto.CurrentHp;
			character.TempHp = updateHealthDto.TempHp;
			_ = dbContext.SaveChanges();

			return Ok(character);
		}
		#endregion
		
		//Delete requests
		#region DeleteRequests
		[HttpDelete]
		[Route("/User/Delete/{UserName}")]
		public async Task<IActionResult> DeleteUser([FromRoute] string UserName)
		{
			var user = await dbContext.Users
				.Include(u => u.Characters)
				.ThenInclude(c => c.InventoryItems)
				.Include(u => u.Characters)
				.ThenInclude(c => c.Attacks)
				.FirstOrDefaultAsync(u => u.UserName == UserName);

			if (user == null) return NotFound();

			_ = dbContext.Users.Remove(user);
			await dbContext.SaveChangesAsync();

			return Ok();
		}

		[HttpDelete]
		[Route("/Character/Delete/{CharacterId}")]
		public async Task<IActionResult> DeleteCharacter([FromRoute] Guid CharacterId)
		{
			var character = await dbContext.Characters
				.Include(c => c.InventoryItems)
				.Include(c => c.Attacks)
				.FirstOrDefaultAsync(c => c.CharacterId == CharacterId);

			if (character == null) return NotFound();

			_ = dbContext.Characters.Remove(character);
			await dbContext.SaveChangesAsync();

			return Ok();
		}

		[HttpDelete]
		[Route("/InventoryItem/Delete/{ItemId}")]
		public async Task<IActionResult> DeleteInventoryItem([FromRoute] Guid ItemId)
		{
			var inventoryItem = await dbContext.InventoryItems.FindAsync(ItemId);

			if (inventoryItem == null) return NotFound();

			_ = dbContext.InventoryItems.Remove(inventoryItem);
			_ = dbContext.SaveChanges();

			return Ok();
		}

		[HttpDelete]
		[Route("/Attack/Delete/{AttackId}")]
		public async Task<IActionResult> DeleteAttack([FromRoute] Guid AttackId)
		{
			var attack = await dbContext.Attacks.FindAsync(AttackId);

			if (attack == null) return NotFound();

			_ = dbContext.Attacks.Remove(attack);
			_ = dbContext.SaveChanges();

			return Ok();
		}
		#endregion
	}
}
