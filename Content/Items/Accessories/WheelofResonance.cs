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
            Item.value = Item.buyPrice(gold: 2);
            Item.rare = ItemRarityID.Blue;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddRecipeGroup(RecipeGroupID.GoldBar);
            recipe.AddIngredient(ItemID.DemoniteBar, 6);
            recipe.AddIngredient(ItemID.CrimtaneBar, 6);
            recipe.AddRecipeGroup(RecipeGroupID.ShadowScale);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            var modPlayer = player.GetModPlayer<ResonancePlayer>();
            modPlayer.resonanceEquipped = true;
        }
    }
}