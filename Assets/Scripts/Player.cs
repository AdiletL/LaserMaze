using Assets.Scripts;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] ParticleSystem _particle;

    [Space]
    [SerializeField] Animator _Portal;

    [Space]
    [SerializeField] GameObject _StartPlayer;
    [SerializeField] GameObject Pointlight;

    [Space]
    [SerializeField] AudioSource SongTeleport, SongLaser, SongUI;

    [Space]
    [SerializeField] int green_red;

    private FloatingJoystick flot;
    private CharacterController CharacContr;

    private Animator animatUI;
    private Animator _animator;

    private Image _imageJoy;

    private Vector3 moveVect;
    public Vector3 direct;

    public float speed;
    public bool joy;

    private int numberRoom;

    private bool isPortal;
    private bool isLaser;

    private int numberColor;

    public event Action<int> numberLayer;

    private void Awake()
    {
        flot = FindObjectOfType<FloatingJoystick>();
        _imageJoy = flot.transform.GetChild(0).GetComponent<Image>();
        animatUI = flot.transform.parent.GetComponent<Animator>();

        _animator = GetComponent<Animator>();
        CharacContr = GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        Portal.OnPortal += OnPortal;
        Room.OnRoom += OnRoom;
    }
    private void OnDisable()
    {
        Portal.OnPortal -= OnPortal;
        Room.OnRoom -= OnRoom;
    }

    private void OnPortal()
    {
        Pointlight.SetActive(false);
        _Portal.SetTrigger("scale");
        animatUI.SetTrigger("AnimatUI");
        SongUI.Play();
        //_StartPlayer.SetActive(false);
    }
    private void OnRoom(int number)
    {
        if (number == numberRoom || !isLaser) return;

        switch (numberColor)
        {
            case 1:
                numberColor = 2;
                SetParticleColor(Color.red);
                break;
                
            case 2:
                numberColor = 1;
                SetParticleColor(Color.green);
                break;
            default:
                break;
        }

        _animator.SetTrigger("change_color");
        numberLayer?.Invoke(numberColor);
        numberRoom = number;
    }
    private void SetParticleColor(Color targetColor)
    {
        _particle.startColor = targetColor;
        _imageJoy.color = targetColor;
    }
    private void Start()
    {
        switch (green_red)
        {
            case 1:
                _animator.SetInteger("Red_Green", 2);
                SetParticleColor(Color.green);
                break;
            case 2:
                SetParticleColor(Color.red);
                _animator.SetInteger("Red_Green", 1);
                break;

            default:
                break;
        }

        numberColor = green_red;
    }
    private void Update()
    {
        if (isPortal) return;

        moveVect = Vector3.zero;
        moveVect.x = flot.horizont() * speed;
        moveVect.z = flot.vertic() * speed;
    }


    private void LateUpdate()
    {
        if (Vector3.Angle(Vector3.forward, moveVect) > 0)
        {
            direct = Vector3.RotateTowards(transform.forward, moveVect, 2f, 0.1f);
            joy = true;
        }
        else if (Vector3.Angle(Vector3.forward, moveVect) == 0)
        {
            joy = false;
        }
        CharacContr.SimpleMove(moveVect * 4f);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Portal"))
        {
            SongTeleport.Play();

        }
        if (other.CompareTag("LaserRed"))
        { 
            SongLaser.Play();
            isLaser = true;
        }

        if (other.CompareTag("LaserGreen"))
        { 
            SongLaser.Play();
            isLaser = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("OneLaserRed"))
        {
            SongLaser.Play();
            switch (numberColor)
            {
                case 1:
                    numberColor = 2;
                    SetParticleColor(Color.red);
                    break;

                case 2:
                    numberColor = 1;
                    SetParticleColor(Color.green);
                    break;
                default:
                    break;
            }

            _animator.SetTrigger("change_color");
            numberLayer?.Invoke(numberColor);
        }
        if (other.CompareTag("OneLaserGreen"))
        {
            SongLaser.Play();
            switch (numberColor)
            {
                case 1:
                    numberColor = 2;
                    SetParticleColor(Color.red);
                    break;

                case 2:
                    numberColor = 1;
                    SetParticleColor(Color.green);
                    break;
                default:
                    break;
            }

            _animator.SetTrigger("change_color");
            numberLayer?.Invoke(numberColor);
        }
    }
}
