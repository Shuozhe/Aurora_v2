using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class PlayerComponent : IComponentData

public class Player : MonoBehaviour
{
  void Start()
  {
    var controller = GetComponent<PlayerController>();
    var turret = GetComponentsInChildren<PlayerControlledTurret>();
    controller.AddTurrets(turret);
  }

  void Update()
  {

  }
}
