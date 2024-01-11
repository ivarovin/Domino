namespace Domino;

public class Jugador
{
    public List<Ficha> Mano = new();
    private readonly Tablero tablero;
    private readonly Pila pila;
        
    public Jugador(Tablero tablero, Pila pila)
    {
        this.pila = pila;
        this.tablero = tablero;
        for (int i = 0; i < 7; i++)
        {
            Mano.Add(pila.Robar());
            // Mano.Add(new Ficha(1, 2));
        }
    }

    public void IntentarJugarFicha(int i)
    {
        tablero.AñadirInicial(Mano[i]);
    }

    // public void IntentarJugarFichaDerecha(int i)
    // {
    //     if (tablero.PuedeAñadirFichaDerecha(Mano[i]))
    //     {
    //         JugarFichaDerecha(Mano[i]);
    //     }
    // }

    public void JugarFichaDerecha(int i)
    {
        tablero.AñadirPorLaDerecha(Mano[i]);
    }

    public void JugarFichaIzquierda(int i)
    {
        tablero.AñadirPorLaIzquierda(Mano[i]);
    }

    public void IntentarRobar()
    {
        if (pila.PuedeRobar())
        {
            Mano.Add(pila.Robar());
        }
    }
}