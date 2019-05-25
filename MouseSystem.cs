using System;
using CUE.NET;
using CUE.NET.Groups;
using CUE.NET.Brushes;
using CUE.NET.Devices.Mouse;
using CUE.NET.Devices.Mouse.Enums;
using CUE.NET.Devices.Generic;
using System.Collections.Generic;
using CUE.NET.Devices.Generic.Enums;

namespace ICUETerrariaIntegration
{
	public class MouseSystem
	{
		public static bool IsMouseCompatible = true;

		private static CorsairMouse mouse;
		private static HitBrush MagicWeaponBrush;
		private static HitBrush MeleeWeaponBrush;

		public static void Setup()
		{
			mouse = CueSDK.MouseSDK;
			if (mouse == null)
			{
				IsMouseCompatible = false;
				return;
			}

			MagicWeaponBrush = new HitBrush(new CorsairColor(255, 0, 0, 255));
			MeleeWeaponBrush = new HitBrush(new CorsairColor(255, 255, 0, 0));

			mouse.Brush = (SolidColorBrush)new CorsairColor(255, 0, 0, 0);
			mouse.Update();
		}

		public static void DealtDamage(bool isMagic, int damage, bool isCrit, int dmgMax)
		{
			HitBrush hitBrush;
			if (isMagic)
				hitBrush = MagicWeaponBrush;
			else
				hitBrush = MeleeWeaponBrush;

			hitBrush.Damage = damage;
			hitBrush.IsCrit = isCrit;
			hitBrush.DamageMax = dmgMax;

			mouse.Brush = hitBrush;
			mouse.Update();
		}

	}
}
