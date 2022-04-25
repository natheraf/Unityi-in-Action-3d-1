using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class FPSInput : MonoBehaviour
{
    public float speed = 6.0f;
    public float gravity = -.5f;
    public float MomentumY = 0f;
    private CharacterController charController;

    // Start is called before the first frame update
    void Start()
    {
      charController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
      float deltaX = Input.GetAxis("Horizontal") * speed;
      float deltaZ = Input.GetAxis("Vertical") * speed;
      float jump = Input.GetAxis("Jump");
      Vector3 movement = new Vector3(deltaX, 0, deltaZ);
      movement = Vector3.ClampMagnitude(movement, speed);
      if (transform.position.y == 1.08f && jump != 0f) {
        MomentumY += 150f;
      }
      if (transform.position.y > 1.08f && MomentumY > -gravity) {
        MomentumY += gravity;
      } if (MomentumY < -gravity) {
        MomentumY = gravity;
      }
      movement.y = MomentumY;
      movement *= Time.deltaTime;
      movement = transform.TransformDirection(movement);
      charController.Move(movement);
    }
}
