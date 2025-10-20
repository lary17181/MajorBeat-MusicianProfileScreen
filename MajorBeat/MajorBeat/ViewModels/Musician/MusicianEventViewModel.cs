using MajorBeat.Models;
using MajorBeat.Enums;
using System.Collections.ObjectModel;

namespace MajorBeat.ViewModels.Musician
{
    public class MusicianEventViewModel
    {
        public Evento Evento { get; set; }

        public string Titulo => Evento.Titulo;
        public string Descricao => Evento.Descricao;
        public string Endereco => Evento.Endereco;
        public DateTime Data => Evento.Data;
        public TimeSpan HoraInicio => Evento.HoraInicio;
        public TimeSpan HoraFim => Evento.HoraFim;
        public Contratante Contratante => Evento.Contratante;
        public ObservableCollection<GeneroEnum> NomeGenero => Evento.NomeGenero;
        public ObservableCollection<InstrumentoEnum> NomeInstrumento => Evento.NomeInstrumento;
        public ObservableCollection<byte[]> ImagemLocalEvento => Evento.ImagemLocalEvento;

       
        public MusicianEventViewModel(Evento evento)
        {
            Evento = evento;
            Evento = new Evento
            {
                Titulo = "Panel�o do Norte",
                Descricao = "Uma noite especial com artistas locais e muita m�sica sertaneja. Ambiente descontra�do, boa comida e �timo p�blico!",
                Endereco = "Rua Alc�ntara, 113 - Vila Guilherme, S�o Paulo",
                Data = new DateTime(2025, 11, 20),
                HoraInicio = new TimeSpan(20, 0, 0),
                HoraFim = new TimeSpan(23, 30, 0),
                NomeGenero = new ObservableCollection<GeneroEnum> { GeneroEnum.Sertanejo, GeneroEnum.Gospel },
                NomeInstrumento = new ObservableCollection<InstrumentoEnum> { InstrumentoEnum.Viol�o, InstrumentoEnum.Bateria },
                ImagemLocalEvento = new ObservableCollection<byte[]>
                {
                    
                },
                Contratante = new Contratante
                {
                    Nome = "Por: Panel�o do Norte Produ��es"
                }
            };
        }
        

    }
}
