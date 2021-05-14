using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] Player _player;
    BoxCollider _box;
    [SerializeField] int num;

    private void Start()
    {
        _box = GetComponent<BoxCollider>();
        _player.numberlayer += ON_Off;
    }
    void ON_Off(int sdf)
    {
        if (Player.number == 2 && num == 2)
        {
                _box.isTrigger = true;
        }
        else if (Player.number == 1 && num == 2)
        {
             _box.isTrigger = false;
        }

        if (Player.number ==1 && num == 1)
        {
            _box.isTrigger = true;
        }
        else if (Player.number == 2 && num ==1)
        {
            _box.isTrigger = false;
        }
    }
}
