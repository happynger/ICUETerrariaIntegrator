using System;
using System.Collections.Generic;
using Terraria.ModLoader;

namespace ICUETerrariaIntegration.Commands
{
	public class DumpDataCommand : ModCommand
	{
		public override string Command
			=> "ci|dump";

		public override CommandType Type
			=> CommandType.Chat;

		public override string Description
			=> "Dumps debug info into today's log";

		public override string Usage
			=> "/ci|dump";

		public override void Action(CommandCaller caller, string input, string[] args)
		{
			Logger.Log();
		}
	}
}
