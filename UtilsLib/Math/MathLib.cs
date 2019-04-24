namespace UtilsLib.Math
{
	public class MathLib
	{
		public static int Mod(int i, int modulo)
		{
			int r = i % modulo;
			return r < 0 ? r + modulo : r;
		}
	}
}
