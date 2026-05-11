using System;
using System.Collections.Generic;
using System.Text;

namespace Polymorphism
{
    class Program
    {
        public abstract class clsBasePizza
        {
            protected double nBasePrice;

            public virtual double getPrice()
            {
                return this.nBasePrice;
            }
        }

        public class clsGourmet : clsBasePizza
        {
            public clsGourmet()
            {
                this.nBasePrice = 7.99;
            }
        }

        public class clsMargherita : clsBasePizza
        {
            public clsMargherita()
            {
                this.nBasePrice = 6.99;
            }
        }

        public abstract class clsTopping : clsBasePizza
        {
            protected clsBasePizza oPizza;

            public clsTopping(clsBasePizza oPizzaToDecorate)
            {
                this.oPizza = oPizzaToDecorate;
            }

            public override double getPrice()
            {
                return (this.oPizza.getPrice() + this.nBasePrice);
            }
        }

        public class clsExtraCheese : clsTopping
        {
            public clsExtraCheese(clsBasePizza oPizzaToDecorate)
                : base(oPizzaToDecorate)
            {
                this.nBasePrice = 0.99;
            }
        }

        public class clsMushroom : clsTopping
        {
            public clsMushroom(clsBasePizza oPizzaToDecorate)
                : base(oPizzaToDecorate)
            {
                this.nBasePrice = 0.79;
            }
        }

        public class clsJalapeno : clsTopping
        {
            public clsJalapeno(clsBasePizza oPizzaToDecorate)
                : base(oPizzaToDecorate)
            {
                this.nBasePrice = 0.49;
            }
        }

        public class clsExtraMeat : clsTopping
        {
            public clsExtraMeat(clsBasePizza oPizzaToDecorate)
                : base(oPizzaToDecorate)
            {
                this.nBasePrice = 1.99;
            }
        }

        public class clsExtraShrimp : clsTopping
        {
            public clsExtraShrimp(clsBasePizza oPizzaToDecorate)
                : base(oPizzaToDecorate)
            {
                this.nBasePrice = 2.99;
            }
        }

        static void Main(string[] args)
        {
            clsMargherita oMPizza = new clsMargherita();

            Console.WriteLine("Plain Margherita Pizza: " + oMPizza.getPrice());

            clsExtraCheese oMPizzaWithEC1 = new clsExtraCheese(oMPizza);

            Console.WriteLine("Margherita Pizza with Extra Cheese: " + oMPizzaWithEC1.getPrice());

            clsExtraCheese oMPizzaWithEC2 = new clsExtraCheese(oMPizzaWithEC1);

            Console.WriteLine("Margherita Pizza with Double Extra Cheese: " + oMPizzaWithEC2.getPrice());

            clsMushroom oMPizzaWithEC2M = new clsMushroom(oMPizzaWithEC2);

            Console.WriteLine("Margherita Pizza with Double Extra Cheese and Mushroom: " + oMPizzaWithEC2M.getPrice());

            clsJalapeno oMPizzaWithEC2MJ = new clsJalapeno(oMPizzaWithEC2M);

            Console.WriteLine("Margherita Pizza with Double Extra Cheese, Mushroom and Jalapeno: " + oMPizzaWithEC2MJ.getPrice());

            clsExtraMeat oMPizzaWithEC2MJEM = new clsExtraMeat(oMPizzaWithEC2MJ);

            Console.WriteLine("Margherita Pizza with Double Extra Cheese, Mushroom, Jalapeno and Extra Meat: " + oMPizzaWithEC2MJEM.getPrice());

            clsExtraShrimp oMPizzaWithEC2MJEMES = new clsExtraShrimp(oMPizzaWithEC2MJEM);
            Console.WriteLine("Margherita Pizza with Double Extra Cheese, Mushroom, Jalapeno, Extra Meat and Extra Shrimp: " + oMPizzaWithEC2MJEMES.getPrice());

            Console.ReadLine();

            clsGourmet oGPizza = new clsGourmet();

            Console.WriteLine("Plain Gourmet Pizza: " + oGPizza.getPrice());

            clsExtraCheese oGPizzaWithEC1 = new clsExtraCheese(oGPizza);

            Console.WriteLine("Gourmet Pizza with Extra Cheese: " + oGPizzaWithEC1.getPrice());

            clsExtraCheese oGPizzaWithEC2 = new clsExtraCheese(oGPizzaWithEC1);

            Console.WriteLine("Gourmet Pizza with Double Extra Cheese: " + oGPizzaWithEC2.getPrice());

            clsMushroom oGPizzaWithEC2M = new clsMushroom(oGPizzaWithEC2);
            Console.WriteLine("Gourmet Pizza with Double Extra Cheese and Mushroom: " + oGPizzaWithEC2M.getPrice());

            clsJalapeno oGPizzaWithEC2MJ = new clsJalapeno(oGPizzaWithEC2M);
            Console.WriteLine("Gourmet Pizza with Double Extra Cheese, Mushroom and Jalapeno: " + oGPizzaWithEC2MJ.getPrice());

            clsExtraMeat oGPizzaWithEC2MJEM = new clsExtraMeat(oGPizzaWithEC2MJ);
            Console.WriteLine("Gourmet Pizza with Double Extra Cheese, Mushroom, Jalapeno and Extra Meat: " + oGPizzaWithEC2MJEM.getPrice());

            clsExtraShrimp oGPizzaWithEC2MJEMES = new clsExtraShrimp(oGPizzaWithEC2MJEM);
            Console.WriteLine("Gourmet Pizza with Double Extra Cheese, Mushroom, Jalapeno, Extra Meat and Extra Shrimp: " + oGPizzaWithEC2MJEMES.getPrice());

            Console.ReadLine();
        }
    }
}
