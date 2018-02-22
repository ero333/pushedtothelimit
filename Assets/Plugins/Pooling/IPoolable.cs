using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CatPot.Framework.Utils.Pooling
{
    public interface IPoolable
    {
        void Initialize();
        void OnRecycle();
        void Destroy();
    }
}