using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asdf : MonoBehaviour
{
    [SerializeField] Player _player;
   [SerializeField] FloatingJoystick _j;
    Vector3 v;
    private void Update()
    {
        if (_player.joy)
        {
            v.x += _player.direct.x * 8;
            v.y += _player.direct.y ;
            v.z += _player.direct.z  *8;
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
