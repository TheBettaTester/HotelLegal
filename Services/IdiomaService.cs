
namespace MauiAppHotel.Services;

public static class IdiomaService
{
    public static string IdiomaAtual { get; private set; } = "pt";

    public static event Action? IdiomaAlterado;

    private static readonly Dictionary<string, Dictionary<string, string>> Traducoes =
        new()
        {
            ["pt"] = new Dictionary<string, string>
            {
                ["Idioma"] = "Idioma",
                ["Portugues"] = "Português",
                ["Ingles"] = "English",
                ["Espanhol"] = "Español",

                ["BoasVindas"] = "Sua estadia começa aqui!",
                ["DescricaoInicial"] = "Planeje sua próxima experiência com conforto e tranquilidade.",
                ["ReserveEstadia"] = "✦ RESERVE SUA ESTADIA",

                ["Hospedes"] = "Hóspedes",
                ["DescricaoHospedes"] = "Informe quantas pessoas participarão da hospedagem.",
                ["Adultos"] = "Adultos",
                ["Criancas"] = "Crianças",
                ["AvisoAdulto"] = "É necessário informar pelo menos um adulto.",

                ["PeriodoEstadia"] = "Período da estadia",
                ["ComoHospedar"] = "Como deseja se hospedar?",
                ["SelecioneModalidade"] = "Selecione a modalidade",
                ["EstadiaTradicional"] = "Estadia tradicional",
                ["Pernoite"] = "Pernoite",
                ["DataEntrada"] = "Data de entrada",
                ["DataSaida"] = "Data de saída",
                ["HorariosPernoite"] = "Horários do pernoite",
                ["HorarioEntrada"] = "Entrada (entre 18h e 23h)",
                ["HorarioSaida"] = "Saída (entre 6h e 10h)",
                ["InfoPernoite"] = "O check-out será realizado na manhã do dia seguinte.",

                ["Acomodacao"] = "Acomodação",
                ["EscolhaAcomodacao"] = "Escolha a acomodação ideal para você.",
                ["SelecioneAcomodacao"] = "Selecione sua acomodação",
                ["Economica"] = "Econômica",
                ["Luxo"] = "Luxo",
                ["Familia"] = "Família",
                ["QuantidadeQuartos"] = "Quantidade de quartos",
                ["QuartosDesejados"] = "Quartos desejados",
                ["InfoCapacidade"] = "A capacidade total será calculada conforme a acomodação e a quantidade de quartos.",

                ["Avancar"] = "AVANÇAR  →",
                ["RodapeInicial"] = "Hotel Legal • Sua experiência começa aqui.",
                ["SobreAplicativo"] = "SOBRE O APLICATIVO",

                ["Atencao"] = "Atenção",
                ["ReservaAdulto"] = "A reserva precisa ter pelo menos um adulto.",
                ["SelecioneAcomodacaoErro"] = "Selecione uma acomodação antes de continuar.",
                ["SelecioneQuartoErro"] = "Selecione pelo menos um quarto.",
                ["AcomodacaoInvalida"] = "A acomodação selecionada é inválida.",
                ["LimiteHospedes"] = "Limite de hóspedes",
                ["HospedesExcedidos"] = "Você selecionou {0} hóspedes, mas {1} quarto(s) da categoria {2} comportam no máximo {3} pessoas. Aumente a quantidade de quartos.",
                ["HorarioInvalido"] = "Horário inválido",
                ["EntradaInvalida"] = "O horário de entrada deve ser entre 18h e 23h.",
                ["SaidaInvalida"] = "O horário de saída deve ser entre 6h e 10h.",
                ["DatasInvalidas"] = "Datas inválidas",
                ["DataSaidaInvalida"] = "A data de saída precisa ser posterior à data de entrada.",
                ["OK"] = "OK",

                ["TituloResumo"] = "Resumo da hospedagem",
                ["DescricaoResumo"] = "Confira os dados antes de confirmar sua reserva.",
                ["SuaReserva"] = "SUA RESERVA",
                ["Modalidade"] = "Modalidade",
                ["TotalHospedes"] = "Total de hóspedes",
                ["Checkin"] = "Check-in",
                ["HorarioEntradaResumo"] = "Horário de entrada",
                ["Checkout"] = "Check-out",
                ["HorarioSaidaResumo"] = "Horário de saída",
                ["TotalNoites"] = "Total de noites",
                ["Noite"] = "noite",
                ["Noites"] = "noites",
                ["Valores"] = "VALORES",
                ["ValorPorQuarto"] = "Valor por quarto/noite",
                ["TotalPorNoite"] = "Total por noite",
                ["NoitesAdicional"] = "Noites com adicional",
                ["NoiteAdicional"] = "noite(s) (+30%)",
                ["Nenhuma"] = "Nenhuma",
                ["AvisoAdicional"] = "Feriados e períodos de férias recebem acréscimo de 30% por noite. Quando as duas condições coincidem, o adicional é aplicado apenas uma vez.",
                ["TotalHospedagem"] = "TOTAL DA HOSPEDAGEM",

                ["Sobre"] = "Sobre",
                ["DescricaoSobre"] = "Conheça um pouco mais sobre o projeto.",
                ["InformacoesProjeto"] = "✦  INFORMAÇÕES DO PROJETO",
                ["Desenvolvedora"] = "DESENVOLVEDORA",
                ["AnoDesenvolvimento"] = "ANO DE DESENVOLVIMENTO",
                ["Voltar"] = "←  VOLTAR",
                ["RodapeSobre"] = "Hotel Legal • 2026"
            },

            ["en"] = new Dictionary<string, string>
            {
                ["Idioma"] = "Language",
                ["Portugues"] = "Português",
                ["Ingles"] = "English",
                ["Espanhol"] = "Español",

                ["BoasVindas"] = "Your stay starts here!",
                ["DescricaoInicial"] = "Plan your next experience with comfort and peace of mind.",
                ["ReserveEstadia"] = "✦ BOOK YOUR STAY",

                ["Hospedes"] = "Guests",
                ["DescricaoHospedes"] = "Enter the number of people staying at the hotel.",
                ["Adultos"] = "Adults",
                ["Criancas"] = "Children",
                ["AvisoAdulto"] = "At least one adult is required.",

                ["PeriodoEstadia"] = "Stay period",
                ["ComoHospedar"] = "How would you like to stay?",
                ["SelecioneModalidade"] = "Select a stay option",
                ["EstadiaTradicional"] = "Standard stay",
                ["Pernoite"] = "Overnight stay",
                ["DataEntrada"] = "Check-in date",
                ["DataSaida"] = "Check-out date",
                ["HorariosPernoite"] = "Overnight stay times",
                ["HorarioEntrada"] = "Check-in (between 6 PM and 11 PM)",
                ["HorarioSaida"] = "Check-out (between 6 AM and 10 AM)",
                ["InfoPernoite"] = "Check-out will take place the following morning.",

                ["Acomodacao"] = "Accommodation",
                ["EscolhaAcomodacao"] = "Choose the accommodation that suits you best.",
                ["SelecioneAcomodacao"] = "Select your accommodation",
                ["Economica"] = "Economy",
                ["Luxo"] = "Luxury",
                ["Familia"] = "Family",
                ["QuantidadeQuartos"] = "Number of rooms",
                ["QuartosDesejados"] = "Rooms requested",
                ["InfoCapacidade"] = "Total capacity will be calculated based on the accommodation and number of rooms.",

                ["Avancar"] = "CONTINUE  →",
                ["RodapeInicial"] = "Hotel Legal • Your experience starts here.",
                ["SobreAplicativo"] = "ABOUT THE APP",

                ["Atencao"] = "Attention",
                ["ReservaAdulto"] = "The reservation must include at least one adult.",
                ["SelecioneAcomodacaoErro"] = "Please select an accommodation before continuing.",
                ["SelecioneQuartoErro"] = "Please select at least one room.",
                ["AcomodacaoInvalida"] = "The selected accommodation is invalid.",
                ["LimiteHospedes"] = "Guest limit",
                ["HospedesExcedidos"] = "You selected {0} guests, but {1} room(s) in the {2} category can accommodate a maximum of {3} people. Please increase the number of rooms.",
                ["HorarioInvalido"] = "Invalid time",
                ["EntradaInvalida"] = "Check-in time must be between 6 PM and 11 PM.",
                ["SaidaInvalida"] = "Check-out time must be between 6 AM and 10 AM.",
                ["DatasInvalidas"] = "Invalid dates",
                ["DataSaidaInvalida"] = "The check-out date must be later than the check-in date.",
                ["OK"] = "OK",

                ["TituloResumo"] = "Booking summary",
                ["DescricaoResumo"] = "Review the details before confirming your reservation.",
                ["SuaReserva"] = "YOUR RESERVATION",
                ["Modalidade"] = "Stay type",
                ["TotalHospedes"] = "Total guests",
                ["Checkin"] = "Check-in",
                ["HorarioEntradaResumo"] = "Check-in time",
                ["Checkout"] = "Check-out",
                ["HorarioSaidaResumo"] = "Check-out time",
                ["TotalNoites"] = "Total nights",
                ["Noite"] = "night",
                ["Noites"] = "nights",
                ["Valores"] = "PRICES",
                ["ValorPorQuarto"] = "Price per room/night",
                ["TotalPorNoite"] = "Total per night",
                ["NoitesAdicional"] = "Nights with surcharge",
                ["NoiteAdicional"] = "night(s) (+30%)",
                ["Nenhuma"] = "None",
                ["AvisoAdicional"] = "Holidays and vacation periods have a 30% surcharge per night. If both conditions overlap, the surcharge is applied only once.",
                ["TotalHospedagem"] = "TOTAL ACCOMMODATION COST",

                ["Sobre"] = "About",
                ["DescricaoSobre"] = "Learn a little more about the project.",
                ["InformacoesProjeto"] = "✦  PROJECT INFORMATION",
                ["Desenvolvedora"] = "DEVELOPER",
                ["AnoDesenvolvimento"] = "YEAR OF DEVELOPMENT",
                ["Voltar"] = "←  BACK",
                ["RodapeSobre"] = "Hotel Legal • 2026"
            },

            ["es"] = new Dictionary<string, string>
            {
                ["Idioma"] = "Idioma",
                ["Portugues"] = "Português",
                ["Ingles"] = "English",
                ["Espanhol"] = "Español",

                ["BoasVindas"] = "¡Tu estadía comienza aquí!",
                ["DescricaoInicial"] = "Planifica tu próxima experiencia con comodidad y tranquilidad.",
                ["ReserveEstadia"] = "✦ RESERVA TU ESTADÍA",

                ["Hospedes"] = "Huéspedes",
                ["DescricaoHospedes"] = "Indica cuántas personas se alojarán en el hotel.",
                ["Adultos"] = "Adultos",
                ["Criancas"] = "Niños",
                ["AvisoAdulto"] = "Es necesario incluir al menos un adulto.",

                ["PeriodoEstadia"] = "Período de estadía",
                ["ComoHospedar"] = "¿Cómo deseas hospedarte?",
                ["SelecioneModalidade"] = "Selecciona la modalidad",
                ["EstadiaTradicional"] = "Estadía tradicional",
                ["Pernoite"] = "Alojamiento nocturno",
                ["DataEntrada"] = "Fecha de entrada",
                ["DataSaida"] = "Fecha de salida",
                ["HorariosPernoite"] = "Horarios del alojamiento nocturno",
                ["HorarioEntrada"] = "Entrada (entre las 18:00 y las 23:00)",
                ["HorarioSaida"] = "Salida (entre las 6:00 y las 10:00)",
                ["InfoPernoite"] = "La salida se realizará a la mañana siguiente.",

                ["Acomodacao"] = "Alojamiento",
                ["EscolhaAcomodacao"] = "Elige el alojamiento ideal para ti.",
                ["SelecioneAcomodacao"] = "Selecciona tu alojamiento",
                ["Economica"] = "Económica",
                ["Luxo"] = "Lujo",
                ["Familia"] = "Familiar",
                ["QuantidadeQuartos"] = "Cantidad de habitaciones",
                ["QuartosDesejados"] = "Habitaciones deseadas",
                ["InfoCapacidade"] = "La capacidad total se calculará según el alojamiento y la cantidad de habitaciones.",

                ["Avancar"] = "CONTINUAR  →",
                ["RodapeInicial"] = "Hotel Legal • Tu experiencia comienza aquí.",
                ["SobreAplicativo"] = "SOBRE LA APLICACIÓN",

                ["Atencao"] = "Atención",
                ["ReservaAdulto"] = "La reserva debe incluir al menos un adulto.",
                ["SelecioneAcomodacaoErro"] = "Selecciona un alojamiento antes de continuar.",
                ["SelecioneQuartoErro"] = "Selecciona al menos una habitación.",
                ["AcomodacaoInvalida"] = "El alojamiento seleccionado no es válido.",
                ["LimiteHospedes"] = "Límite de huéspedes",
                ["HospedesExcedidos"] = "Has seleccionado {0} huéspedes, pero {1} habitación(es) de la categoría {2} pueden alojar como máximo a {3} personas. Aumenta la cantidad de habitaciones.",
                ["HorarioInvalido"] = "Horario no válido",
                ["EntradaInvalida"] = "La hora de entrada debe estar entre las 18:00 y las 23:00.",
                ["SaidaInvalida"] = "La hora de salida debe estar entre las 6:00 y las 10:00.",
                ["DatasInvalidas"] = "Fechas no válidas",
                ["DataSaidaInvalida"] = "La fecha de salida debe ser posterior a la fecha de entrada.",
                ["OK"] = "OK",

                ["TituloResumo"] = "Resumen de la estadía",
                ["DescricaoResumo"] = "Revisa los datos antes de confirmar tu reserva.",
                ["SuaReserva"] = "TU RESERVA",
                ["Modalidade"] = "Modalidad",
                ["TotalHospedes"] = "Total de huéspedes",
                ["Checkin"] = "Entrada",
                ["HorarioEntradaResumo"] = "Hora de entrada",
                ["Checkout"] = "Salida",
                ["HorarioSaidaResumo"] = "Hora de salida",
                ["TotalNoites"] = "Total de noches",
                ["Noite"] = "noche",
                ["Noites"] = "noches",
                ["Valores"] = "PRECIOS",
                ["ValorPorQuarto"] = "Precio por habitación/noche",
                ["TotalPorNoite"] = "Total por noche",
                ["NoitesAdicional"] = "Noches con recargo",
                ["NoiteAdicional"] = "noche(s) (+30%)",
                ["Nenhuma"] = "Ninguna",
                ["AvisoAdicional"] = "Los días festivos y los períodos de vacaciones tienen un recargo del 30% por noche. Si ambas condiciones coinciden, el recargo se aplica una sola vez.",
                ["TotalHospedagem"] = "COSTO TOTAL DE LA ESTADÍA",

                ["Sobre"] = "Acerca de",
                ["DescricaoSobre"] = "Conoce un poco más sobre el proyecto.",
                ["InformacoesProjeto"] = "✦  INFORMACIÓN DEL PROYECTO",
                ["Desenvolvedora"] = "DESARROLLADORA",
                ["AnoDesenvolvimento"] = "AÑO DE DESARROLLO",
                ["Voltar"] = "←  VOLVER",
                ["RodapeSobre"] = "Hotel Legal • 2026"
            }
        };

    public static string Obter(string chave)
    {
        if (Traducoes.TryGetValue(IdiomaAtual, out var idioma) &&
            idioma.TryGetValue(chave, out var traducao))
        {
            return traducao;
        }

        return Traducoes["pt"].TryGetValue(chave, out var padrao)
            ? padrao
            : chave;
    }

    public static void DefinirIdioma(string idioma)
    {
        if (!Traducoes.ContainsKey(idioma))
            return;

        if (IdiomaAtual == idioma)
            return;

        IdiomaAtual = idioma;
        IdiomaAlterado?.Invoke();
    }
}
