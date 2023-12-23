namespace Domino;

public class Jugador
{
    public List<Ficha> Mano = new();
    private readonly Tablero tablero;
        
    public Jugador(Tablero tablero)
    {
        this.tablero = tablero;
        for (int i = 0; i < 7; i++)
        {
            Mano.Add(new Ficha(1, 2));
        }
    }

    public void JugarFicha(int i)
    {
        tablero.AñadirInicial(Mano[i]);
    }

    public void JugarFichaDerecha(int i)
    {
        tablero.AñadirPorLaDerecha(Mano[i]);
    }

    public void JugarFichaIzquierda(int i)
    {
        tablero.AñadirPorLaIzquierda(Mano[i]);
    }
}