using Terraria;
using Terraria.ModLoader;

namespace ResonanceandHarmony.Content.NPCs
{
    public class ResonanceGlobalNPC : GlobalNPC
    {
        public override bool InstancePerEntity => true;

        // Effects applied TO THIS NPC
        public float damageAmp;        // player deals more damage to this NPC
        public float damageReduction; // this NPC deals less damage to player

        public override void ResetEffects(NPC npc)
        {
            // decay over time (optional)
            damageAmp *= 0.98f;
            damageReduction *= 0.98f;
        }

        // Modify damage taken by NPC
        public override void ModifyIncomingHit(NPC npc, ref NPC.HitModifiers modifiers)
        {
            modifiers.SourceDamage += damageAmp;
        }

        // Modify damage dealt by NPC
        public override void ModifyHitPlayer(NPC npc, Player target, ref Player.HurtModifiers modifiers)
        {
            modifiers.FinalDamage *= (1f - damageReduction);
        }
        public override void OnKill(NPC npc)
        {
            damageAmp = 0f;
            damageReduction = 0f;
        }
    }
}