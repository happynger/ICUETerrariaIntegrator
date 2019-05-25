using System.Collections.Generic;
using System;
using CUE.NET;
using CUE.NET.Brushes;
using CUE.NET.Devices.Generic;
using CUE.NET.Devices.Generic.Enums;
using CUE.NET.Devices.Keyboard;
using CUE.NET.Exceptions;
using CUE.NET.Groups;

namespace ICUETerrariaIntegration
{
	public class KeyboardSystem
	{
		public static CorsairKeyboard keyboard;
		public static bool IsKeyboardCompatible = true;

		private static List<CorsairLedId> HealthLedIDs;
		private static List<CorsairLedId> ManaLedIDs;
		private static ListLedGroup HealthGroup;
		private static ListLedGroup ManaGroup;

		private static readonly CorsairColor HealthColor = new CorsairColor(255, 255, 0, 0);
		private static readonly CorsairColor ManaColor = new CorsairColor(255, 0, 0, 255);
		private static readonly HealthBrush HealthBrush = new HealthBrush(HealthColor);
		private static readonly ManaBrush ManaBrush = new ManaBrush(ManaColor);

		public static void Setup()
		{
			keyboard = CueSDK.KeyboardSDK;
			if (keyboard == null)
			{
				IsKeyboardCompatible = false;
				return;
			}

			HealthLedIDs = new List<CorsairLedId>()
			{
				CorsairLedId.D0,
				CorsairLedId.D1,
				CorsairLedId.D2,
				CorsairLedId.D3,
				CorsairLedId.D4,
				CorsairLedId.D5,
				CorsairLedId.D6,
				CorsairLedId.D7,
				CorsairLedId.D8,
				CorsairLedId.D9,
			};
			ManaLedIDs = new List<CorsairLedId>()
			{
				CorsairLedId.F1,
				CorsairLedId.F2,
				CorsairLedId.F3,
				CorsairLedId.F4,
				CorsairLedId.F5,
				CorsairLedId.F6,
				CorsairLedId.F7,
				CorsairLedId.F8,
				CorsairLedId.F9,
				CorsairLedId.F10,
				CorsairLedId.F11,
				CorsairLedId.F12,
			};

			HealthGroup = new ListLedGroup(keyboard, HealthLedIDs);
			ManaGroup = new ListLedGroup(keyboard, ManaLedIDs);
			
			keyboard.Brush = (SolidColorBrush)CorsairColor.Transparent;
			keyboard.Update();
		}

		public static void ChangeHealth(int health, int healthMax)
		{
			float healthp = (float)Math.Ceiling((float)health / healthMax * 10) / 10f;
			int num_keys = (int)((healthp + 0.00001f) * 10);
			HealthBrush.BarProgress = num_keys;
			HealthBrush.HealthP = (int)((float)health / healthMax * 100);

			HealthGroup.Brush = HealthBrush;
			keyboard.Update();
		}

		public static void ChangeMana(int mana, int manaMax)
		{
			float manap = (float)Math.Ceiling((float)mana / manaMax * 10) / 10f;
			int num_keys = (int)((manap + 0.00001f) * 12);
			ManaBrush.BarProgress = num_keys;
			ManaBrush.ManaP = (int)((float)mana / manaMax * 120);

			ManaGroup.Brush = ManaBrush;
			keyboard.Update();
		}
	}
}
