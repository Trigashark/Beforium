using Beforium.Projectiles;
using Beforium.Tiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Beforium.Items.Weapons
{
	public class ShellStriker : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Slash and Bash.");
		}
		public override void SetDefaults()
		{
			item.damage = 25;
			item.melee = true;
			item.channel = true;
			item.rare = ItemRarityID.Green;
			item.width = 28;
			item.height = 30;
			item.useTime = 20;
			item.UseSound = SoundID.Item13;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useAnimation = 20;
			item.value = Item.sellPrice(silver: 25);
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
		public override bool AltFunctionUse(Player player)
		{
			return true;
		}
		public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse == 2)
			{
				item.damage = 9;
				item.melee = true;
				item.channel = true;
				item.rare = ItemRarityID.Green;
				item.width = 28;
				item.height = 30;
				item.useTime = 5;
				item.UseSound = SoundID.Item1;
				item.useStyle = ItemUseStyleID.Stabbing;
				item.useAnimation = 5;
				item.knockBack = 0;
			}
			else
			{
				item.damage = 25;
				item.melee = true;
				item.channel = true;
				item.rare = ItemRarityID.Green;
				item.width = 28;
				item.height = 30;
				item.useTime = 35;
				item.UseSound = SoundID.Item1;
				item.useStyle = ItemUseStyleID.SwingThrow;
				item.shootSpeed = 14f;
				item.useAnimation = 35;
				item.autoReuse = true;
				item.knockBack = 1;
			}
			return base.CanUseItem(player);
		}
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.NextBool(3))
			{
				if (player.altFunctionUse == 2)
				{
		
				}
			}
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			speedX = new Vector2(speedX, speedY).Length() * (speedX > 0 ? 1 : -1);
			speedY = 0;
			Vector2 speed = new Vector2(speedX, speedY);
			speed = speed.RotatedByRandom(MathHelper.ToRadians(30));
			damage = (int)(damage * .1f);
			speedX = speed.X;
			speedY = speed.Y;
			return true;
		}
	}
}