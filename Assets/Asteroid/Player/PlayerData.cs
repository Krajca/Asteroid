using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AsteroidGame.Player
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "AsteroidData/PlayerData")]
    public class PlayerData : ScriptableObject
    {
        public float TurnSpeed;
        public float Acceleration;
    }
}