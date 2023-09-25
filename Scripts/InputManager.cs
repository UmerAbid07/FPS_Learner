using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    public PlayerInput.OnFootActions onFoot;
    private PlayerMovement playerMovement;
    private PlayerLook look;
    
    // Start is called before the first frame update
    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        look = GetComponent<PlayerLook>();
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;
        onFoot.Jump.performed += ctx => playerMovement.jump();
        onFoot.Crouch.performed += ctx => playerMovement.crouch();
        onFoot.Sprint.performed += ctx => playerMovement.sprint();
       
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        playerMovement.ProcessMove(onFoot.Movement.ReadValue<Vector2>());
    }
    private void LateUpdate()
    {
        look.ProcessLook(onFoot.Look.ReadValue<Vector2>());
    }
    private void OnEnable()
    {
        onFoot.Enable();
    }
    private void OnDisable()
    {
        onFoot.Disable();
    }
}
