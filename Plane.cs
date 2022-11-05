using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
  public Animator animator;
  public Bullet bullet;

  public Transform offset;

  public float bulletSpeed = 10f;
  public Vector2 bulletDir = Vector2.right;

  public float fireRate = 15;
  private float fireCounter = 0;
  private bool onFire = false;

  public PlaneInput planeInput;

  void OnEnable()
  {
    if (planeInput != null)
    {
      planeInput.fireInputEvent += OnFireInput;
    }
  }

  void OnDisable()
  {
    if (planeInput != null)
    {
      planeInput.fireInputEvent -= OnFireInput;
    }
  }

  public void Update()
  {

    // if (Input.GetButtonDown("Fire1"))
    // {
    //   onFire = true;
    //   fireCounter = 0;
    // }
    // else if (Input.GetButtonUp("Fire1"))
    // {
    //   onFire = false;
    // }

    if (onFire)
    {
      fireCounter += Time.deltaTime;
      if (fireCounter >= 1 / fireRate)
      {
        fireCounter = fireCounter % 1 / fireRate;
        Fire();
      }
    }
  }

  public void OnFireInput(bool isDown)
  {
    onFire = isDown;
  }

  public void Fire()
  {
    // if (bullet == null) return;
    // Bullet bulletComp = Instantiate(bullet, offset.position, Quaternion.identity);
    Bullet bulletComp = BulletPool.SharedInstace.pop();
    if (bulletComp == null) return;
    bulletComp.transform.position = offset.position;
    bulletComp.transform.rotation = Quaternion.identity;
    bulletComp.Init(bulletDir * bulletSpeed);
  }
}
