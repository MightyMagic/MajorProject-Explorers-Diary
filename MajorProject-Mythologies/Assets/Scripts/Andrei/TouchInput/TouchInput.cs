using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchInput : MonoBehaviour
{
    public static TouchInput Instance { get; private set; }

    [SerializeField] FixedJoystick joystick;
    [SerializeField] Button touchJumpButton;

    public bool jumpIsPressed { get; private set; }
    public bool jumpIsHeld {  get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        jumpIsPressed = false;
        jumpIsHeld = false;
    }

    private void Update()
    {
        jumpIsPressed = false;
    }

    public void OnJumpPress()
    {
        jumpIsPressed = true;
        jumpIsHeld = true;
    }

    public void OnButtonRelease()
    {
        jumpIsHeld = false;
        Debug.Log("Button was released.");
    }

    public float TouchHorizontal()
    {
        return joystick.Horizontal;
    }

    public bool IsTouchJumpPressed()
    {
        return jumpIsPressed;
    }

    public bool IsTouchJumpHeld()
    {
        return jumpIsHeld;
    }

}
