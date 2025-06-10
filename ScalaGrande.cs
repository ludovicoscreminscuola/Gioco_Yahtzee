using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ScalaGrande: Configurazione
{

    public ScalaGrande()
    {
        ParteSuperiore = false;
    }
    public override void ImpostaNome()
    {
        Nome = "ScalaGrande";
    }
    public override void CalcolaPunteggio(int[] valoriDadi)
    {
        Punteggio = 0;
        int conteggio = 1;
        int[] arr = valoriDadi;
        Array.Sort(arr);
        for (int i = 1; i < 5; i++)
        {
            if (arr[i] == (arr[i - 1] + 1))
            {
                conteggio++;
            }
        }
        if (conteggio >= 5)
        {
            Punteggio = 40;
        }
    }
}