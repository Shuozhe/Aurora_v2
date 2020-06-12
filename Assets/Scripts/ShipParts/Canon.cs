using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour, IFireable
{
  [SerializeField]
  GameObject projectile;

  float timer = 0;

  public void Fire(float strength = 1)
  {
    if (projectile)
    {
      Instantiate(projectile, gameObject.transform);
    }
  }

  void Update()
  {

  }
}
