namespace Domino;

public class Pila
{
    private List<Ficha> fichas;

    public Pila()
    {
        fichas = new List<Ficha>();
        for (int i = 0; i < 7; i++)
        {
            for (int j = i; j < 7; j++)
            {
                fichas.Add(new Ficha(i, j));
            }
        }
    }

}