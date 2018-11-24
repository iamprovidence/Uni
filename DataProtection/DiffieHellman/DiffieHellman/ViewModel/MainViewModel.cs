using System.Numerics;

namespace DiffieHellman.ViewModel
{
    class MainViewModel : System.ComponentModel.INotifyPropertyChanged
    {
        // CONST
        readonly int P_MIN_VALUE = 1000;
        readonly int P_MAX_VALUE = 100000;
        readonly int POWER_MAX_VALUE = 5000;

        // FIELDS
        System.Random rand;

        Models.Side A;
        Models.Side B;
        Models.Algorithm algo;

        BigInteger? p;
        BigInteger? a;
        uint? smallX;
        uint? smallY;
        BigInteger? bigX;
        BigInteger? bigY;
        BigInteger? k1;
        BigInteger? k2;

        #region Commands
        RelayCommand generatePA;
        RelayCommand sendPA;
        RelayCommand generateX;
        RelayCommand generateY;
        RelayCommand sendX;
        RelayCommand sendY;
        #endregion
        
        // EVENT
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        // CONSTRUCTORS
        public MainViewModel()
        {
            rand = new System.Random();

            A = null;
            B = null;
            algo = new Models.Algorithm();

            p = null;
            a = null;
            smallX = null;
            smallY = null;
            bigX = null;
            bigY = null;
            k1 = null;
            k2 = null;

            #region Commands
            generatePA = new RelayCommand(GeneratePAMethod);
            sendPA = new RelayCommand(SendPAMethod, IsPSetted);
            generateX = new RelayCommand(GenerateXMethod, IsABSetted);
            generateY = new RelayCommand(GenerateYMethod, IsABSetted);
            sendX = new RelayCommand(SendXMethod, IsABSetted);
            sendY = new RelayCommand(SendYMethod, IsABSetted);
            #endregion
        }

        // PROPERTIES

        public BigInteger? ParamP
        {
            get
            {
                return p;
            }
            set
            {
                if (value.HasValue && (value.Value < P_MIN_VALUE || value.Value > P_MAX_VALUE))
                {
                    ShowMessage($"Should be in range of [{P_MIN_VALUE};{P_MAX_VALUE}]");
                    return;
                }

                if (value.HasValue && !algo.IsPrime(value.Value))
                {
                    ShowMessage("Should be prime");
                    return;
                }

                p = value;
                if (value.HasValue)
                {
                    ParamA = algo.FindPrimitiveRoot(p.Value);
                    ClearValue();
                }
                OnPropertyChanged();
            }
        }
        public BigInteger? ParamA
        {
            get
            {
                return a;
            }
            set
            {
                a = value;
                OnPropertyChanged();
            }
        }
        public uint? SmallX
        {
            get
            {
                return smallX;
            }
            set
            {
                smallX = value;
                if (smallX.HasValue) A.NumPower = smallX.Value;
                ClearValue();
                OnPropertyChanged();
            }
        }
        public uint? SmallY
        {
            get
            {
                return smallY;
            }
            set
            {
                smallY = value;
                if (smallY.HasValue) B.NumPower = smallY.Value;
                ClearValue();
                OnPropertyChanged();
            }
        }
        public BigInteger? BigX
        {
            get
            {
                return bigX;
            }
            set
            {
                bigX = value;
                if (value.HasValue)
                {
                    K2 = B.CalculateKey(bigX.Value);
                }
                OnPropertyChanged();
            }
        }
        public BigInteger? BigY
        {
            get
            {
                return bigY;
            }
            set
            {
                bigY = value;
                if (value.HasValue)
                {
                    K1 = A.CalculateKey(bigY.Value);
                }
                OnPropertyChanged();
            }
        }
        public BigInteger? K1
        {
            get
            {
                return k1;
            }
            set
            {
                k1 = value;
                OnPropertyChanged();

                OnPropertyChanged(nameof(IsKeyEqual));
            }
        }
        public BigInteger? K2
        {
            get
            {
                return k2;
            }
            set
            {
                k2 = value;
                OnPropertyChanged();

                OnPropertyChanged(nameof(IsKeyEqual));
            }
        }
        public bool? IsKeyEqual
        {
            get
            {
                if (k1 == null && k2 == null) return null;
                return k1.Equals(k2);
            }
        }

        #region Commands
        public RelayCommand GeneratePA => generatePA;
        public RelayCommand SendPA => sendPA;
        public RelayCommand GenerateX => generateX;
        public RelayCommand GenerateY => generateY;
        public RelayCommand SendX => sendX;
        public RelayCommand SendY => sendY;
        #endregion
        
        // METHODS

        // COMMAND METHODS
        private void GeneratePAMethod(object obj)
        {
            int p;
            do
            {
                p = rand.Next(P_MIN_VALUE, P_MAX_VALUE);
            } while (!algo.IsPrime(p));
            ParamP = p;

            ClearAll();
        }
        private void SendPAMethod(object obj)
        {
            A = new Models.Side(p.Value, a.Value);
            B = new Models.Side(p.Value, a.Value);

            SmallX = A.NumPower;
            SmallY = B.NumPower;

            ClearValue();
        }
        private void GenerateXMethod(object obj)
        {
            SmallX = (uint)rand.Next(POWER_MAX_VALUE);

            ClearValue();
        }
        private void GenerateYMethod(object obj)
        {
            SmallY = (uint)rand.Next(POWER_MAX_VALUE);

            ClearValue();
        }
        private void SendXMethod(object obj)
        {
            BigX = A.CalculateValueForOtherSide();

        }
        private void SendYMethod(object obj)
        {
            BigY = B.CalculateValueForOtherSide();
        }
        // COMMAND RESTRICTION METHODS
        private bool IsABSetted(object obg)
        {
            return A != null && B != null;
        }
        private bool IsPSetted(object obg)
        {
            return ParamP.HasValue;
        }
        // OTHER METHODS
        private void ShowMessage(string message, string header = "Error")
        {
            new View.MessageBox
            {
                HeaderText = header,
                ContentText = message
            }.ShowDialog();
        }
        private void ClearAll()
        {
            A = null;
            B = null;

            SmallX = null;
            SmallY = null;

            ClearValue();
        }
        private void ClearValue()
        {
            BigX = null;
            BigY = null;

            K1 = null;
            K2 = null;

            OnPropertyChanged(nameof(IsKeyEqual));
        }
        protected void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName]string property = "")
        {
            PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(property));
        }
    }
}
