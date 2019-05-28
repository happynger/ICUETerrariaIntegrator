using System;
using CUE.NET;
using CUE.NET.Devices.Generic.Enums;
using CUE.NET.Exceptions;
using Terraria.ModLoader;

namespace ICUETerrariaIntegration
{
	public class MainClass : Mod
	{
		public static MainClass Instance { get; set; }
		public static bool IsSDKAvailable = true;

		public override void Load()
		{
			Config.Load();
			Logger.Initialize();

			try
			{
				CueSDK.PossibleX64NativePaths.Add(Config.SDKPathx64);
				CueSDK.PossibleX86NativePaths.Add(Config.SDKPathx86);
				CueSDK.Initialize(true);
				KeyboardSystem.Setup();
				MouseSystem.Setup();
			}
			catch (CUEException e)
			{ Logger.Log($"[CUE Exception] : {Enum.GetName(typeof(CorsairError), e.Error)}"); }
			catch (WrapperException e)
			{ Logger.Log($"[Wrapper Exception] : {e.Message}"); IsSDKAvailable = false; }

			Config.SaveConfig();
		}

		public MainClass()
		{
			Instance = this;
		}
	}
}
