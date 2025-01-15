using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : NetworkBehaviour
{
    public NetworkObject coinPrefab;

    public void SpawnCoins()
    {
        foreach(CoinSpawnPoint coinSpawnPoint in FindObjectsOfType<CoinSpawnPoint>())
        {
            Runner.Spawn(coinPrefab, coinSpawnPoint.transform.position, coinSpawnPoint.transform.rotation);
        }
    }
}
