
using MauiAppHotel.Services;

namespace MauiAppHotel.Views;

public partial class ContratacaoHospedagem : ContentPage
{
    private int adultos = 1;
    private int criancas = 0;
    private int quantidadeQuartos = 1;

    private const int LimiteAdultos = 30;
    private const int LimiteCriancas = 30;
    private const int LimiteQuartos = 10;

    public ContratacaoHospedagem()
    {
        InitializeComponent();

        pck_idioma.ItemsSource = new List<string>
        {
            "🇧🇷 Português",
            "🇺🇸 English",
            "🇪🇸 Español"
        };

        pck_idioma.SelectedIndex = 0;
        pck_idioma.SelectedIndexChanged += Idioma_Changed;

        pck_modalidade.ItemsSource = new List<string>
        {
            IdiomaService.Obter("EstadiaTradicional"),
            IdiomaService.Obter("Pernoite")
        };

        pck_modalidade.SelectedIndex = 0;

        pck_quarto.ItemsSource = new List<string>
        {
            IdiomaService.Obter("Economica"),
            IdiomaService.Obter("Luxo"),
            IdiomaService.Obter("Familia")
        };

        dtpck_checkin.MinimumDate = DateTime.Today;
        dtpck_checkin.Date = DateTime.Today;

        dtpck_checkout.MinimumDate = DateTime.Today.AddDays(1);
        dtpck_checkout.Date = DateTime.Today.AddDays(1);

        AtualizarQuantidades();
        AplicarIdioma();

        dtpck_checkin.DateSelected += (sender, e) =>
        {
            DateTime novaData = e.NewDate ?? DateTime.Today;

            if (pck_modalidade.SelectedIndex == 1)
            {
                dtpck_checkout.Date = novaData.AddDays(1);
                return;
            }

            DateTime proximoDia = novaData.AddDays(1);

            dtpck_checkout.MinimumDate = proximoDia;

            DateTime dataCheckout =
                dtpck_checkout.Date ?? proximoDia;

            if (dataCheckout <= novaData)
            {
                dtpck_checkout.Date = proximoDia;
            }
        };
    }

    // Atualiza todos os textos conforme o idioma escolhido
    private void AplicarIdioma()
    {
        lbl_idioma.Text = IdiomaService.Obter("Idioma");

        lbl_boas_vindas.Text = IdiomaService.Obter("BoasVindas");
        lbl_descricao_inicial.Text = IdiomaService.Obter("DescricaoInicial");
        lbl_reserve_estadia.Text = IdiomaService.Obter("ReserveEstadia");

        lbl_titulo_hospedes.Text = $"01. {IdiomaService.Obter("Hospedes")}";
        lbl_descricao_hospedes.Text = IdiomaService.Obter("DescricaoHospedes");
        lbl_adultos.Text = IdiomaService.Obter("Adultos");
        lbl_criancas.Text = IdiomaService.Obter("Criancas");
        lbl_aviso_adulto.Text = IdiomaService.Obter("AvisoAdulto");

        lbl_titulo_periodo.Text = $"02. {IdiomaService.Obter("PeriodoEstadia")}";
        lbl_como_hospedar.Text = IdiomaService.Obter("ComoHospedar");
        lbl_data_entrada.Text = IdiomaService.Obter("DataEntrada");
        lbl_data_saida.Text = IdiomaService.Obter("DataSaida");
        lbl_titulo_horarios.Text = IdiomaService.Obter("HorariosPernoite");
        lbl_horario_entrada.Text = IdiomaService.Obter("HorarioEntrada");
        lbl_horario_saida.Text = IdiomaService.Obter("HorarioSaida");
        lbl_info_pernoite.Text = IdiomaService.Obter("InfoPernoite");

        lbl_titulo_acomodacao.Text = $"03. {IdiomaService.Obter("Acomodacao")}";
        lbl_escolha_acomodacao.Text = IdiomaService.Obter("EscolhaAcomodacao");
        lbl_quantidade_quartos.Text = IdiomaService.Obter("QuantidadeQuartos");
        lbl_quartos_desejados.Text = IdiomaService.Obter("QuartosDesejados");
        lbl_info_capacidade.Text = IdiomaService.Obter("InfoCapacidade");

        btn_avancar.Text = IdiomaService.Obter("Avancar");
        lbl_rodape.Text = IdiomaService.Obter("RodapeInicial");
        btn_sobre.Text = IdiomaService.Obter("SobreAplicativo");

        // Atualiza as opções dos seletores sem perder a escolha atual
        int modalidadeSelecionada = pck_modalidade.SelectedIndex;
        int acomodacaoSelecionada = pck_quarto.SelectedIndex;

        pck_modalidade.ItemsSource = new List<string>
        {
            IdiomaService.Obter("EstadiaTradicional"),
            IdiomaService.Obter("Pernoite")
        };

        pck_modalidade.SelectedIndex = modalidadeSelecionada;

        pck_modalidade.Title = IdiomaService.Obter("SelecioneModalidade");

        pck_quarto.ItemsSource = new List<string>
        {
            IdiomaService.Obter("Economica"),
            IdiomaService.Obter("Luxo"),
            IdiomaService.Obter("Familia")
        };

        pck_quarto.SelectedIndex = acomodacaoSelecionada;

        pck_quarto.Title = IdiomaService.Obter("SelecioneAcomodacao");
    }

