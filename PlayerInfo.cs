using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.IO;
using Microsoft.Xna.Framework;

namespace ICUETerrariaIntegration
{
	public class PlayerInfo : ModPlayer
	{
		public static int health;
		public static int mana;
		public static int healthMax;
		public static int manaMax;

		public override void OnEnterWorld(Player player)
		{
			Color msgColor = Color.Red;

			if (!KeyboardSystem.IsKeyboardCompatible && !Config.DisableWarnings)
				Main.NewText("Current Keyboard is not supported by this mod :(", msgColor);

			if (!MouseSystem.IsMouseCompatible && !Config.DisableWarnings)
				Main.NewText("Current Mouse is not supported by this mod :(", msgColor);
		}

		public override void PostUpdate()
		{
			if (!KeyboardSystem.IsKeyboardCompatible)
				return;

			health = player.statLife;
			mana = player.statMana;
			healthMax = player.statLifeMax2;
			manaMax = player.statManaMax2;

			KeyboardSystem.ChangeHealth(health, healthMax);
			KeyboardSystem.ChangeMana(mana, manaMax);
		}

		public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
		{
			if (!MouseSystem.IsMouseCompatible)
				return;

			bool ismagic = item.magic;
			int dmgMax = item.damage;
			MouseSystem.DealtDamage(ismagic, damage, crit, dmgMax);
		}
	}
}
