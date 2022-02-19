using Beforium.Projectiles;
using Beforium.Projectiles;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace Beforium.Items.Weapons
{
	public class Shellshot : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Shell reinforced bow.");
		}
		public override void SetDefaults()
		{
			item.damage = 25; 
			item.ranged = true; 
			item.width = 40; 
			item.height = 20; 
			item.useTime = 30; 
			item.useAnimation = 30;
			item.useStyle = ItemUseStyleID.HoldingOut; 
			item.noMelee = true; 
			item.knockBack = 4; 
			item.value = 10000; 
			item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.Item19; 
			item.autoReuse = true; 
			item.shoot = 10; 
			item.shootSpeed = 10f; 
			item.useAmmo = AmmoID.Arrow;
		}
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-5, 0);
		}
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(ModContent.ItemType<Carapace>(), 10);
			modRecipe.AddIngredient(ModContent.ItemType<Scales>(), 10);
			modRecipe.AddIngredient(ItemID.Seashell, 5);
			modRecipe.AddTile(TileID.Anvils);
			modRecipe.SetResult(this);
			modRecipe.AddRecipe();
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (type == ProjectileID.WoodenArrowFriendly)
			{
				
			}
			return true; 
		}
	}
}