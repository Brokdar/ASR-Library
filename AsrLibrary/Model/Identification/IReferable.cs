namespace ASR.Model.Identification
{
    /// <summary>
    /// Instances of this class can be referred to by their identifier (while adhering to
    /// namespace borders).
    /// </summary>
    public interface IReferable
    {
        /// <summary>
        /// This specifies an identifying shortName for the object. It needs to be unique 
        /// within its context and is intended for humans but even more for technical reference.
        /// </summary>
        string ShortName { get; }
    }
}