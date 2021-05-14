using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public int room;
    public static int rooms;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            rooms = room;
        }
    }
}
