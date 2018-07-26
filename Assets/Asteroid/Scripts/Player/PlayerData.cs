using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AsteroidGame.Player
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "AsteroidData/PlayerData")]
    public class PlayerData : ScriptableObject
    {
        public float ShipTurnSpeed = 4f;
        public float ShipAcceleration = 1f;

        public int PlayerLives = 3;
        public float PlayerRespawnTime = 1f;
    }
}