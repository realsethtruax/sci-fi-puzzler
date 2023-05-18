using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public Dictionary<string, Room> rooms;

    public Room GetRoom(string roomName) {
        if (rooms[roomName])
        {
            return rooms[roomName];
        }
        else { 
            Debug.LogError("Room with the name: " + roomName + " not found in the map's dictionary of rooms.");
            return null;        
        }

    }
}
