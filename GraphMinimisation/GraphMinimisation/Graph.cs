using System.Collections;

namespace GraphMinimisation
{
    public class Graph : IEnumerable<Rib>
    {
        public List<Rib> ribs;
        public List<List<Rib>> grafs;
        public Graph(int capacity)
        {
            grafs = new List<List<Rib>>();
            for (int i = 0; i < capacity + 1; i++)
            {
                grafs.Add(new List<Rib>());
            }
            ribs = new List<Rib>();
        }
        public Graph(Graph graf)
        {
            this.ribs = graf.ribs;
            this.grafs = graf.grafs;
        }
        public Graph(Rib val, int n = 10)
        {
            grafs = new List<List<Rib>>();
            for (int i = 0; i < n + 1; i++)
            {
                grafs.Add(new List<Rib>());
            }
            grafs[val.A].Add(val);
            grafs[val.B].Add(val);
            ribs = new List<Rib>() { val };
        }
        public Graph(int[,] matrix)
        {
            ribs = new List<Rib>();
            grafs = new List<List<Rib>>();
            for (int i = 0; i < matrix.GetLength(0) + 1; i++)
            {
                grafs.Add(new List<Rib>());
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = i + 1; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] != 0)
                    {
                        grafs[i].Add(new Rib(i, j, matrix[i, j]));
                        grafs[j].Add(new Rib(j, i, matrix[i, j]));
                        ribs.Add(new Rib(i, j, matrix[i, j]));
                    }
                }
                grafs[i].Reverse();
            }
        }
        public IEnumerator<Rib> Enumerator => ribs.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => ribs.GetEnumerator();
        public void Sort(IComparer<Rib> comparer)
        {
            ribs.Sort(comparer);
        }
        public void Sort()=>Sort(new RibCompareW());        
        public void Add(Graph graph)
        {
            foreach (Rib edge in graph)
            {
                ribs.Add(edge);
            }
        }
        public void Add(List<Rib> graph)
        {
            foreach (Rib edge in graph)
            {
                ribs.Add(edge);
            }
        }
        public int Lenght()
        {
            int weight = 0;
            foreach (Rib rib in ribs)
            {
                weight += rib.weight;
            }
            return weight;
        }
        public void Remove(Rib edge)
        {
            ribs.Remove(edge);
            grafs[edge.A].Remove(edge);
            grafs[edge.B].Remove(edge);

        }
        public void Add(Rib edge)
        {
            ribs.Add(edge);
            grafs[edge.A].Add(edge);
            grafs[edge.B].Add(edge);
        }
        public void Print()
        {
            foreach (var item in ribs)
            {
                item.Print();
            }
            Console.WriteLine();
        }
        public Graph FindMinimumKraskala()
        {
            Sort();
            var disjointSets = new SetCollection();
            foreach (Rib r in this.ribs)
            {
                disjointSets.Add(r);
            }
            return disjointSets.setGraph.First().setGraph;
        }
        public Graph FindMinimumPrim(int starter = 1)
        {
            if (starter <= 0 || starter >= grafs.Count - 1)
            {
                Console.WriteLine( "Такой вершины нет\nВыбрана:Вершина 1.  " );
                starter = 1;
            }                            
            bool[] selected = new bool[grafs.Count - 1];
            selected[starter - 1] = true;
            grafs[starter - 1].Sort(new RibCompareW());
            selected[grafs[starter - 1].First().B] = true;
            var outGraph = new Graph(grafs.Count - 1);
            var inGraph = new Graph(grafs[starter - 1].First(), grafs.Count - 1);
            outGraph.Add(grafs[starter - 1]);
            outGraph.Add(grafs[grafs[starter - 1].First().B]);
            int k = 0;
            while (inGraph.ribs.Count < 9)
            {
                outGraph.Sort();
                foreach (var item in outGraph)
                {
                    if (!selected[item.B])
                    {
                        inGraph.Add(item);
                        outGraph.Add(grafs[item.B]);
                        selected[item.B] = true;
                        break;
                    }
                }                
            }
            Console.WriteLine(k);
            return inGraph;
        }
        public IEnumerator<Rib> GetEnumerator()
        {
            return ((IEnumerable<Rib>)ribs).GetEnumerator();
        }
        public class RibCompareW : IComparer<Rib>
        {
            int IComparer<Rib>.Compare(Rib? x, Rib? y)
            {
                if (y is null
                    && x is null)
                    return 0;
                if (y is null)
                    return 1;
                if (x is null)
                    return -1;
                if (x.weight == y.weight)
                    return x!.B.CompareTo(y!.B);
                return x!.weight.CompareTo(y!.weight);
            }
        }
        public class RibCompareA : IComparer<Rib>
        {
            int IComparer<Rib>.Compare(Rib? x, Rib? y) => x!.A > y!.A ? 1 : x.A == y.A ? 0 : -1;
        }
        public class RibCompareB : IComparer<Rib>
        {
            int IComparer<Rib>.Compare(Rib? x, Rib? y) => x!.B > y!.B ? 1 : x.B == y.B ? 0 : -1;
        }
    }

}


