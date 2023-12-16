namespace Domino;

public class Tablero
{
    public List<Ficha> Fichas { get; } = new List<Ficha>();

    public void AñadirInicial(Ficha ficha)
    {
        Fichas.Add(ficha);
    }

    // public ?? ComprobarYAñadirPorLaIzquierda(Ficha ficha)
    // {
    //     if (!PuedeAñadirFichaIzquierda(ficha)) {
    //         return false
    //     } else {
    //         Fichas.Insert(0, ficha);
    //         return true
    //     }
    // }

    public void AñadirPorLaIzquierda(Ficha ficha)
    {
        if(!PuedeAñadirFichaIzquierda(ficha)) throw new Exception("No se puede añadir la ficha por la izq");
        Fichas.Insert(0, ficha.Girar());
    }

    public void AñadirPorLaDerecha(Ficha ficha)
    {
        if(!PuedeAñadirFichaDerecha(ficha)) throw new Exception("No se puede añadir la ficha por la derecha");
        Fichas.Insert(Fichas.Count, ficha.Girar());
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
