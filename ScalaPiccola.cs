using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ScalaPiccola: Configurazione
{

    public ScalaPiccola()
    {
        ParteSuperiore = false;
    }
    public override void ImpostaNome()
    {
        Nome = "ScalaPiccola";
    }
    public override void CalcolaPunteggio(int[] valoriDadi)
    {
        Punteggio = 0;
        int conteggio = 1;
        int[] arr = valoriDadi;
        Array.Sort(arr);

        for (int i = 1; i < 5; i++)
        {
            if (arr[i] == (arr[i-1]+1))
            {
                conteggio++;
            }
        }
        if (conteggio >= 4)
        {
            Punteggio = 30;
        }
    }
}