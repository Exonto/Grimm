using System;
using System.Runtime.Serialization;

namespace Grimm.Game.GameWorld
{
    [Serializable]
    internal class GridAlreadyHasLocationException : Exception
    {
        public GridAlreadyHasLocationException()
        {
        }
    }
}