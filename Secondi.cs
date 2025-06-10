using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

public class Secondi: Configurazione
{
    public Secondi()
    {
        ParteSuperiore = true;
    }
    public override void ImpostaNome()
    {
        Nome = "Secondi";
    }
    public override void CalcolaPunteggio(int[] valoriDadi)
    {
        Punteggio = 0;

        for (int i = 0; i < 5; i++)
        {
            if (valoriDadi[i] == 2)
            {
                Punteggio += 2;
            }
        }
    }
}