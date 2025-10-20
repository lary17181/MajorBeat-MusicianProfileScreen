using MajorBeat.Enums;
using MajorBeat.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using MajorBeat.Views.Hirers;
using MajorBeat.ViewModels.Hirer;
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
            nomeInstrumento = new ObservableCollection<InstrumentoEnum>
        {
            InstrumentoEnum.Guitarra,
            InstrumentoEnum.Violão
        },
            nomeGenero = new ObservableCollection<GeneroEnum>
        {
            GeneroEnum.Sertanejo,
            GeneroEnum.Gospel
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
            Titulo = "Panelão do Norte",
            Descricao = "Uma noite especial com artistas locais...",
            Endereco = "Av. Norte, 123 - São Paulo, SP",
            Data = new DateTime(2025, 11, 20),
            HoraInicio = new TimeSpan(20, 0, 0),
            HoraFim = new TimeSpan(23, 30, 0),
            NomeGenero = new ObservableCollection<GeneroEnum> { GeneroEnum.Sertanejo },
            NomeInstrumento = new ObservableCollection<InstrumentoEnum> { InstrumentoEnum.Violão, InstrumentoEnum.Bateria },
            ImagemLocalEvento = new ObservableCollection<byte[]>(),
            Contratante = new Contratante
            {
                Nome = "Panelão do Norte Produções"
            }
          
        }; 
        await Navigation.PushAsync(new MusicianEventView(evento));
    }
}
    
    