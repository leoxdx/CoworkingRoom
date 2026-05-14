using System;
using System.Collections.Generic;
using System.Text;

namespace CoworkingRoom.Models
{
    public class Agendamento
    {
        public int Id { get; set; }
        public int SalaId { get; set; }
        public DateTime DataHoraInicio { get; set; }
        public DateTime DataHoraFim { get; set; }
    }
}
