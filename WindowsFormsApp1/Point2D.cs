using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
	/// Точка типа Double
	public struct Point2D
	{
		public double X, Y;
		public Point2D(double x, double y)
		{
			X = x;
			Y = y;
		}

		public override string ToString()
		{
			return "(" + X.ToString() + "; " + Y.ToString() + ")";
        }

		public string ToString(string format)
		{
			return "(" + X.ToString(format) + "; " + Y.ToString(format) + ")";
		}
	}
}
