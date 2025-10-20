using System.Collections.ObjectModel;
using System.Threading.Tasks;
using MajorBeat.ViewModels.Musicians;
using System;
using MajorBeat.Enums;

namespace MajorBeat.Views.Musicians;

public partial class MusicianProfilePage : ContentPage
{
    private ProfileMusicianViewModel _viewModel;

    public MusicianProfilePage()
    {
        InitializeComponent();

        _viewModel = new ProfileMusicianViewModel
        {
            // Atribui valores diretamente ao ViewModel
            Username = "Marquinhos",
            Nome = "Marcos Jos�",
            Biografia = "Oi, eu sou o Marquinhos. Minha m�sica � um peda�o de mim, uma mistura das minhas ra�zes e das minhas descobertas pelo caminho. Minha m�sica � essa mistura de influ�ncias, uma mistura que vem do cora��o, mas tamb�m de uma busca constante por novas formas de me expressar.",

            // Atribuindo uma lista de instrumentos e g�neros
            Instrumentos = new List<InstrumentoEnum> { InstrumentoEnum.Guitarra },
            Generos = new List<GeneroEnum> { GeneroEnum.Sertanejo },

            // Outros campos
            Email = "marcos.jose123@gmail.com",
            Logradouro = "R. Alc�ntara, 113 - Vila Guilherme,\nS�o Paulo - SP, 02110-010",
            Telefone = "(11) 99999-9999",
            LinkFacebook = "marcos.jose",
            LinkLinkdin = "marcos.jose",
            LinkInsta = "marcos.jose",
            LinkTwitter = "marcos.jose"
        };

        // Define o BindingContext
        BindingContext = _viewModel;

        // Configura��o do evento de mudan�a de posi��o no Carousel
        ImageCarousel.PositionChanged += OnCarouselPositionChanged;
    }

    // Evento para atualizar a posi��o
    private void OnCarouselPositionChanged(object sender, PositionChangedEventArgs e)
    {
        // Atualiza o �ndice da imagem no ViewModel
        _viewModel.CurrentIndex = e.CurrentPosition;

        // Atualiza o texto da posi��o (ap�s o binding no XAML)
        UpdatePositionLabel();
    }

    // Atualiza o texto da label de posi��o da imagem
    private void UpdatePositionLabel()
    {
        PositionLabel.Text = $"{_viewModel.CurrentIndex + 1}/{_viewModel.Images.Count}";
    }

    // M�todos de navega��o entre p�ginas
    private async void search_page_btn_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MusicianSearchPage());
    }

    private async void home_page_btn_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MusicianHomePage());
    }

    private async void profile_page_btn_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MusicianProfilePage());
    }

    // Estilos e visibilidade das abas - Galeria
    private void OnGaleriaTapped(object sender, TappedEventArgs e)
    {
        UpdateTabStyles("Galeria");

        // Mostrar ou ocultar os stacks
        galeriaStack.IsVisible = !galeriaStack.IsVisible;
        sobreStack.IsVisible = false;
        avaliacoesStack.IsVisible = false;
    }

    // Estilos e visibilidade das abas - Sobre
    private void OnSobreTapped(object sender, TappedEventArgs e)
    {
        UpdateTabStyles("Sobre");

        // Mostrar ou ocultar os stacks
        sobreStack.IsVisible = !sobreStack.IsVisible;
        galeriaStack.IsVisible = false;
        avaliacoesStack.IsVisible = false;
    }

    // Estilos e visibilidade das abas - Avalia��es
    private void OnAvaliacoesTapped(object sender, TappedEventArgs e)
    {
        UpdateTabStyles("Avaliacoes");

        // Mostrar ou ocultar os stacks
        avaliacoesStack.IsVisible = !avaliacoesStack.IsVisible;
        galeriaStack.IsVisible = false;
        sobreStack.IsVisible = false;
    }

    // Fun��o auxiliar para atualizar as cores e estilos das abas
    private void UpdateTabStyles(string tab)
    {
        switch (tab)
        {
            case "Galeria":
                TabGaleria.TextColor = Color.FromArgb("#4F1271");
                TabGaleria.FontAttributes = FontAttributes.Bold;
                BoxViewGaleria.HeightRequest = 4;
                BoxViewGaleria.BackgroundColor = Color.FromArgb("#4F1271");

                ResetOtherTabs("Galeria");
                break;

            case "Sobre":
                TabSobre.TextColor = Color.FromArgb("#4F1271");
                TabSobre.FontAttributes = FontAttributes.Bold;
                BoxViewSobre.HeightRequest = 4;
                BoxViewSobre.BackgroundColor = Color.FromArgb("#4F1271");

                ResetOtherTabs("Sobre");
                break;

            case "Avaliacoes":
                TabAvaliacoes.TextColor = Color.FromArgb("#4F1271");
                TabAvaliacoes.FontAttributes = FontAttributes.Bold;
                BoxViewAvaliacoes.HeightRequest = 4;
                BoxViewAvaliacoes.BackgroundColor = Color.FromArgb("#4F1271");

                ResetOtherTabs("Avaliacoes");
                break;
        }
    }

    // Resetando as outras abas
    private void ResetOtherTabs(string activeTab)
    {
        if (activeTab != "Galeria")
        {
            TabGaleria.TextColor = Color.FromArgb("#783F8E");
            TabGaleria.FontAttributes = FontAttributes.None;
            BoxViewGaleria.HeightRequest = 3;
            BoxViewGaleria.BackgroundColor = Color.FromArgb("#783F8E");
        }

        if (activeTab != "Sobre")
        {
            TabSobre.TextColor = Color.FromArgb("#783F8E");
            TabSobre.FontAttributes = FontAttributes.None;
            BoxViewSobre.HeightRequest = 3;
            BoxViewSobre.BackgroundColor = Color.FromArgb("#783F8E");
        }

        if (activeTab != "Avaliacoes")
        {
            TabAvaliacoes.TextColor = Color.FromArgb("#783F8E");
            TabAvaliacoes.FontAttributes = FontAttributes.None;
            BoxViewAvaliacoes.HeightRequest = 3;
            BoxViewAvaliacoes.BackgroundColor = Color.FromArgb("#783F8E");
        }
    }
}