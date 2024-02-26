using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private int num;

    private BoxCollider _box;

    private void OnEnable()
    {
        _player.numberLayer += ON_Off;
    }
    private void OnDisable()
    {
        _player.numberLayer -= ON_Off;
    }

    private void Start()
    {
        _box = GetComponent<BoxCollider>();
    }

    private void ON_Off(int number)
    {
        if (number == num)
            _box.isTrigger = true;
        else
            _box.isTrigger = false;
    }
}
