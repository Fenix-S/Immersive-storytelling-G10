using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class movementController : MonoBehaviour
{
    public float speed = 1f;
    public XRNode input;
    public loadManager loadManager;
    private XRRig rig;
    private Vector2 inputAxis;
    private CharacterController character;

    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();
        rig = GetComponent<XRRig>();

        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            var r = transform.rotation;
            r.y = 0;
            transform.rotation = r;
        }
    }

    // Update is called once per frame
    void Update()
    {
       InputDevice device = InputDevices.GetDeviceAtXRNode(input);
       device.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxis);
    }

    public void Move(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        //inputAxis = context.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        if (loadManager != null && loadManager.isLoading)
        {
            return;
        }
        Quaternion headYaw = Quaternion.Euler(0, rig.cameraGameObject.transform.eulerAngles.y, 0);
        Vector3 direction = headYaw * new Vector3(inputAxis.x, 0, inputAxis.y);
        direction.x = Mathf.Round(direction.x);
        direction.z = Mathf.Round(direction.z);
        if (SceneManager.GetActiveScene().buildIndex == 1 || SceneManager.GetActiveScene().buildIndex == 3 || SceneManager.GetActiveScene().buildIndex == 4)
        {
            var vector = direction * speed;
            character.SimpleMove(vector);
        }
        else
        {
            var temp = direction * Time.fixedDeltaTime * speed;
            character.Move(temp);
        }
    }
}
