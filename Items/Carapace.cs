using Terraria.ID;
using Terraria.ModLoader;

namespace Beforium.Items
{
	public class Carapace : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("A hard shell left by a crab.");
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.maxStack = 999;
			item.value = 100;
			item.rare = ItemRarityID.Blue;
		}
	}
}