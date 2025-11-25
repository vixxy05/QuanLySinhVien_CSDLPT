using System.Windows.Forms;

namespace QuanLySinhVienWinForms
{
	internal static class ApplicationConfiguration
	{
		public static void Initialize()
		{
			Application.EnableVisualStyles();
			Application.SetHighDpiMode(HighDpiMode.SystemAware);
			Application.SetCompatibleTextRenderingDefault(false);
		}
	}
}



