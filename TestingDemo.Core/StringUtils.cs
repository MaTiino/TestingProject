namespace TestingDemo.Core;

public static class StringUtils
{
    public const int MaxInputLength = 1000;
    public const int MaxOutputLength = 100;

    public static bool CzyPalindrom(string tekst)
    {
        if (tekst == null) return false;
        var odwr = new string(tekst.Reverse().ToArray());
        return tekst == odwr;
    }

    public static int PoliczSamogloski(string tekst)
    {
        if (string.IsNullOrEmpty(tekst))
            return 0;

        char[] samogloski = { 'a', 'e', 'i', 'o', 'u', 'y', 'ą', 'ę', 'ó', 'A', 'E', 'I', 'O', 'U', 'Y', 'Ą', 'Ę', 'Ó' };
        return tekst.Count(c => samogloski.Contains(c));
    }

    public static string OdwrocTekst(string tekst)
    {
        if (string.IsNullOrEmpty(tekst))
            return string.Empty;

        if (tekst.Length > MaxInputLength)
            throw new ArgumentException($"Tekst nie może być dłuższy niż {MaxInputLength} znaków.");

        var result = new string(tekst.Reverse().ToArray());
        if (result.Length > MaxOutputLength)
        {
            result = result.Substring(0, MaxOutputLength - 3) + "...";
        }
        return result;
    }

    public static int PoliczSlowa(string tekst)
    {
        if (string.IsNullOrEmpty(tekst))
            return 0;

        if (tekst.Length > MaxInputLength)
            throw new ArgumentException($"Tekst nie może być dłuższy niż {MaxInputLength} znaków.");

        return tekst.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length;
    }

    public static int PoliczZnaki(string tekst)
    {
        if (string.IsNullOrEmpty(tekst))
            return 0;

        if (tekst.Length > MaxInputLength)
            throw new ArgumentException($"Tekst nie może być dłuższy niż {MaxInputLength} znaków.");

        return tekst.Length;
    }
} 