using Fusion;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RoomManager : NetworkBehaviour
{

    [Networked, Capacity(64), OnChangedRender(nameof(OnWinnerTextChanged))]
    public string WinnerText { get; set; }

    public NetworkObject coinPrefab;
    public TextMeshProUGUI winnerTMP;

    public void OnWinnerTextChanged()
    {
        winnerTMP.text = WinnerText;
    }

    public void DelayedSpawnCoins()
    {
        Invoke(nameof(SpawnCoins), 0.5f);

    }

    public void SpawnCoins()
    {
        foreach (CoinSpawnPoint coinSpawnPoint in FindObjectsOfType<CoinSpawnPoint>())
        {
            var coin = Runner.Spawn(coinPrefab);

            coin.transform.position = coinSpawnPoint.transform.position;
            coin.transform.rotation = coinSpawnPoint.transform.rotation;
        }
    }

    internal void CheckEndGame()
    {
        if (HasStateAuthority)
        {
           if(FindObjectsOfType<Coin>().Length == 0)
            {
                WinnerText = "Gioco finito";
            }
        }
    }
}
