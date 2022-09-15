﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ColTurismo.Common.DTOs.ReservaVuelo
{
    public class ReservaVueloDTO
    {
        public int NumeroVuelo { get; set; }

        public int CodTurista { get; set; }

        public string Clase { get; set; }
    }
}
