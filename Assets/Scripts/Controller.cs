using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class Controller : MonoBehaviour
{
    public static Controller instance;
    private PlayerInput playerInput;

    private CharacterController controller;

    public float speed = 0f;
    public float cameraYAngleLimit = 30f;
    public Animator camAnim;
    private bool isWalking;

    public GameObject bullet;
    public Transform firePoint;

    //Camara
    public Transform cameraTransform;
    public float sensibilidadX = 100f;
    public float sensibilidadY = 100f;


    private float rotacionX = 0f;


    void Awake()
    {
        instance = this;
        playerInput = GetComponent<PlayerInput>();

        
    }
    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;

    }

    void Update()
    {
        /*float moveX = Input.GetAxis("Horizontal"); // A y D
        float moveZ = Input.GetAxis("Vertical");   // W y S*/

        Vector3 move = transform.right * GameManagerExample.instance.fMovement.x + transform.forward * GameManagerExample.instance.fMovement.y;

        MoverCamara();

        controller.Move(move * speed * Time.deltaTime);

        /*
        if (GameManagerExample.instance.Confirm())
        {
            Instantiate(bullet, firePoint.position, firePoint.rotation);
        }*/
    }

    void MoverCamara()
    {
        float mouseX = GameManagerExample.instance.fCamera.x * sensibilidadX * Time.deltaTime;
        float mouseY = GameManagerExample.instance.fCamera.y * sensibilidadY * Time.deltaTime;

        mouseX = Mathf.Clamp(mouseX, -90, 90);
        // Rotar el jugador horizontalmente (eje Y)
        transform.Rotate(Vector3.up * mouseX);

        // Rotar la cámara verticalmente (eje X) 
        rotacionX -= mouseY;
        rotacionX = Mathf.Clamp(rotacionX, -cameraYAngleLimit, cameraYAngleLimit);
        cameraTransform.localRotation = Quaternion.Euler(rotacionX, 0f, 0f);

    }


}
