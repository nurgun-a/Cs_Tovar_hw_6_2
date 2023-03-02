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

            WriteLine(@"Стрелками наверх и вниз передвигаетесь по списку,
стрелками налево и направо, добавляете и удаляете количество

            Нажмите Enter чтобы продолжить");
            ReadLine();
            while (true)
            {
                Clear();
                WriteLine($"Поставщик:");
                Tovar.Show_h();
                pr.Sort(new Class_name());
                Menu(pr.tovars, index);
                WriteLine($"------------------------------------------------------------------");
                WriteLine($"Заказ:");
                Tovar.Show_h();

                ms.Sort(new Class_name());
                foreach (Tovar item in ms)
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
                Tovar.Sum(ms.tovars);
                WriteLine($"Итого: {Tovar.Sum(ms.tovars)} рублей");
                
                switch (ReadKey(true).Key)
                {
                    case ConsoleKey.DownArrow:
                        if (index < pr.tovars.Count - 1)
                            index++;
                        break;
                    case ConsoleKey.UpArrow:
                        if (index >0)
                            index--;
                        break;
                    case ConsoleKey.Enter:
                        {
                            Clear();
                            WriteLine($"Заказ оформлен:");
                            //ms.tovars.Clear();
                            foreach (Tovar item in ms)
                            {
                                if (item.Quantity >0)
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
                            WriteLine($"Итого: {Tovar.Sum(ms.tovars)} рублей");
                            ReadLine();
                            Environment.Exit(0);
                        }
                        break; 

                    case ConsoleKey.RightArrow:
                        switch (index)
                        {
                            case 0:
                                {
                                    if (ms.tovars.Any() && pr.tovars[0].Quantity > 0  )
                                    {
                                        pr.tovars[0].Quantity--;
                                        ms.tovars[0].Quantity++;
                                    }
                                    else break;
                                }
                                break;
                            case 1:
                                {
                                    if (ms.tovars.Any() && pr.tovars[1].Quantity > 0)
                                    {
                                        pr.tovars[1].Quantity--;
                                        ms.tovars[1].Quantity++;
                                    }
                                   
                                }
                                break;
                            case 2:
                                {
                                    if (ms.tovars.Any() && pr.tovars[2].Quantity > 0)
                                    {
                                        pr.tovars[2].Quantity--;
                                        ms.tovars[2].Quantity++;
                                    }
                                    
                                }
                                break;
                            case 3:
                                {
                                    if (ms.tovars.Any() && pr.tovars[3].Quantity > 0)
                                    {
                                        pr.tovars[3].Quantity--;
                                        ms.tovars[3].Quantity++;
                                    }
                                   
                                }
                                break;
                            case 4:
                                {
                                    if (ms.tovars.Any() && pr.tovars[4].Quantity > 0)
                                    {
                                        pr.tovars[4].Quantity--;
                                        ms.tovars[4].Quantity++;
                                    }
                                    
                                }
                                break;
                            case 5:
                                {
                                    if (ms.tovars.Any() && pr.tovars[5].Quantity > 0)
                                    {
                                        pr.tovars[5].Quantity--;
                                        ms.tovars[5].Quantity++;
                                    }
                                   
                                }
                                break;
                            case 6:
                                {
                                    if (ms.tovars.Any() && pr.tovars[6].Quantity > 0)
                                    {
                                        pr.tovars[6].Quantity--;
                                        ms.tovars[6].Quantity++;
                                    }
                                  
                                }
                                break;
                            default:
                                break;
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        switch (index)
                        {
                            case 0:
                                {
                                    if (ms.tovars[0].Quantity > 0)
                                    {
                                        pr.tovars[0].Quantity++;
                                        ms.tovars[0].Quantity--;
                                    }
                                    else WriteLine($"error");
                                }
                                break;
                            case 1:
                                {
                                    if (ms.tovars[1].Quantity > 0)
                                    {
                                        pr.tovars[1].Quantity++;
                                        ms.tovars[1].Quantity--;
                                    }
                                    else WriteLine($"error");
                                }
                                break;
                            case 2:
                                {
                                    if (ms.tovars[2].Quantity > 0)
                                    {
                                        pr.tovars[2].Quantity++;
                                        ms.tovars[2].Quantity--;
                                    }
                                    else WriteLine($"error");
                                }
                                break;
                            case 3:
                                {
                                    if (ms.tovars[3].Quantity > 0)
                                    {
                                        pr.tovars[3].Quantity++;
                                        ms.tovars[3].Quantity--;
                                    }
                                    else WriteLine($"error");
                                }
                                break;
                            case 4:
                                {
                                    if (ms.tovars[4].Quantity > 0)
                                    {
                                        pr.tovars[4].Quantity++;
                                        ms.tovars[4].Quantity--;
                                    }
                                    else WriteLine($"error");
                                }
                                break;
                            case 5:
                                {
                                    if (ms.tovars[5].Quantity > 0)
                                    {
                                        pr.tovars[5].Quantity++;
                                        ms.tovars[5].Quantity--;
                                    }
                                    else WriteLine($"error");
                                }
                                break;
                            case 6:
                                {
                                    if (ms.tovars[6].Quantity > 0)
                                    {
                                        pr.tovars[6].Quantity++;
                                        ms.tovars[6].Quantity--;
                                    }
                                    else WriteLine($"error");
                                }
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        break;
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
    }
}
