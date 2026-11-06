
using System.Globalization;
using MauiAppHotel.Services;

namespace MauiAppHotel.Views;

public partial class Resumo : ContentPage
{
    private readonly CultureInfo culturaBrasileira =
        new CultureInfo("pt-BR");

    private readonly int adultos;
    private readonly int criancas;
    private readonly string acomodacao;
    private readonly int quantidadeQuartos;
    private readonly DateTime checkin;
    private readonly DateTime checkout;
    private readonly decimal valorAplicado;
    private readonly bool pernoite;
    private readonly TimeSpan? horarioEntrada;
    private readonly TimeSpan? horarioSaida;

    private readonly int totalNoites;
    private readonly int noitesComAdicional;
    private readonly decimal valorTotal;

    public Resumo(
        int adultos,
        int criancas,
        string acomodacao,
        int quantidadeQuartos,
        DateTime checkin,
        DateTime checkout,
        decimal valorAplicado,
        bool pernoite = false,
        TimeSpan? horarioEntrada = null,
        TimeSpan? horarioSaida = null)
    {
        InitializeComponent();

        this.adultos = adultos;
        this.criancas = criancas;
        this.acomodacao = acomodacao;
        this.quantidadeQuartos = quantidadeQuartos;
        this.checkin = checkin;
        this.checkout = checkout;
        this.valorAplicado = valorAplicado;
        this.pernoite = pernoite;
        this.horarioEntrada = horarioEntrada;
        this.horarioSaida = horarioSaida;

        totalNoites = (checkout.Date - checkin.Date).Days;

        int adicional = 0;

        // Verifica cada noite da hospedagem
        for (DateTime noite = checkin.Date;
             noite < checkout.Date;
             noite = noite.AddDays(1))
        {
            if (EhFeriadoNacional(noite) ||
                EhPeriodoDeFerias(noite))
            {
                adicional++;
            }
        }

        noitesComAdicional = adicional;

        // Calcula o valor considerando todos os quartos
        int noitesNormais = totalNoites - noitesComAdicional;

        decimal valorPorNoite = valorAplicado * quantidadeQuartos;

        decimal valorNormal =
            noitesNormais * valorPorNoite;

        decimal valorAdicional =
            noitesComAdicional * valorPorNoite * 1.30m;

        valorTotal = valorNormal + valorAdicional;

        AtualizarDados();
        AplicarIdioma();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        AplicarIdioma();
    }

    // Atualiza os dados da reserva
    private void AtualizarDados()
    {
        int totalHospedes = adultos + criancas;

        lblAcomodacao.Text = acomodacao;
        lblQuartos.Text = quantidadeQuartos.ToString();

        lblModalidade.Text = pernoite
            ? IdiomaService.Obter("Pernoite")
            : IdiomaService.Obter("EstadiaTradicional");

        lblAdultos.Text = adultos.ToString();
        lblCriancas.Text = criancas.ToString();
        lblTotalHospedes.Text = totalHospedes.ToString();

        lblCheckin.Text = checkin.ToString(
            "dd/MM/yyyy", culturaBrasileira);

        lblCheckout.Text = checkout.ToString(
            "dd/MM/yyyy", culturaBrasileira);

        lblNoites.Text = totalNoites == 1
            ? $"1 {IdiomaService.Obter("Noite")}"
            : $"{totalNoites} {IdiomaService.Obter("Noites")}";

        linhaHorarioEntrada.IsVisible = pernoite;
        linhaHorarioSaida.IsVisible = pernoite;

        if (pernoite)
        {
            lblHorarioEntrada.Text =
                horarioEntrada?.ToString(@"hh\:mm") ?? "--:--";

            lblHorarioSaida.Text =
                horarioSaida?.ToString(@"hh\:mm") ?? "--:--";
        }

        decimal valorPorNoite = valorAplicado * quantidadeQuartos;

        lblValorQuarto.Text = valorAplicado.ToString(
            "C2", culturaBrasileira);

        lblQuantidadeQuartosValor.Text =
            quantidadeQuartos.ToString();

        lblDiaria.Text = valorPorNoite.ToString(
            "C2", culturaBrasileira);

        lblFeriados.Text = noitesComAdicional == 0
            ? IdiomaService.Obter("Nenhuma")
            : $"{noitesComAdicional} {IdiomaService.Obter("NoiteAdicional")}";

        lblTotal.Text = valorTotal.ToString(
            "C2", culturaBrasileira);
    }

    // Traduz os textos da tela
    private void AplicarIdioma()
    {
        Title = IdiomaService.Obter("TituloResumo");

        lblTituloResumo.Text = IdiomaService.Obter("TituloResumo");
        lblDescricaoResumo.Text = IdiomaService.Obter("DescricaoResumo");

        lblTituloReserva.Text = IdiomaService.Obter("SuaReserva");
        lblTextoAcomodacao.Text = IdiomaService.Obter("Acomodacao");
        lblTextoQuartos.Text = IdiomaService.Obter("QuantidadeQuartos");
        lblTextoModalidade.Text = IdiomaService.Obter("Modalidade");
        lblTextoAdultos.Text = IdiomaService.Obter("Adultos");
        lblTextoCriancas.Text = IdiomaService.Obter("Criancas");
        lblTextoTotalHospedes.Text = IdiomaService.Obter("TotalHospedes");
        lblTextoCheckin.Text = IdiomaService.Obter("Checkin");
        lblTextoHorarioEntrada.Text = IdiomaService.Obter("HorarioEntradaResumo");
        lblTextoCheckout.Text = IdiomaService.Obter("Checkout");
        lblTextoHorarioSaida.Text = IdiomaService.Obter("HorarioSaidaResumo");
        lblTextoNoites.Text = IdiomaService.Obter("TotalNoites");

        lblTituloValores.Text = IdiomaService.Obter("Valores");
        lblTextoValorQuarto.Text = IdiomaService.Obter("ValorPorQuarto");
        lblTextoQuantidadeQuartosValor.Text = IdiomaService.Obter("QuantidadeQuartos");
        lblTextoDiaria.Text = IdiomaService.Obter("TotalPorNoite");
        lblTextoFeriados.Text = IdiomaService.Obter("NoitesAdicional");
        lblAvisoAdicional.Text = IdiomaService.Obter("AvisoAdicional");
        lblTextoTotal.Text = IdiomaService.Obter("TotalHospedagem");

        btnVoltar.Text = IdiomaService.Obter("Voltar");

        AtualizarDados();
    }

    // Verifica feriados nacionais
    private bool EhFeriadoNacional(DateTime data)
    {
        int ano = data.Year;

        DateTime[] feriados =
        {
            new DateTime(ano, 1, 1),
            new DateTime(ano, 4, 21),
            new DateTime(ano, 5, 1),
            new DateTime(ano, 9, 7),
            new DateTime(ano, 10, 12),
            new DateTime(ano, 11, 2),
            new DateTime(ano, 11, 15),
            new DateTime(ano, 11, 20),
            new DateTime(ano, 12, 25)
        };

        return feriados.Contains(data.Date);
    }

    // Verifica os períodos de férias
    private bool EhPeriodoDeFerias(DateTime data)
    {
        return data.Month == 12 ||
               data.Month == 1 ||
               data.Month == 7;
    }

    // Botão voltar
    private async void Voltar_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}
