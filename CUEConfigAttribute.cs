using System;

namespace ICUETerrariaIntegration
{
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
	public class CUEConfigAttribute : Attribute
	{
		public string Name { get; }

		public CUEConfigAttribute(string name)
		{
			Name = name;
		}
	}
}
