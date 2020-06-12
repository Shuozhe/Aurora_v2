using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class PlayerComponent : IComponentData

public class Player : MonoBehaviour
{
  List<IFireable> weapons_;

  void Start()
  {
    var controller = GetComponent<PlayerController>();
    var turret = GetComponentsInChildren<PlayerControlledTurret>();
    controller.AddTurrets(turret);
  }

  private void OnGUI()
  {
    if (GUILayout.Button("Press Me"))
      Debug.Log("Hello!");
  }

  
}
