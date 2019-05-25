using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ICUETerrariaIntegration.Items
{
	public class ExampleItem : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("ExampleItem");
			Tooltip.SetDefault("An example item to check the tutorial");
		}

		public override void SetDefaults()
		{
			item.damage = 100;
			item.melee = true;
			item.width = 128;
			item.height = 128;
			item.useTime = 10;
			item.useAnimation = 10;
			item.useStyle = 1;
			item.knockBack = 3;
			item.value = 100000;
			item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override bool UseItem(Player player)
		{
			return true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DirtBlock, 10);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
