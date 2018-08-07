using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Enemy : MonoBehaviour {

  protected float bottom = -15.0f;

  [HideInInspector]
  public int hp;
  public int fix_hp;
  public float enemy_speed;
  public float nomal_bullet_speed;
  public GameObject nomal_bullet;
  protected List<GameObject> nomal_bullets;
  protected float time;
  protected float pass;
  public float interval = 1.5f;

  /*
  public void Quadratic (float passing_x, float passing_z, float max_x, float max_z) {
    float a = passing_z - max_z / ( (passing_x - max_x) * (passing_x - max_x) );
    x += speed * 3;
    z = a * (x - max_x) * (x - max_x) + max_z;
    transform.position = new Vector3 (x, 0, z);
  }
  */

  public void Dead () {
    if (hp <= 0) {
      HideEnemy ();
    }
  }

  public void BeyondLine() {
    if (this.transform.position.z < bottom) {
      HideEnemy ();
    }
  }

  public GameObject CreateBullet (GameObject obj) {
    GameObject bullet;
    bullet = (GameObject)Instantiate (obj);
    bullet.transform.parent = this.transform;
    HideBullet (bullet);
    return bullet;
  }

  public void BulletAppear() {
    for (int i = 0; i < nomal_bullets.Count; i ++) {
      if (!nomal_bullets[i].gameObject.activeSelf) {
        nomal_bullets [i].transform.position = this.transform.position;
        nomal_bullets [i].gameObject.SetActive (true);
        break;
      }
    }
  }

  public void NomalAttack () {
    for (int i = 0; i < nomal_bullets.Count; i++) {
      if (nomal_bullets [i].gameObject.activeSelf) {
        nomal_bullets [i].transform.position =
                           new Vector3 (nomal_bullets[i].transform.position.x, 0, nomal_bullets [i].transform.position.z - nomal_bullet_speed);
        if (nomal_bullets[i].transform.position.z < bottom) {
          HideBullet (nomal_bullets [i]);
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
