namespace Library;

public class Array
{
    public int[] array { get; set; }
    public Array(int[] elements)
    {
        array = elements;
    }
    public int this[int index]
    {
        get
        {
            if (index >= 0 && index < array.Length)
            {
                return array[index];
            }
            throw new IndexOutOfRangeException("Индекс вышел из границы.");
        }
    }
    public static bool operator <(Array left, Array right)
    {
        int sumLeft = left.array.Sum();
        int sumRight = right.array.Sum();
        return sumLeft < sumRight;
    }
    public static bool operator >(Array left, Array right)
    {
        int sumLeft = left.array.Sum();
        int sumRight = right.array.Sum();
        return sumLeft > sumRight;
    }
    public static Array operator *(Array array1, Array array2)
    {
        if (array1.array.Length != array2.array.Length)
        {
            throw new ArgumentException("Разные рамзеры массивов");
        }

        int[] result = new int[array1.array.Length];
        for (int i = 0; i < array1.array.Length; i++)
        {
            result[i] = array1.array[i] * array2.array[i];
        }

        return new Array(result);
    }
    public static explicit operator int(Array array)
    {
        return array.array.Length;
    }
    public static Array operator +(Array array1, Array array2)
    {
        var resultArray = new int[array1.array.Length + array2.array.Length];
        System.Array.Copy(array1.array, resultArray, array1.array.Length);
        System.Array.Copy(array2.array, 0, resultArray, array1.array.Length, array2.array.Length);
        return new Array(resultArray);
    }
    public static bool operator ==(Array? array1, Array? array2)
    {
        if (ReferenceEquals(array1, array2))
            return true;

        if (array1 is null || array2 is null)
            return false;

        return array1.array.Length == array2.array.Length && array1.array.SequenceEqual(array2.array);
    }
    public static bool operator !=(Array array1, Array array2)
    {
        return !(array1 == array2);
    }
    public static bool operator <=(Array array1, Array array2)
    {
        return array1.array.Length <= array2.array.Length;
    }
    public static bool operator >=(Array array1, Array array2)
    {
        return array1.array.Length >= array2.array.Length;
    }

    public override string ToString()
    {
        return string.Join(" ", array);
    }
}