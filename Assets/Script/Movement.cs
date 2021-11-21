
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] Vector3 movementTransform;
    CharacterController characterController;
    PlayerInputController playerInputController;
    Vector2 readingValue;
    Vector3 movementValue;
    public float speedZ;
    [SerializeField] float speed = 2f;
    float minSpeed = 2f;
    float maxSpeed = 4f;
    [SerializeField] GameObject playerModel;

    public static Movement instance;
    

    // Start is called before the first frame update
    void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }
        readingValue = Vector2.zero;
        playerInputController = new PlayerInputController();
        characterController = GetComponent<CharacterController>();

        playerInputController.CharacterControls.Move.started += movementInput;
        playerInputController.CharacterControls.Move.performed += movementInput;
        playerInputController.CharacterControls.Move.canceled += movementInput;



    }

    // Update is called once per frame
    void Update()
    {
        characterController.Move(movementValue * Time.deltaTime * speed);
        //this.transform.position += Vector3.forward*Time.deltaTime*speedZ;

    }
    void movementInput(InputAction.CallbackContext context)
    {
        readingValue = context.ReadValue<Vector2>();
        movementValue.x = readingValue.x;
        movementValue.z = readingValue.y;


    }


    private void OnEnable()
    {
        playerInputController.Enable();
    }
    private void OnDisable()
    {
        playerInputController.Disable();
    }
}
