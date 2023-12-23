namespace Domino;

// Reglas domino
// https://es.wikipedia.org/wiki/Domin%C3%B3
// Tablero 
// El juego tiene 28 fichas
// Cada jugador empieza con 7 fichas
// Gana el jugador que se quede sin fichas.
// Si no puedes colocar ficha robas una del montón.
// Si no hay fichas en el montón se pasa el turno.

public class TestJugador
{
    [Test]
    public void JugadorFichasIniciales()
    {
        var tablero = new Tablero();
        var jugador = new Jugador(tablero, new Pila());
        
        Assert.AreEqual(jugador.Mano.Count, 7);
    }

    [Test]
    public void JugadorAñadeFichaTablero()
    {
        var tablero = new Tablero();
        var jugador = new Jugador(tablero, new Pila());

        jugador.JugarFicha(0);
        
        Assert.AreEqual(tablero.Fichas.Count, 1);
    }
    
    [Test]
    public void JugadorAñadeFichaTableroConectaDerecha()
    {
        var tablero = new Tablero();
        var jugador = new Jugador(tablero, new Pila());
        tablero.AñadirInicial(new Ficha(1, 2));

        jugador.JugarFichaDerecha(0);
        
        Assert.AreEqual(tablero.Fichas.Count, 2);
    }
    
    [Test]
    public void JugadorAñadeFichaTableroConectaIzquierda()
    {
        var tablero = new Tablero();
        var jugador = new Jugador(tablero, new Pila());
        tablero.AñadirInicial(new Ficha(2, 1));

        jugador.JugarFichaIzquierda(0);
        
        Assert.AreEqual(tablero.Fichas.Count, 2);
    }
    
    [Test]
    public void GenerarPila()
    {
        var pila = new Pila();
        
        Assert.AreEqual(pila.FichasRestantes, 28);
    }
    
    [Test]
    public void RobarDeLaPila()
    {
        var pila = new Pila();

        pila.Robar();
        
        Assert.AreEqual(pila.FichasRestantes, 27);
    }

    [Test]
    public void JugadorPuedeRobar()
    {
        var tablero = new Tablero();
        var jugador = new Jugador(tablero, new Pila());

        // jugador.Robar();
        // Assert.AreEqual(jugador.Mano.Count, 6);
        // Assert.AreEqual(pila.FichasRestantes, 27);
    }
}