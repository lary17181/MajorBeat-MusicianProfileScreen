using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MajorBeat.Enums;
using MajorBeat.Models;
using Microsoft.Maui.Graphics;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows.Input;

namespace MajorBeat.ViewModels.Hirer;

public partial class MusicianProfileViewModel : ObservableObject
{
        public Musico Musico { get; set; } 
        public string Username { get; private set; }
        public string Nome { get; private set; }
        public string Biografia { get; private set; }
        public ObservableCollection<InstrumentoEnum> Instrumentos { get; private set; } = new();
        public ObservableCollection<GeneroEnum> Generos { get; private set; } = new();
        public string Email { get; private set; }
        public string Logradouro { get; private set; }
        public string Telefone { get; private set; }
        public string LinkFacebook { get; private set; }
        public string LinkLinkdin { get; private set; }
        public string LinkInsta { get; private set; }
        public string LinkTwitter { get; private set; }


    [ObservableProperty]
    private DateTime currentMonth = DateTime.Now;

    public ObservableCollection<DateTime> UnavailableDates { get; set; } = new ObservableCollection<DateTime>
{
    DateTime.Today.AddDays(2),
    DateTime.Today.AddDays(5),
    DateTime.Today.AddDays(9),
    DateTime.Today.AddDays(12),
    DateTime.Today.AddDays(17),
    DateTime.Today.AddDays(25)
};

    public ICommand NextMonthCommand { get; }
    public ICommand PreviousMonthCommand { get; }

    public string CurrentMonthDisplay => CurrentMonth.ToString("MMMM yyyy", new CultureInfo("pt-BR"));

    public ObservableCollection<string> Images { get; } = new()
        {
          "musicianprofile1.png",
          "musicianprofile2.png",
          "musicianprofile3.png"
         };

    [ObservableProperty] private int currentIndex;

    public MusicianProfileViewModel()
    {
        // Valores default que aparecem na view enquanto não houver API
        Username = "Marquinhos";
        Nome = "Marcos José";
        Biografia = "Oi, eu sou o Marquinhos. Minha música é um pedaço de mim...";
        Instrumentos = new ObservableCollection<InstrumentoEnum> { InstrumentoEnum.Guitarra, InstrumentoEnum.Violão };
        Generos = new ObservableCollection<GeneroEnum> { GeneroEnum.Sertanejo, GeneroEnum.Gospel };
        Email = "marcos.jose123@gmail.com";
        Logradouro = "R. Alcântara, 113 - Vila Guilherme, São Paulo - SP";
        Telefone = "(11) 99999-9999";
        LinkFacebook = "marcos.jose";
        LinkLinkdin = "marcos.jose";
        LinkInsta = "marcos.jose";
        LinkTwitter = "marcos.jose";


        NextMonthCommand = new Command(() =>
        {
            CurrentMonth = CurrentMonth.AddMonths(1);
            OnPropertyChanged(nameof(CurrentMonth));
            OnPropertyChanged(nameof(CurrentMonthDisplay));
        });

        PreviousMonthCommand = new Command(() =>
        {
            CurrentMonth = CurrentMonth.AddMonths(-1);
            OnPropertyChanged(nameof(CurrentMonth));
            OnPropertyChanged(nameof(CurrentMonthDisplay));
        });
    }

        private void ChangeMonth(int offset)
        {
            CurrentMonth = CurrentMonth.AddMonths(offset);
            OnPropertyChanged(nameof(CurrentMonthDisplay));
        }

    public MusicianProfileViewModel(Musico musico)
    {
        if (musico == null) return;

        Musico = musico;

        Nome = musico.nome;
        Username = musico.apelido ?? musico.nome;
        Biografia = musico.biografia;
        Email = musico.email;
        Telefone = musico.telefone;
        Logradouro = musico.endereco;

        Instrumentos = musico.nomeInstrumento ?? new ObservableCollection<InstrumentoEnum>();
        Generos = musico.nomeGenero ?? new ObservableCollection<GeneroEnum>();

        if (musico.links != null && musico.links.Count >= 4)
        {
            LinkFacebook = musico.links.ElementAtOrDefault(0);
            LinkLinkdin = musico.links.ElementAtOrDefault(1);
            LinkInsta = musico.links.ElementAtOrDefault(2);
            LinkTwitter = musico.links.ElementAtOrDefault(3);
        }

        if (musico.mediaUrl != null && musico.mediaUrl.Count > 0)
        {
            Images.Clear();
            foreach (var url in musico.mediaUrl)
                Images.Add(url);
        }
    }

        public void SetCarouselIndex(int index)
        {
            CurrentIndex = index;
         }

    
        [RelayCommand]
        private void NextImage()
        {
            if (CurrentIndex < Images.Count - 1) CurrentIndex++;
        }

        [RelayCommand]
        private void PrevImage()
        {
            if (CurrentIndex > 0) CurrentIndex--;
        }
}
        
