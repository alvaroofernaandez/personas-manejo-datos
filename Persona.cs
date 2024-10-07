using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ficheros2
{
    public class Persona
    {
        public string nombre {  get; set; }
        public string apellidos { get; set; }
        public int nota { get; set; }

        public Persona(string nombre, string apellidos, int nota)
        {
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.nota = nota;

        }

    }
}
