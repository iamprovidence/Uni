using System.Numerics;

using RSA_ElGamal.Model;
using RSA_ElGamal.Model.RSA;

namespace RSA_ElGamal.ViewModel
{
    class ApplicationViewModel : System.ComponentModel.INotifyPropertyChanged
    {
        // CONST
        readonly int MIN_PQ = 1000;
        readonly int MAX_PQ = 100000;
        readonly int MAX_E = 1000;

        readonly string latinLatters = "abcdefghijklmnopqrstuvwxyz";
        readonly string ukrainianLatters = "абвгґдеєжзиіїйклмнопрстуфхцчшщьюя";
        readonly string symbols = " .,!?*+&:;-_—\'\"\\\r\n[]";
        readonly string numbers = "0123456789";

        // FIELDS
        System.Random random;
        Algorithms algorithms;
        Alphabet alphabet;

        string text;
        string encryptedText;
        string decryptedText;

        BigInteger? p;
        BigInteger? q;
        BigInteger? e;
        BigInteger? d;

        Receiver alice;
        Sender bob;

        string hashA;
        string hashB;

        string digitalSignatureA;
        string digitalSignatureB;

        #region Commands
        RelayCommand loadText;
        RelayCommand encryptText;

        RelayCommand saveEncryptedText;
        RelayCommand decryptText;

        RelayCommand saveDecryptedText;

        RelayCommand generatePQ;
        RelayCommand confirmPQ;
        RelayCommand generateE;
        RelayCommand confirmE;
        RelayCommand sendEN;
        #endregion
        // EVENT
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        // CONSTRUCOTORS
        public ApplicationViewModel()
        {
            random = new System.Random();
            algorithms = new Algorithms();
            alphabet = new Alphabet(string.Concat(latinLatters, ukrainianLatters, symbols, numbers));

            text = null;
            encryptedText = null;
            decryptedText = null;

            p = null;
            q = null;
            e = null;
            d = null;

            alice = null;
            bob = null;

            hashA = null;
            hashB = null;

            digitalSignatureA = null;
            digitalSignatureB = null;

            #region Commands
            loadText = null;
            encryptText = new RelayCommand(EncryptTextMethod, CanEncodeText);
            saveEncryptedText = null;
            decryptText = new RelayCommand(DecryptTextMethod, CanDecodeText);
            saveDecryptedText = null;

            generatePQ = new RelayCommand(GeneratePQMethod);
            confirmPQ = new RelayCommand(ConfirmPQMethod, CanConfirmPQ);

            generateE = new RelayCommand(GenerateEMethod, CanGenerateE);
            confirmE = new RelayCommand(ConfirmEMethod, CanConfirmE);
            sendEN = new RelayCommand(SendENMethod, CanSendEN);
            #endregion
        }


        // PROPERTIES
        public string Text
        {
            get
            {
                return text;
            }
            set
            {
                text = value;
                OnPropertyChanged();
            }
        }
        public string EncryptedText
        {
            get
            {
                return encryptedText;
            }
            set
            {
                encryptedText = value;
                OnPropertyChanged();
            }
        }
        public string DecryptedText
        {
            get
            {
                return decryptedText;
            }
            set
            {
                decryptedText = value;
                OnPropertyChanged();
            }
        }

        public BigInteger? P
        {
            get
            {
                return p;
            }
            set
            {
                p = value;
                CleanSides();
                OnPropertyChanged();
            }
        }
        public BigInteger? Q
        {
            get
            {
                return q;
            }
            set
            {
                q = value;
                CleanSides();
                OnPropertyChanged();
            }
        }
        public BigInteger? N
        {
            get
            {
                return alice?.N;
            }            
        }
        public BigInteger? Phi
        {
            get
            {
                return alice?.Phi;
            }
        }
        public BigInteger? E
        {
            get
            {
                return e;
            }
            set
            {
                e = value;                
                OnPropertyChanged();
            }           
        }
        public BigInteger? D
        {
            get
            {
                return d;
            }
            set
            {
                d = value;
                OnPropertyChanged();
            }
        }

        public string HashA
        {
            get
            {
                return hashA;
            }
            set
            {
                hashA = value;
                OnPropertyChanged();

                OnPropertyChanged(nameof(IsDigitalSignatureEqual));
            }
        }
        public string HashB
        {
            get
            {
                return hashB;
            }
            set
            {
                hashB = value;
                OnPropertyChanged();

                OnPropertyChanged(nameof(IsDigitalSignatureEqual));
            }
        }
        public string DigitalSignatureA
        {
            get
            {
                return digitalSignatureA;
            }
            set
            {
                digitalSignatureA = value;
                OnPropertyChanged();

                OnPropertyChanged(nameof(IsDigitalSignatureEqual));
            }
        }
        public string DigitalSignatureB
        {
            get
            {
                return digitalSignatureB;
            }
            set
            {
                digitalSignatureB = value;
                OnPropertyChanged();

                OnPropertyChanged(nameof(IsDigitalSignatureEqual));
            }
        }
        public bool? IsDigitalSignatureEqual
        {
            get
            {
                if (DigitalSignatureA == null && hashA == null) return null;
                return DigitalSignatureA == hashA;
            }
        }
        #region Command
        // lazy loading became truth
        public RelayCommand LoadText
        {
            get
            {
                if (loadText == null)
                {
                    loadText = new RelayCommand(LoadTextMethod);
                }
                return loadText;
            }
        }
        public RelayCommand EncryptText => encryptText;
        public RelayCommand SaveEncryptedText
        {
            get
            {
                if (saveEncryptedText == null)
                {
                    saveEncryptedText = new RelayCommand(SaveTextMethod, CanSaveText);
                }
                return saveEncryptedText;
            }
        }
        public RelayCommand DecryptText => decryptText;

