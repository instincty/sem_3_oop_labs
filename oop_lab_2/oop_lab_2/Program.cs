using System;

class VolumeCalculation
{
    public double rectVol(double a, double b, double c)
    {
        return a * b * c;
    }
    public double pyramidVol(double pbase, double height)
    {
        return pbase * height * (1.0 / 3);
    }
    public double sphereVolR(double radius)
    {
        return (4.0 / 3) * Math.PI * radius * radius * radius;
    }
}

class Program
{
    static void Main()
    {
        char fType;
        VolumeCalculation vol = new VolumeCalculation();
        Console.Write("Choose a figure (r - rectangle, p - pyramid, s - sphere): ");
        fType = char.ToUpper(Console.ReadLine()[0]);
        switch (fType)
        {
            case 'R':
                double a, b, c;
                Console.WriteLine("Enter a, b, c:");
                a = double.Parse(Console.ReadLine());
                b = double.Parse(Console.ReadLine());
                c = double.Parse(Console.ReadLine());
                Console.WriteLine("Rectangle volume = " + vol.rectVol(a, b, c));
                break;
            case 'P':
                double pbase, height;
                Console.WriteLine("Enter base, height:");
                pbase = double.Parse(Console.ReadLine());
                height = double.Parse(Console.ReadLine());
                Console.WriteLine("Pyramid volume = " + vol.pyramidVol(pbase, height));
                break;
            case 'S':
                double r;
                Console.WriteLine("Enter radius:");
                r = double.Parse(Console.ReadLine());
                Console.WriteLine("Sphere volume = " + vol.sphereVolR(r));
                break;
            default:
                Console.WriteLine("Wrong input!");
                break;
        }
        Console.ReadLine();
    }
}