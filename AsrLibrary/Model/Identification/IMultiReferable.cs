using System.Collections.Generic;
using ASR.Model.Documentation;

namespace ASR.Model.Identification
{
    /// <inheritdoc />
    /// <summary>
    /// Instances of this class can be referred to by their identifier (while adhering to
    /// namespace borders). They also may have a longName. But they are not considered
    /// to contribute substantially to the overall structure of an AUTOSAR description. In
    /// particular it does not contain other Referrables.
    /// </summary>
    public interface IMultiReferable : IReferable
    {
        /// <summary>
        /// This specifies the long name of the object. Long name is targeted to 
        /// human readers and acts like a headline.
        /// </summary>
        IReadOnlyCollection<MultiLanguageParagraph> LongName { get; }
    }
}