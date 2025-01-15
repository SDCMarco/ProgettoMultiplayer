using Cinemachine;
using Fusion;
using Fusion.Sockets;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplayerManager : MonoBehaviour , INetworkRunnerCallbacks
{
    public NetworkObject playerPrefab;
    public NetworkRunner networkRunner;
    public CinemachineVirtualCamera cinemachineVirtualCamera;
    public NetworkObject roomManagerPrefab;

    // Start is called before the first frame update
    void Start()
    {
        Connect();   
    }

    private void SpawnLocalPlayer()
    {
        NetworkObject player = networkRunner.Spawn(playerPrefab, new Vector3(0,0,0),Quaternion.identity);
        cinemachineVirtualCamera.Follow = player.transform.GetChild(0);
    }

    private void Connect()
    {
        networkRunner = GetComponent<NetworkRunner>();

        StartGameArgs startGameArgs = new StartGameArgs();
        startGameArgs.GameMode = GameMode.Shared;
        startGameArgs.SessionName = "ScuolaDiComics2";
        startGameArgs.PlayerCount = 10;

        networkRunner.StartGame(startGameArgs);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnObjectExitAOI(NetworkRunner runner, NetworkObject obj, PlayerRef player)
    {

    }

    public void OnObjectEnterAOI(NetworkRunner runner, NetworkObject obj, PlayerRef player)
    {

    }

    public void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
    {

    }

    public void OnPlayerLeft(NetworkRunner runner, PlayerRef player)
    {

    }

    public void OnInput(NetworkRunner runner, NetworkInput input)
    {

    }

    public void OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input)
    {

    }

    public void OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason)
    {

    }

    public void OnConnectedToServer(NetworkRunner runner)
    {
        Debug.Log("Connesso!");
        SpawnLocalPlayer();
        if (runner.IsSharedModeMasterClient)
        {
            SpawnRoomManager();
        }
    }

    private void SpawnRoomManager()
    {
        NetworkObject roomManager = networkRunner.Spawn(roomManagerPrefab);
        roomManager.GetComponent<RoomManager>().DelayedSpawnCoins();
    }

    public void OnDisconnectedFromServer(NetworkRunner runner, NetDisconnectReason reason)
    {

    }

    public void OnConnectRequest(NetworkRunner runner, NetworkRunnerCallbackArgs.ConnectRequest request, byte[] token)
    {

    }

    public void OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason)
    {

    }

    public void OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message)
    {

    }

    public void OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList)
    {

    }

    public void OnCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data)
    {

    }

    public void OnHostMigration(NetworkRunner runner, HostMigrationToken hostMigrationToken)
    {

    }

    public void OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ReliableKey key, ArraySegment<byte> data)
    {

    }

    public void OnReliableDataProgress(NetworkRunner runner, PlayerRef player, ReliableKey key, float progress)
    {

    }

    public void OnSceneLoadDone(NetworkRunner runner)
    {

    }

    public void OnSceneLoadStart(NetworkRunner runner)
    {

    }
}
