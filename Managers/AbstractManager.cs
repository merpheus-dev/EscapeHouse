using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Subtegral.EscapeHouse.Managers
{
    public abstract class AbstractManager<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static T Instance;
        protected void Awake()
        {
            if (Instance == null)
            {
                Instance = FindObjectOfType<T>();
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

}