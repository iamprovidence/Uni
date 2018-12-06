namespace SimpleSubstitutionCipher.Models.Interfaces
{
    public interface ICypher
    {
        Classes.Alphabet Alphabet { get; set; }
        string Encrypt(string text);
        string Decrypt(string text);
    }
}
