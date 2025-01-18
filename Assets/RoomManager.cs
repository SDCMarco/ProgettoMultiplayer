using Fusion;
using StarterAssets;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class RoomManager : NetworkBehaviour
{

    [Networked, Capacity(64), OnChangedRender(nameof(OnWinnerTextChanged))]
    public string WinnerText { get; set; }

    public NetworkObject coinPrefab;
    public TextMeshProUGUI winnerTMP;

    public override void Spawned()
    {
        base.Spawned();
        OnWinnerTextChanged();
    }

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
                List<ThirdPersonController> orderedPlayerList = FindObjectsOfType<ThirdPersonController>().ToList().OrderBy(x => x.CollectedCoins).ToList();
                int bestScore = orderedPlayerList.Last().CollectedCoins;

                List<ThirdPersonController> winners = orderedPlayerList.FindAll(x => x.CollectedCoins == bestScore);

                if(winners.Count == 1)
                {
                    WinnerText = "Gioco finito. Ha vinto: " + winners.First().Object.StateAuthority.ToString();
                }
                else
                {
                    string winnersString = "";
                    foreach(ThirdPersonController tpc in winners)
                    {
                        winnersString += tpc.Object.StateAuthority.ToString() + "\n";
                    }
                    WinnerText = "Gioco finito. Hanno vinto:"+ winnersString;
                }
            }
        }
    }
}
