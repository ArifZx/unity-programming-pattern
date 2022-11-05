using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
  public static BulletPool SharedInstace;
  public Queue<Bullet> poolObjects;
  public Bullet prefab;
  public int amount;

  void Awake()
  {
    SharedInstace = this;
  }

  void Start()
  {
    poolObjects = new Queue<Bullet>();
    Bullet tmp;
    for (int i = 0; i < amount; i++)
    {
      tmp = Instantiate(prefab);
      tmp.gameObject.SetActive(false);
      poolObjects.Enqueue(tmp);
    }
  }

  public Bullet pop()
  {
    Bullet tmp = poolObjects.Dequeue();
    if (tmp == null) return null;
    tmp.bulletUnsuedEvent += onBulletUnused;
    tmp.gameObject.SetActive(true);
    return tmp;
  }

  private void onBulletUnused(Bullet b)
  {
    // unlisten event
    b.bulletUnsuedEvent -= onBulletUnused;
    // simpan ke queue
    b.gameObject.SetActive(false);
    poolObjects.Enqueue(b);
  }
}
