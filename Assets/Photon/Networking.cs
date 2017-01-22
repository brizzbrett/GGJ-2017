using System;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/// <summary>
/// This script lets the player connect to the game.
/// </summary>
public class Networking : MonoBehaviour
{
    public bool AutoConnect = true;
    int roomNum = 1;
    string roomName = "MidnightWar";
    RoomOptions roomOptions;
    private bool conn = false;
    string gameScene = "sc2";//game scene

    private void OnGUI()
    {
        GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
    }
    public void Start()
    {
        PhotonNetwork.autoJoinLobby = false;
        PhotonNetwork.ConnectUsingSettings("v4.2");
        roomOptions = new RoomOptions() { IsVisible = false, MaxPlayers = 2 };
        print("trying to connect to server");
    }

    private void OnFailedToConnectToMasterServer(NetworkConnectionError error)
    {
        print("Failed to connect to master server. Error:" + error);
    }

    private void OnConnectedToMaster()
    {
        print("connected to server");
        conn = true;
        Connect(); //This is the auto-join for when there isn't an interface to use.
    }

    public void Connect()
    {
        if (conn == true)
        {
            conn = false;
            print("connecting to room");
            PhotonNetwork.JoinOrCreateRoom(roomName + roomNum, roomOptions, TypedLobby.Default);
        }
    }

    public void OnJoinedRoom()
    {
        print("joined room: " + PhotonNetwork.room.Name);
        checkPlayers();
    }

    public void OnPhotonPlayerConnected()
    {
        print("new player joined room");
        checkPlayers();
    }

    public void OnJoinRoomFailed()
    {
        print("room join failed, trying next room");
        roomNum++;
        PhotonNetwork.JoinOrCreateRoom(roomName + roomNum, roomOptions, TypedLobby.Default);
    }

    public void OnPhotonPlayerDisconnected()
    {
        if (PhotonNetwork.room != null)
        {
            PhotonNetwork.LeaveRoom();
        }
    }

    public void OnLeftRoom()
    {
        PhotonNetwork.Disconnect();
    }

    public void OnLeftLobby()
    {

        PhotonNetwork.Disconnect();
    }

    public void OnDisconnectedFromPhoton()
    {
        reload();
    }

    private void checkPlayers()
    {
        if (PhotonNetwork.room.PlayerCount == 2)
        {
            SceneManager.LoadScene(gameScene);
        }
    }

    public void reload()
    {
        StartCoroutine("reloadScene");
    }

    IEnumerator reloadScene()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("TitleScreen");
    }
}
