// Base class for every shape.
// All shapes have a color and a method to get the area.
public class Shape
{
    private string _color;

    public Shape(string color)
    {
        _color = color;
    }

    public string GetColor()
    {
        return _color;
    }

    public void SetColor(string color)
    {
        _color = color;
    }

    // Virtual method. Each shape will override this with its own formula.
    public virtual double GetArea()
    {
        return 0;
    }
}