using Beforium.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Beforium.Items.Weapons
{ 
	public class ShellPiercer : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Could be used to spear fish");
		}

		public override void SetDefaults()
		{
			item.damage = 30;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 30;
			item.useTime = 30;
			item.shootSpeed = 4.7f;
			item.knockBack = 1.5f;
			item.width = 32;
			item.height = 32;
			item.scale = 1f;
			item.rare = ItemRarityID.Green;
			item.value = Item.sellPrice(silver: 10);
			item.melee = true;
			item.noMelee = true; 
			item.noUseGraphic = true; 
			item.autoReuse = true;
			item.UseSound = SoundID.Item1;
			item.shoot = ModContent.ProjectileType<ShellPiercerProjectile>();
		}
		public override bool CanUseItem(Player player)
		{
			return player.ownedProjectileCounts[item.shoot] < 2;
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