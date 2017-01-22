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


    public void Start()
    {
        PhotonNetwork.autoJoinLobby = false;
        PhotonNetwork.ConnectUsingSettings("v4.2");
        roomOptions = new RoomOptions() { IsVisible = false, MaxPlayers = 2 };
    }

    public void Connect()
    {
        PhotonNetwork.JoinOrCreateRoom(roomName + roomNum, roomOptions, TypedLobby.Default);
    }

    public void OnJoinedRoom()
    {
        checkPlayers();
    }

    public void OnPhotonPlayerConnected()
    {
        checkPlayers();
    }

    public void OnJoinRoomFailed()
    {
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
            //Go to the new scene to play the game
        }
    }

    public void reload()
    {
        StartCoroutine("reloadScene");
    }

    IEnumerator reloadScene()
    {
        yield return new WaitForSeconds(3);
        SceneManager.SetActiveScene(SceneManager.GetActiveScene());
    }
}
