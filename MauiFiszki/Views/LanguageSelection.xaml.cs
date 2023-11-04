namespace MauiFiszki.Views;

public partial class LanguageSelection : ContentPage
{
	public LanguageSelection()
	{
		InitializeComponent();
		
	}

    async void language_Clicked(System.Object sender, System.EventArgs e)
    {
		Button button = (Button)sender;

		if (button.Text == "Angielski")
		{
			await Navigation.PushAsync(new SectionSelection("Angielski"));
		}
		else if (button.Text == "Niemiecki")
		{
			await Navigation.PushAsync(new SectionSelection("Niemiecki"));
		}
		title.Focus();
    }
}
