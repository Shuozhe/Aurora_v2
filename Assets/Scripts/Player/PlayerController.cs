using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
  Vector2 move_ = Vector2.zero;

  public void OnMove(InputValue vec2)
  {
    move_ = vec2.Get<Vector2>();
  }

  public void OnBrake(InputValue button)
  {
    GetComponent<Rigidbody2D>().angularVelocity = Mathf.Lerp(GetComponent<Rigidbody2D>().angularVelocity, 0, 1);
    GetComponent<Rigidbody2D>().velocity = Vector2.Lerp(GetComponent<Rigidbody2D>().velocity, Vector2.zero, 1);
  }

  void FixedUpdate()
  {
    GetComponent<Rigidbody2D>().AddForce(move_);
  }
}
