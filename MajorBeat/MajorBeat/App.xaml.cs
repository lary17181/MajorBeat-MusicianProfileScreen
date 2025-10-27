using MajorBeat.Views;

using MajorBeat.Views.Hirers;
using MajorBeat.Views.Musicians;

namespace MajorBeat
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Application.Current.UserAppTheme = AppTheme.Light;

            MainPage = new AppShell();
        }
    }
}
