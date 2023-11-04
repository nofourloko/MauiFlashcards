using System.Collections.ObjectModel;
using System.Diagnostics.Metrics;
using MauiFiszki.Models;
namespace MauiFiszki.Views;


public partial class SectionSelection : ContentPage
{
	public LanguageSectionList selectionList { set; get; }
	public SectionSelection(string languageSelected)
	{
		selectionList = new LanguageSectionList(languageSelected);
		InitializeComponent();
		BindingContext = this;
	}

    async void ListView_ItemSelected(System.Object sender, Microsoft.Maui.Controls.SelectedItemChangedEventArgs e)
    {
		if(e.SelectedItem != null)
		{
			LannguageSectionDeatails dzial = (LannguageSectionDeatails)e.SelectedItem;
			await Navigation.PushAsync(new Fiszki(dzial));
		}
        Section_ListView.SelectedItem = null;
    }

    async void ButtonBack_Clicked(System.Object sender, System.EventArgs e)
    {
		await Navigation.PushAsync(new LanguageSelection());
    }

}
