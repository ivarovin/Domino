namespace Domino;

// Reglas domino
// https://es.wikipedia.org/wiki/Domin%C3%B3
// El juego tiene 28 fichas
// Cada jugador empieza con 7 fichas
// Cada ficha tiene 2 celdas.
// Cada celda tiene un número del 0 al 6.
// Las fichas se conectan por las celdas con mismo número.
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
}

public class Ficha
{
    public Celda n1;
    public Celda n2;
    public bool orientacion;
}

public class Celda
{
    public int value;

    public Celda(int value)
    {
        this.value = value;
    }
}

public class Player
{ }
