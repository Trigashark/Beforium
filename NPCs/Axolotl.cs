using Beforium.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace Beforium.NPCs
{
	public class Axolotl : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Axolotl");
			Main.npcFrameCount[npc.type] = 4;
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

		public override void FindFrame(int frameHeight)
		{
			npc.frameCounter += 0.15f;
			npc.frameCounter %= Main.npcFrameCount[npc.type];
			int frame = (int)npc.frameCounter;
			npc.frame.Y = frame * frameHeight;
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			if (spawnInfo.playerSafe)
			{
				return 0f;
			}
			return SpawnCondition.OceanMonster.Chance * 200f;
		}

		
		public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
		{
			var effects = npc.direction == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
			spriteBatch.Draw(Main.npcTexture[npc.type], npc.Center - Main.screenPosition + new Vector2(0, npc.gfxOffY), npc.frame,
							 drawColor, npc.rotation, npc.frame.Size() / 2, npc.scale, effects, 0);
			return false;
		}
	
		public override void OnHitPlayer(Player target, int damage, bool crit)
		{
			if (Main.rand.Next(8) == 0)
			{
				target.AddBuff(BuffID.Sunflower, 180, true);
				target.AddBuff(BuffID.Lovestruck, 180, true);
			}
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