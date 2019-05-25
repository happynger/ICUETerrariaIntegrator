using System;
using Terraria;
using System.Reflection;
using Terraria.ModLoader;
using Terraria.Localization;
using Microsoft.Xna.Framework;

namespace ICUETerrariaIntegration.Commands
{
	public class ListConfigCommand : ModCommand
	{
		public override string Command
			=> "ci|list";

		public override string Description
			=> "Lists Current Values of the Config";

		public override string Usage
			=> "/ci|list";

		public override CommandType Type
			=> CommandType.Chat;

		public override void Action(CommandCaller caller, string input, string[] args)
		{
			Type type = typeof(Config);

			foreach (FieldInfo field in type.GetFields())
			{
				foreach (var attribute in field.GetCustomAttributes(false))
				{
					CUEConfigAttribute cattr = (CUEConfigAttribute)attribute;

					if (cattr != null)
						Main.NewText($"{cattr.Name} : {field.GetValue(null)}", Color.Purple);
				}
			}
			
		}
	}
}
