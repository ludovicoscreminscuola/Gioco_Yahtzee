using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class QuattroDiUnTipo: Configurazione
{

    public QuattroDiUnTipo()
    {
        ParteSuperiore = false;
    }
    public override void ImpostaNome()
    {
        Nome = "QuattroDiUnTipo";
    }
    public override void CalcolaPunteggio(int[] valoriDadi)
    {
        Punteggio = 0;
        int conteggioNumeriUguali = 0;
        int i = 0;

        while (i < 5 && conteggioNumeriUguali < 4)
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

        if (conteggioNumeriUguali >= 4)
        {
            for (int t = 0; t < 5; t++)
            {
                Punteggio += valoriDadi[t];
            }
        }
    }
}