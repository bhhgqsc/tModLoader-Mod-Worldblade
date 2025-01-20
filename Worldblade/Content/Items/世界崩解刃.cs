using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Worldblade.Content.Items
{ 	
	// This is a basic item template.
	// Please see tModLoader's ExampleMod for every other example:
	// https://github.com/tModLoader/tModLoader/tree/stable/ExampleMod
	public class 世界崩解刃 : ModItem
	{	
		// The Display Name and Tooltip of this item can be edited in the 'Localization/en-US_Mods.wordblade.hjson' file.
		public override void SetDefaults()
		{	
			Item.damage = 548;
			Item.DamageType = DamageClass.Melee;
			Item.width = 192;
			Item.height = 225;
			Item.useTime = 6;
			Item.useAnimation = 20;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 20;
			Item.value = Item.buyPrice(silver: 1);
			Item.rare = ItemRarityID.Quest;
			Item.UseSound = SoundID.Item;
			Item.autoReuse = true;
			Item.scale = 3f;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.TerraBlade, 1);
			recipe.AddIngredient(ItemID.BrokenHeroSword, 1);
			recipe.AddIngredient(ItemID.BreakerBlade, 1);
			recipe.AddIngredient(ItemID.ChlorophyteClaymore, 1);
			recipe.AddIngredient(ItemID.TitaniumSword, 1);
			recipe.AddIngredient(ItemID.PearlwoodSword, 1);
			recipe.AddIngredient(ItemID.AvengerEmblem, 1);
			recipe.AddIngredient(ItemID.SpectreBar, 5);
			recipe.AddIngredient(ItemID.DirtBlock, 50);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{	
			velocity.X = 40f * player.direction;
			velocity.Y = 0;
			Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI);
			return false;
		}
	}
}
