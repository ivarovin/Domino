namespace Domino;

public interface Mezclador
{
    List<Ficha> Mezclar(List<Ficha> fichas);
}

public class MezcladorTest : Mezclador
{
    public List<Ficha> Mezclar(List<Ficha> fichas)
    {
        return fichas;
    }
}

public class Pila
{
    private List<Ficha> fichas;

    public int FichasRestantes => fichas.Count;

    public Pila(Mezclador mezclador)
    {
        fichas = new List<Ficha>();
        for (int i = 0; i < 7; i++)
        {
            for (int j = i; j < 7; j++)
            {
                fichas.Add(new Ficha(i, j));
            }
        }

        fichas = mezclador.Mezclar(fichas);
    }

    public Ficha Robar()
    {
        if (FichasRestantes == 0)
        {
            throw new Exception("No hay fichas para robar");
        }

        var ficha = fichas[0];
        fichas.Remove(ficha);

        return ficha;
    }

}