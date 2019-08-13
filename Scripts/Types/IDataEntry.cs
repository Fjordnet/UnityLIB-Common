using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fjord.Common.Types
{
    /// <summary>
    /// Common interface for all DataEntry subclasses
    /// </summary>
    public interface IDataEntry
    {
        string Id { get; }
    }
}