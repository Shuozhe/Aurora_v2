using Generated;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
  [SerializeField] private Controller controls_;
  [SerializeField] private Rigidbody2D player_;

  private PlayerControlledTurret[] turrets_;

  private Vector2 look_ = Vector2.zero;
  private Vector2 move_ = Vector2.zero;

  public void AddTurrets(PlayerControlledTurret[] turrets)
  {
    turrets_ = turrets;
  }

  private void OnEnable()
  {
    controls_ = new Controller();
    controls_.Player.Move.performed += HandleMove;
    controls_.Player.Look.performed += HandleLook;
    controls_.Player.Fire.performed += HandleFire;
    controls_.Player.Brake.performed += HandleBrake;

    controls_.Player.Move.Enable();
    controls_.Player.Look.Enable();
    controls_.Player.Fire.Enable();
    controls_.Player.Brake.Enable();

    player_ = GetComponent<Rigidbody2D>();
  }

  private void OnDisable()
  {
    controls_.Player.Move.performed -= HandleMove;
    controls_.Player.Look.performed -= HandleLook;
    controls_.Player.Fire.performed -= HandleFire;
    controls_.Player.Brake.performed -= HandleBrake;
  }
  void FixedUpdate()
  {
    player_.AddForce(move_);
    CustomPointer.pointerPosition += look_;
  }

  private void HandleLook(InputAction.CallbackContext context)
  {
    look_ = context.ReadValue<Vector2>();
    Debug.Log($"Look: {look_}");

  }

  public void HandleBrake(InputAction.CallbackContext context)
  {
    player_.angularVelocity = Mathf.Lerp(GetComponent<Rigidbody2D>().angularVelocity, 0, 1);
    player_.velocity = Vector2.Lerp(GetComponent<Rigidbody2D>().velocity, Vector2.zero, 1);
  }

  private void HandleMove(InputAction.CallbackContext context)
  {
    move_ = context.ReadValue<Vector2>();
  }

  private void HandleFire(InputAction.CallbackContext context)
  {
    foreach (var turret in turrets_)
      turret.Fire();
  }
}
