
using MauiAppHotel.Services;

namespace MauiAppHotel.Views;

public partial class Sobre : ContentPage
{
    public Sobre()
    {
        InitializeComponent();

        AplicarIdioma();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        AplicarIdioma();
    }

    private void AplicarIdioma()
    {
        Title = IdiomaService.Obter("Sobre");

        lblSlogan.Text = IdiomaService.Obter("BoasVindas");
        lblSobreAplicativo.Text = IdiomaService.Obter("SobreAplicativo");
        lblDescricaoSobre.Text = IdiomaService.Obter("DescricaoSobre");

        lblInformacoesProjeto.Text = IdiomaService.Obter("InformacoesProjeto");
        lblDesenvolvedora.Text = IdiomaService.Obter("Desenvolvedora");
        lblAnoDesenvolvimento.Text = IdiomaService.Obter("AnoDesenvolvimento");

        btnVoltar.Text = IdiomaService.Obter("Voltar");
        lblRodape.Text = IdiomaService.Obter("RodapeSobre");
    }

    private async void Voltar_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}
