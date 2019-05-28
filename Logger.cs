using System;
using System.IO;
using Terraria;
using Microsoft.Xna.Framework;

namespace ICUETerrariaIntegration
{
	public static class Logger
	{
		private static readonly string LogPath = Path.Combine(Main.SavePath, "Logs", "ICUEIntegration");
		private static string FilePath;

		public static void Initialize()
		{
			var date = DateTime.Now.Date.ToString("MM-dd-yyyy");

			if (!Directory.Exists(LogPath))
				Directory.CreateDirectory(LogPath);

			FilePath = Path.Combine(LogPath, $"{date}.txt");
		}

		public static void Log(string message)
		{
			var fd = File.AppendText(FilePath);

			fd.WriteLine(message);
			fd.Flush();
		}

		public static void Log()
		{
			var fd = File.AppendText(FilePath);

			Main.NewText("Logging information!", Color.Yellow);

			fd.WriteLine("--------------DEBUG INFO--------------");
			fd.WriteLine($"Current Health =>> {PlayerInfo.health}");
			fd.WriteLine($"Current Max Health =>> {PlayerInfo.healthMax}");
			fd.WriteLine($"Current Mana =>> {PlayerInfo.mana}");
			fd.WriteLine($"Current Max Mana =>> {PlayerInfo.manaMax}");
			fd.WriteLine("------Keyboard-------");
			fd.WriteLine($"Last Proportion of Health =>> {KeyboardSystem.HealthP}");
			fd.WriteLine($"Last Proportion of Mana =>> {KeyboardSystem.ManaP}");
			fd.WriteLine("--------------END   INFO--------------");
			fd.Flush();

			Main.NewText("Information has been saved!", Color.Yellow);
		}
	}
}
