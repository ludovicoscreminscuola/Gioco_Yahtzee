using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Yahtzee: Configurazione
{
    public Yahtzee()
    {
        ParteSuperiore = false;
    }
    public override void ImpostaNome()
    {
        Nome = "Yahtzee";
    }
    public override void CalcolaPunteggio(int[] valoriDadi)
    {
        int[] arr = valoriDadi;
        Array.Sort(arr);
        Punteggio = 0;
        bool cond = true;
        int i = 0;

        while (i <= 3 && cond)
        {
            if (arr[i] != arr[i+1])
            {
                cond = false;
            }
            else
            {
                i++;
            }
        }

        if (cond)
        {
            Punteggio = 50;
        }
    }
}