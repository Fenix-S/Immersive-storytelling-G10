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
    private XRRig rig;
    private Vector2 inputAxis;
    private CharacterController character;
    private Rigidbody body;

    // Start is called before the first frame update
    void Start()
    {

        character = GetComponent<CharacterController>();
        body = GetComponent<Rigidbody>();
        rig = GetComponent<XRRig>();
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
        Quaternion headYaw = Quaternion.Euler(0, rig.cameraGameObject.transform.eulerAngles.y, 0);
        Vector3 direction = headYaw * new Vector3(inputAxis.x, 0, inputAxis.y);
        direction.x = Mathf.Round(direction.x);
        direction.z = Mathf.Round(direction.z);
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            var vector = direction * speed;
            character.SimpleMove(vector);
        }
        else
        {
            var temp = direction * Time.fixedDeltaTime * speed;
            print(direction);
            character.Move(temp);
        }
        body.angularVelocity = Vector3.zero;
    }
}
