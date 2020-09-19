//************************************************************************************************
// Copyright © 2016 Steven M Cohn.  Yada yada...
//************************************************************************************************

namespace Cropper
{
	using System;
	using System.Drawing;


	internal static class UIHelper
	{

		public static (float, float) GetDpiValues()
		{
			using (var graphics = Graphics.FromHwnd(IntPtr.Zero))
			{
				return (graphics.DpiX, graphics.DpiY);
			}
		}
	}
}
