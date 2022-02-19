using Beforium.Tiles;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Beforium.Items
{
	public class BalisticFishLauncher : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Technology has improved to the point of strapping dynamite onto a fish."
				+ "\nHaHa fish go brrrrrrrrrrrrrrrrr.");
		}

		public override void SetDefaults()
		{
			item.damage = 73666;
			item.ranged = true;
			item.width = 26;
			item.height = 26;
			item.useTime = 100;
			item.useAnimation = 100;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.channel = true;
			item.knockBack = 8;
			item.value = Item.sellPrice(silver: 50);
			item.rare = ItemRarityID.Orange;
			item.UseSound = SoundID.Item61;
			item.shoot = ModContent.ProjectileType<Projectiles.BalisticFish>();
			item.shootSpeed = 8f;
			item.autoReuse = false;
			
		}

		

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Dynamite, 3);
			recipe.AddIngredient(ItemID.GrenadeLauncher, 1);
			recipe.AddIngredient(ItemID.Goldfish, 20);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this); 
			recipe.AddRecipe(); 
		}
	}
}