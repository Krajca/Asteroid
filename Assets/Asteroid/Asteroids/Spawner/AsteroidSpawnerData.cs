using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AsteroidSpawnerData", menuName = "AsteroidData/AsteroidSpawnerData")]
public class AsteroidSpawnerData : ScriptableObject
{
    public int bigAsteroidPooledAmount;
    public bool colorIsRandom = false;
    public Color thisColor = Color.white;

    public AsteroidTypeData[] AsteroidTypes;
}
