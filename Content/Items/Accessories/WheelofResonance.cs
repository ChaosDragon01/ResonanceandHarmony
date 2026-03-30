using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ResonanceandHarmony.Content.Players;

namespace ResonanceandHarmony.Content.Items.Accessories
{
    public class WheelOfResonance : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.accessory = true;
            Item.value = Item.buyPrice(gold: 1);
            Item.rare = ItemRarityID.Blue;
        }


        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Wood, 10);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<ResonancePlayer>().resonanceEquipped = true;
        }
    }
}