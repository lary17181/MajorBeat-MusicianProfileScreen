using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MajorBeat.Enums;
using MajorBeat.Models;
using Microsoft.Maui.Graphics;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

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

    
     public ObservableCollection<string> Images { get; } = new()
        {
          "musicianprofile1.png",
          "musicianprofile2.png",
          "musicianprofile3.png"
         };

    [ObservableProperty] private int currentIndex;

    public ObservableCollection<DiaCalendario> DiasCalendario { get; } = new();

    private readonly int[] diasDisponiveisExemplo = new int[] { 2, 5, 8, 12, 16, 19, 23, 27 };
    private readonly int[] diasOcupadosExemplo = new int[] { 3, 9, 14, 18, 25 };

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

        CarregarDiasCalendario(DateTime.Today);
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

        CarregarDiasCalendario(DateTime.Today);
    }

    public void CarregarDiasCalendario(DateTime referenceDate)
    {
        DiasCalendario.Clear();

        var primeiro = new DateTime(referenceDate.Year, referenceDate.Month, 1);
        int diasNoMes = DateTime.DaysInMonth(referenceDate.Year, referenceDate.Month);

        for (int d = 1; d <= diasNoMes; d++)
        {
            Color cor;

            if (diasDisponiveisExemplo.Contains(d))
                cor = Color.FromArgb("#4F1271"); 
            else
                cor = Color.FromArgb("#BBA1C9");

            DiasCalendario.Add(new DiaCalendario
            {
                Dia = d.ToString(),
                CorDia = cor,
                Data = new DateTime(referenceDate.Year, referenceDate.Month, d),
                Disponivel = cor == Color.FromArgb("#4F1271")
            });
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
        public class DiaCalendario
        {
            public string Dia { get; set; }
            public Color CorDia { get; set; }
            public DateTime Data { get; set; }
            public bool Disponivel { get; set; }
}

