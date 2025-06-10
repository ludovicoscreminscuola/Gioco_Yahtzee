using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Gioco
{
    public Dado Dado1 { get; set; }
    public Dado Dado2 { get; set; }
    public Dado Dado3 { get; set; }
    public Dado Dado4 { get; set; }
    public Dado Dado5 { get; set; }

    public bool TurnoFinito { get; set; }

    public List<Dado> ListaDadi { get; set; }

    public Uni Uno1 { get; set; }
    public Secondi Due2 { get; set; }
    public Terzi Tre3 { get; set; }

    public Quarti Quattro4 { get; set; }

    public Quinti Cinque5 { get; set; }
    public Sesti Sei6 { get; set; }
    public TreDiUnTipo TreDiUnTipo1 { get; set; }

    public QuattroDiUnTipo QuattroDiUnTipo1 { get; set; }

    public FullHouse FullHouse1 { get; set; }
    
    public ScalaPiccola ScalaPiccola1 { get; set; }

    public ScalaGrande ScalaGrande1 { get; set; }
    public Chance Chance1 { get; set; }
    public Yahtzee Yahtzee1 { get; set; }
    public List<Configurazione> ListaConfigurazioni { get; set; }
    public int NumeroTurni { get; set; }

    public int NumeroLanciDiUnTurno { get; set; }

    public Gioco()
    {
        Dado1 = new Dado();
        Dado2 = new Dado();
        Dado3 = new Dado();
        Dado4 = new Dado();
        Dado5 = new Dado();
        ListaDadi = new List<Dado>() { Dado1, Dado2, Dado3, Dado4, Dado5 };

        Uno1 = new Uni();
        Due2 = new Secondi();
        Tre3 = new Terzi();
        Quattro4 = new Quarti();
        Cinque5 = new Quinti();
        Sei6 = new Sesti();
        TreDiUnTipo1 = new TreDiUnTipo();
        QuattroDiUnTipo1 = new QuattroDiUnTipo();
        FullHouse1 = new FullHouse();
        ScalaPiccola1 = new ScalaPiccola();
        ScalaGrande1 = new ScalaGrande();
        Chance1 = new Chance();
        Yahtzee1 = new Yahtzee();
        ListaConfigurazioni = new List<Configurazione>
        { Uno1, Due2, Tre3, Quattro4, Cinque5, Sei6, TreDiUnTipo1, QuattroDiUnTipo1,
        FullHouse1, ScalaPiccola1, ScalaGrande1, Chance1, Yahtzee1 };

        NumeroTurni = 0;
        TurnoFinito = false;
        NumeroLanciDiUnTurno = 1;
    }

    public void FaiLanci()
    {
        foreach (Dado dado in ListaDadi)
        {
            if (dado.IsOn)
            {
                dado.Lancia();
            }
            NumeroLanciDiUnTurno++;
        }
        if (NumeroLanciDiUnTurno == 3)
        {
            NumeroLanciDiUnTurno = 0;
        }
    }

    public void FaiTurno()
    {
        int i = 1;
        while (!TurnoFinito && i <= 3 && NumeroTurni < 13)
        {
            FaiLanci();
            i++;
            NumeroTurni++;
        }
    }

    public List<Configurazione> SimulaPunteggi()
    {
        int[] valoriDeiDadi = new int[5];
        int i = 0;

        foreach(Dado d in ListaDadi)
        {
            valoriDeiDadi[i] = d.Valore;
            i++;
        }

        foreach (Configurazione g in ListaConfigurazioni)
        {
            if (!g.IsOccupato)
            {
                g.CalcolaPunteggio(valoriDeiDadi);
            }
        }
        return ListaConfigurazioni;
    }
}