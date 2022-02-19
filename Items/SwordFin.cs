using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Beforium.Projectiles;
using Beforium.Dusts;

namespace Beforium.Items
{
	public class SwordFin : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("You are one with the oceans tide.");
		}

		public override void SetDefaults()
		{
			item.damage = 100;
			item.melee = true;
			item.width = 1;
			item.height = 1;
			item.useTime = 30;
			item.useAnimation = 30;
			item.knockBack = 20;
			item.value = Item.buyPrice(gold: 10);
			item.rare = ItemRarityID.Purple;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.crit = 200;
			item.shoot = ModContent.ProjectileType<ExampleAnimatedPierce>();
			item.shootSpeed = 20f;
			item.useStyle = ItemUseStyleID.SwingThrow; // 1 is the useStyle
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DirtBlock, 10);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.NextBool(3))
			{

				Terraria.Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, ModContent.DustType<Pixel>());
			}
		}

		public override void OnHitNPC(Player player, Terraria.NPC target, int damage, float knockback, bool crit)
		{
			item.shoot = ModContent.ProjectileType<ExampleAnimatedPierce>();
		}


	}
}