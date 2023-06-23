using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    [SerializeField] private float inputAxisX;
    [SerializeField] private float inputAxisZ;
    [SerializeField] private float moveSpeed = 15.0f;
    [SerializeField] private float runningSpeed = 25.0f;
    [SerializeField] private float rotationSpeed = 15.0f;
    private Vector3 moveDirection = Vector3.zero;
    private Vector3 rotation;
    [SerializeField] private CharacterController _characterController;


    private bool isRunning;


    // Start is called before the first frame update
    void Start()
    {  
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
    }
    private void CheckInput()
    {

        inputAxisX = Input.GetAxisRaw("Horizontal");
        inputAxisZ = Input.GetAxisRaw("Vertical");

        rotation = new Vector3(0, inputAxisX * rotationSpeed * Time.deltaTime, 0);
        moveDirection = new Vector3(0, 0, inputAxisZ);

        moveDirection = this.transform.TransformDirection(moveDirection);
        runState();
        this.transform.Rotate(rotation);


    }

    void runState()
    {
            _characterController.Move(moveDirection * moveSpeed * Time.deltaTime);
    }
}
