namespace Domino;

// Reglas domino
// https://es.wikipedia.org/wiki/Domin%C3%B3
// Tablero 
// El juego tiene 28 fichas
// Cada jugador empieza con 7 fichas
// Gana el jugador que se quede sin fichas.
// Si no puedes colocar ficha robas una del montón.
// Si no hay fichas en el montón se pasa el turno.

public class TestASASFASFA
{
    [Test]
    public void JugadorFichasIniciales()
    {
        var jugador = new Jugador();
        
        Assert.AreEqual(jugador.Mano.Count, 7);
    }

    public class Jugador
    {
        public List<Ficha> Mano = new();
    }
    
    
}