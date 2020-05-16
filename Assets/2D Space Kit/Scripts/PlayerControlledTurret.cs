using UnityEngine;
using System.Collections;

public class PlayerControlledTurret : MonoBehaviour
{

  public GameObject weapon_prefab;
  public GameObject[] barrel_hardpoints;
  public float turret_rotation_speed = 3f;
  public float shot_speed;

  // Update is called once per frame
  void Update()
  {
    //This makes the turret aim at the mouse position (Controlled by CustomPointer, but you can replace CustomPointer.pointerPosition with Input.MousePosition and it should work)
    Vector2 turretPosition = Camera.main.WorldToScreenPoint(transform.position);
    Vector3 direction = CustomPointer.pointerPosition - turretPosition;
    transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.LerpAngle(transform.rotation.eulerAngles.z, (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg) - 90f, turret_rotation_speed * Time.deltaTime)));
  }
}
