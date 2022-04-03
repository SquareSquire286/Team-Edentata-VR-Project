using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomActivator : MonoBehaviour
{
    public GameObject room1, room2, room3, room4, room5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateRoomVisibility(GameObject roomPlayerIsIn)
    {
        if (roomPlayerIsIn == room1)
        {
            room1.SetActive(true);
            room2.SetActive(true);
            room3.SetActive(false);
            room4.SetActive(false);
            room5.SetActive(false);
        }

        else if (roomPlayerIsIn == room2)
        {
            room1.SetActive(true);
            room2.SetActive(true);
            room3.SetActive(true);
            room4.SetActive(false);
            room5.SetActive(false);
        }

        else if (roomPlayerIsIn == room3)
        {
            room1.SetActive(false);
            room2.SetActive(true);
            room3.SetActive(true);
            room4.SetActive(true);
            room5.SetActive(false);
        }

        else if (roomPlayerIsIn == room4)
        {
            room1.SetActive(false);
            room2.SetActive(false);
            room3.SetActive(true);
            room4.SetActive(true);
            room5.SetActive(true);
        }

        else if (roomPlayerIsIn == room5)
        {
            room1.SetActive(false);
            room2.SetActive(false);
            room3.SetActive(false);
            room4.SetActive(true);
            room5.SetActive(true);
        }
    }
}
