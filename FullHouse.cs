using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

public class FullHouse: Configurazione
{

    public FullHouse()
    {
        ParteSuperiore = false;
    }
    public override void ImpostaNome()
    {
        Nome = "FullHouse";
    }
    public override void CalcolaPunteggio(int[] valoriDadi)
    {
        Punteggio = 0;

        int[] conteggioNumeri = new int[6];


        foreach (int valore in valoriDadi)
        {
            conteggioNumeri[valore - 1]++;
        }

        bool trovatoGruppoDiDue = false;
        bool trovatoGruppoDiTre = false;

        foreach (int conteggio in conteggioNumeri)
        {
            if (conteggio == 2)
                trovatoGruppoDiDue = true;
            else if (conteggio == 3)
                trovatoGruppoDiTre = true;
        }

        if (trovatoGruppoDiDue && trovatoGruppoDiTre)
        {
            Punteggio = 25;
        }
    }
}