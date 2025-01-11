using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplayerManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public NetworkRunner networkRunner;
    // Start is called before the first frame update
    void Start()
    {
        networkRunner = GetComponent<NetworkRunner>();
        StartGameArgs startGameArgs = new StartGameArgs();
        startGameArgs.GameMode = GameMode.Shared;
        startGameArgs.SessionName = "ScuolaDiComics1";
        startGameArgs.PlayerCount = 10;
        networkRunner.StartGame(startGameArgs);
        Instantiate(playerPrefab);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
