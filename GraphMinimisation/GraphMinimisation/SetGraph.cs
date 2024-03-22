namespace GraphMinimisation
{
    public class SetGraph
    {
        public Graph setGraph;
        public List<int> Vertices;
        public SetGraph(Rib rib)
        {
            setGraph = new Graph(rib);
            Vertices = new List<int>();
            Vertices.Add(rib.A);
            Vertices.Add(rib.B);
        }
        public void Union(SetGraph set, Rib ribConect)
        {
            setGraph.Add(set.setGraph);
            Vertices.AddRange(set.Vertices);
            setGraph.Add(ribConect);
        }
        public void Add(Rib rib)
        {
            setGraph.Add(rib);
            Vertices.Add(rib.A);
            Vertices.Add(rib.B);
        }
        public bool Contains(int vertex)
        {
            return Vertices.Contains(vertex);
        }
    }

}


