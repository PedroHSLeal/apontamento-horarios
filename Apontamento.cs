using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horarios
{
    internal class Apontamento
    {
        public DateOnly Data { get; set; }
        public TimeOnly HorarioInicio { get; set; }
        public string Descricao { get; set; }
    }
}
