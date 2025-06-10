using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

public class Uni: Configurazione
{

    public Uni()
    {
        ParteSuperiore = true;
    }
    public override void ImpostaNome()
    {
        Nome = "Uni";
    }
    public override void CalcolaPunteggio(int[]valoriDadi)
    {
        Punteggio = 0;
        for (int i = 0; i < 5; i++)
        {
            if (valoriDadi[i] == 1)
            {
                Punteggio++;
            }
        }
    }
}