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

        [ObservableProperty] private Evento evento;

        [ObservableProperty] private bool isBusy;

        [ObservableProperty] private int totalImages;

        [ObservableProperty] private int imageIndice;

        public ObservableCollection<string> ImagensMock => new()
{
        "panelao.png"
        };
        public string CountImages => TotalImages > 0 ? $"{ImageIndice + 1} / {TotalImages}" : "0 / 0";

        public MusicianEventViewModel(Evento _evento)
        {
            _eventService = new EventService();

            Evento = _evento;

            if (Evento != null)
            {
                InicializarCarrossel();
            }
            /*Evento = _evento;
            LoadEventDataCommand.ExecuteAsync(_evento.IdEvento);

            PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == nameof(ImageIndice))
                {
                    OnPropertyChanged(nameof(CountImages));
                }
            };*/
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

        /*[RelayCommand]
        public async Task LoadEventData(long id)
        {
            try
            {
                isBusy = true;
                var eventoResult = await _eventService.GetEventById(id);

                if (eventoResult != null)
                {
                    Evento = eventoResult;
                    InicializarCarrossel();
                }
                else
                {
                    Debug.WriteLine($"[ERRO DE DADOS] Evento com ID {id} não encontrado na API.");
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Erro", $"Falha ao carregar detalhes do evento: {ex.Message}", "OK");
                await Shell.Current.GoToAsync("..");
            }
        }*/
    }
}
