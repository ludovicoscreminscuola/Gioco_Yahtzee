using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

public class BloccoFogli
{
    Fogliosegnapunti Fogliosegnapunti1 { get; set; }
    public List<Fogliosegnapunti> ListaFogli { get; set; }
    public bool IsPartitaFinita { get; set; }

    public int NumeroGiocatori { get; set; }

    public BloccoFogli()
    {
        Fogliosegnapunti1 = new Fogliosegnapunti();
        ListaFogli = new List<Fogliosegnapunti>();
        IsPartitaFinita = false;
        NumeroGiocatori = ListaFogli.Count;
    }

    public void AggiungiFoglio(string nomeGiocatore)
    {
        Fogliosegnapunti nuovoFogliosegnapunti1 = new Fogliosegnapunti();
        nuovoFogliosegnapunti1.NomeGiocatore = nomeGiocatore;
        ListaFogli.Add(nuovoFogliosegnapunti1);
    }

    public string EsitoPartita()
    {
        int max = 0;
        string esito = "";

        foreach(Fogliosegnapunti f in ListaFogli)
        {
            if (f.CalcolaPunteggioFinale() > max)
            {
                max = f.CalcolaPunteggioFinale();
                esito = f.ToString();
            }
        }

        return esito;
    }

    public void Reset()
    {
        ListaFogli.Clear();
    }
}