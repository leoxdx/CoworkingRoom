using System;
using System.Collections.Generic;
using System.Text;

namespace CoworkingRoom.Models
{
    internal class LogOperacao
    {
        public int Id { get; set; }
        public string NomeTabela { get; set; } = string.Empty;
        public string TipoOperacao { get; set; } = string.Empty;

        public DateTime DataHora { get; set; }

    }
}
