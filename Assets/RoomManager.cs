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
           var coin= Runner.Spawn(coinPrefab, coinSpawnPoint.transform.position, coinSpawnPoint.transform.rotation);
            coin.transform.position = coinSpawnPoint.transform.position;
            coin.transform.rotation = coinSpawnPoint.transform.rotation;
        }
    }
}
