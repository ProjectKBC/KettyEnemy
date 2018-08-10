using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
  protected float bottom = -600.0f;

  [HideInInspector]
  public int hp;
  public int fix_hp;
  public float enemySpeed;
  public float nomalBulletSpeed;
  public GameObject nomalBullet;
  protected List<GameObject> nomalBullets;
  protected float time;
  protected float pass;
  public float interval = 1.5f;
  protected const int bulletPool = 10;

  virtual protected void Awake() {
    hp = fix_hp;
    time = 0.0f;
    nomalBullets = new List<GameObject> ();
    for (int i = 0; i < bulletPool; i++) {
      nomalBullets.Add (CreateBullet (nomalBullet));
    }
    pass = interval;
  }

  virtual protected void Update () {
    if (Mathf.Floor (time * 10) / 10 == pass) {
      BulletAppear ();
      pass += interval;
    }
    Dead ();
    NomalAttack ();
    BeyondLine ();
  }

  virtual protected void OnDisable () {
    hp = fix_hp;
    time = 0.0f;
    pass = interval;
  }

  public void Dead () {
    if (hp <= 0) {
      HideEnemy ();
    }
  }

  public void BeyondLine() {
    if (this.transform.position.y < bottom) {
      HideEnemy ();
    }
  }

  public GameObject CreateBullet (GameObject obj) {
    GameObject bullet;
    bullet = (GameObject)Instantiate (obj);
    //bullet.transform.parent = this.transform;
    HideBullet (bullet);
    return bullet;
  }

  public void BulletAppear() {
    for (int i = 0; i < nomalBullets.Count; i ++) {
      if (!nomalBullets[i].gameObject.activeSelf) {
        nomalBullets [i].transform.position = this.transform.position;
        nomalBullets [i].gameObject.SetActive (true);
        break;
      }
    }
  }

  public void NomalAttack () {
    for (int i = 0; i < nomalBullets.Count; i++) {
      if (nomalBullets [i].gameObject.activeSelf) {
        Vector3 pos = nomalBullets [i].transform.position;
        pos.y -= nomalBulletSpeed;
        nomalBullets [i].transform.position = pos;
        if (nomalBullets[i].transform.position.y < bottom) {
          HideBullet (nomalBullets [i]);
        }
      }
    }
  }

  public void HideEnemy () {
    this.gameObject.SetActive (false);
    this.transform.position = new Vector3 (0, 0, 200);
  }

  public void HideBullet (GameObject bullet) {
    bullet.gameObject.SetActive (false);
    bullet.transform.position = new Vector3 (0, 0, 200);
  }

  public bool IsHit () {
    
    return false;
  }

}
