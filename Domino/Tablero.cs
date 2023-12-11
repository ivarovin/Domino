namespace Domino;

public class Tablero
{
    public List<Ficha> Fichas { get; } = new List<Ficha>();

    public void Añadir(Ficha ficha)
    {
        Fichas.Add(ficha);
    }

    public void AñadirPorLaIzquierda(Ficha ficha)
    {
        // Fichas.
    }

    public void AñadirPorLaDerecha(Ficha ficha)
    {
        // Fichas.
    }

    public bool PuedeAñadirFichaIzquierda(Ficha ficha)
    {
        return ficha.Conecta(CeldaIzquierda());
    }

    public bool PuedeAñadirFichaDerecha(Ficha ficha)
    {
        return ficha.Conecta(CeldaDerecha());
    }

    public Celda CeldaIzquierda() => Fichas.First().n1;
    public Celda CeldaDerecha() => Fichas.Last().n2;
}
