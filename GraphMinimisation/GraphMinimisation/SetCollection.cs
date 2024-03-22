namespace GraphMinimisation
{
    public class SetCollection
    {
        public List<SetGraph> setGraph;
        public SetCollection()
        {
            setGraph = new List<SetGraph>();
        }
        public SetGraph Find(int vertex)
        {
            foreach (SetGraph set in setGraph)
            {
                if (set.Contains(vertex)) 
                    return set;
            }
            return null!;
        }
        public void Add(Rib rib)
        {
            SetGraph setA = Find(rib.A);
            SetGraph setB = Find(rib.B);

            if (setA != null && setB == null)
            {
                setA.Add(rib);
            }
            else if (setA == null && setB != null)
            {
                setB.Add(rib);
            }
            else if (setA == null && setB == null)
            {
                SetGraph set = new SetGraph(rib);
                setGraph.Add(set);
            }
            else if (setA != null && setB != null)
            {
                if (setA != setB)
                {
                    setA.Union(setB, rib);
                    setGraph.Remove(setB);
                }
            }
        }
    }

}


