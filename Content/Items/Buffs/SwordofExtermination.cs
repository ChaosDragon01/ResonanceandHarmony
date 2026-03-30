using Terraria;
using Terraria.ModLoader;


namespace ResonanceandHarmony.Content.Items.Buffs
{
    public class SwordOfExtermination : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = true;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            // DoT effect (placeholder)
            npc.lifeRegen -= 20; // scales with damage amp

        }
    }
}