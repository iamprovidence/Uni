namespace FiniteElementMethod.Models.Structs
{
    /// <summary>
    /// Helps to store reference
    /// </summary>
    /// <typeparam name="T">
    /// A type on which instance reference is stored
    /// </typeparam>
    sealed class Reference<T>
    {
        public T Value { get; set; }
    }
}
