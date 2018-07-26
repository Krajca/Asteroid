using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AsteroidGame.Input
{
    public abstract class Input : MonoBehaviour
    {
        protected bool canPassInput;

        public void SwitchInputTo(bool i)
        {
            canPassInput = i;
        }
    }

    
}