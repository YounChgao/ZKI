using System;
using static System.Math;
using static System.Console;
using static System.Convert;

namespace ZKI4
{
    class Program
    {
        static void Main(string[] args)
        {
            void task1()
            {
                char[,] tabl = new char[32, 32];
                char[] arr = { 'з', 'у', 'ш', 'в', 'ь', 'я', 'ж', 'щ', 'к', 'г', 'л', 'ф', 'м', 'д', 'п', 'ъ', 'ы', 'н', 'ю', 'о', 'с', 'и', 'й', 'т', 'ч', 'б', 'а', 'э', 'х', 'ц', 'е', 'р' };
                for (int i = 0; i < tabl.GetLength(0); i++)
                {
                    for (int j = 0; j < tabl.GetLength(1); j++)
                    {
                        tabl[i, j] = arr[j];
                    }
                    char last = arr[0];
                    for (int j = 0; j < arr.Length - 1; j++)
                    {
                        arr[j] = arr[j + 1];
                    }
                    arr[arr.Length - 1] = last;
                }

                char[] arr1 = { 'а', 'б', 'в', 'г', 'д', 'е', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я' };
                arr = arr1;
                Write("Введите предложение: "); char[] str = ReadLine().ToCharArray();
                Write("Введите ключевое слово: "); char[] key = ReadLine().ToCharArray(); int c = 0;
                char[] shifr = new char[str.Length];
                for (int q = 0; q < str.Length; q++)
                {
                    if (c >= key.Length)
                    {
                        c = 0;
                    }
                    int index_i = 0, index_j = 0;
                    if (str[q] == ' ')
                    {
                        shifr[q] = ' ';
                        continue;
                    }
                    for (int i = 0; i < arr.Length; i++)
                    {
                        if (str[q] == arr[i])
                        {
                            index_i = i;
                            break;
                        }
                    }
                    for (int j = 0; j < arr.Length; j++)
                    {
                        if (key[c] == arr[j])
                        {
                            index_j = j;
                            break;
                        }
                    }
                    shifr[q] = tabl[index_i, index_j];
                    c++;
                }
                Write(shifr);
            }

            void task2()
            {
                char[] arr1 = { 'а', 'б', 'в', 'г', 'д', 'е', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я' };
                Write("Введите предложение: "); char[] str = ReadLine().ToCharArray();
                char[,] tabl1 =
                {
                    {'ч','в','ы','п','о','к' },
                    {':','д','у','г','ш','з' },
                    {'э','ф','л','ъ','_','х' },
                    {'а','.','ю','р','ж','щ' },
                    {'н','ц','б','и','т','ь' },
                    {'.','с','я','м','е','й' }
                };
                char[,] tabl2 =
                {
                    {'е','л','ц',':','п','.' },
                    {'х','ъ','а','н','ш','д' },
                    {'й','э','к','с','ы','б' },
                    {'_','ф','у','я','т','и' },
                    {'ч','г','н','о','.','ж' },
                    {'ь','в','щ','з','ю','р' }
                };

                for (int q = 0; q < str.Length; q += 2)
                {
                    if (str[q] == ' ')
                    {
                        q++;
                    }
                    int index_i = 0, index_j = 0;
                    int index_i2 = 0, index_j2 = 0;
                    bool f1 = true, f2 = true;
                    for (int i = 0; i < tabl1.GetLength(0); i++)
                    {
                        if (f1 == false)
                        {
                            break;
                        }
                        for (int j = 0; j < tabl1.GetLength(1); j++)
                        {
                            if (str[q] == tabl1[i, j])
                            {
                                index_i = i;
                                index_j = j;
                                f1 = false;
                                break;
                            }
                        }
                    }
                    for (int i = 0; i < tabl2.GetLength(0); i++)
                    {
                        if (f2 == false)
                        {
                            break;
                        }
                        for (int j = 0; j < tabl2.GetLength(1); j++)
                        {
                            if (str[q + 1] == tabl2[i, j])
                            {
                                index_i2 = i;
                                index_j2 = j;
                                f2 = false;
                                break;
                            }
                        }
                    }
                    if (index_i == index_i2)
                    {
                        str[q + 1] = tabl1[index_i2, index_j - 1];
                        str[q] = tabl2[index_i, index_j2 + 1];
                    }
                    else
                    {
                        str[q] = tabl1[index_i2, index_j];
                        str[q + 1] = tabl2[index_i, index_j2];
                    }
                }
                Write(str);
            }

            bool menu = true;
            while (menu)
            {
                try
                {
                    Write("1\n 2\nВыберите номер задания (0 для выхода из программы): ");
                    int sw = ToInt32(ReadLine());
                    switch (sw)
                    {
                        case 0:
                            {
                                menu = false;
                                break;
                            }
                        case 1:
                            {
                                try
                                {
                                    task1();
                                }
                                catch
                                {
                                    WriteLine("Ошибка ввода_1");
                                }
                                break;
                            }
                        case 2:
                            {
                                try
                                {
                                    task2();
                                }
                                catch
                                {
                                    WriteLine("Ошибка ввода_2");
                                }
                                break;
                            }
                    }
                    WriteLine();
                    WriteLine();
                }
                catch
                {
                    WriteLine("Ошибка");
                }
            }
        }
    }
}
