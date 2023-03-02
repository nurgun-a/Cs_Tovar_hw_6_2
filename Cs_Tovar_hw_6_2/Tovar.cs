using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Cs_Tovar_hw_6_2
{
    class Tovar : IComparable, ICloneable
    {
        string Name;
        double Price;
        int Expiration;
        DateTime dd;
        public int Quantity { get; set; }
        public Tovar() { }
        public Tovar(string _name, double _price, int _expiration, DateTime _dd) 
        {
            Name = _name;
            Price = _price;
            Expiration = _expiration;
            dd = _dd;
        }

        public object Clone()
        {
            Tovar tmp = (Tovar)MemberwiseClone();
            return tmp;
            //throw new NotImplementedException();
        }
        public virtual string Get_name() => Name;
        public int CompareTo(object obj)
        {
            if (obj is Tovar)
            {
                return Price.CompareTo((obj as Tovar).Price);
            }
            throw new NotImplementedException();
        }
        public static double Sum(List<Tovar> list)
        {
            double tmp=0;
            foreach (Tovar item in list)
            {
                if(item.Quantity>0) tmp += (item.Quantity * item.Price);
            }
            return tmp;
        }
        public override string ToString() 
            => $"{Name.PadRight(25)}|{Convert.ToString(Expiration).PadRight(8)}|{Convert.ToString(Price).PadRight(8)}|{Convert.ToString(dd.ToShortDateString()).PadRight(11)}";
        public static void Show_h()
        {
            WriteLine($"------------------------------------------------------------------");
            WriteLine($"{"Наименование".PadRight(25)}|{"Cр.годн.".PadRight(8)}|{"Цена".PadRight(8)}|{"Дата изг.".PadRight(11)}| Кол.-во");
            WriteLine($"------------------------------------------------------------------");
        }
    }

    class Milk: Tovar
    { 
        public Milk() { }
        public Milk(string _name, double _price, int _expiration, DateTime _dd)
            : base(_name, _price, _expiration, _dd) { }
        public void ShowMilk() => WriteLine($"Хранить при температуре +2, +6");
        public override string ToString() => $"{base.ToString()}|{Convert.ToString(Quantity).PadRight(6)}";

    }
    class Air_fresh : Tovar
    {
        public Air_fresh() { }
        public Air_fresh(string _name, double _price, int _expiration, DateTime _dd)
            : base(_name, _price, _expiration, _dd) { }
        public void ShowAir() => WriteLine($"Огнеопасно. Не хранить возле огня");
        public override string ToString() => $"{base.ToString()}|{Convert.ToString(Quantity).PadRight(6)}";

    }
    class Bread : Tovar
    {
        public Bread() { }
        public Bread(string _name, double _price, DateTime _dd)
            : base(_name, _price, 3, _dd) { }
        public override string ToString() => $"{base.ToString()}|{Convert.ToString(Quantity).PadRight(6)}";

    }
}
