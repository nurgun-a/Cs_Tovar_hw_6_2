using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.Collections;

namespace Cs_Tovar_hw_6_2
{
    class Class_name : IComparer<Tovar>
    {
        public int Compare(Tovar x, Tovar y) => string.Compare(x.Get_name(), y.Get_name());
    }
    class Provider_1 : IEnumerable
    {       
        public List <Tovar> tovars = new List<Tovar> 
        {
             new Milk("Простоквашино 2,5% 1л.",67.99,14,DateTime.Now),
            new Milk("Простоквашино 3,2% 1л.",82.99,14,DateTime.Now),
            new Bread("Хлеб белый",48.99,DateTime.Now),
            new Bread("Батон нарезной",49.99,DateTime.Now),
            new Bread("Хлеб бородинский",47.99,DateTime.Now),
            new Air_fresh("Glade 300 мл.",101,1825,new DateTime(2021,10,25)),
            new Air_fresh("Chirton 300 мл.",110,1825,new DateTime(2022,6,11))
        };       
        public IEnumerator GetEnumerator() => tovars.GetEnumerator();
        public void Sort()
        {
            tovars.Sort((a, b) => a.CompareTo(b));
        }
        public void Sort(Class_name comp)
        {
            tovars.Sort(comp);
        }
        
    }
}
