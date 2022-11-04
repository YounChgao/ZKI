using System;
using static System.Math;
using static System.Console;
using static System.Convert;

namespace ZKI3
{
    class Program
    {
        static void Main(string[] args)
        {
            void task1()
            {
                String alfavit = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"; alfavit.ToCharArray();
                Write("Введите строку: ");
                char[] str = ReadLine().ToCharArray();
                
                for (int i = 0; i < str.Length; i++)
                {
                    str[i] = char.ToUpper(str[i]);
                    for (int j = 0; j < alfavit.Length; j++)
                    {
                        if (str[i] == alfavit[j])
                        {
                            if (j > alfavit.Length - 4)
                            {
                                if (str[i] == 'X')
                                {
                                    str[i] = 'A';
                                }
                                if (str[i] == 'Y')
                                {
                                    str[i] = 'B';
                                }
                                if (str[i] == 'Z')
                                {
                                    str[i] = 'C';
                                }
                                break;
                            }
                            else
                            {
                                str[i] = alfavit[j + 3];
                                break;
                            }
                        }
                    }
                }
                foreach (char c in str)
                {
                    Write(c);
                }
            }
            
            void task2()
            {
                char[,] alfavit =
                {
                    {'И', 'Н', 'Ф', 'О', 'Р', 'М', 'А', 'Ц',},
                    {'И', 'Я', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё',},
                    {'Ж', 'З', 'Й', 'К', 'Л', 'П', 'С', 'Т',},
                    {'У', 'Х', 'Ч', 'Ш', 'Щ', 'Ъ', 'Ы', 'Ь',},
                    {'Э', 'Ю', 'Я', 'А', 'Б', 'В', 'Г', 'Д' }
                };
                Write("Введите строку: ");
                char[] str = ReadLine().ToCharArray();
                for (int sm = 0; sm < str.Length; sm++)
                {
                    str[sm] = char.ToUpper(str[sm]);
                    bool f = true;
                    for (int i = 0; i < alfavit.GetLength(0); i++)
                    {
                        for (int j = 0; j < alfavit.GetLength(1); j++)
                        {
                            if (str[sm] == alfavit[i, j])
                            {
                                if (i == alfavit.GetLength(0) - 1)
                                {
                                    str[sm] = alfavit[0, j];
                                    
                                }
                                else
                                {
                                    str[sm] = alfavit[i + 1, j];
                                }
                                f = false;
                            }
                        }
                        if (f == false)
                        {
                            break;
                        }
                    }
                    Write(str[sm]);
                }
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
