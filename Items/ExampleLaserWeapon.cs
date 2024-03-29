﻿using Beforium.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Beforium.Items
{
	public class ExampleLaserWeapon : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Shoot a laser beam that can eliminate anything...");
		}

		public override void SetDefaults()
		{
			item.damage = 40;
			item.noMelee = true;
			item.magic = true;
			item.channel = true; 
			item.mana = 5;
			item.rare = ItemRarityID.Pink;
			item.width = 28;
			item.height = 30;
			item.useTime = 20;
			item.UseSound = SoundID.Item13;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.shootSpeed = 14f;
			item.useAnimation = 20;
			item.shoot = ModContent.ProjectileType<ExampleLaser>();
			item.value = Item.sellPrice(silver: 3);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DirtBlock, 10);
			recipe.AddIngredient(ItemID.WoodYoyo);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}