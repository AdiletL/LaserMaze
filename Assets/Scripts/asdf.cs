using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asdf : MonoBehaviour
{
    [SerializeField] Player _player;
    [SerializeField] FloatingJoystick _j;
    private Vector3 v;

    private void Update()
    {
        if (_player.joy)
        {
            v.x += _player.direct.x;
            v.y += _player.direct.y;
            v.z += _player.direct.z;
        }
        else
        {
            v.x += 1f;
            v.y += 1f;
            v.z += 1f;
        }
        transform.rotation = Quaternion.Euler(v.z, 0,-v.x);
    }
}
