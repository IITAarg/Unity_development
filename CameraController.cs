
using UnityEngine;

/// <summary>
/// Camera movement script for third person games.
/// This Script should not be applied to the camera! It is attached to an empty object and inside
/// it (as a child object) should be your game's MainCamera.
/// </summary>
public class CameraController : MonoBehaviour
{
    // Configuracion general
    [Header("Camera config")]
    [SerializeField] Camera PlayerCamera;

    [Header("Zoom config")]
    [SerializeField] bool canZoom = true;
    [SerializeField] float MaxFieldOfView = 75;
    [SerializeField] float MinFieldOfView = 35;


    [Header("Camera movement")]
    [SerializeField] Vector2 cameraLimit = new Vector2(-45, 40);
    [SerializeField] Vector3 offset = new Vector3(0,0,0);

    [Header("Player Config")]
    [SerializeField] bool followPlayer = true;
    [SerializeField] Transform PlayerToFollow;

    [Header("Input config")]
    [SerializeField] PlayerMovementInputController inputController;


    //Configuracion Extra
    float mouseX;
    float mouseY;


    void Start()
    {
        // Si no tengo una camara configurada la configuro
        if(PlayerCamera == null) PlayerCamera = Camera.main;
       

    }

    void Update()
    {
        // Cancelamos en caso de que el juego este pausado
        if (Time.timeScale == 0) return;

        // Set camera zoom when mouse wheel is scrolled
        float ScrollValue = inputController.zoomAxisValue;
        if ( canZoom && ScrollValue != 0)
        {
            // Cambio el campo de vision de la camara
            PlayerCamera.fieldOfView -= ScrollValue * Time.deltaTime;
            PlayerCamera.fieldOfView = Mathf.Clamp(PlayerCamera.fieldOfView, MinFieldOfView, MaxFieldOfView);
        }
        
        // Seguimos al jugador
        if (followPlayer && PlayerToFollow != null) transform.position = PlayerToFollow.position + offset;

        // Rotacion de la camara
        if (inputController.cameraMovemntActive)
        {
            // Calculo la rotacion de la camara
            mouseX += inputController.verticalCameraAxisValue;
            mouseY += inputController.horizontalCameraAxisValue;
            mouseY = Mathf.Clamp(mouseY, cameraLimit.x, cameraLimit.y);

            // Roto la camara
            transform.rotation = Quaternion.Euler(-mouseY, mouseX, 0);

        }

    }

}