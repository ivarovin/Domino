namespace Domino;

// Reglas domino
// https://es.wikipedia.org/wiki/Domin%C3%B3
// Tablero 
// El juego tiene 28 fichas
// Cada jugador empieza con 7 fichas
// X Cada ficha tiene 2 celdas.
// X Cada celda tiene un número del 0 al 6.
// X Las fichas se conectan por las celdas con mismo número.
// Gana el jugador que se quede sin fichas.
// Si no puedes colocar ficha robas una del montón.
// Si no hay fichas en el montón se pasa el turno.

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        Assert.Pass();
    }

    [Test]
    public void Conectables()
    {
        var celda1 = new Celda(3);
        var celda2 = new Celda(3);
        Assert.AreEqual(celda1, celda2);
    }

    [Test]
    public void NoConectables()
    {
        var celda1 = new Celda(3);
        var celda2 = new Celda(6);
        Assert.AreNotEqual(celda1, celda2);
    }

    [Test]
    public void FichasConectables()
    {
        var ficha1 = new Ficha(1, 2);
        var ficha2 = new Ficha(2, 3);

        Assert.IsTrue(ficha1.Conecta(ficha2));
    }

    [Test]
    public void AñadirFichaATablero()
    {
        var tablero = new Tablero();

        tablero.Añadir(new Ficha(1, 2));

        Assert.AreEqual(tablero.Fichas.Count, 1);
    }

    [Test]
    public void PuedeAñadirFichaIzquierda()
    {
        var tablero = new Tablero();

        tablero.Añadir(new Ficha(2, 1));

        Assert.IsTrue(tablero.PuedeAñadirFichaIzquierda(new Ficha(2, 3)));
    }

    [Test]
    public void NoPuedeAñadirFichaIzquierda()
    {
        var tablero = new Tablero();

        tablero.Añadir(new Ficha(1, 2));

        Assert.IsFalse(tablero.PuedeAñadirFichaIzquierda(new Ficha(2, 3)));
    }

    [Test]
    public void sfsdds()
    {
        Assert.IsFalse(new Ficha(1, 2).Conecta(3));
    }
}

public class Tablero
{
    public List<Ficha> Fichas { get; } = new List<Ficha>();

    public void Añadir(Ficha ficha)
    {
        Fichas.Add(ficha);
    }

    public bool PuedeAñadirFichaIzquierda(Ficha ficha)
    {
        return CeldaIzquierda().Equals(ficha.n1);
    }

    public Celda CeldaIzquierda() => Fichas.First().n1;
    public Celda CeldaDerecha() => Fichas.Last().n2;
}

public class Ficha
{
    public Ficha(Celda n1, Celda n2)
    {
        this.n1 = n1;
        this.n2 = n2;
    }

    public readonly Celda n1;
    public readonly Celda n2;

    public bool Conecta(Ficha otra)
    {
        return n1.Equals(otra.n1) || n1.Equals(otra.n2) || n2.Equals(otra.n1) || n2.Equals(otra.n2);
    }

    public bool Conecta(Celda otra)
    {
        return n1.Equals(otra) || n2.Equals(otra);
    }
}

public struct Celda
{
    public int value;

    public Celda(int value)
    {
        if (value < 0)
        {
            throw new ArgumentException("El valor no puede ser menor a 0");
        }

        if (value > 6)
        {
            throw new ArgumentException("El valor no puede ser mayor a 6");
        }

        this.value = value;
    }

    public static implicit operator Celda(int value)
    {
        return new Celda(value);
    }
}

public class Player
{
}