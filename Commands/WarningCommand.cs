using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ICUETerrariaIntegration.Commands
{
	public class WarningCommand : ModCommand
	{
		public override string Command
			=> "ci|disablewarn";

		public override string Description
			=> "Disables the warnings on load into world.";

		public override string Usage
			=> "/ci|disablewarn <true/false>";

		public override CommandType Type
			=> CommandType.Chat;

		public override void Action(CommandCaller caller, string input, string[] args)
		{
			bool result;

			if (args.Length == 0)
				throw new UsageException($"No argument received");

			if (!bool.TryParse(args[0], out result))
			{
				ErrorLogger.Log("Wrong Argument passed to ci_disable command");
				throw new UsageException($"Wrong argument: {args[0]}");
			}

			Config.DisableWarnings = result;
			Config.SaveConfig();
			Main.NewText($"Disable Warnings = {Config.DisableWarnings}", Color.Aquamarine);
		}
	}
}
