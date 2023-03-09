using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.Collections;

namespace Cs_Tovar_hw_6_2
{
    class Program
    {
        delegate void CommandHandler();
        static void Main(string[] args)
        {
            Title = "Tovar";
            Random rand = new Random();
            Provider_1 pr = new Provider_1();
            My_store ms = new My_store();
            My_store ms1 = new My_store();
            foreach (Tovar item in pr)
            {
                item.Quantity = rand.Next(10,2000);
                Tovar tmp = (Tovar)item.Clone();
                tmp.Quantity = 0;
                ms.tovars.Add(tmp);
            }
            int index = 0;

            WriteLine(@"    Стрелками наверх и вниз передвигаетесь по списку,
    Стрелка налево  - уменьшаете количество на 1
    Стрелка направо - добавляете количество на 1
    Пробел - ввести количество вручную
    Enter  - оформить заказ и выйти из программы
    Escape - выйти

                Нажмите Enter чтобы продолжить");
            ReadLine();           
            while (true)
            {
                Clear();
                WriteLine($"Заказ:");
                Tovar.Show_h();
                pr.Sort(new Class_name());
                ms.Sort(new Class_name());
                Menu(ms.tovars, index);

                WriteLine($"Итого: {Tovar.Sum(ms.tovars)} рублей");
                WriteLine();
                WriteLine($"------------------------------------------------------------------");
                WriteLine($"Поставщик:");
                Tovar.Show_h();                
                foreach (Tovar item in pr)
                    {
                        Write($"{item}");
                    if (item is Milk) 
                    {
                        (item as Milk).ShowMilk();
                    }
                    else if (item is Air_fresh)
                    {
                        (item as Air_fresh).ShowAir();
                    }
                    else WriteLine();
                }
                WriteLine($"------------------------------------------------------------------");
                try
                {
                    switch (ReadKey(true).Key)
                    {
                        case ConsoleKey.DownArrow:
                            if (index < pr.tovars.Count - 1)
                                index++;
                            break;
                        case ConsoleKey.UpArrow:
                            if (index > 0)
                                index--;
                            break;
                        case ConsoleKey.Enter:
                            {
                                Clear();
                                WriteLine($"Заказ оформлен:");
                                foreach (Tovar item in ms)
                                {
                                    if (item.Quantity > 0)
                                    {
                                        Tovar tmp = (Tovar)item.Clone();
                                        ms1.tovars.Add(tmp);
                                    }
                                }
                                Tovar.Show_h();
                                ms.Sort(new Class_name());
                                foreach (Tovar item in ms1)
                                {
                                    Write($"{item}");
                                    if (item is Milk)
                                    {
                                        (item as Milk).ShowMilk();
                                    }
                                    else if (item is Air_fresh)
                                    {
                                        (item as Air_fresh).ShowAir();
                                    }
                                    else WriteLine();
                                }
                                WriteLine($"------------------------------------------------------------------");
                                Tovar.Sum(ms1.tovars);
                                if (!ms1.tovars.Any()) throw new MyEx1();
                                WriteLine($"Итого: {Tovar.Sum(ms.tovars)} рублей");
                                WriteLine();
                                WriteLine($"{DateTime.Now.ToShortDateString()}");
                                ReadLine();
                                Environment.Exit(0);
                            }
                            break;
                        case ConsoleKey.Escape:
                            {
                                Environment.Exit(0);
                            }
                            break;
                        case ConsoleKey.RightArrow:
                            {
                                if (ms.tovars.Any() && pr.tovars[index].Quantity > 0)
                                {
                                    pr.tovars[index].Quantity--;
                                    ms.tovars[index].Quantity++;
                                }
                                else break;
                            }
                            break;
                        case ConsoleKey.LeftArrow:
                            {
                                if (ms.tovars[index].Quantity > 0)
                                {
                                    pr.tovars[index].Quantity++;
                                    ms.tovars[index].Quantity--;
                                }
                                else WriteLine($"error");
                            }
                            break;
                        case ConsoleKey.Spacebar:
                            {
                                Clear();
                                Tovar.Show_h();
                                WriteLine($"{ pr.tovars[index]}");
                                Write("Введите количество: "); int Itmp = int.Parse(ReadLine());
                                if (Itmp > 0 && pr.tovars[index].Quantity >= Itmp)
                                {
                                    pr.tovars[index].Quantity -= Itmp;
                                    ms.tovars[index].Quantity += Itmp;
                                }
                                else throw new MyEx2();
                            }
                            break;

                        default:
                            break;
                    }
                }
                catch (MyEx1 ex)
                {
                    WriteLine($"            {ex.Message}");
                    ReadLine();
                }
                catch (MyEx2 ex)
                {
                    WriteLine($"            {ex.Message}");
                    ReadLine();
                }
                catch (Exception ex)
                {
                    WriteLine($"{ex.Message}");
                }                
            }            
        }
        private static void Menu(List<Tovar>st,int _index)
        {
            for (int i = 0; i < st.Count; i++)
            {
                if (i==_index)
                {
                    BackgroundColor = ForegroundColor;
                    ForegroundColor = ConsoleColor.Black;
                }
                WriteLine(st[i]);
                ResetColor();
            }
            WriteLine();
        }

        public class MyEx1 : ApplicationException
        {
            public DateTime TimeException { get; private set; }
            public MyEx1() : base("Выберите хотябы один товар, чтобы оформить заказ") { }

        }
        public class MyEx2 : ApplicationException
        {
            public DateTime TimeException { get; private set; }
            public MyEx2() : base("Некорректный ввод") { }

        }
    }
}
