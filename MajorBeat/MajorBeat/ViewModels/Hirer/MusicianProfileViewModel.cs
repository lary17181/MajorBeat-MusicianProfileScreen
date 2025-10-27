using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MajorBeat.Enums;
using MajorBeat.Models;
using MajorBeat.Views.Hirers;
using MajorBeat.Views.Musicians;
using MajorBeat.Services.Musicians;
using System.Collections.ObjectModel;
using System.Diagnostics.Metrics;
using System.Globalization;

namespace MajorBeat.ViewModels.Hirer;

public partial class MusicianProfileViewModel : ObservableObject
{
    private readonly MusicianService _musicianService;

    [ObservableProperty] private Musico musico;

    [ObservableProperty] private string username;

    [ObservableProperty] private string nome;

    [ObservableProperty] private string biografia;

    [ObservableProperty] private ObservableCollection<NomeInstrumento> instrumentos = new();

    [ObservableProperty] private ObservableCollection<NomeGenero> generos = new();

    [ObservableProperty] private string email;

    [ObservableProperty] private string logradouro;

    [ObservableProperty] private string telefone;

    [ObservableProperty] private string linkFacebook;

    [ObservableProperty] private string linkLinkdin;

    [ObservableProperty] private string linkInsta;

    [ObservableProperty] private string linkTwitter;

    [ObservableProperty] private DateTime currentMonth = DateTime.Now;

    private int _currentIndex;
    public int CurrentIndex
    {
        get => _currentIndex;
        set
        {
            if (SetProperty(ref _currentIndex, value))
            {
                OnPropertyChanged(nameof(ImageCounter));
            }
        }
    }

    private ObservableCollection<string> _images = new()
    {
        "musicianprofile1.png",
        "musicianprofile2.png",
        "musicianprofile3.png"
    };

    public ObservableCollection<string> Images
    {
        get => _images;
        set
        {
            if (SetProperty(ref _images, value))
            {
                OnPropertyChanged(nameof(TotalImages));
                OnPropertyChanged(nameof(ImageCounter));
            }
        }
    }

    public int TotalImages => _images?.Count ?? 0;
    public string ImageCounter => $"{CurrentIndex + 1}/{TotalImages}";
    public string CurrentMonthDisplay => CurrentMonth.ToString("MMMM yyyy", new CultureInfo("pt-BR"));

    [ObservableProperty] private bool isGaleriaVisible;

    [ObservableProperty] private bool isSobreVisible;

    [ObservableProperty] private bool isAvaliacoesVisible;

    [ObservableProperty] private Color tabGaleriaTextColor;

    [ObservableProperty] private Color tabSobreTextColor;

    [ObservableProperty] private Color tabAvaliacoesTextColor;

    [ObservableProperty] private Color boxViewGaleriaBackgroundColor;

    [ObservableProperty] private Color boxViewSobreBackgroundColor;

    [ObservableProperty] private Color boxViewAvaliacoesBackgroundColor;

    [ObservableProperty] private FontAttributes tabGaleriaFontAttributes;

    [ObservableProperty] private FontAttributes tabSobreFontAttributes;

    [ObservableProperty] private FontAttributes tabAvaliacoesFontAttributes;

    [ObservableProperty] private double boxViewGaleriaHeightRequest;

    [ObservableProperty] private double boxViewSobreHeightRequest;

    [ObservableProperty] private double boxViewAvaliacoesHeightRequest;

    private readonly Color _activeTabColor = Color.FromArgb("#4F1271");
    private readonly Color _inactiveTabColor = Color.FromArgb("#783F8E");
    private const double _activeBoxHeight = 4;
    private const double _inactiveBoxHeight = 3;
    private const FontAttributes _activeFont = FontAttributes.Bold;
    private const FontAttributes _inactiveFont = FontAttributes.None;
    public MusicianProfileViewModel()
    {
        _musicianService = new MusicianService();

        // Valores temporários antes de vir da API
        Username = "Marquinhos";
        Nome = "Marcos José";
        Biografia = "Oi, eu sou o Marquinhos. Minha música é um pedaço de mim, uma mistura das minhas raízes e das minhas descobertas pelo caminho.";
        Instrumentos = new ObservableCollection<NomeInstrumento> { NomeInstrumento.VOZ, NomeInstrumento.VIOLAO };
        Generos = new ObservableCollection<NomeGenero> { NomeGenero.SERTANEJO, NomeGenero.MPB };
        Email = "marcos.jose123@gmail.com";
        Logradouro = "R. Alcântara, 113 - Vila Guilherme, São Paulo - SP";
        Telefone = "(11) 99999-9999";
        LinkFacebook = "marcos.jose";
        LinkLinkdin = "marcos.jose";
        LinkInsta = "marcos.jose";
        LinkTwitter = "marcos.jose";

        SelectTab("Galeria");
    }

