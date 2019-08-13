using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fjord.Common.Types
{
    public abstract class DataEntry : IDataEntry
    {
        public virtual string Id { get { return ""; } }

        public override bool Equals(object obj)
        {
            DataEntry other = obj as DataEntry;
            if (null == other)
                return false;
            return Id == other.Id;
        }
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}