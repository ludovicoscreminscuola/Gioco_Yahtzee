using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Dado
{
    public int Valore { get; set; }
    public bool IsOn { get; set; }

    private Random generatore;

    public Dado()
    {
        generatore = new Random();
        IsOn = true;
    }

    public void Lancia()
    {
        Valore = generatore.Next(1, 7);
    }
}