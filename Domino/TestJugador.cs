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
        var jugador = new Jugador(tablero, new Pila(new MezcladorTest()));
        
        Assert.AreEqual(jugador.Mano.Count, 7);
    }

    [Test]
    public void JugadorAñadeFichaTablero()
    {
        var tablero = new Tablero();
        var jugador = new Jugador(tablero, new Pila(new MezcladorTest()));

        jugador.IntentarJugarFicha(0);
        
        Assert.AreEqual(tablero.Fichas.Count, 1);
    }
    
    [Test]
    public void JugadorAñadeFichaTableroConectaDerecha()
    {
        var tablero = new Tablero();
        var jugador = new Jugador(tablero, new Pila(new MezcladorTest()));
        tablero.AñadirInicial(new Ficha(0,0));

        jugador.JugarFichaDerecha(0);
        
        Assert.AreEqual(tablero.Fichas.Count, 2);
    }
    
    [Test]
    public void JugadorAñadeFichaTableroConectaIzquierda()
    {
        var tablero = new Tablero();
        var jugador = new Jugador(tablero, new Pila(new MezcladorTest()));
        tablero.AñadirInicial(new Ficha(0,0));

        jugador.JugarFichaIzquierda(0);
        
        Assert.AreEqual(tablero.Fichas.Count, 2);
    }
    
    [Test]
    public void GenerarPila()
    {
        var pila = new Pila(new MezcladorTest());
        
        Assert.AreEqual(pila.FichasRestantes, 28);
    }
    
    [Test]
    public void RobarDeLaPila()
    {
        var pila = new Pila(new MezcladorTest());

        pila.Robar();
        
        Assert.AreEqual(pila.FichasRestantes, 27);
    }

    [Test]
    public void JugadorPuedeRobar()
    {
        var tablero = new Tablero();
        var pila = new Pila(new MezcladorTest());
        var jugador = new Jugador(tablero, pila);

        var numeroInicialJugador = jugador.Mano.Count;
        var numeroInicialPila = pila.FichasRestantes;
        
        jugador.IntentarRobar();
        
        Assert.AreEqual(numeroInicialJugador + 1,jugador.Mano.Count);
        Assert.AreEqual(numeroInicialPila - 1, pila.FichasRestantes);
    }

    [Test]
    public void JugadorIntentaRobarDePilaVacia()
    {
        var tablero = new Tablero();
        var pila = new Pila(new MezcladorTest());
        var jugador = new Jugador(tablero, pila);

        for (int i = 0; i < 300; i++)
        {
            jugador.IntentarRobar();
        }
        
        Assert.AreEqual(28, jugador.Mano.Count);
    }
    
    [Test]
    public void JugadorIntentaJugarFichaIncorrecta()
    {
        var tablero = new Tablero();
        var jugador = new Jugador(tablero, new Pila(new MezcladorTest()));

        tablero.AñadirInicial(new Ficha(6,6));
        jugador.IntentarJugarFicha(0);

        Assert.AreEqual(tablero.Fichas.Count, 1);
    }
    
}