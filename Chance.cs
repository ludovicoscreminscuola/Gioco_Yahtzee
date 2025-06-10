using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Chance: Configurazione
{
    public Chance()
    {
        ParteSuperiore = false;
    }
    public override void ImpostaNome()
    {
        Nome = "Chance";
    }

    public override void CalcolaPunteggio(int[] valoriDadi)
    {
        Punteggio = 0;

        for(int i = 0; i < 5; i++)
        {
            Punteggio += valoriDadi[i];
        }

    }
}