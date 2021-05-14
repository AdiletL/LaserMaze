using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] ParticleSystem _particle;
    [SerializeField] FloatingJoystick flot;
    [SerializeField] Animator _Portal, animatUI;
    [SerializeField] GameObject _StartPlayer;
    [SerializeField] GameObject Pointlight;
    [SerializeField] Image _imageJoy;
    [SerializeField] int green_red;
    [SerializeField] AudioSource SongTeleport, SongLaser, SongScore, SongUI;
    private CharacterController CharacContr;
    private Animator _animator;
    private Vector3 moveVect;
    public Vector3 direct;
    private Rigidbody rb;
    public static int number;
    public static bool _score, timescore;
    private int rom;
    public  float speed;
    private float counter;
    public bool joy;
    private bool Portal, laser, Animat, _songUI;
    public delegate void NumberLayer(int number);
    public event NumberLayer numberlayer;

    public Color StartColor {
    set { var main = _particle.main;
            main.startColor = value;
        }
    }
    private void Start()
    {
        var main = _particle.main;
        
        _animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        CharacContr = GetComponent<CharacterController>();
        if (green_red == 1)
        {
            laser = true;
            _animator.SetInteger("Red_Green", 2);
            StartColor = Color.green;
            _imageJoy.color = Color.green;
        }
        else if (green_red == 2)
        {
            laser = false;
            _animator.SetInteger("Red_Green", 1);
            StartColor = Color.red;
            _imageJoy.color = Color.red;
        }
       number = green_red;
    }
    private void Update()
    {
        moveVect = Vector3.zero;
        moveVect.x = flot.horizont() * speed;
        moveVect.z = flot.vertic() * speed;
    }
    private void LateUpdate()
    {
        if (!Portal)
        {
                if (/*Vector3.Angle(Vector3.forward, moveVect) > 1f ||*/ Vector3.Angle(Vector3.forward, moveVect) /*==*/> 0)
                {
                    direct = Vector3.RotateTowards(transform.forward, moveVect, 2f, 0.1f);
                //transform.rotation = Quaternion.LookRotation(direct);
                    joy = true;
                }
                if (Vector3.Angle(Vector3.forward, moveVect) == 0)
                {
                    joy = false;
                }
                CharacContr.SimpleMove(moveVect * 4f);
        }
        else
        {
            _score = true;
            Pointlight.SetActive(false);
            _Portal.SetTrigger("scale");
            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(0,0,0), .2f);
           
            if (transform.localScale.x < .1f)
            {
                
                counter += Time.deltaTime;
                if (counter > .5f)
                {       
                        animatUI.SetTrigger("AnimatUI");
                    if (counter >.6f && !_songUI)
                    {
                        _songUI = false;
                         SongUI.Play();
                        _songUI = true;
                    }     
                }
                    if (counter > 3f)
                    {
                        timescore = true;
                        SongScore.Play();
                        if (counter > 5)
                        {
                        
                        _StartPlayer.SetActive(false);
                       gameObject.SetActive(false);
                    
                        }
                    }
            }
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Portal"))
        {
            Portal = true;
            SongTeleport.Play();
            
        }
       if (other.CompareTag("LaserRed"))
        { laser = true; SongLaser.Play(); Animat = true; }

        if (other.CompareTag("LaserGreen"))
        { laser = false; SongLaser.Play(); Animat = true; }

        if (other.CompareTag("Room"))
        {
            if (Room.rooms != rom)
            {
                if (laser && Animat)
                {
                    _animator.SetTrigger("change_color");

                    _imageJoy.color = Color.green;
                    number = 1;
                    StartColor = Color.green;

                }
                else if(!laser && Animat)
                {
                    _animator.SetTrigger("change_color");

                    _imageJoy.color = Color.red;
                    number = 2;
                    StartColor = Color.red;

                } 
                numberlayer.Invoke(number);
                rom = Room.rooms;
            }
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("OneLaserRed"))
        {
            _animator.SetTrigger("change_color");
            SongLaser.Play();
            _imageJoy.color = Color.green;
            number = 1;
            StartColor = Color.green;
            numberlayer.Invoke(number);
        }
        if (other.CompareTag("OneLaserGreen"))
        {
            _animator.SetTrigger("change_color");
            SongLaser.Play();
            _imageJoy.color = Color.red;
            number = 2;
            StartColor = Color.red;
            numberlayer.Invoke(number);
        }
    }
}
