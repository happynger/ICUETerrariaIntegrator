using System.Drawing;
using System.Collections.Generic;
using CUE.NET.Brushes;
using CUE.NET.Devices.Generic;
using CUE.NET.Devices.Generic.Enums;

namespace ICUETerrariaIntegration
{
	public class ManaBrush : AbstractBrush
	{
		public CorsairColor Color { get; set; }
		public int BarProgress { get; set; }
		public int ManaP { get; set; }

		public ManaBrush(CorsairColor color)
		{
			Color = color;
		}

		protected override CorsairColor GetColorAtPoint(RectangleF rectangle, BrushRenderTarget renderTarget)
		{
			CorsairColor color;
			int ID;

			if (renderTarget.LedId == CorsairLedId.F12)
				ID = (int)CorsairLedId.F12 - 61;
			else
				ID = (int)renderTarget.LedId - 1;

			if (ID < BarProgress)
				color = Color;
			else if (ID == BarProgress)
			{
				float factor = (ManaP - (BarProgress - 1) * 10) / 10f;
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
