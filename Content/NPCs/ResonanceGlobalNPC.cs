using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ResonanceandHarmony.Content.NPCs
{
    public class ResonanceGlobalNPC : GlobalNPC
    {
        public override bool InstancePerEntity => true;

        public const float MaxDamageAmp = 0.5f;
        public const float MaxDamageReduction = 0.5f;
        public const int DecayDelayTicks = 600; // 10 seconds

        // Effects applied TO THIS NPC
        public float damageAmp;        // player deals more damage to this NPC
        public float damageReduction; // this NPC deals less damage to player
        public int lastInteractionTick;

        public override void ResetEffects(NPC npc)
        {
            int ticksSinceInteraction = Main.GameUpdateCount - lastInteractionTick;

            if (ticksSinceInteraction > DecayDelayTicks)
            {
                damageAmp = MathHelper.Clamp(damageAmp - 0.004f, 0f, MaxDamageAmp);
                damageReduction = MathHelper.Clamp(damageReduction - 0.004f, 0f, MaxDamageReduction);
            }
        }

        // Modify damage taken by NPC
        public override void ModifyIncomingHit(NPC npc, ref NPC.HitModifiers modifiers)
        {
            modifiers.SourceDamage *= 1f + damageAmp;
        }

        // Modify damage dealt by NPC
        public override void ModifyHitPlayer(NPC npc, Player target, ref Player.HurtModifiers modifiers)
        {
            modifiers.FinalDamage *= 1f - damageReduction;
        }

        public override void OnKill(NPC npc)
        {
            damageAmp = 0f;
            damageReduction = 0f;
            lastInteractionTick = 0;
        }
    }
}