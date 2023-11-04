namespace MauiFiszki;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(Views.SectionSelection), typeof(Views.SectionSelection));
		Routing.RegisterRoute(nameof(Views.Fiszki), typeof(Views.Fiszki));
		Routing.RegisterRoute(nameof(Views.LanguageSelection), typeof(Views.LanguageSelection));
    }
}

