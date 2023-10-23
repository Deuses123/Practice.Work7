namespace Library;

public struct ComplexStruct
{
    public double Real { get; }
    public double Imaginary { get; }

    public ComplexStruct(double real, double imaginary)
    {
        Real = real;
        Imaginary = imaginary;
    }

    public static ComplexStruct FromDouble(double real)
    {
        return new ComplexStruct(real, 0);
    }

    public override string ToString()
    {
        return $"{Real} + {Imaginary}i";
    }

    public override bool Equals(object obj)
    {
        if (!(obj is ComplexStruct))
        {
            return false;
        }

        ComplexStruct other = (ComplexStruct)obj;
        return Real == other.Real && Imaginary == other.Imaginary;
    }

    public override int GetHashCode()
    {
        return Real.GetHashCode() ^ Imaginary.GetHashCode();
    }

    public static bool operator ==(ComplexStruct a, ComplexStruct b)
    {
        return a.Equals(b);
    }

    public static bool operator !=(ComplexStruct a, ComplexStruct b)
    {
        return !a.Equals(b);
    }

    public static ComplexStruct operator +(ComplexStruct a, ComplexStruct b)
    {
        return new ComplexStruct(a.Real + b.Real, a.Imaginary + b.Imaginary);
    }

    public static ComplexStruct operator -(ComplexStruct a, ComplexStruct b)
    {
        return new ComplexStruct(a.Real - b.Real, a.Imaginary - b.Imaginary);
    }

    public static ComplexStruct operator *(ComplexStruct a, ComplexStruct b)
    {
        double real = (a.Real * b.Real) - (a.Imaginary * b.Imaginary);
        double imaginary = (a.Real * b.Imaginary) + (a.Imaginary * b.Real);
        return new ComplexStruct(real, imaginary);
    }

    public static ComplexStruct operator /(ComplexStruct a, ComplexStruct b)
    {
        double denominator = (b.Real * b.Real) + (b.Imaginary * b.Imaginary);
        double real = ((a.Real * b.Real) + (a.Imaginary * b.Imaginary)) / denominator;
        double imaginary = ((a.Imaginary * b.Real) - (a.Real * b.Imaginary)) / denominator;
        return new ComplexStruct(real, imaginary);
    }
}
public class ComplexClass
{
    public double Real { get; set; }
    public double Imaginary { get; set; }

    public ComplexClass (double real, double imaginary)
    {
        Real = real;
        Imaginary = imaginary;
    }

    public static ComplexClass FromDouble(double real)
    {
        return new ComplexClass(real, 0);
    }

    public override string ToString()
    {
        if (Imaginary >= 0)
        {
            return $"{Real} + {Imaginary}i";
        }
        else
        {
            return $"{Real} - {Math.Abs(Imaginary)}i";
        }
    }

    public override bool Equals(object obj)
    {
        if (!(obj is ComplexClass))
        {
            return false;
        }

        ComplexClass other = (ComplexClass)obj;
        return Real == other.Real && Imaginary == other.Imaginary;
    }

    public override int GetHashCode()
    {
        return Real.GetHashCode() ^ Imaginary.GetHashCode();
    }

    public static bool operator ==(ComplexClass a, ComplexClass b)
    {
        return a.Equals(b);
    }

    public static bool operator !=(ComplexClass a, ComplexClass b)
    {
        return !a.Equals(b);
    }

    public static ComplexClass operator +(ComplexClass a, ComplexClass b)
    {
        return new ComplexClass(a.Real + b.Real, a.Imaginary + b.Imaginary);
    }

    public static ComplexClass operator -(ComplexClass a, ComplexClass b)
    {
        return new ComplexClass(a.Real - b.Real, a.Imaginary - b.Imaginary);
    }

    public static ComplexClass operator *(ComplexClass a, ComplexClass b)
    {
        double real = (a.Real * b.Real) - (a.Imaginary * b.Imaginary);
        double imaginary = (a.Real * b.Imaginary) + (a.Imaginary * b.Real);
        return new ComplexClass(real, imaginary);
    }

    public static ComplexClass operator /(ComplexClass a, ComplexClass b)
    {
        double denominator = (b.Real * b.Real) + (b.Imaginary * b.Imaginary);
        double real = ((a.Real * b.Real) + (a.Imaginary * b.Imaginary)) / denominator;
        double imaginary = ((a.Imaginary * b.Real) - (a.Real * b.Imaginary)) / denominator;
        return new ComplexClass(real, imaginary);
    }
}