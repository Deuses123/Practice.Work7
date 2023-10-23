namespace Library;

public class Frac
{
    private long numerator;
    private long denominator;

    public Frac(long numerator, long denominator)
    {
        if (denominator == 0)
        {
            throw new ArgumentException("Знаменатель не может быть равен нулю.");
        }

        this.numerator = numerator;
        this.denominator = denominator;
        Reduce();
    }

    public Frac(int numerator, int denominator)
        : this((long)numerator, (long)denominator)
    {
    }

    public Frac(int numerator)
        : this(numerator, 1)
    {
    }

    public long Numerator => numerator;
    public long Denominator => denominator;

    public override string ToString()
    {
        return $"{numerator}/{denominator}";
    }

    public override bool Equals(object obj)
    {
        if (!(obj is Frac other))
        {
            return false;
        }

        return numerator == other.numerator && denominator == other.denominator;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(numerator, denominator);
    }

    public static Frac operator +(Frac a, Frac b)
    {
        long num = a.numerator * b.denominator + b.numerator * a.denominator;
        long den = a.denominator * b.denominator;
        return new Frac(num, den);
    }

    public static Frac operator -(Frac a, Frac b)
    {
        long num = a.numerator * b.denominator - b.numerator * a.denominator;
        long den = a.denominator * b.denominator;
        return new Frac(num, den);
    }

    public static Frac operator *(Frac a, Frac b)
    {
        long num = a.numerator * b.numerator;
        long den = a.denominator * b.denominator;
        return new Frac(num, den);
    }

    public static Frac operator /(Frac a, Frac b)
    {
        if (b.numerator == 0)
        {
            throw new DivideByZeroException("Деление на ноль.");
        }

        long num = a.numerator * b.denominator;
        long den = a.denominator * b.numerator;
        return new Frac(num, den);
    }

    public static bool operator ==(Frac a, Frac b)
    {
        return a.Equals(b);
    }

    public static bool operator !=(Frac a, Frac b)
    {
        return !a.Equals(b);
    }

    public static implicit operator double(Frac a)
    {
        return (double)a.numerator / a.denominator;
    }

    private void Reduce()
    {
        long gcd = GCD(Math.Abs(numerator), Math.Abs(denominator));
        numerator /= gcd;
        denominator /= gcd;

        if (denominator < 0)
        {
            numerator = -numerator;
            denominator = -denominator;
        }
    }

    private long GCD(long a, long b)
    {
        while (b != 0)
        {
            long temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }
}
public struct FracStruct
{
    private long numerator;
    private long denominator;

    public FracStruct(long numerator, long denominator)
    {
        if (denominator == 0)
        {
            throw new ArgumentException("Знаменатель не может быть равен нулю.");
        }

        this.numerator = numerator;
        this.denominator = denominator;
        Reduce();
    }

    public FracStruct(int numerator, int denominator)
        : this((long)numerator, (long)denominator)
    {
    }

    public FracStruct(int numerator)
        : this(numerator, 1)
    {
    }

    public long Numerator => numerator;
    public long Denominator => denominator;

    public override string ToString()
    {
        return $"{numerator}/{denominator}";
    }

    public override bool Equals(object obj)
    {
        if (!(obj is FracStruct other))
        {
            return false;
        }

        return numerator == other.numerator && denominator == other.denominator;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(numerator, denominator);
    }

    public static FracStruct operator +(FracStruct a, FracStruct b)
    {
        long num = a.numerator * b.denominator + b.numerator * a.denominator;
        long den = a.denominator * b.denominator;
        return new FracStruct(num, den);
    }

    public static FracStruct operator -(FracStruct a, FracStruct b)
    {
        long num = a.numerator * b.denominator - b.numerator * a.denominator;
        long den = a.denominator * b.denominator;
        return new FracStruct(num, den);
    }

    public static FracStruct operator *(FracStruct a, FracStruct b)
    {
        long num = a.numerator * b.numerator;
        long den = a.denominator * b.denominator;
        return new FracStruct(num, den);
    }

    public static FracStruct operator /(FracStruct a, FracStruct b)
    {
        if (b.numerator == 0)
        {
            throw new DivideByZeroException("Деление на ноль.");
        }

        long num = a.numerator * b.denominator;
        long den = a.denominator * b.numerator;
        return new FracStruct(num, den);
    }

    public static bool operator ==(FracStruct a, FracStruct b)
    {
        return a.Equals(b);
    }

    public static bool operator !=(FracStruct a, FracStruct b)
    {
        return !a.Equals(b);
    }

    public static implicit operator double(FracStruct a)
    {
        return (double)a.numerator / a.denominator;
    }

    private void Reduce()
    {
        long gcd = GCD(Math.Abs(numerator), Math.Abs(denominator));
        numerator /= gcd;
        denominator /= gcd;

        if (denominator < 0)
        {
            numerator = -numerator;
            denominator = -denominator;
        }
    }

    private long GCD(long a, long b)
    {
        while (b != 0)
        {
            long temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }
}