        public RelayCommand SaveDecryptedText
        {
            get
            {
                if (saveDecryptedText == null)
                {
                    saveDecryptedText = new RelayCommand(SaveTextMethod, CanSaveText);
                }
                return saveDecryptedText;
            }
        }
        public RelayCommand GeneratePQ => generatePQ;
        public RelayCommand ConfirmPQ => confirmPQ;
        public RelayCommand GenerateE => generateE;
        public RelayCommand ConfirmE => confirmE;
        public RelayCommand SendEN => sendEN;
        #endregion
        // METHODS
        private void GeneratePQMethod(object obj)
        {            
            do
            {
                p = random.Next(MIN_PQ, MAX_PQ);
            } while (!algorithms.IsPrime(p.Value)); 

            do
            {
                q = random.Next(MIN_PQ, MAX_PQ);
            } while (!algorithms.IsPrime(q.Value));

            OnPropertyChanged(nameof(P));
            OnPropertyChanged(nameof(Q));
        }

        private void ConfirmPQMethod(object obj)
        {
            try
            {
                alice = new Receiver(alphabet, p.Value, q.Value);
            }
            catch (System.Exception ex)
            {
                OnErrorMessage(ex.Message);
                alice = null;
            }

            OnPropertyChanged(nameof(N));
            OnPropertyChanged(nameof(Phi));
        }

        private void GenerateEMethod(object obj)
        {
            int rand;
            do
            {
                rand = random.Next(MAX_E);
            } while (!algorithms.IsCoprime(rand, alice.Phi));

            E = rand;
            D = null;
            bob = null;
        }

        private void ConfirmEMethod(object obj)
        {
            try
            {
                alice.E = e.Value;
            }
            catch (System.Exception ex)
            {
                OnErrorMessage(ex.Message);
                return;
            }

            D = alice.D;

            CleanSignature();
            OnPropertyChanged(nameof(D));
        }
        private void SendENMethod(object obj)
        {
            bob = new Sender(alphabet, E.Value, N.Value);
        }

        

        private void LoadTextMethod(object obj)
        {
            Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog()
            {
                Filter = "Txt file (*.txt)|*.txt",
                DefaultExt = ".txt"
            };
            
            if (ofd.ShowDialog() == true)
            {
                Text = System.IO.File.ReadAllText(ofd.FileName);
            }
        }
        private void EncryptTextMethod(object obj)
        {
            Text = Alphabet.TextAdapter(Text).Trim();

            BigInteger hashB = algorithms.HashFunction(alphabet, Text, bob.N);
            HashB = hashB.ToString();
            DigitalSignatureB = algorithms.CalcDigitalSignature(hashB, bob.E, bob.N).ToString();

            EncryptedText = bob.Encrypt(Text);
        }

        private void DecryptTextMethod(object obj)
        {
            try
            {
                DecryptedText = alice.Decode(encryptedText);
            }
            catch (System.Exception ex)
            {
                OnErrorMessage(ex.Message);
            }

            if (DigitalSignatureB != null)
            {
                BigInteger hashA = algorithms.HashFunction(alphabet, DecryptedText, alice.N);
                HashA = hashA.ToString();
                DigitalSignatureA = algorithms.CalcDigitalSignature(BigInteger.Parse(digitalSignatureB), alice.D, alice.N).ToString();
            }        
        }
        private void SaveTextMethod(object obj)
        {
            Microsoft.Win32.SaveFileDialog sfd = new Microsoft.Win32.SaveFileDialog()
            {
                Filter = "Txt file (*.txt)|*.txt",
                DefaultExt = ".txt"
            };

            if (sfd.ShowDialog() == true)
            {
                System.IO.File.WriteAllText(path: sfd.FileName, contents: obj.ToString());
            }
        }
        // RESTRICTION METHOD
        private bool CanConfirmPQ(object obj)
        {
            return p.HasValue && q.HasValue;
        }
        private bool CanGenerateE(object obj)
        {
            return alice != null;
        }
        private bool CanConfirmE(object obj)
        {
            return alice != null && e.HasValue;
        }
        private bool CanSendEN(object obj)
        {
            return e.HasValue && d.HasValue && alice != null;
        }

        private bool CanEncodeText(object obj)
        {
            return !string.IsNullOrWhiteSpace(text) && bob != null && d != null;
        }
        private bool CanSaveText(object obj)
        {
            string text = obj as string;
            return text != null && !string.IsNullOrWhiteSpace(text);
        }
        private bool CanDecodeText(object obj)
        {
            return !string.IsNullOrWhiteSpace(encryptedText) && alice != null;
        }
        // OTHER METHODS
        private void CleanAll()
        {
            CleanText();

            CleanPQ();

            CleanSides();
        }
        private void CleanText()
        {
            Text = string.Empty;
            EncryptedText = string.Empty;
            DecryptedText = string.Empty;
        }
        private void CleanPQ()
        {
            p = null;
            q = null;
        }
        private void CleanSides()
        {
            alice = null;
            bob = null;
            e = null;
            d = null;

            CleanSignature();

            OnPropertyChanged(nameof(Phi));
            OnPropertyChanged(nameof(N));
            OnPropertyChanged(nameof(E));
            OnPropertyChanged(nameof(D));
        }
        private void CleanSignature()
        {
            DigitalSignatureA = null;
            DigitalSignatureB = null;
            HashA = null;
            HashB = null;
        }
        protected void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName]string property = "")
        {
            PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(property));
        }
        protected void OnErrorMessage(string message, string header = "Error")
        {
            System.Windows.MessageBox.Show(message, header,
                System.Windows.MessageBoxButton.OK, 
                System.Windows.MessageBoxImage.Error);
        }
    }
}
