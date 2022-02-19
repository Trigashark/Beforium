using Microsoft.Xna.Framework;
using Beforium.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Beforium.Items.Weapons
{
	public class Shellstaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shell Staff");
			Tooltip.SetDefault("Fire spining shells at your foes");
		}


		public override void SetDefaults()
		{
			item.damage = 20;
			item.magic = true;
			item.mana = 7;
			item.width = 40;
			item.height = 40;
			item.useTime = 11;
			item.useAnimation = 22;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.knockBack = 2f;
			item.value = 200;
			item.rare = ItemRarityID.Blue;
			item.UseSound = new Terraria.Audio.LegacySoundStyle(2, 8);
			item.autoReuse = true;
			item.shoot = ModContent.ProjectileType<MagicShell>();
			item.shootSpeed = 8f;
			item.autoReuse = false;
		}
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(10, 0);
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
	}
}