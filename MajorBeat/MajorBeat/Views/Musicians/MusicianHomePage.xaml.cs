using MajorBeat.Enums;
using MajorBeat.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using MajorBeat.Views.Hirers;
using MajorBeat.ViewModels.Hirer;
using MajorBeat.ViewModels.Musician;
namespace MajorBeat.Views.Musicians;


public partial class MusicianHomePage : ContentPage
{
    public MusicianHomePage()
    {
        InitializeComponent();
    }

    private async void search_page_btn_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MusicianSearchPage());
    }

    private async void profile_page_btn_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MusicianProfilePage());
    }

    private async void calendar_page_btn_Clicked(object sender, EventArgs e) =>
        await Navigation.PushAsync(new HirerCalendarPage());

    private async void OnMusicianTapped(object sender, EventArgs e)
    {
        var musico = new Musico
        {
            nome = "Marcos José",
            apelido = "Marquinhos",
            email = "marcos.jose123@gmail.com",
            telefone = "(11) 99999-9999",
            endereco = "R. Alcântara, 113 - Vila Guilherme, São Paulo - SP",
            biografia = "Oi, eu sou o Marquinhos. Minha música é um pedaço de mim...",
            dtCriacao = DateTime.Now,
            nomeInstrumento = new ObservableCollection<NomeInstrumento>
        {
            NomeInstrumento.VOZ,
            NomeInstrumento.VIOLAO
        },
            nomeGenero = new ObservableCollection<NomeGenero>
        {
            NomeGenero.MPB,
            NomeGenero.SERTANEJO
        },
            links = new ObservableCollection<string>
        {
            "marcos.jose",
            "marcos.jose",
            "marcos.jose",
            "marcos.jose"
        },
            mediaUrl = new ObservableCollection<string>
        {
            "musicianprofile1.png",
            "musicianprofile2.png",
            "musicianprofile3.png"
        },
            avaliacoes = new ObservableCollection<Avaliacao>(),
            chats = new ObservableCollection<Chat>()
        };

        await Navigation.PushAsync(new MusicianProfileView(musico));
    }


    private async void OnEventTapped(object sender, EventArgs e)
    {
        var evento = new Evento
        {
            IdEvento = 1,
            Titulo = "Panelão do Norte",
            Descricao = "Um evento voltado à valorização da música independente, com artistas locais e novas bandas.",
            Endereco = "Rua Alcântara,113 - São Paulo, SP",
            Data = new DateTime(2025, 10, 30),
            HoraInicio = new TimeSpan(18, 0, 0),
            HoraFim = new TimeSpan(23, 0, 0),
            NomeGenero = new ObservableCollection<Enums.NomeGenero> { NomeGenero.MPB, NomeGenero.SERTANEJO },
            NomeInstrumento = new ObservableCollection<NomeInstrumento> { NomeInstrumento.VOZ, NomeInstrumento.VIOLAO },
            ImagemLocalEvento = new ObservableCollection<string>
        {
            "panelao.png"
        },
            Contratante = new Contratante
            {
                Nome = "Panelão do Norte Produções"
            },
        };
        await Navigation.PushAsync(new MusicianEventView(evento.IdEvento));
        
    }

}
    
    