using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

[Serializable]
public class GameManagerExample : MonoBehaviour
{
   
    public static GameManagerExample instance;
    
    public InputActionAsset inputs;
    public InputAction iConfirm; 
    public InputAction iMove;
    public InputAction iLook;

    public Vector2 fMovement;
    public Vector2 fCamera;



    private void Awake()
    {
        iConfirm = inputs.FindAction("Confirm");
        iMove = inputs.FindAction("Move");
        iLook = inputs.FindAction("Look");

        iConfirm.Enable();
        iMove.Enable();
        iLook.Enable();


    }

    // Update is called once per frame
    void Update()
    {
        fMovement = iMove.ReadValue<Vector2>();
        fCamera = iLook.ReadValue<Vector2>();

    }

    void Start()
    {
        System.Globalization.CultureInfo.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }


    public bool Left()
    {
         return iMove.WasPressedThisFrame() && fMovement.x < 0;
    }
    public bool LeftHeld()
    {
       return fMovement.x < 0;
    }
    public bool Right()
    {
         return iMove.WasPressedThisFrame() && fMovement.x > 0;
    }
    public bool RightHeld()
    {
        return fMovement.x > 0;
    }
    public bool Up()
    {
         return iMove.WasPressedThisFrame() && fMovement.y > 0;
    }
    public bool UpHeld()
    {
            return fMovement.y > 0;
    }
    public bool Down(bool held = false)
    {
         return iMove.WasPressedThisFrame() && fMovement.y < 0;
    }
    public bool DownHeld()
    {
            return fMovement.y < 0;
    }
    public bool Confirm()
    {
        return iConfirm.triggered;
    }
    
    
    public bool ConfirmHeld()
    {
            return iConfirm.IsPressed();
    }

  


}
