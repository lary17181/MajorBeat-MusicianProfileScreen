using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MajorBeat.Models;
using MajorBeat.Services.Users;
using System.Collections.ObjectModel;
using Microsoft.Extensions.Logging;
using MajorBeat.Views.Musicians;
using MajorBeat.Views.Hirers;
using System.Diagnostics;
using MajorBeat.Enums;

namespace MajorBeat.ViewModels.Musician
{
    public partial class MusicianEventViewModel : ObservableObject
    {
        private readonly EventService _eventService;
        private readonly long _eventId;

        [ObservableProperty] private Evento evento;

        [ObservableProperty] private bool isBusy;

        [ObservableProperty] private int totalImages;

        [ObservableProperty] private int imageIndice;

        public ObservableCollection<string> ImagensMock => new() 
{
        "panelao.png"
        };
        public string CountImages => TotalImages > 0 ? $"{ImageIndice + 1} / {TotalImages}" : "0 / 0";

       
        public MusicianEventViewModel(long eventId)
        {
            _eventService = new EventService();
            _eventId = eventId;

            LoadMockData(eventId);
            InicializarCarrossel();

            PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == nameof(ImageIndice))
                {
                    OnPropertyChanged(nameof(CountImages));
                }
            };

        }
        private void LoadMockData(long id)
        {
            Evento = new Evento
            {
                IdEvento = id,
                Titulo = "Panelão do Norte",
                Descricao = "Um evento voltado à valorização da música independente, com artistas locais e novas bandas.",
                Endereco = "Rua Alcântara,113 - São Paulo, SP",
                Data = new DateTime(2025, 10, 30),
                HoraInicio = new TimeSpan(18, 0, 0),
                HoraFim = new TimeSpan(23, 0, 0),
                NomeGenero = new ObservableCollection<Enums.NomeGenero> { Enums.NomeGenero.MPB, Enums.NomeGenero.SERTANEJO },
                NomeInstrumento = new ObservableCollection<Enums.NomeInstrumento> { Enums.NomeInstrumento.VOZ, Enums.NomeInstrumento.VIOLAO },
                ImagemLocalEvento = new ObservableCollection<string>
        {
            "panelao.png" 
        },
                Contratante = new Contratante
                {
                    Nome = "Panelão do Norte Produções"
                },
            };
        }
        /*public ObservableCollection<string> ImagensExibicao
        {
            get
            {
                if (Evento?.ImagemLocalEvento != null && Evento.ImagemLocalEvento.Any())
                {
                    return Evento.ImagemLocalEvento;
                }
                return new ObservableCollection<string> { "panelao.png" };
            }
        }
        */
        [RelayCommand]
        public async Task LoadEventData(long id)
        {
            if (id <= 0)
            {
                // Se o ID for inválido, carrega o mock
                LoadMockData(id);
                InicializarCarrossel();
                return;
            }

            try
            {
                IsBusy = true;
                var eventoResult = await _eventService.GetEventById(id);

                if (eventoResult != null)
                {
                    Evento = eventoResult;
                    Debug.WriteLine($"[API SUCESSO] Evento {id} carregado.");
                }
                else
                {
                    Debug.WriteLine($"[API AVISO] Evento {id} não encontrado. Usando Mock.");
                    LoadMockData(id);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[API ERRO] Falha ao carregar evento {id}: {ex.Message}. Usando Mock.");
                LoadMockData(id);
            }
            finally
            {
                IsBusy = false;
                InicializarCarrossel();
            }
        }


        private void InicializarCarrossel()
        {
            if (Evento?.ImagemLocalEvento != null && Evento.ImagemLocalEvento.Count > 0)
            {
                TotalImages = Evento.ImagemLocalEvento.Count;
                ImageIndice = 0;
            }
            else
            {
                TotalImages = 0;
                ImageIndice = 0;
            }

        }

       
    }
}