    // Seleção do idioma
    private void Idioma_Changed(object sender, EventArgs e)
    {
        string idioma = pck_idioma.SelectedIndex switch
        {
            0 => "pt",
            1 => "en",
            2 => "es",
            _ => "pt"
        };

        IdiomaService.DefinirIdioma(idioma);

        AplicarIdioma();
    }

    // Atualiza os números exibidos na tela
    private void AtualizarQuantidades()
    {
        lbl_adultos_quantidade.Text = adultos.ToString();
        lbl_criancas_quantidade.Text = criancas.ToString();
        lbl_quartos_quantidade.Text = quantidadeQuartos.ToString();
    }

    // Botões dos adultos
    private void DiminuirAdultos_Clicked(object sender, EventArgs e)
    {
        if (adultos > 1)
        {
            adultos--;
            AtualizarQuantidades();
        }
    }

    private void AumentarAdultos_Clicked(object sender, EventArgs e)
    {
        if (adultos < LimiteAdultos)
        {
            adultos++;
            AtualizarQuantidades();
        }
    }

    // Botões das crianças
    private void DiminuirCriancas_Clicked(object sender, EventArgs e)
    {
        if (criancas > 0)
        {
            criancas--;
            AtualizarQuantidades();
        }
    }

    private void AumentarCriancas_Clicked(object sender, EventArgs e)
    {
        if (criancas < LimiteCriancas)
        {
            criancas++;
            AtualizarQuantidades();
        }
    }

    // Botões da quantidade de quartos
    private void DiminuirQuartos_Clicked(object sender, EventArgs e)
    {
        if (quantidadeQuartos > 1)
        {
            quantidadeQuartos--;
            AtualizarQuantidades();
        }
    }

    private void AumentarQuartos_Clicked(object sender, EventArgs e)
    {
        if (quantidadeQuartos < LimiteQuartos)
        {
            quantidadeQuartos++;
            AtualizarQuantidades();
        }
    }

    // Alterna entre estadia tradicional e pernoite
    private void Modalidade_Changed(object sender, EventArgs e)
    {
        bool pernoite = pck_modalidade.SelectedIndex == 1;

        layout_horarios.IsVisible = pernoite;
        layout_checkout.IsVisible = !pernoite;
        lbl_info_pernoite.IsVisible = pernoite;

        dtpck_checkout.IsEnabled = !pernoite;

        if (pernoite)
        {
            DateTime entrada =
                dtpck_checkin.Date ?? DateTime.Today;

            dtpck_checkout.Date = entrada.AddDays(1);
        }
        else
        {
            DateTime entrada =
                dtpck_checkin.Date ?? DateTime.Today;

            DateTime proximoDia = entrada.AddDays(1);

            dtpck_checkout.MinimumDate = proximoDia;

            DateTime saida =
                dtpck_checkout.Date ?? proximoDia;

            if (saida <= entrada)
            {
                dtpck_checkout.Date = proximoDia;
            }
        }
    }

