using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
  public delegate void bulletUnusedDelegate(Bullet b);
  public event bulletUnusedDelegate bulletUnsuedEvent;

  public Vector2 direction = Vector2.right;
  public float speed;

  public Rigidbody2D rb2d;

  public void Init(Vector2 velocity)
  {
    this.speed = velocity.magnitude;
    this.direction = velocity.normalized;
    if (rb2d == null) return;
    rb2d.velocity = direction * speed;
  }

  void OnEnable()
  {
    Init(this.direction * speed);
  }

  void OnBecameInvisible()
  {
    bulletUnsuedEvent(this);
    // before pakai singelton
    // gameObject.SetActive(false);
    // BulletPool.SharedInstace.poolObjects.Enqueue(this);
  }
}
