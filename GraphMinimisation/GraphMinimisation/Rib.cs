namespace GraphMinimisation
{
    public class Rib 
    {
        public int A;
        public int B;
        public int weight;
        public Rib(int A, int B, int len)
        {
            this.A = A; this.B = B; this.weight = len;
        }
        public void Print()
        {
            Console.WriteLine($"Ребро: X{A + 1} -- X{B + 1} Длина: {weight}");
        }
        public int CompareTo(Rib other)
        {
            if (other == null)
                return 1;
            return weight.CompareTo(other.weight);
        }
        public Rib Reverse()
        {
            A = A + B;
            B = A - B;
            A = A - B;
            return this;
        }        
    }

}


