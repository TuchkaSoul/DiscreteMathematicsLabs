using AppGraphTheory;

namespace GraphMinimisation
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            MatrixGraf mat = new MatrixGraf("m0.txt");
            Console.WriteLine("[ Использована матрица из файла: m0.txt ]");
            mat.WriteMatrix();
            if (mat.CountComp() > 1)
            {
                Console.WriteLine("Граф не является связанным.");
                mat.Exit();
            }
            Graph graf1 = new Graph(MatrixGraf.matrix);
            Console.WriteLine("Входной граф\n[Рёбра графа]");            
            graf1.Print();
            Console.WriteLine("-------------------------------------------------\n[ Начало работы алгоритмов]");
            Graph grafr = graf1.FindMinimumPrim(2);
            Console.WriteLine("Вес Остова Прима: " + grafr.Lenght()+ "\nДерево полученное Алгоритмом Прима с сначалом в вершине \"2\"");
            grafr.Print();
            grafr = graf1.FindMinimumPrim(9);
            Console.WriteLine("Вес Остова Прима: " + grafr.Lenght() + "\nДругое дерево с сначалом в вершине \"9\" полученное Алгоритмом Прима");
            grafr.Print();
            Console.WriteLine("-------------------------------------------------");
            grafr = graf1.FindMinimumKraskala();
            Console.WriteLine("Вес Остова Краскала: "+grafr.Lenght()+ "\nДерево полученное Алгоритмом Прима");
            grafr.Print();          
        }
    }
}
