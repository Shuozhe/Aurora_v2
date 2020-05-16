using UnityEngine;
using System;
using System.Collections;
using UnityEngine.InputSystem;

//NOTE: This is a script from my Spaceflight Controls package (For 3D games), a lot of this stuff isn't going to be relevant in a 2D space game, but I figured I'd include it anyway in the off chance it'll help someone.

[System.Serializable]
public class CustomPointer : MonoBehaviour
{
  enum MouseMode
  {
    ABSOLUTE,
    RELATIVE,
  };
  MouseMode mode_;

  public Texture pointerTexture; //The image for the pointer, generally a crosshair or dot.
  public static Vector2 pointerPosition; //Position of the pointer in screen coordinates.

  [HideInInspector]
  public Rect deadzone_rect; //Rect representation of the deadzone.

  public static CustomPointer instance; //The instance of this class (Should only be one)
                                        // Use this for initialization

  private Vector2 cursor_ = Vector2.zero;

  void Awake()
  {
    pointerPosition = new Vector2(Screen.width / 2, Screen.height / 2); //Set pointer position to center of screen
    instance = this;
    mode_ = MouseMode.RELATIVE;
  }

  void OnToggleMouseMode(InputValue button)
  {
    mode_ = (mode_ == MouseMode.RELATIVE ? MouseMode.ABSOLUTE : MouseMode.RELATIVE);
  }

  void OnLook(InputValue vec2)
  {
    if (mode_ == MouseMode.ABSOLUTE)
      return;

    cursor_ = vec2.Get<Vector2>();
    pointerPosition += cursor_ / 10f;
    VerifyPointer();
  }

  void OnLookAbs(InputValue vec2)
  {
    if (mode_ == MouseMode.ABSOLUTE)
    {
      pointerPosition = vec2.Get<Vector2>();
      VerifyPointer();
    }
  }

  // Update is called once per frame
  void Update()
  {
    VerifyPointer();
  }

  void VerifyPointer()
  {
    pointerPosition.x = Mathf.Clamp(pointerPosition.x, 0, Screen.width);
    pointerPosition.y = Mathf.Clamp(pointerPosition.y, 0, Screen.height);
  }

  void OnGUI()
  {
    //Draw the pointer texture.
    if (pointerTexture != null)
      GUI.DrawTexture(new Rect(pointerPosition.x - (pointerTexture.width / 2), Screen.height - pointerPosition.y - (pointerTexture.height / 2), pointerTexture.width, pointerTexture.height), pointerTexture);
  }
}