    // Botão AVANÇAR
    private async void Avancar_Clicked(object sender, EventArgs e)
    {
        int totalHospedes = adultos + criancas;

        if (adultos < 1)
        {
            await DisplayAlertAsync(
                IdiomaService.Obter("Atencao"),
                IdiomaService.Obter("ReservaAdulto"),
                IdiomaService.Obter("OK"));

            return;
        }

        if (pck_quarto.SelectedIndex < 0)
        {
            await DisplayAlertAsync(
                IdiomaService.Obter("Atencao"),
                IdiomaService.Obter("SelecioneAcomodacaoErro"),
                IdiomaService.Obter("OK"));

            return;
        }

        if (quantidadeQuartos < 1)
        {
            await DisplayAlertAsync(
                IdiomaService.Obter("Atencao"),
                IdiomaService.Obter("SelecioneQuartoErro"),
                IdiomaService.Obter("OK"));

            return;
        }

        // A identificação usa o índice, não o texto traduzido
        int tipoAcomodacao = pck_quarto.SelectedIndex;

        string acomodacao;
        int capacidade;
        decimal diaria;
        decimal valorPernoite;

        switch (tipoAcomodacao)
        {
            case 0:
                acomodacao = IdiomaService.Obter("Economica");
                capacidade = 2;
                diaria = 180m;
                valorPernoite = 126m;
                break;

            case 1:
                acomodacao = IdiomaService.Obter("Luxo");
                capacidade = 3;
                diaria = 260m;
                valorPernoite = 182m;
                break;

            case 2:
                acomodacao = IdiomaService.Obter("Familia");
                capacidade = 5;
                diaria = 350m;
                valorPernoite = 245m;
                break;

            default:
                await DisplayAlertAsync(
                    IdiomaService.Obter("Atencao"),
                    IdiomaService.Obter("AcomodacaoInvalida"),
                    IdiomaService.Obter("OK"));

                return;
        }

        // Capacidade total considerando todos os quartos
        int capacidadeTotal = capacidade * quantidadeQuartos;

        if (totalHospedes > capacidadeTotal)
        {
            string mensagem = string.Format(
                IdiomaService.Obter("HospedesExcedidos"),
                totalHospedes,
                quantidadeQuartos,
                acomodacao,
                capacidadeTotal);

            await DisplayAlertAsync(
                IdiomaService.Obter("LimiteHospedes"),
                mensagem,
                IdiomaService.Obter("OK"));

            return;
        }

        DateTime checkin =
            dtpck_checkin.Date ?? DateTime.Today;

        DateTime checkout;
        decimal valorAplicado;

        bool pernoite = pck_modalidade.SelectedIndex == 1;

        TimeSpan? horarioEntrada = null;
        TimeSpan? horarioSaida = null;

        if (pernoite)
        {
            TimeSpan entrada =
                tmpck_entrada.Time ?? new TimeSpan(20, 0, 0);

            TimeSpan saida =
                tmpck_saida.Time ?? new TimeSpan(8, 0, 0);

            if (entrada < new TimeSpan(18, 0, 0) ||
                entrada > new TimeSpan(23, 0, 0))
            {
                await DisplayAlertAsync(
                    IdiomaService.Obter("HorarioInvalido"),
                    IdiomaService.Obter("EntradaInvalida"),
                    IdiomaService.Obter("OK"));

                return;
            }

            if (saida < new TimeSpan(6, 0, 0) ||
                saida > new TimeSpan(10, 0, 0))
            {
                await DisplayAlertAsync(
                    IdiomaService.Obter("HorarioInvalido"),
                    IdiomaService.Obter("SaidaInvalida"),
                    IdiomaService.Obter("OK"));

                return;
            }

            checkout = checkin.AddDays(1);
            valorAplicado = valorPernoite;

            horarioEntrada = entrada;
            horarioSaida = saida;
        }
        else
        {
            checkout =
                dtpck_checkout.Date ?? checkin.AddDays(1);

            valorAplicado = diaria;

            if (checkout <= checkin)
            {
                await DisplayAlertAsync(
                    IdiomaService.Obter("DatasInvalidas"),
                    IdiomaService.Obter("DataSaidaInvalida"),
                    IdiomaService.Obter("OK"));

                return;
            }
        }

        await Navigation.PushAsync(
            new Resumo(
                adultos,
                criancas,
                acomodacao,
                quantidadeQuartos,
                checkin,
                checkout,
                valorAplicado,
                pernoite,
                horarioEntrada,
                horarioSaida
            )
        );
    }

    // Botão SOBRE O APLICATIVO
    private async void Sobre_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Sobre());
    }
}
