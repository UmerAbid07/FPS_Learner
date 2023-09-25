using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Camera cam;
    [SerializeField]
    private float distance = 3.0f;
    [SerializeField]
    private LayerMask mask;
    private PlayerUI playerUI;   
    public InputManager inputManager;
    // Start is called before the first frame update
    void Start()
    {
        inputManager = GetComponent<InputManager>();

        cam = GetComponent<PlayerLook>().cam;
         playerUI = GetComponent<PlayerUI>();
    }

    // Update is called once per frame
    void Update()
    {
        playerUI.UpdateText(string.Empty);
        //create a ray at the center of the camera shooting outward
        Ray ray = new Ray(cam.transform.position,cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);
        RaycastHit hitInfo;
        if(Physics.Raycast(ray, out hitInfo, distance, mask))
        {
            if (hitInfo.collider.GetComponent<Interactables>() != null)
            {
                Interactables interactables = hitInfo.collider.GetComponent<Interactables>();
                playerUI.UpdateText(interactables.promptMessage);
                if(inputManager.onFoot.Interect.triggered)
                {
                    interactables.baseinterect();
                    Debug.Log("isOpen");
                }
            }
        }

    }
}
