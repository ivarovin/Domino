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

    [Test]
    public void NoConectables()
    {
        var celda1 = new Celda(3);
        var celda2 = new Celda(6);
        Assert.AreNotEqual(celda1, celda2);
    }

    [Test]
    public void NoInverso()
    {
        var ficha1 = new Ficha(1, 2, false);
        
        Assert.AreEqual(ficha1.Izquierda, (Celda)1);
        Assert.AreEqual(ficha1.Derecha, (Celda)2);
    }

    [Test]
    public void Inverso()
    {
        var ficha1 = new Ficha(1, 2, true);
        
        Assert.AreEqual(ficha1.Izquierda, (Celda)2);
        Assert.AreEqual(ficha1.Derecha, (Celda)1);
    }

    [Test]
    public void FichasConectablesSinInverso()
    {
        var ficha1 = new Ficha(1, 2, false);
        var ficha2 = new Ficha(2, 3, false);
        
        Assert.IsTrue(ficha1.ConectaConDer(ficha2));
        Assert.IsFalse(ficha1.ConectaConIzq(ficha2));
    }
    
    [Test]
    public void FichasConectablesInverso()
    {
        var ficha1 = new Ficha(1, 2, false);
        var ficha2 = new Ficha(3, 2, true);
        
        Assert.IsTrue(ficha1.ConectaConDer(ficha2));
        Assert.IsFalse(ficha1.ConectaConIzq(ficha2));
    }
}

public class Ficha
{
    public Celda Derecha => inverso? izquierda : derecha;

    public Celda Izquierda => inverso? derecha : izquierda;

    public Ficha(Celda izquierda, Celda derecha, bool inverso)
    {
        this.izquierda = izquierda;
        this.derecha = derecha;
        this.inverso = inverso;
    }

    readonly Celda izquierda;
    readonly Celda derecha;
    private bool inverso;

    public bool ConectaConDer(Ficha ficha2)
    {
        return Derecha.Equals(ficha2.Izquierda);
    }

    public bool ConectaConIzq(Ficha ficha2)
    {
        return Izquierda.Equals(ficha2.Derecha);
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
{ }