    public MusicianProfileViewModel(Musico musico)
    {
        _musicianService = new MusicianService();
        SetMusicianData(musico);

        SelectTab("Galeria");
    }

    private void SetMusicianData(Musico musico)
    {
        if (musico == null) return;

        Musico = musico;
        Nome = musico.nome;
        Username = musico.apelido ?? musico.nome;
        Biografia = musico.biografia;
        Email = musico.email;
        Telefone = musico.telefone;
        Logradouro = musico.endereco;
        Instrumentos = musico.nomeInstrumento ?? new ObservableCollection<NomeInstrumento>();
        Generos = musico.nomeGenero ?? new ObservableCollection<NomeGenero>();

        if (musico.links != null)
        {
            LinkFacebook = musico.links.ElementAtOrDefault(0);
            LinkLinkdin = musico.links.ElementAtOrDefault(1);
            LinkInsta = musico.links.ElementAtOrDefault(2);
            LinkTwitter = musico.links.ElementAtOrDefault(3);
        }

        _images.Clear();
        if (musico.mediaUrl != null && musico.mediaUrl.Any())
        {
            foreach (var url in musico.mediaUrl)
                _images.Add(url);
        }
    }

    [RelayCommand]
    private void NextMonth()
    {
        CurrentMonth = CurrentMonth.AddMonths(1);
        OnPropertyChanged(nameof(CurrentMonthDisplay));
    }

    [RelayCommand]
    private void PreviousMonth()
    {
        CurrentMonth = CurrentMonth.AddMonths(-1);
        OnPropertyChanged(nameof(CurrentMonthDisplay));
    }

    [RelayCommand]
    private void NextImage()
    {
        if (CurrentIndex < _images.Count - 1)
            CurrentIndex++;
    }

    [RelayCommand]
    private void PrevImage()
    {
        if (CurrentIndex > 0)
            CurrentIndex--;
    }

    [RelayCommand]
    private void SelectTab(string tabName)
    {
        IsGaleriaVisible = (tabName == "Galeria");
        IsSobreVisible = (tabName == "Sobre");
        IsAvaliacoesVisible = (tabName == "Avaliacoes");

        TabGaleriaTextColor = IsGaleriaVisible ? _activeTabColor : _inactiveTabColor;
        TabGaleriaFontAttributes = IsGaleriaVisible ? _activeFont : _inactiveFont;
        BoxViewGaleriaHeightRequest = IsGaleriaVisible ? _activeBoxHeight : _inactiveBoxHeight;
        BoxViewGaleriaBackgroundColor = IsGaleriaVisible ? _activeTabColor : _inactiveTabColor;

        TabSobreTextColor = IsSobreVisible ? _activeTabColor : _inactiveTabColor;
        TabSobreFontAttributes = IsSobreVisible ? _activeFont : _inactiveFont;
        BoxViewSobreHeightRequest = IsSobreVisible ? _activeBoxHeight : _inactiveBoxHeight;
        BoxViewSobreBackgroundColor = IsSobreVisible ? _activeTabColor : _inactiveTabColor;

        TabAvaliacoesTextColor = IsAvaliacoesVisible ? _activeTabColor : _inactiveTabColor;
        TabAvaliacoesFontAttributes = IsAvaliacoesVisible ? _activeFont : _inactiveFont;
        BoxViewAvaliacoesHeightRequest = IsAvaliacoesVisible ? _activeBoxHeight : _inactiveBoxHeight;
        BoxViewAvaliacoesBackgroundColor = IsAvaliacoesVisible ? _activeTabColor : _inactiveTabColor;
    }

    /*[RelayCommand]
    public async Task LoadMusicianById(string nome)
    {
        try
        {
            var result = await _musicianService.GetMusicianByName(nome);
            if (result != null && result.Any())
            {
                SetMusicianData(result.First());
            }
        }
        catch (Exception ex)
        {
            await App.Current.MainPage.DisplayAlert("Erro", $"Erro ao carregar músico: {ex.Message}", "OK");
        }
    }*/

   

}
