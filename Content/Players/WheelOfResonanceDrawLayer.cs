using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using ResonanceandHarmony.Content.Players;

namespace ResonanceandHarmony.Content.Players
{
    public class WheelOfResonanceDrawLayer : PlayerDrawLayer
    {
        public override Position GetDefaultPosition() => new AfterParent(PlayerDrawLayers.Head);

        public override bool GetDefaultVisibility(PlayerDrawSet drawInfo)
        {
            var player = drawInfo.drawPlayer;
            var mp = player.GetModPlayer<ResonancePlayer>();
            return mp.resonanceEquipped || mp.harmonyEquipped || mp.eightHandledWheelEquipped;
        }

        protected override void Draw(ref PlayerDrawSet drawInfo)
        {
            Player player = drawInfo.drawPlayer;
            var mp = player.GetModPlayer<ResonancePlayer>();
            if (mp == null)
                return;

            if (!mp.resonanceEquipped && !mp.harmonyEquipped && !mp.eightHandledWheelEquipped)
                return;

            Texture2D texture = ModContent.Request<Texture2D>("ResonanceandHarmony/Content/Items/Accessories/WheelOfResonance").Value;
            if (texture == null)
                return;

            Vector2 position = player.Center - Main.screenPosition + new Vector2(0f, -player.height * 0.65f);
            float rotation = MathHelper.ToRadians(mp.adaptationClickCount * 45f);
            Vector2 origin = texture.Size() * 0.5f;
            Color drawColor = Lighting.GetColor((int)player.Center.X / 16, (int)player.Center.Y / 16, Color.White);

            Main.EntitySpriteDraw(texture, position, null, drawColor, rotation, origin, 1f, SpriteEffects.None, 0);
        }
    }
}
