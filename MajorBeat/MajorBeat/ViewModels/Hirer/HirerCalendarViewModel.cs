using CommunityToolkit.Mvvm.ComponentModel; 
using CommunityToolkit.Mvvm.Input;          
using MajorBeat.Models;
using MajorBeat.Views.Musicians;
using Microsoft.Extensions.Logging;
using System.Collections.ObjectModel;


namespace MajorBeat.ViewModels.Hirer;

public partial class HirerCalendarViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<Evento> eventos;

    [ObservableProperty]
    private ObservableCollection<Evento> eventosFiltrados;

    [ObservableProperty]
    private ObservableCollection<string> filtros;

    [ObservableProperty]
    private ObservableCollection<DateTime> unavailableDates = new();

    [ObservableProperty]
    private string filtroSelecionado;

    [ObservableProperty]
    private DateTime currentMonth = DateTime.Today;

    public HirerCalendarViewModel()
    {
        Filtros = new ObservableCollection<string> { "Próximos", "Concluídos" };

        Eventos = new ObservableCollection<Evento>
        {
            new Evento
            {
                IdEvento = 1,
                Nome = "Panelão do Norte",
                Data = new DateTime(2025, 10, 30),
                HoraInicio = new TimeSpan(18, 0, 0),
                HoraFim = new TimeSpan(21, 0, 0),
            },
            new Evento
            {
                IdEvento = 2,
                Nome = "Festival Harmoniar",
                Data = new DateTime(2025, 11, 10),
                HoraInicio = new TimeSpan(14, 0, 0),
                HoraFim = new TimeSpan(23, 0, 0),
            },
            new Evento
            {
                IdEvento = 3,
                Nome = "Casamento",
                Data = new DateTime(2025, 9, 15),
                HoraInicio = new TimeSpan(19, 0, 0),
                HoraFim = new TimeSpan(22, 0, 0),
            }
        };

        foreach (var evento in Eventos)
            UnavailableDates.Add(evento.Data);

        EventosFiltrados = new ObservableCollection<Evento>();

        FiltroSelecionado = "Próximos";

    }

    partial void OnFiltroSelecionadoChanged(string value)
    {
        FiltrarEventos();
    }

    private void FiltrarEventos()
    {
        if (Eventos == null || EventosFiltrados == null)
            return;

        var eventosParaExibir = FiltroSelecionado == "Concluídos"
            ? Eventos.Where(e => e.Data < DateTime.Today)
            : Eventos.Where(e => e.Data >= DateTime.Today);

        EventosFiltrados.Clear();
        foreach (var evento in eventosParaExibir)
        {
            EventosFiltrados.Add(evento);
        }
    }

    [RelayCommand]
    private void AdicionarEvento()
    {
        App.Current.MainPage.DisplayAlert("Novo Evento", "Abrir tela de criação de evento.", "OK");
    }

    [RelayCommand]
    private void AbrirOpcoes(Evento e)
    {
        if (e == null) return;

        App.Current.MainPage.DisplayActionSheet(
            $"Evento: {e.Nome}",
            "Cancelar",
            null,
            "Editar Evento",
            "Excluir Evento");
    }

    [RelayCommand]
    private async Task AbrirDetalhesEvento(Evento evento)
    {
        if (evento == null) return;

        await Shell.Current.Navigation.PushAsync(new MusicianEventView(evento.IdEvento));
    }



}