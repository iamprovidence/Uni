namespace SimpleSubstitutionCipher.Models.RandomGenerator
{
    public class BBS
    {
        // FIELDS
        int p;
        int q;
        int n;
        int x;
        int x0;

        int s;
        // CONSTRUCTORS
        public BBS(int p, int q, int x)
        {
            if (p % 4 != 3 || q % 4 != 3)
            {
                throw new System.ArgumentException("\"P\" and \"Q\" must be = 3mod4");
            }
            this.p = p;
            this.q = q;
            this.x = x;
            CalcX0();
        }
        private void CalcX0()
        {
            this.n = p * q;

            int gcd = Math.Algorithms.GCD(x, n);
            if (gcd != 1)
            {
                throw new System.ArgumentException(string.Format("Numbers \"X\" and \"N\" must be relatively simple\n X: {0} N: {1} GCD: {2}"
                                                                    , x, n, gcd));
            }
            this.x0 = (x*x) % n;

            this.Reset();
        }
        // PROPERTIES
        public int P
        {
            get
            {
                return p;
            }
            set
            {
                if (value % 4 != 3)
                {
                    throw new System.ArgumentException("\"P\" must be = 3mod4");
                }
                this.p = value;
                CalcX0();
            }
        }
        public int Q
        {
            get
            {
                return Q;
            }
            set
            {
                if (value % 4 != 3)
                {
                    throw new System.ArgumentException("\"Q\" must be = 3mod4");
                }
                this.q = value;
                CalcX0();
            }
        }
        public int X
        {
            get
            {
                return x;
            }
            set
            {
                this.x = value;
                CalcX0();
            }
        }
        // METHODS
        public byte[] GenerateByteArray(int length)
        {
            byte[] byteArr = new byte[length];
            
            for (int i = 0; i < byteArr.Length; ++i)
            {
                byteArr[i] = this.NextByte();
            }
            return byteArr;
        }
        public byte NextByte()
        {
            byte b = (byte)((s * s) % 2);
            s = (s * s) % n;
            return b;
        }
        public void Reset()
        {
            this.s = x0;
        }
    }
}
