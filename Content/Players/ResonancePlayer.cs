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

        public float resonanceMeter; // 0 to 1 (50% = 0.5f)

        public override void ResetEffects()
        {
            resonanceEquipped = false;
            harmonyEquipped = false;
        }

        public override void UpdateDead()
        {
            resonanceMeter = 0f;
        }

        // -------------------------
        // DAMAGE DEALT
        // -------------------------
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (!resonanceEquipped)
                return;

            var npcData = target.GetGlobalNPC<ResonanceGlobalNPC>();

            // Build meter
            resonanceMeter += damageDone / 1000f; // placeholder scaling

            // RNG: apply damage boost to THIS NPC
            if (Main.rand.NextFloat() < 0.2f) // placeholder chance
            {
                npcData.damageAmp += 0.1f; // placeholder value
            }

            // Trigger Extermination debuff at 50%
            if (resonanceMeter >= 0.5f)
            {
                // Fixed: Removed the lowercase "buffs." typo
                target.AddBuff(ModContent.BuffType<SwordOfExtermination>(), 300);
                resonanceMeter -= 0.5f;
            }
        }

        // -------------------------
        // DAMAGE TAKEN
        // -------------------------
        public override void OnHurt(Player.HurtInfo info)
        {
            if (!harmonyEquipped)
                return;

            // Fixed: Correctly fetch the attacker using SourceNPCIndex
            NPC attacker = null;
            if (info.DamageSource.SourceNPCIndex >= 0)
            {
                attacker = Main.npc[info.DamageSource.SourceNPCIndex];
            }

            if (attacker == null)
                return;

            var npcData = attacker.GetGlobalNPC<ResonanceGlobalNPC>();

            float roll = Main.rand.NextFloat();

            if (roll < 0.6f)
            {
                // Damage reduction
                npcData.damageReduction += 0.1f; // placeholder
            }
            else if (roll < 0.9f)
            {
                // Heal %
                int heal = (int)(info.Damage * 0.2f); // placeholder
                Player.statLife += heal;
                Player.HealEffect(heal);
            }
            else
            {
                // Immunity
                Player.immune = true;
                Player.immuneTime = 60;
            }
        }
    }
}