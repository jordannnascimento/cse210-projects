using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create a list that holds any kind of Shape.
        List<Shape> shapes = new List<Shape>();

        // Add one of each shape.
        shapes.Add(new Square("Red", 5));
        shapes.Add(new Rectangle("Blue", 4, 6));
        shapes.Add(new Circle("Green", 3));

        // Go through the list and show each shape's color and area.
        // Even though they are all "Shape", each one runs its own
        // GetArea() because of polymorphism.
        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"Color: {shape.GetColor()} - Area: {shape.GetArea()}");
        }
    }
}