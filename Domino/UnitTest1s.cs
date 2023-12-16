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

        tablero.AñadirInicial(new Ficha(1, 2));

        Assert.AreEqual(tablero.Fichas.Count, 1);
    }

    [Test]
    public void AñadirFichaATableroIzquierda()
    {
        var tablero = new Tablero();
        tablero.AñadirInicial(new Ficha(1, 2));
        tablero.AñadirPorLaIzquierda(new Ficha(1,2));
        
        Assert.IsTrue(tablero.Fichas.Count == 2);
    }
    
    [Test]
    public void AñadirFichaATableroDerecha()
    {
        var tablero = new Tablero();
        tablero.AñadirInicial(new Ficha(1, 2));
        tablero.AñadirPorLaDerecha(new Ficha(1,2));
        
        Assert.IsTrue(tablero.Fichas.Count == 2);
    }

    [Test]
    public void FalloAlAñadirPorLaIzquierda()
    {
        var tablero = new Tablero();
        tablero.AñadirInicial(new Ficha(1, 2));
        Assert.Catch(() => tablero.AñadirPorLaIzquierda(new Ficha(3,3)));
    }

    [Test]
    public void FalloAlAñadirPorLaDerecha()
    {
        var tablero = new Tablero();
        tablero.AñadirInicial(new Ficha(1, 2));
        Assert.Catch(() => tablero.AñadirPorLaDerecha(new Ficha(3,3)));
    }

    [Test]
    public void PuedeAñadirFichaIzquierda()
    {
        var tablero = new Tablero();

        tablero.AñadirInicial(new Ficha(2, 1));

        Assert.IsTrue(tablero.PuedeAñadirFichaIzquierda(new Ficha(2, 3)));
    }

    [Test]
    public void NoPuedeAñadirFichaIzquierda()
    {
        var tablero = new Tablero();

        tablero.AñadirInicial(new Ficha(1, 2));

        Assert.IsFalse(tablero.PuedeAñadirFichaIzquierda(new Ficha(2, 3)));
    }

    [Test]
    public void PuedeAñadirFichaDerecha()
    {
        var tablero = new Tablero();

        tablero.AñadirInicial(new Ficha(1, 2));

        Assert.IsTrue(tablero.PuedeAñadirFichaDerecha(new Ficha(2, 3)));
    }

    
    [Test]
    public void NoPuedeAñadirFichaDerecha()
    {
        var tablero = new Tablero();

        tablero.AñadirInicial(new Ficha(2, 1));

        Assert.IsFalse(tablero.PuedeAñadirFichaDerecha(new Ficha(2, 3)));
    }

    

    [Test]
    public void ConectarFichaConCelda()
    {
        Assert.IsTrue(new Ficha(1, 2).Conecta(2));
    }

    [Test]
    public void NoConectarFichaConCelda()
    {
        Assert.IsFalse(new Ficha(1, 2).Conecta(3));
    }
}
