using System;

namespace LearningInheritance
{
    class ParentClass
    {
        public string Name { get; set; }
        protected int Id { get; set; } = 9;

        public void AfiseazaDetaliiClasaParinte()
        {
            Console.WriteLine($"Eu sunt {Name}");
            Console.WriteLine($"ID: {Id}");
        }

        public virtual void PrinteazaInformatii()
        {
            Console.WriteLine("Aceasta este clasa parinte.");
        }
    }

    class ChildClass : ParentClass, IComparable
    {
        protected internal double Score { get; set; }

        public ChildClass(string childName, double childScore)
        {
            Name = childName;
            Score = childScore;
        }

        public void PreiaIdDeLaClasaParinte()
        {
            Console.WriteLine($"Acesta este ID-ul meu: {Id}");
        }

        public void ActualizeazaNume(string numeNou)
        {
            Name = numeNou;
            Console.WriteLine("Nume actualizat cu succes!");
        }

        public void CresteIdCu(int increment)
        {
            Id += increment;
            Console.WriteLine($"ID-ul a crescut cu {increment}. Noul ID: {Id}");
        }

        public void SuprascrieNumeParinte()
        {
            Name = "Copil";
            Console.WriteLine("Numele parintelui a fost suprascris cu Copil!");
        }

        public void SchimbaIdParinte(int noulId)
        {
            base.Id = noulId;
            Console.WriteLine($"ID-ul parintelui a fost schimbat in {noulId}");
        }

        public void AfiseazaDetaliiClasaCopil()
        {
            Console.WriteLine($"Nume copil: {Name}");
            Console.WriteLine($"ID copil: {Id}");
            Console.WriteLine($"Scor copil: {Score}");
        }

        public void InmultesteIdCu(int factor)
        {
            Id *= factor;
            Console.WriteLine($"ID-ul inmultit cu {factor}. Noul ID: {Id}");
        }

        public void ReseteazaLaValorileParintelui()
        {
            Name = base.Name;
            Id = base.Id;
            Console.WriteLine("Resetat la valorile parintelui.");
        }

        public override void PrinteazaInformatii()
        {
            Console.WriteLine("Aceasta este clasa copil.");
        }

        public int CompareTo(object obj)
        {
            if (obj is ChildClass altCopil)
            {
                return Score.CompareTo(altCopil.Score);
            }
            throw new ArgumentException("Obiectul nu este de tipul ChildClass");
        }
    }

    interface IComparable
    {
        int CompareTo(object obj);
    }

    static class ExtensionMethods
    {
        // Metoda de extensie pentru a calcula scorul mediu al unui array de obiecte ChildClass
        public static double CalculeazaScorMediu(this ChildClass[] copii)
        {
            double suma = 0;
            foreach (ChildClass copil in copii)
            {
                suma += copil.Score;
            }
            return suma / copii.Length;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ChildClass copil = new ChildClass("John", 85.5);

            copil.ActualizeazaNume("Peter");
            copil.AfiseazaDetaliiClasaParinte();

            copil.CresteIdCu(3);
            copil.PreiaIdDeLaClasaParinte();

            copil.SuprascrieNumeParinte();
            copil.AfiseazaDetaliiClasaParinte();

            copil.SchimbaIdParinte(15);
            copil.AfiseazaDetaliiClasaParinte();

            copil.AfiseazaDetaliiClasaCopil();

            copil.InmultesteIdCu(2);
            copil.PreiaIdDeLaClasaParinte();

            copil.ReseteazaLaValorileParintelui();
            copil.AfiseazaDetaliiClasaCopil();

            copil.PrinteazaInformatii();

            if (copil is IComparable)
            {
                Console.WriteLine("Clasa copil implementeaza interfata IComparable.");
            }
            else
            {
                Console.WriteLine("Clasa copil nu implementeaza interfata IComparable.");
            }

            // Functionalitate suplimentara
            Console.WriteLine("\nFunctionalitate suplimentara:");

            ParentClass parinte = copil;
            parinte.AfiseazaDetaliiClasaParinte();
            parinte.PrinteazaInformatii();

            // Utilizarea metodei CompareTo
            ChildClass copil2 = new ChildClass("Sarah", 95.7);
            int rezultatComparare = copil.CompareTo(copil2);
            Console.WriteLine($"Rezultat comparare: {rezultatComparare}");

            // Crearea unui array de obiecte ChildClass
            ChildClass[] copii = new ChildClass[]
            {
                new ChildClass("Emma", 76.4),
                new ChildClass("Michael", 91.2),
                new ChildClass("Olivia", 82.8),
                new ChildClass("James", 89.6),
                new ChildClass("Sophia", 94.1)
            };

            // Sortarea array-ului folosind metoda Array.Sort()
            Array.Sort(copii);

            // Afișarea array-ului sortat
            Console.WriteLine("\nCopii sortati:");
            foreach (ChildClass c in copii)
            {
                c.AfiseazaDetaliiClasaCopil();
            }

            Console.WriteLine("\nApasati orice tasta pentru a iesi.");
            Console.ReadKey();
        }
    }
}
