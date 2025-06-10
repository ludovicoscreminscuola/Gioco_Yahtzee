using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Fogliosegnapunti
{
    public string NomeGiocatore { get; set; }
    public List<Configurazione> PunteggiFinali { get; set; }
    public Gioco Gioco1 { get; set; }

    public int NumeroTurni { get; set; }

    public int PunteggioParteSuperiore { get; set; }

    public Fogliosegnapunti()
    {
        Gioco1 = new Gioco();
        PunteggiFinali = Gioco1.ListaConfigurazioni;
        NumeroTurni = 0;
        PunteggioParteSuperiore = 0;
    }

    public List<Configurazione> MostraPotenzialiPunteggi()
    {
        return Gioco1.SimulaPunteggi();
    }




    public void ImpostaPunteggio(Configurazione oggettoSelezionato)
    {
        foreach(Configurazione g in PunteggiFinali)
        {
            if (g.Equals(oggettoSelezionato))
            {
                g.IsOccupato = true;
                foreach(Configurazione t in Gioco1.ListaConfigurazioni)
                {
                    if (g.Equals(t) && !g.IsOccupato)
                    {
                        g.Punteggio = t.Punteggio;
                    }
                }
            }
        }
        foreach(Configurazione k in Gioco1.SimulaPunteggi())
        {
            if (k.Equals(oggettoSelezionato))
            {
                k.IsOccupato = true;
            }
        }
    }

    public int CalcolaBonus()
    {
        PunteggioParteSuperiore = 0;
        int esito = 0;
        foreach(Configurazione g in Gioco1.ListaConfigurazioni)
        {
            if (g.ParteSuperiore)
            {
                PunteggioParteSuperiore += g.Punteggio;
            }
        }

        if (PunteggioParteSuperiore >= 63)
        {
            esito = 35;
        }
        return esito;
    }

    public int CalcolaPunteggioFinale()
    {
        int punti = 0;
        foreach (Configurazione g in Gioco1.ListaConfigurazioni)
        {
            punti += g.Punteggio;
        }

        punti += CalcolaBonus();

        return punti;
    }

    public override string ToString()
    {
        return NomeGiocatore + " ha vinto con un punteggio di " + CalcolaPunteggioFinale();
    }
}