using Beforium.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Beforium.NPCs
{
	public class Bloodfin : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bloodfin");
			Main.npcFrameCount[npc.type] = 1;
		}
		public override void SetDefaults()
		{
			npc.width = 60;
			npc.height = 18;
			npc.damage = 0;
			npc.defense = 10;
			npc.lifeMax = 1;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath4;
			npc.value = 340f;
			npc.knockBackResist = .35f;
			npc.aiStyle = 16;
			npc.noGravity = true;
			aiType = NPCID.Goldfish;


		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			if (spawnInfo.playerSafe)
			{
				return 0f;
			}
			return SpawnCondition.OceanMonster.Chance * 1000f;
		}
		public override void AI()
		{
			npc.spriteDirection = npc.direction;
			Lighting.AddLight((int)((npc.position.X + (float)(npc.width / 2)) / 16f), (int)((npc.position.Y + (float)(npc.height / 2)) / 16f), 0.46f, 0.32f, .1f);
		}

		public override void NPCLoot()
		{
			if (Main.rand.NextBool(7))
			{
				Item.NewItem(npc.getRect(), ModContent.ItemType<Scales>());
				int centerX = (int)(npc.position.X + (float)(npc.width / 2)) / 16;
				int centerY = (int)(npc.position.Y + (float)(npc.height / 2)) / 16;
				int halfLength = npc.width / 2 / 16 + 1;

			}
		}
	}

}
