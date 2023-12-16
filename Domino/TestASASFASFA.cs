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
        var tablero = new Tablero();
        var jugador = new Jugador(tablero);
        
        Assert.AreEqual(jugador.Mano.Count, 7);
    }

    [Test]
    public void JugadorAñadeFichaTablero()
    {
        var tablero = new Tablero();
        var jugador = new Jugador(tablero);

        jugador.JugarFicha(0);
        
        Assert.AreEqual(tablero.Fichas.Count, 1);
    }
    
    // [Test]
    // public void GenerarFichas()
    // {
    //     var fichas = new List<Ficha>();
    //     for (int i = 0; i < 7; i++)
    //     {
    //         for (int j = i; j < 7; j++)
    //         {
    //             fichas.Add(new Ficha(i, j));
    //         }
    //     }
    // }
}