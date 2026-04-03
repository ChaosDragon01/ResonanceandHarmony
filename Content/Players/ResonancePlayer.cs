using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using ResonanceandHarmony.Content.NPCs;
using ResonanceandHarmony.Content.Items.Buffs;

namespace ResonanceandHarmony.Content.Players
{
    public class ResonancePlayer : ModPlayer
    {
        public bool resonanceEquipped;
        public bool harmonyEquipped;
        public bool eightHandledWheelEquipped;

        public int phenomenaHitsDealt;
        public int phenomenaHitsTaken;
        public int adaptationClickCount;
        public int adaptationHitCounter;

        public override void ResetEffects()
        {
            resonanceEquipped = false;
            harmonyEquipped = false;
            eightHandledWheelEquipped = false;
        }

        public override void UpdateDead()
        {
            phenomenaHitsDealt = 0;
            phenomenaHitsTaken = 0;
            adaptationClickCount = 0;
            adaptationHitCounter = 0;
        }

        private void RegisterAdaptationHit()
        {
            adaptationHitCounter++;
            if (adaptationHitCounter >= 5)
            {
                adaptationHitCounter = 0;
                adaptationClickCount = (adaptationClickCount + 1) % 8;
            }
        }

        // -------------------------
        // DAMAGE DEALT
        // -------------------------
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (!resonanceEquipped && !eightHandledWheelEquipped)
                return;

            var npcData = target.GetGlobalNPC<ResonanceGlobalNPC>();
            npcData.lastInteractionTick = Main.GameUpdateCount;

            npcData.damageAmp = MathHelper.Clamp(npcData.damageAmp + 0.05f, 0f, ResonanceGlobalNPC.MaxDamageAmp);
            phenomenaHitsDealt++;
            RegisterAdaptationHit();

            if (npcData.damageAmp >= ResonanceGlobalNPC.MaxDamageAmp)
            {
                target.AddBuff(ModContent.BuffType<SwordOfExtermination>(), 300);
            }
        }

        // -------------------------
        // DAMAGE TAKEN
        // -------------------------
        public override void OnHurt(Player.HurtInfo info)
        {
            if (!harmonyEquipped && !eightHandledWheelEquipped)
                return;

            NPC attacker = null;
            if (info.DamageSource.SourceNPCIndex >= 0)
            {
                attacker = Main.npc[info.DamageSource.SourceNPCIndex];
            }

            if (attacker == null)
                return;

            var npcData = attacker.GetGlobalNPC<ResonanceGlobalNPC>();
            npcData.lastInteractionTick = Main.GameUpdateCount;

            npcData.damageReduction = MathHelper.Clamp(npcData.damageReduction + 0.05f, 0f, ResonanceGlobalNPC.MaxDamageReduction);
            phenomenaHitsTaken++;
            RegisterAdaptationHit();
        }
    }
}