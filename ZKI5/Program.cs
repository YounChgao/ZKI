using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

class Program
{
    static void Main(string[] args)
    {
        Example1();
        WriteLine();
        Example2();
    }

    static void Example1()
    {
        string alph = "abcdefghijklmnopqrstuvwxyz";
        string text = "hello";
        string key = "xmckl";

        var pad = new OnTimePad(alph);
        string encrypt = pad.Crypt1(text, key, true);
        string decrypt = pad.Crypt1(encrypt, key, false);

        WriteLine("Оригинал: ");
        WriteLine("Шифротекст: " + encrypt);
        WriteLine("Расшифровка: " + decrypt);
    }

    static void Example2()
    {
        string alph = "абвгдежзийклмнопрстуфхцчшыьэюя ."; // нет букв ё ъ щ
        string text = "мама мыла раму.";
        string key = "кофе";

        var pad = new OnTimePad(alph);
        string encrypt = pad.Crypt2(text, key);
        string decrypt = pad.Crypt2(encrypt, key);

        WriteLine("Оригинал: ");
        WriteLine("Шифротекст: " + encrypt);
        WriteLine("Расшифровка: " + decrypt);
    }
}

class OnTimePad
{
    Dictionary<char, int> alph = new Dictionary<char, int>();
    Dictionary<int, char> alph_r = new Dictionary<int, char>();

    public OnTimePad(IEnumerable<char> Alphabet)
    {
        int i = 0;
        foreach (char c in Alphabet)
        {
            alph.Add(c, i);
            alph_r.Add(i++, c);
        }
    }
    public string Crypt1(string Text, string Key, bool Crypt)
    {
        char[] key = Key.ToCharArray();
        char[] text = Text.ToCharArray();
        var sb = new StringBuilder();

        for (int i = 0; i < text.Length; i++)
        {
            int idx;
            if (alph.TryGetValue(text[i], out idx))
            {
                int r = alph.Count + idx;
                r += (Crypt ? 1 : -1) * alph[key[i % key.Length]];
                sb.Append(alph_r[r % alph.Count]);
            }
        }

        return sb.ToString();
    }
    public string Crypt2(string Text, string Key)
    {
        char[] key = Key.ToCharArray();
        char[] text = Text.ToCharArray();
        var sb = new StringBuilder();

        for (int i = 0; i < text.Length; i++)
        {
            int ind;
            if (alph.TryGetValue(text[i], out ind))
            {
                sb.Append(alph_r[(ind ^ alph[key[i % key.Length]]) % alph.Count]);
            }
        }
        return sb.ToString();
    }
}