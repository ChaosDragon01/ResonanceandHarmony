using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ResonanceandHarmony.Content.Players;

namespace ResonanceandHarmony.Content.Items.Accessories
{
    public class WheelOfHarmony : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.accessory = true;
            Item.value = Item.buyPrice(gold: 1);
            Item.rare = ItemRarityID.Green;
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
            player.GetModPlayer<ResonancePlayer>().harmonyEquipped = true;
        }
    }
}