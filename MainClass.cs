using System;
using CUE.NET;
using System.Reflection;
using Terraria.ModLoader;
using CUE.NET.Exceptions;
using CUE.NET.Devices.Generic.Enums;

namespace ICUETerrariaIntegration
{
	public class MainClass : Mod
	{
		public static MainClass Instance { get; set; }
		public static bool IsSDKAvailable = true;

		public override void Load()
		{
			Config.Load();

			try
			{
				CueSDK.PossibleX64NativePaths.Add(Config.SDKPathx64);
				CueSDK.PossibleX86NativePaths.Add(Config.SDKPathx86);
				CueSDK.Initialize(true);
				Console.WriteLine($"Initialised with {CueSDK.LoadedArchitecture}-SDK");
				KeyboardSystem.Setup();
				MouseSystem.Setup();
			}
			catch (CUEException e)
				{ Console.WriteLine($"[CUE Exception] : {Enum.GetName(typeof(CorsairError), e.Error)}"); }
			catch (WrapperException e)
				{ Console.WriteLine($"[Wrapper Exception] : {e.Message}"); IsSDKAvailable = false; }

			Config.SaveConfig();
		}

		public MainClass()
		{
			Instance = this;
		}
	}
}
