namespace Domino;

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

    public Ficha AlinearDerecha(Celda otra)
    {
        if(n1.Equals(otra))
        {
            return Girada();
        }
        if(n2.Equals(otra))
        {
            return this;
        }
        throw new Exception("No se puede alinear derecha");
    }
    public Ficha AlinearIzquierda(Celda otra)
    {
        if(n2.Equals(otra))
        {
            return Girada();
        }
        if(n1.Equals(otra))
        {
            return this;
        }
        throw new Exception("No se puede alinear izquierda");
    }
    
    public Ficha Girada()
    {
        return new Ficha(n2, n1);
    }
}
