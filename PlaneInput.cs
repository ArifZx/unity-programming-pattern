using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneInput : MonoBehaviour
{
  public delegate void fireInputDelegate(bool isDown);
  public event fireInputDelegate fireInputEvent;

  void Update()
  {
    if (Input.GetButtonDown("Fire1"))
    {
      fireInputEvent(true);
    }
    else if (Input.GetButtonUp("Fire1"))
    {
      fireInputEvent(false);
    }
  }
}
