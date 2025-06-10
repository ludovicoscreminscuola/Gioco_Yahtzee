using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Terzi: Configurazione
{

    public Terzi()
    {
        ParteSuperiore = true;
    }
    public override void ImpostaNome()
    {
        Nome = "Terzi";
    }
    public override void CalcolaPunteggio(int[] valoriDadi)
    {
        Punteggio = 0;

        for (int i = 0; i < 5; i++)
        {
            if (valoriDadi[i] == 3)
            {
                Punteggio += 3;
            }
        }
    }
}