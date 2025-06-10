using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Configurazione: IEquatable<Configurazione>
{
    public int Punteggio { get; set; }
    public string Nome { get; set; }

    public bool ParteSuperiore { get; set; }
    public bool IsOccupato { get; set; }

    public Configurazione()
    {
        IsOccupato = false;
    }

    public abstract void CalcolaPunteggio(int[] valoriDadi);
    public abstract void ImpostaNome();

    public bool Equals(Configurazione altro)
    {
        if (this.Nome == altro.Nome)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}