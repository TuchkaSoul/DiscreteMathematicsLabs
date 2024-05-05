namespace FiniteAutomaton
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Насторойка автомата
            // Алфавит
            char[] alphabet = { 'a', 'b', 'c', 'd' };
            FiniteAutomaton fa = new FiniteAutomaton(alphabet);

            // Определите переход в состояние
            fa.AddTransition(0, 'a', 1);
            fa.AddTransition(0, 'b', 0);
            fa.AddTransition(0, 'c', 0);
            fa.AddTransition(0, 'd', 0);

            fa.AddTransition(1, 'a', 1);
            fa.AddTransition(1, 'b', 2);
            fa.AddTransition(1, 'c', 0);
            fa.AddTransition(1, 'd', 0);

            fa.AddTransition(2, 'a', 0);
            fa.AddTransition(2, 'b', 0);
            fa.AddTransition(2, 'd', 0);

            // Установите начальное и конечное состояния
            fa.InitialState = 0;
            fa.FinalStates.Add(0);
            fa.FinalStates.Add(1);
            fa.FinalStates.Add(2);
            #endregion

            #region Демонстрационные тесты
            Console.WriteLine("[ Положительные тесты ]\n");
            Check(fa, "");
            Check(fa, "a");
            Check(fa, "d");
            Check(fa, "ab");
            Check(fa, "bbbb");
            Check(fa, "ababab");
            Check(fa, "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            Console.WriteLine("[ Отрицательные тесты ]\n");
            Check(fa, " ");
            Check(fa, "x");
            Check(fa, "abc");
            Check(fa, "aaaabca");
            Check(fa, "bbabbcabcaaa");
            Check(fa, "ab ac");
            Check(fa, "abca");
            Check(fa, null!);
            #endregion

            Console.WriteLine("[ Тесты вручную ]\n");
            Console.WriteLine("Для выхода нажмите \"\x1B[33mesc\x1B[0m\", любую кнопку для продолжения.");
            while (Console.ReadKey(true).Key !=ConsoleKey.Escape)
            {
                Console.WriteLine("Введите слово:");
                Check(fa, Console.ReadLine()!);
                Console.WriteLine("Для выхода нажмите \"\x1B[33mesc\x1B[0m\"");
            }
        }
        public static void Check(FiniteAutomaton fa, string word)
        {
            bool accepted = fa.Accepts(word);
            Console.WriteLine($"Это слово {(accepted ? $"\"\x1B[32m{word}\x1B[0m\"" : $"\"\x1B[31m{word}\x1B[0m\"")} {(accepted ? "" : "не ")}принимается автоматом.\n");
        }
    }
    class FiniteAutomaton
    {
        private int initialState;
        private HashSet<int> finalStates;
        private Dictionary<int, Dictionary<char, int>> transitionFunction;

        public FiniteAutomaton(char[] alphabet)
        {
            transitionFunction = new Dictionary<int, Dictionary<char, int>>();
            finalStates=new HashSet<int>();
            foreach (char c in alphabet)
            {
                transitionFunction.Add(c, new Dictionary<char, int>());
            }
        }
        public int InitialState
        {
            get { return initialState; }
            set { initialState = value; }
        }
        public HashSet<int> FinalStates
        {
            get { return finalStates; }
            set { finalStates = value; }
        }
        public void AddTransition(int state, char input, int nextState)
        {
            if (!transitionFunction.ContainsKey(state))
            {
                transitionFunction.Add(state, new Dictionary<char, int>());
            }
            transitionFunction[state].Add(input, nextState);
        }
        public bool Accepts(string word)
        {
            if (word is null) return false;
            int currentState = initialState;
            foreach (char c in word)
            {
                if (!transitionFunction[currentState].TryGetValue(c, out int nextState))
                {
                    return false;
                }                
                currentState = nextState;
            }
            return finalStates.Contains(currentState);
        }
    }
}