namespace Domino;

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
