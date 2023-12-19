internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Добро пожаловать в калькулятор множеств\n");
        int leftBorder, rightBorder;

        List<int> universum = new();
        List<int> myltiSetA = new();
        List<int> myltiSetB = new();
        List<int> myltiSetC = new();
        CreateUniversum(universum, myltiSetA, myltiSetB, myltiSetC, out leftBorder, out rightBorder);

        while (true)
        {
            CallMainMenu(ref leftBorder, ref rightBorder, universum, myltiSetA, myltiSetB, myltiSetC);
        }
    }
    public static void CallMainMenu(ref int leftBorder, ref int rightBorder, List<int> universum, List<int> myltiSetA, List<int> myltiSetB, List<int> myltiSetC)
    {
        int numberInstruction;
        Console.WriteLine("Главное меню:");
        Console.WriteLine("1) Задать пользовательский универсум\n" +
            "2) Задать множества\n" +
            "3) Провести операции над множествами\n" +
            "4) Отобразить множества\n" +
            "5) Завершить работу");
        Console.Write("Выберите команду: ");
        EnterValue(out numberInstruction);
        while (numberInstruction < 0 || numberInstruction > 5)
        {
            Console.WriteLine("Это должно быть не отрицательное число и не больше 5 \n");
            EnterValue(out numberInstruction);
        }
        switch (numberInstruction)
        {
            case 1:
                CreateUniversum(universum, myltiSetA, myltiSetB, myltiSetC, out leftBorder, out rightBorder, true);
                break;
            case 2:
                CallSetMenu(leftBorder, rightBorder, universum, myltiSetA, myltiSetB, myltiSetC);
                break;
            case 3:
                CallOperationMenu(universum, myltiSetA, myltiSetB, myltiSetC);
                break;
            case 4:
                Console.WriteLine("Выбор множества:");
                Console.WriteLine("1) Множество 1\n" +
                    "2) Множество 2\n" +
                    "3) Множество 3\n" +
                    "4) Универсум\n" +
                    "5) Все множества");
                EnterValue(out int numberInstruction1);
                while (numberInstruction1 < 0 || numberInstruction1 > 5)
                {
                    Console.WriteLine("Это должно быть не отрицательное число и не больше 5 \n");
                    EnterValue(out numberInstruction1);
                }
                switch (numberInstruction1)
                {
                    case 1:
                        Console.WriteLine("Выбрано множество A или 1\n");
                        WriteMultiset(myltiSetA); break;
                    case 2:
                        Console.WriteLine("Выбрано множество B или 2\n");
                        WriteMultiset(myltiSetB); break;
                    case 3:
                        Console.WriteLine("Выбрано множество C или 3\n");
                        WriteMultiset(myltiSetC); break;
                    case 4:
                        Console.WriteLine("Выбран универсум\n");
                        WriteMultiset(universum); break;
                    case 5:
                        Console.WriteLine("Выбрано множество A или 1\n");
                        WriteMultiset(myltiSetA); Console.WriteLine("Выбрано множество B или 2\n");
                        WriteMultiset(myltiSetB); Console.WriteLine("Выбрано множество C или 3\n");
                        WriteMultiset(myltiSetC); Console.WriteLine("Выбран универсум\n");
                        WriteMultiset(universum);

                        break;

                }
                break;

            case 5:
                System.Environment.Exit(0);
                break;
        }
    }
    public static void CallOperationMenu(List<int> universum, List<int> myltiSetA, List<int> myltiSetB, List<int> myltiSetC)
    {
        int numberInstruction;
        Console.WriteLine("Выбор операции:");
        Console.WriteLine("1) Объединение\n" +
            "2) Пересечение\n" +
            "3) Разность\n" +
            "4) Симметрическая разность\n" +
            "5) Дополнение");
        Console.Write("Выберите команду: ");
        EnterValue(out numberInstruction);
        while (numberInstruction < 0 || numberInstruction > 5)
        {
            Console.WriteLine("Это должно быть не отрицательное число и не больше 5 \n");
            EnterValue(out numberInstruction);
        }
        switch (numberInstruction)
        {
            case 1:
                Console.WriteLine("Выбрана операция Объединения 2 множеств");
                WriteMultiset(MergerOperation(MakeChoiceOperation(universum, myltiSetA, myltiSetB, myltiSetC), MakeChoiceOperation(universum, myltiSetA, myltiSetB, myltiSetC)));
                break;
            case 2:
                Console.WriteLine("Выбрана операция Пересечения 2 множеств");
                WriteMultiset(OverlapOperation(MakeChoiceOperation(universum, myltiSetA, myltiSetB, myltiSetC), MakeChoiceOperation(universum, myltiSetA, myltiSetB, myltiSetC)));
                break;
            case 3:
                Console.WriteLine("Выбрана операция Разности 2 множеств");
                WriteMultiset(DifferenceOperation(MakeChoiceOperation(universum, myltiSetA, myltiSetB, myltiSetC), MakeChoiceOperation(universum, myltiSetA, myltiSetB, myltiSetC)));
                break;
            case 4:
                Console.WriteLine("Выбрана операция Симметрической разницы 2 множеств");
                WriteMultiset(SymmetricDifferenceOperation(MakeChoiceOperation(universum, myltiSetA, myltiSetB, myltiSetC), MakeChoiceOperation(universum, myltiSetA, myltiSetB, myltiSetC)));
                break;
            case 5:
                Console.WriteLine("Выбрана операция Дополнения множества");
                WriteMultiset(AdditionOperation(MakeChoiceOperation(universum, myltiSetA, myltiSetB, myltiSetC), universum));
                break;
        }
    }
    public static List<int> MakeChoiceOperation(List<int> universum, List<int> myltiSetA, List<int> myltiSetB, List<int> myltiSetC)
    {
        int numberInstruction;
        Console.WriteLine("Выбор множества для операции:");
        Console.WriteLine("1) Множество 1\n" +
            "2) Множество 2\n" +
            "3) Множество 3\n" +
            "4) Универсум\n");
        Console.Write("Выберите команду: ");
        EnterValue(out numberInstruction);
        while (numberInstruction < 0 || numberInstruction > 4)
        {
            Console.WriteLine("Это должно быть не отрицательное число и не больше 4 \n");
            EnterValue(out numberInstruction);
        }
        switch (numberInstruction)
        {
            case 1:
                Console.WriteLine("Выбрано множество A или 1\n");
                return myltiSetA;
            case 2:
                Console.WriteLine("Выбрано множество B или 2\n");
                return myltiSetB;
            case 3:
                Console.WriteLine("Выбрано множество C или 3\n");
                return myltiSetC;
            case 4:
                Console.WriteLine("Выбран универсум или U\n");
                return universum;
        }
        return myltiSetA;
    }
    public static void CallSetMenu(int leftBorder, int rightBorder, List<int> universum, List<int> myltiSetA, List<int> myltiSetB, List<int> myltiSetC)
    {
        int numberInstruction;
        Console.WriteLine("Выбор множества:");
        Console.WriteLine("1) Множество 1\n" +
            "2) Множество 2\n" +
            "3) Множество 3\n");
        EnterValue(out numberInstruction);
        while (numberInstruction < 0 || numberInstruction > 3)
        {
            Console.WriteLine("Это должно быть не отрицательное число и не больше 3 \n");
            EnterValue(out numberInstruction);
        }
        switch (numberInstruction)
        {
            case 1:
                Console.WriteLine("Выбрано для заполнения множество A или 1");
                MakeChoiceFilling(myltiSetA, leftBorder, rightBorder);
                break;
            case 2:
                Console.WriteLine("Выбрано для заполнения множество B или 2");
                MakeChoiceFilling(myltiSetB, leftBorder, rightBorder);
                break;
            case 3:
                Console.WriteLine("Выбрано для заполнения множество C или 3");
                MakeChoiceFilling(myltiSetC, leftBorder, rightBorder);
                break;

        }
    }
    public static void MakeChoiceFilling(List<int> multi, int leftBorder, int rightBorder)
    {
        int numberInstruction;
        Console.WriteLine("Выбор операции:");
        Console.WriteLine("1) Случайное заполнение \n" +
            "2) Случайное положительное заполнение\n" +
            "3) Случайное отрицательное заполнение\n" +
            "4) Случайное нечётное заполнение\n" +
            "5) Случайное чётное заполнение\n" +
            "6) Случайное заполнение кратных n\n" +
            "7) Задать диапазоном\n" +
            "8) Ручное заполнение\n" +
            "9) Вернуться в Главное меню");
        Console.Write("Выберите команду: ");
        EnterValue(out numberInstruction);
        while (numberInstruction < 0 || numberInstruction > 9)
        {
            Console.WriteLine("Это должно быть не отрицательное число и не больше 9 \n");
            EnterValue(out numberInstruction);
        }
        switch (numberInstruction)
        {
            case 1: UseRandomFilling(multi, leftBorder, rightBorder); break;
            case 2: UseRandomPositiveFilling(multi, leftBorder, rightBorder); break;
            case 3: UseRandomNegativeFilling(multi, leftBorder, rightBorder); break;
            case 4: UseRandomEvenFilling(multi, leftBorder, rightBorder, 1); break;
            case 5: UseRandomEvenFilling(multi, leftBorder, rightBorder); break;
            case 6: UseRandomMultipleFilling(multi, leftBorder, rightBorder); break;
            case 7: UseSerialFilling(multi, leftBorder, rightBorder); break;
            case 8: UseManualFilling(multi, leftBorder, rightBorder); break;
            case 9: break;
        }
    }
    public static List<int> AdditionOperation(List<int> mylti, List<int> univer)
    {
        List<int> result = new();
        Console.WriteLine($"Вы решили использовать дополнение множества");
        foreach (var item in univer)
        {
            if (!mylti.Contains(item))
            { result.Add(item); }
        }
        return result;
    }
    public static List<int> DifferenceOperation(List<int> mylti1, List<int> mylti2)
    {
        List<int> result = new();
        Console.WriteLine($"Вы решили использовать разность множеств");
        foreach (var item in mylti1)
        {
            if (!mylti2.Contains(item))
            { result.Add(item); }
        }
        return result;
    }
    public static List<int> SymmetricDifferenceOperation(List<int> mylti1, List<int> mylti2)
    {
        List<int> result = new();
        Console.WriteLine($"Вы решили использовать симметрическую разность множеств");
        foreach (var item in mylti1)
        {
            if (!mylti2.Contains(item))
            { result.Add(item); }
        }
        foreach (var item in mylti2)
        {
            if (!mylti1.Contains(item))
            {
                result.Add(item);
            }
        }
        return result;
    }
    public static List<int> OverlapOperation(List<int> mylti1, List<int> mylti2)
    {
        List<int> result = new();
        Console.WriteLine($"Вы решили использовать пересечение множеств");
        for (int i = 0; i < mylti1.Count; i++)
        {
            if (mylti2.Contains(mylti1[i]))
            {
                result.Add(mylti1[i]);
            }
        }
        for(int i = 0;i < mylti2.Count; i++)
        {
            if (mylti1.Contains(mylti2[i]) && !result.Contains(mylti2[i])) result.Add(mylti2[i]);
        }
        return result;
    }
    public static List<int> MergerOperation(List<int> mylti1, List<int> mylti2)
    {
        List<int> result = new();
        Console.WriteLine($"Вы решили использовать объединение множеств");
        foreach (var item in mylti1)
        {
            if (!result.Contains(item))
            {
                result.Add(item);
            }
        }
        foreach (var item in mylti2)
        {
            if (!result.Contains(item))
            {
                result.Add(item);
            }
        }
        return result;
    }
    public static void EnterElementCount(out int elementCount, int leftBorder, int rightBorder)
    {
        Console.WriteLine("\nВведите сколько элементов желаете добавить в множество \n");
        EnterValue(out elementCount); while (elementCount < 0)
        {
            Console.WriteLine("Это должно быть не отрицательное число \n");
            EnterValue(out elementCount);
        }
        while (elementCount > rightBorder - leftBorder + 1)
        {
            Console.WriteLine($"Вы желаете добавить число элементов превышающее мощность универсума..\n" +
                $"предел равен {rightBorder - leftBorder + 1}");
            EnterElementCount(out elementCount, leftBorder, rightBorder);
        }
    }
    public static void UseRandomFilling(List<int> mylti, int leftBorder, int rightBorder)
    {
        mylti.Clear();
        Console.WriteLine("Вы решили использовать рандомное заполнение");
        EnterElementCount(out int elementCount, leftBorder, rightBorder);
        int buf;
        Random rnd = new Random();
        if (elementCount == rightBorder - leftBorder + 1)
        {
            for (int i = leftBorder; i <= rightBorder; i++)
            {
                mylti.Add(i);
            }
            return;
        }
        while (elementCount > 0)
        {
            buf = rnd.Next(leftBorder, rightBorder);
            if (!mylti.Contains(buf))
            {
                mylti.Add(buf);
                elementCount--;
            }
        }
        mylti.Sort();
    }
    public static void UseRandomNegativeFilling(List<int> mylti, int leftBorder, int rightBorder)
    {
        mylti.Clear(); Console.WriteLine("Вы решили использовать рандомное отрицательное заполнение");
        if (leftBorder >= 0)
        {
            Console.WriteLine("Универсум не поддерживает отрицательные элементы");
            return;
        }
        if (rightBorder >= 0)
            rightBorder = 0;

        EnterElementCount(out int elementCount, leftBorder, rightBorder);
        int buf;
        Random rnd = new Random();
        if (rightBorder >= 0)
            if (elementCount == rightBorder - leftBorder + 1)
            {
                for (int i = leftBorder; i <= rightBorder; i++)
                {
                    if (i < 0)
                        mylti.Add(i);
                    else return;
                }
                mylti.Sort();
                return;
            }

        while (elementCount > 0)
        {
            buf = rnd.Next(leftBorder, rightBorder);
            if (!mylti.Contains(buf) && buf < 0)
            {
                mylti.Add(buf);
                elementCount--;
            }
        }
        mylti.Sort();
    }
    public static void UseRandomPositiveFilling(List<int> mylti, int leftBorder, int rightBorder)
    {
        mylti.Clear(); Console.WriteLine("Вы решили использовать рандомное положительное заполнение");
        if (rightBorder < 0)
        {
            Console.WriteLine("Универсум не поддерживает положительные элементы");
            return;
        }
        if (leftBorder < 0)
            leftBorder = 0;

        EnterElementCount(out int elementCount, leftBorder, rightBorder);
        int buf;
        Random rnd = new Random();
        if (rightBorder >= 0)
            if (elementCount == rightBorder - leftBorder + 1)
            {
                for (int i = leftBorder; i <= rightBorder; i++)
                {
                    if (i >= 0)
                        mylti.Add(i);
                }
                mylti.Sort();
                return;
            }

        while (elementCount > 0)
        {
            buf = rnd.Next(leftBorder, rightBorder);
            if (!mylti.Contains(buf) && buf >= 0)
            {
                mylti.Add(buf);
                elementCount--;
            }
        }
        mylti.Sort();
    }
    public static void UseRandomEvenFilling(List<int> mylti, int leftBorder, int rightBorder,int even = 0) //возможно зависание
    {
        mylti.Clear();
        if (even == 0) Console.WriteLine("Вы решили использовать рандомное чётное заполнение");
        else Console.WriteLine("Вы решили использовать рандомное нечётное заполнение");
        if (rightBorder == leftBorder && rightBorder % 2 == even)
        {
            mylti.Add(rightBorder);
            return;
        }
        Console.WriteLine("\nВведите сколько элементов желаете добавить в множество \n");
        EnterValue(out int elementCount); while (elementCount < 0)
        {
            Console.WriteLine("Это должно быть не отрицательное число \n");
            EnterValue(out elementCount);
        }
        while (elementCount > (rightBorder - leftBorder + 2) / 2)
        {
            Console.WriteLine($"Вы желаете добавить число элементов превышающее мощность универсума..\n" +
                $"предел равен {(rightBorder - leftBorder + 2) / 2}");
            EnterValue(out elementCount); while (elementCount < 0)
            {
                Console.WriteLine("Это должно быть не отрицательное число \n");
                EnterValue(out elementCount);
            }
        }

        int buf;
        Random rnd = new Random();

        if (elementCount == (rightBorder - leftBorder + 2) / 2)
        {
            for (int i = leftBorder; i <= rightBorder; i++)
            {
                if (Math.Abs(i % 2) == Math.Abs(even))
                    mylti.Add(i);

            }
            mylti.Sort();
            return;
        }

        while (elementCount > 0)
        {
            buf = rnd.Next(leftBorder, rightBorder);
            if (!mylti.Contains(buf) && Math.Abs(buf % 2) == even)
            {
                mylti.Add(buf);
                elementCount--;
            }
        }
        mylti.Sort();
    }
    public static void UseRandomMultipleFilling(List<int> mylti, int leftBorder, int rightBorder) //возможно зависание
    {
        mylti.Clear();
        Console.WriteLine("Вы решили использовать рандомное заполнение кратных n\nВведите число которое желаете использовать в качестве коэффициента кратности\n");
        EnterValue(out int n);
        while (n < 0 && n > rightBorder)
        {
            Console.WriteLine("Это должно быть натуральным и меньше максимальной границы универсума\n");
            EnterValue(out n);
        }
        n=Math.Abs(n);
        if (rightBorder == leftBorder && rightBorder % n == 0)
        {
            mylti.Add(rightBorder);
            return;
        }
        Console.WriteLine("\nВведите сколько элементов желаете добавить в множество \n");
        EnterValue(out int elementCount); while (elementCount < 0)
        {
            Console.WriteLine("Это должно быть не отрицательное число \n");
            EnterValue(out elementCount);
        }
        while (elementCount > (rightBorder - leftBorder + 1) / n)
        {
            Console.WriteLine($"Вы желаете добавить число элементов превышающее мощность универсума..\n" +
                $"предел равен {(rightBorder - leftBorder + 1) / n}");
            EnterValue(out elementCount); while (elementCount < 0)
            {
                Console.WriteLine("Это должно быть не отрицательное число \n");
                EnterValue(out elementCount);
            }
        }

        int buf;
        Random rnd = new Random();

        if (elementCount == (rightBorder - leftBorder + 1) / n)
        {
            for (int i = leftBorder; i <= rightBorder; i++)
            {
                if (Math.Abs(i % n) == 0)
                    mylti.Add(i);

            }
            mylti.Sort();
            return;
        }

        while (elementCount > 0)
        {
            buf = rnd.Next(leftBorder, rightBorder);
            if (!mylti.Contains(buf) && Math.Abs(buf % n) == 0)
            {
                mylti.Add(buf);
                elementCount--;
            }
        }
        mylti.Sort();
    }
    public static void CreateUniversum(List<int> univer, List<int> univer1, List<int> univer2, List<int> univer3, out int leftBorder, out int rightBorder, bool whetherAsk = false)
    {
        bool isCheck = true;
        univer1.Clear();
        univer2.Clear();
        univer3.Clear();
        if (whetherAsk)
        {
            Console.WriteLine("Вы решили задать пользовательские границы универсума.\n");
            do
            {
                if (!isCheck) Console.WriteLine("\n!Левая граница должна быть меньше правой!!\n");
                Console.WriteLine("Введите левую границу универсума");
                EnterValue(out leftBorder); while (leftBorder < -500 || leftBorder > 500)
                {
                    Console.WriteLine("принадлежать диапазону [-500;500]\n");
                    EnterValue(out leftBorder);
                }
                Console.WriteLine("Введите правую границу универсума");
                EnterValue(out rightBorder); while (rightBorder < -500 || rightBorder > 500)
                {
                    Console.WriteLine("принадлежать диапазону [-500;500]\n");
                    EnterValue(out rightBorder);
                }
                isCheck = leftBorder <= rightBorder;

            } while (!isCheck);
        }
        else
        {
            leftBorder = -500; rightBorder = 500;
        }
        univer.Clear();
        for (int i = leftBorder; i <= rightBorder; i++)
        {
            univer.Add(i);
        }
    }
    public static void UseSerialFilling(List<int> mylti, int leftBorder1, int rightBorder1)
    {
        mylti.Clear();
        bool isCheck = true;
        int leftBorder, rightBorder;
        Console.WriteLine("\nВы решили использовать заполнение через диапазон");
        do
        {
            if (!isCheck) Console.WriteLine("\n!Левая граница должна быть меньше правой!!\n");
            Console.WriteLine("Введите левую границу диапазона");
            EnterValue(out leftBorder); while (leftBorder < leftBorder1 || leftBorder > rightBorder1)
            {
                Console.WriteLine($"принадлежать диапазону [{leftBorder1};{rightBorder1}]\n");
                EnterValue(out leftBorder);
            }
            Console.WriteLine("Введите правую границу диапазона");
            EnterValue(out rightBorder); while (rightBorder < leftBorder1 || rightBorder > rightBorder1)
            {
                Console.WriteLine($"принадлежать диапазону [{leftBorder1};{rightBorder1}]\n");
                EnterValue(out rightBorder);
            }
            isCheck = leftBorder <= rightBorder;

        } while (!isCheck);

        for (int i = leftBorder; i <= rightBorder; i++)
        {
            mylti.Add(i);
        }
    }
    public static void UseManualFilling(List<int> mylti, int leftBorder, int rightBorder)
    {
        Console.WriteLine($"Вы решили использовать ручное заполнение");
        EnterElementCount(out int elementCount, leftBorder, rightBorder);
        if (elementCount == rightBorder - leftBorder + 1)
        {
            for (int i = leftBorder; i <= rightBorder; i++)
            {
                mylti.Add(i);
            }
            return;
        }
        mylti.Clear();
        int buf, counter = 0;
        for (int i = 0; i < elementCount; i++)
        {
            EnterValue(out buf); while (buf < leftBorder || buf > rightBorder)
            {
                Console.WriteLine($"принадлежать диапазону [{leftBorder};{rightBorder}]\n");
                EnterValue(out buf);
            }
            if (!mylti.Contains(buf))
            {
                mylti.Add(buf);
            }
            else counter++;

        }
        mylti.Sort();
        Console.WriteLine($"Было добавлено={elementCount - counter},удаленно повторов={counter} \n");
    }
    public static void WriteMultiset(List<int> multiSet)
    {
        multiSet.Sort();
        Console.Write("{");
        int i = 1;
        foreach (int j in multiSet)
        {
            Console.Write($"{i++}){j},\t");
        }
        Console.Write("}\n\n");
    }
    public static void EnterValue(out int value)// функция считыватель действительных чисел 
    {
        while (!int.TryParse(Console.ReadLine(), out value))
        {
            Console.WriteLine("Неверный тип данных. Должно быть целым числом.");
        }
    }
}