using System.IO;

namespace MatrixProperties
{
    public class Program
    {
        static int[,] matrix;
        static string path = "m1.txt";

        static void Main(string[] args)
        {
            Console.WriteLine("*Анализ матрицы отношений*");
            for (int i = 1; i <= 8; i++)
            {
                path = "m" + i.ToString() + ".txt";
                CheckAll(path);
                Console.WriteLine("Нажмите любую кнопку для продолжения.\nДля выхода нажмите esc");
                if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                    Environment.Exit(0);
            }
            //ReadMatrix(path);
            //WriteMatrix();
            //Console.WriteLine(CheckConnectivity());

        }
        public static void CheckAll(string path)
        {
            ReadMatrix(path);
            Console.WriteLine("\n_____________\n" + path + "\n_____________\n");
            WriteMatrix();
            Console.WriteLine("__________________________________________\n");
            string refl = CheckReflexivity();
            Console.WriteLine("Рефлективность: \t" + refl);
            string sym = CheckSymmetry();
            Console.WriteLine("Симметричность: \t" + sym);
            string tran = CheckTransitive();
            Console.WriteLine("Транзитивность: \t" + tran);
            string equi = CheckEquivalence(refl, sym, tran);
            Console.WriteLine("Эквивалентность:\t" + equi);
            string conn = CheckConnectivity();
            Console.WriteLine("Связность:\t\t" + conn);
            string ord = CheckOrder(refl, sym, tran, conn);
            Console.WriteLine("Порядок:\t\t" + ord);
            Console.WriteLine("\n__________________________________________\n");
            Console.WriteLine(@"\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\");
        }
        public static string CheckOrder(string refl, string sym, string tran, string conn)
        {
            if (sym == "Антисимметричное" && tran == "Транзитивное")
            {
                if (refl == "Рефлексивное")
                {
                    if (conn == "Связное") return "Нестрогое, полное";
                    else return "Нестрогое, частичное";
                }
                else
                {
                    if (conn == "Связное") return "Строгое, полное";
                    else return "Строгое, частичное";
                }
            }
            return "Порядок не имеет";
        }
        public static string CheckConnectivity()
        {
            bool isConnectivity = true;
            for (int i = 0; i < matrix.GetLength(0) && isConnectivity; i++)
                for (int j = i + 1; j < matrix.GetLength(1); j++)
                {
                    if (!(matrix[i, j] == 1 || matrix[j, i] == 1))
                        isConnectivity = false;
                }
            if (isConnectivity) return "Связное";
            else return "Не связное";
        }

        public static string CheckEquivalence(string refl, string sym, string tran)
        {
            if (refl == "Рефлексивное" && sym == "Симметричное" && tran == "Транзитивное")
                return "Эквивалентное";
            else return "Не эквивалентное";

        }
        public static string CheckTransitive()
        {
            bool isTransitive = true;
            for (int i = 0; i < matrix.GetLength(0) && isTransitive; i++)
            {
                for (int j = 0; j < matrix.GetLength(1) && isTransitive; j++)
                {
                    for (int k = 0; k < matrix.GetLength(1) && isTransitive; k++)
                    {
                        if (matrix[i, j] == 1 && matrix[j, k] == 1 && matrix[i, k] != 1)
                        {
                            isTransitive = false;
                            return "Не транзитивное";
                        }
                    }
                }
            }
            if (isTransitive) { return "Транзитивное"; }
            return "";
        }
        public static void ReadMatrix(string path)
        {
            string[] lines = File.ReadAllLines(path);
            matrix = new int[lines.GetLength(0), (lines[0].Length + 1) / 2];
            for (int i = 0; i < 6; i++)
            {
                string[] buf = lines[i].Split(' ');
                for (int j = 0; j < 6; j++)
                {
                    matrix[i, j] = int.Parse(buf[j]);
                }
            }
        }
        public static void WriteMatrix()
        {
            if (matrix == null) { Console.WriteLine("Матрица пуста. "); return; }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        public static string CheckReflexivity()
        {
            bool isReflexivity = true;
            bool isNotReflexivity = true;
            for (int i = 0, j = 0; i < matrix.GetLength(0) && (isReflexivity || isNotReflexivity); i++, j++)
            {
                if (!(matrix[i, j] == 1 && isReflexivity)) isReflexivity = false;
                if (!(matrix[i, j] == 0 && isNotReflexivity)) isNotReflexivity = false;
            }
            if (isReflexivity) { return "Рефлексивное"; }
            else if (isNotReflexivity) { return "Aнтирефлексивное"; }
            else { return "Частично рефлексивное"; }
        }
        public static string CheckSymmetry()
        {
            bool isSymmetry = true;
            bool isAntiSymmetry = true;
            for (int i = 0; i < matrix.GetLength(0) && (isSymmetry || isAntiSymmetry); i++)
            {
                for (int j = i + 1; j < matrix.GetLength(1) && (isSymmetry || isAntiSymmetry); j++)
                {
                    if (!(matrix[i, j] * matrix[j, i] == matrix[i, j])) isSymmetry = false;
                    if (!(matrix[i, j] * matrix[j, i] == 0)) isAntiSymmetry = false;
                }
            }
            string isReflexivity = CheckReflexivity();
            if (isSymmetry) { return "Симметричное"; }
            else if (isAntiSymmetry && isReflexivity != "Антирефлексивное")
            { return "Антисимметричное"; }
            else if (isAntiSymmetry && isReflexivity == "Антирефлексивное")
            { return "Асимметричное"; }
            else return "Неявно Симметричное";
        }
    }
}