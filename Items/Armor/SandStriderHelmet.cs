using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Beforium.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
	public class SandStriderHelmet : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("May the shells protect you.");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = ItemRarityID.Green;
			item.defense = 5;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<SandStriderBreastplate>() && legs.type == ModContent.ItemType<SandStriderLeggings>();
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "The sand wraps around you";
			player.allDamage -= 0.5f;
			
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DirtBlock, 10);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}