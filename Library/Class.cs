namespace Library;

public class Class
{
    private string Template1 { get; set; }
    private string Template2 { get; set; }

    public Class(string template1, string template2)
    {
        Template1 = template1;
        Template2 = template2;
    }

    public static bool operator ==(Class? o1, Class? o2)
    {
        if (ReferenceEquals(o1, o2)) return true;
        if (o1 is null || o2 is null) return false;
        return o1.Template1 == o2.Template1 && o1.Template2 == o2.Template2;
    }
    
    public static bool operator !=(Class obj1, Class obj2)
    {
        return !(obj1 == obj2);
    }
    
    
    
    public override bool Equals(object? obj)
    {
        if (obj is Class a) return this == a;
        return false;
    }
    
    public override int GetHashCode()
    {
        return HashCode.Combine(Template1, Template2);
    }
}