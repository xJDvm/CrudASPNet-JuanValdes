using System;
using System.Collections.Generic;

#nullable disable

namespace players.Models.Request
{
    public partial class JugadoresRequest
    {
        public int Id { get; set; }
        public string Nick { get; set; }
        public int? Edad { get; set; }
        public string Pais { get; set; }
        public int? Wins { get; set; }
    }
}
