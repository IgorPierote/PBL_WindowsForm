﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL_WindowsForms.Objetos
{
    public class Meteoro : PBL_WindowsForms.Objetos.Objetos_Na_Atmosfera
    {
        public double DistanciaDoCanhao { get; private set; }
        public double AlturaInicial { get; private set; }

        public Meteoro()
        {
            DistanciaDoCanhao = 500;
            AlturaInicial = 188.675145948;
            Voy = 0;
        }

        public override void SetAltura(double tempo)
        {
            Altura = AlturaInicial + Voy * tempo - (Gravidade / 2) * Math.Pow(tempo, 2);
        }
    }
}
