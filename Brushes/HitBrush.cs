using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CUE.NET;
using CUE.NET.Brushes;
using CUE.NET.Devices.Generic;

namespace ICUETerrariaIntegration
{
	public class HitBrush : AbstractBrush
	{
		public CorsairColor Color { get; set; }
		public int Damage { get; set; }
		public int DamageMax { get; set; }
		public bool IsCrit { get; set; }

		public HitBrush(CorsairColor color)
		{
			Color = color;
		}

		protected override CorsairColor GetColorAtPoint(RectangleF rectangle, BrushRenderTarget renderTarget)
		{
			CorsairColor color;

			if (Damage >= DamageMax)
				color = Color;
			else if (IsCrit)
				color = new CorsairColor(193, 5, 255);
			else
			{
				float factor = (float)Math.Ceiling((float)(Damage / DamageMax) * 10) / 10f;
				color = new CorsairColor(255,
										 (byte)(Color.R * factor),
										 (byte)(Color.G * factor),
										 (byte)(Color.B * factor));
			}

			return color;
		}
	}
}
