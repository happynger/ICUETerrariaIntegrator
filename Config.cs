using System;
using System.IO;
using System.Reflection;
using Terraria;
using Terraria.IO;

namespace ICUETerrariaIntegration
{
	public static class Config
	{
		#region Configurations
		//! If you add any Configurations make sure to add them to the ReadConfig methods
		[CUEConfig("Disable Warnings")]
		public static bool DisableWarnings = false;
		[CUEConfig("SDK Path x64")]
		public static string SDKPathx64 = @"C:\Program Files (x86)\Steam\steamapps\common\Terraria\CUESDK\x64\CUESDK_2015.dll";
		[CUEConfig("SDK Path x86")]
		public static string SDKPathx86 = @"C:\Program Files (x86)\Steam\steamapps\common\Terraria\CUESDK\x86\CUESDK_2015.dll";
		#endregion

		private static readonly string configPath = Path.Combine(Main.SavePath, "Mod Configs", "ICUEIntegration.json");
		private static readonly Preferences configuration = new Preferences(configPath);

		public static void Load()
		{
			bool success = ReadConfig();

			if (!success)
				CreateConfig();
		}

		private static bool ReadConfig()
		{
			if (configuration.Load())
			{
				configuration.Get("Disable Warnings", ref DisableWarnings);
				configuration.Get("SDK Path x64", ref SDKPathx64);
				configuration.Get("SDK Path x86", ref SDKPathx86);
				return true;
			}
			return false;
		}

		public static void SaveConfig()
		{
			Type type = typeof(Config);

			configuration.Clear();
			foreach (FieldInfo field in type.GetFields())
			{
				var attribute = field.GetCustomAttribute<CUEConfigAttribute>();

				var tmp = field.GetValue(null);
				configuration.Put(attribute.Name, tmp);
			}
			configuration.Save();
		}
		private static void CreateConfig()
		{
			Type type = typeof(Config);

			configuration.Clear();
			foreach (var field in type.GetFields())
			{
				var attribute = field.GetCustomAttribute<CUEConfigAttribute>();

				var tmp = field.GetValue(null);
				configuration.Put(attribute.Name, tmp);
			}
			configuration.Save();
		}
	}
}
