using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ResonanceandHarmony.Content.Players;

namespace ResonanceandHarmony.Content.Items.Accessories
{
    public class EightHandledWheelOfAdaptation : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Eight-Handled Wheel of Adaptation");
            Tooltip.SetDefault("Combines resonance and harmony to adapt offensively and defensively.");
        }

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 24;
            Item.accessory = true;
            Item.value = Item.buyPrice(gold: 10);
            Item.rare = ItemRarityID.LightRed;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddRecipeGroup(RecipeGroupID.GoldBar);
            recipe.AddIngredient(ItemID.DemoniteBar, 8);
            recipe.AddIngredient(ItemID.CrimtaneBar, 8);
            recipe.AddRecipeGroup(RecipeGroupID.ShadowScale);
            recipe.AddIngredient(ItemID.TissueSample, 8);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            var modPlayer = player.GetModPlayer<ResonancePlayer>();
            modPlayer.resonanceEquipped = true;
            modPlayer.harmonyEquipped = true;
            modPlayer.eightHandledWheelEquipped = true;
        }
    }
}
