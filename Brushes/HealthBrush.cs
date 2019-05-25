using System.Collections.Generic;
using System.Drawing;
using CUE.NET.Brushes;
using CUE.NET.Devices.Generic;
using CUE.NET.Devices.Generic.Enums;

namespace ICUETerrariaIntegration
{
	public class HealthBrush : AbstractBrush
	{
		public CorsairColor Color { get; set; }
		public int BarProgress { get; set; }
		public int HealthP { get; set; }

		public HealthBrush(CorsairColor color)
		{
			Color = color;
		}

		protected override CorsairColor GetColorAtPoint(RectangleF rectangle, BrushRenderTarget renderTarget)
		{
			CorsairColor color;
			int ID = (int)renderTarget.LedId - 13;

			if (ID < BarProgress)
				color = Color;
			else if (ID == BarProgress)
			{
				float factor = (HealthP - (BarProgress - 1) * 10) / 10f;
				color = new CorsairColor(255,
										 (byte)(Color.R * factor),
										 (byte)(Color.G * factor),
										 (byte)(Color.B * factor));
			}
			else
				color = new CorsairColor(255, 0, 0, 0);

			return color;
		}
	}
}
