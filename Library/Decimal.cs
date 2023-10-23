using System.Text;

namespace Library;

using System;
using System.Linq;

public class Decimal
{
    private char[] _digits = new char[100]; // Массив для хранения десятичных цифр
    
    public Decimal(string value)
    {
        if (value.Length > 100)
            throw new ArgumentOutOfRangeException("Value is too large.");

      
        // Заполнение массива десятичными цифрами
        int startIndex = 100 - value.Length;
        for (int i = 0; i < value.Length; i++)
        {
            _digits[startIndex + i] = value[i];
        }
    }
    //Сравенения 
    public static bool operator <(Decimal left, Decimal right)
    {
        return string.CompareOrdinal(left.ToString(), right.ToString()) < 0;
    }

    public static bool operator >(Decimal left, Decimal right)
    {
        return string.CompareOrdinal(left.ToString(), right.ToString()) > 0;
    }

    public static bool operator <=(Decimal left, Decimal right)
    {
        return string.CompareOrdinal(left.ToString(), right.ToString()) <= 0;
    }

    public static bool operator >=(Decimal left, Decimal right)
    {
        return string.CompareOrdinal(left.ToString(), right.ToString()) >= 0;
    }
    
    //Сложение, вычитание, умножение и деление
    
    public static Decimal operator +(Decimal n1, Decimal n2) {
        int carry = 0;
        List<int> result = new List<int>();
        
        var n1Arr = n1._digits
            .Where(c => c >= '0' && c <= '9')
            .Select(c => (int)(c - '0')) 
            .ToArray();
        
        var n2Arr = n2._digits
            .Where(c => c >= '0' && c <= '9')
            .Select(c => (int)(c - '0'))
            .ToArray();
        
        int i = n1Arr.Length - 1;
        int j = n2Arr.Length - 1;

            
        while (i >= 0 || j >= 0 || carry > 0) {
            int digit1 = (i >= 0) ? n1Arr[i] : 0;
            int digit2 = (j >= 0) ? n2Arr[j] : 0;
            int sum = digit1 + digit2 + carry;
            carry = sum / 10;
            result.Add(sum % 10);
            i--;
            j--;
        }

        string r = "";
        result.ForEach(x => r+=x);
        
        
        // Создание объекта Decimal из массива чисел
        return new Decimal(new string(r.Reverse().ToArray()));
    }

    public static Decimal operator -(Decimal left, Decimal right)
    {
        char[] result = new char[100];
        char borrow = '0';

        for (int i = 99; i >= 0; i--)
        {
            int diff = left._digits[i] - '0' - (right._digits[i] - '0') - (borrow - '0');
            if (diff < 0)
            {
                diff += 10;
                borrow = '1';
            }
            else
            {
                borrow = '0';
            }
            result[i] = (char)(diff + '0');
        }

        return new Decimal(new string(result));
    }
    
    
    public static Decimal operator *(Decimal d1, Decimal d2)
    {
        int[] a = d1._digits.Where(i => i is >= '0' and <= '9').Select(c => c - '0').ToArray();
        int[] b = d2._digits.Where(i => i is >= '0' and <= '9').Select(c => c - '0').ToArray();
        
        int[] c = new int[a.Length + b.Length];
        for (int k = 0; k < c.Length; k++)
        {
            int sum = 0;
            for (int i = 0; i < a.Length; i++)
            {
                int j = k - i;
                if (j >= 0 && j < b.Length)
                    sum += a[i] * b[j];
            }
            c[k] = sum;
        }
        for (int k = 0; k < c.Length - 1; k++)
        {
            int p = c[k] % 10;
            int q = c[k] / 10;
            c[k] = p;
            c[k + 1] += q;
        }

        string g = c.Where(i => i is >= 0 and < 10).Aggregate("", (current, i) => current + i);

        return new Decimal(g);
    }

    
    //Нулевое значение
    public bool IsZero()
    {
        return _digits.All(digit => digit == '0');
    }
    public override string ToString()
    {
        int startIndex = System.Array.FindIndex(_digits, digit => digit != '0');
        if (startIndex == -1)
            return "0";

        return new string(_digits, startIndex, 100 - startIndex);
    }
    
    
    
    
    //Побочные методы



public static Decimal operator/(Decimal di, Decimal divis)
{
    string dividend = new string(di._digits);
    string divisor = new string(divis._digits);

    int maxLength = Math.Max(dividend.Length, divisor.Length);
    int position = 0;

    StringBuilder quotient = new StringBuilder();
    StringBuilder currentDividend = new StringBuilder();

    while (position < maxLength)
    {
        if (position < dividend.Length)
        {
            currentDividend.Append(dividend[position]);
        }
        else
        {
            currentDividend.Append('0');
        }

        bool divisionPerformed = false;
        int digit = 0;

        while (CompareStrings(currentDividend.ToString(), divisor) >= 0)
        {
            currentDividend = SubtractStrings(currentDividend.ToString(), divisor);
            digit++;
            divisionPerformed = true;
        }

        if (divisionPerformed || position < dividend.Length)
        {
            quotient.Append(digit);
        }

        position++;
    }

    return new Decimal(quotient.ToString());
}

static int CompareStrings(string str1, string str2)
{
    if (str1.Length > str2.Length)
    {
        return 1;
    }
    if (str1.Length < str2.Length)
    {
        return -1;
    }
    return string.CompareOrdinal(str1, str2);
}

static StringBuilder SubtractStrings(string minuend, string subtrahend)
{
    StringBuilder result = new StringBuilder();
    int borrow = 0;

    for (int i = minuend.Length - 1; i >= 0; i--)
    {
        int minuendDigit = minuend[i] - '0';
        int subtrahendDigit = i >= minuend.Length - subtrahend.Length ? subtrahend[i - (minuend.Length - subtrahend.Length)] - '0' : 0;
        int difference = minuendDigit - subtrahendDigit - borrow;

        if (difference < 0)
        {
            difference += 10;
            borrow = 1;
        }
        else
        {
            borrow = 0;
        }

        result.Insert(0, difference);
    }

    while (result.Length > 1 && result[0] == '0')
    {
        result.Remove(0, 1);
    }

    return result;
}

}