using UnityEngine;
using UnityEngine.Events;

namespace CatPot.Framework.Utils.Pooling
{
    public class PoolableObject : MonoBehaviour
    {
        public UnityEvent OnEnabled;
        public UnityEvent OnRecycle;
        public UnityEvent OnReset; // Called automatically before returning an object to the pool

        private void OnEnable()
        {
            OnEnabled.Invoke();
        }

        /// <summary>
        /// Replace destroying the GameObject with this call
        /// </summary>
        public void Destroy()
        {
            OnRecycle.Invoke();
        }
    }
}