namespace MauiFiszki.Views;
using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;
using System.Threading.Tasks;
using Models;
using MauiFiszki.DbConntection;


public partial class Fiszki : ContentPage
{
    public FiszkaData fiszkaData { set; get; }
    public LanguageSectionList update { set; get; }
    public static LannguageSectionDeatails Dział { set; get; }
    public ResourceDictionary ColorResource = Application.Current.Resources.MergedDictionaries.FirstOrDefault() as ResourceDictionary;

    public Fiszki(LannguageSectionDeatails dzial)
	{
        update = new LanguageSectionList(dzial.Lang);
        Dział = dzial;
        fiszkaData = new FiszkaData(dzial);
        InitializeComponent();
        BindingContext = this;
	}

    void End()
    {
        buttonShowAllSections.IsVisible = true;
        resultLabel.TextColor = ColorResource["MyBlue"] as Color;
    }

    async void ChceckAnswear(string result)
    {
        insertLayout.IsVisible = false;
        resultLayout.IsVisible = true;
        resultLabel.Text = result;

        if (result == "Gratulacje")
        {
            End();
            return;
        }

        if (result == "Dobrze")
        {
            gridLayout.BackgroundColor = Colors.Green;
        }
        else
        {
            gridLayout.BackgroundColor = Colors.Red;
            fiszkaData.RigthAnswear(resultLabelBlad);
        }

        await Task.Delay(1500);

        resultLabelBlad.IsVisible = false;
        insertLayout.IsVisible = true;
        resultLayout.IsVisible = false;

        gridLayout.BackgroundColor = ColorResource["MyYellow"] as Color;
    }

    void ButtonCheck_Clicked(System.Object sender, System.EventArgs e)
    {
        string word = InputTlumacznie.Text;
        InputTlumacznie.Text = "";

        ChceckAnswear(fiszkaData.check(word));
    }

    async void ButtonShowAllSections_Clicked(System.Object sender, System.EventArgs e)
    {
        fiszkaData.completition = "Ukończone!!!";
        update.SectionUpdate(Dział);
        await Navigation.PushAsync(new SectionSelection(Dział.Lang));

    }
}
