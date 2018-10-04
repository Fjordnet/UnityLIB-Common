using System;

namespace Fjord.Common.Types
{
    [Serializable]
    public struct Bool3
    {
        public bool X;
        public bool Y;
        public bool Z;

        public Bool3(bool x, bool y, bool z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public bool AnyTrue()
        {
            return X || Y || Z;
        }
        
        public bool AllTrue()
        {
            return X && Y && Z;
        }
    }
}