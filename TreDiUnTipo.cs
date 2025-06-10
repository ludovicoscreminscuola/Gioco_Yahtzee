using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class TreDiUnTipo: Configurazione
{
    public TreDiUnTipo()
    {
        ParteSuperiore = false;
    }
    public override void ImpostaNome()
    {
        Nome = "TreDiUnTipo";
    }
    public override void CalcolaPunteggio(int[] valoriDadi)
    {
        Punteggio = 0;
        int conteggioNumeriUguali = 0;
        int i = 0;

        while (i < 5 && conteggioNumeriUguali < 3)
        {
            conteggioNumeriUguali = 0;
            for (int k = 0; k < 5; k++)
            {
                if (valoriDadi[i] == valoriDadi[k])
                {
                    conteggioNumeriUguali++;
                }
            }
            i++;
        }

        if (conteggioNumeriUguali >= 3)
        {
            for (int t = 0; t < 5; t++)
            {
                Punteggio += valoriDadi[t];
            }
        }
    }
}