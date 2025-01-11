using Cinemachine;
using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplayerManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public NetworkRunner networkRunner;
    public CinemachineVirtualCamera cinemachineVirtualCamera;
    // Start is called before the first frame update
    void Start()
    {
        Connect();
        SpawnLocalPlayer();
    }

    private void SpawnLocalPlayer()
    {
        GameObject player = Instantiate(playerPrefab);
        cinemachineVirtualCamera.Follow = player.transform.GetChild(0);
    }

    private void Connect()
    {
        networkRunner = GetComponent<NetworkRunner>();
        StartGameArgs startGameArgs = new StartGameArgs();
        startGameArgs.GameMode = GameMode.Shared;
        startGameArgs.SessionName = "ScuolaDiComics1";
        startGameArgs.PlayerCount = 10;
        networkRunner.StartGame(startGameArgs);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
