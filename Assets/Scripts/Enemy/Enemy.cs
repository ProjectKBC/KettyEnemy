using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Enemy : MonoBehaviour {
  //未着手

  [HideInInspector]
  public int hp;
  public int fix_hp;
  public float enemy_speed;
  public float nomal_bullet_speed;
  public GameObject nomal_bullet;
  [HideInInspector]
  public List<GameObject> nomal_bullets;
  private float time;
  private float pass;
  public float interval = 1.5f;

  private const int bulletPool = 10;

  public enum MovePattern {
    quadratic
  }

  private void Awake () {
    hp = fix_hp;
    for (int i = 0; i < bulletPool; i++) {
      nomal_bullets.Add (CreateBullet (nomal_bullet));
    }
  }

  private void Update () {
    time += Time.deltaTime;
    if (Mathf.Floor (time * 10) / 10 / interval >= (pass % nomal_bullets.Count)) {
      Debug.Log (time);
      Appear ();
      pass += interval;
    }
    IsBorn ();
    NomalAttack ();
    Dead ();
  }

  /*
  public void Quadratic (float passing_x, float passing_z, float max_x, float max_z) {
    float a = passing_z - max_z / ( (passing_x - max_x) * (passing_x - max_x) );
    x += speed * 3;
    z = a * (x - max_x) * (x - max_x) + max_z;
    transform.position = new Vector3 (x, 0, z);
  }
  */

  public void IsBorn () {
    if (this.transform.parent.gameObject.activeSelf) {
      this.gameObject.SetActive (true);
    }
  }

  public void Dead () {
    if (hp <= 0) {
      this.gameObject.SetActive (false);
    }
  }

  public GameObject CreateBullet (GameObject obj) {
    GameObject bullet;
    bullet = (GameObject)Instantiate (obj);
    bullet.transform.parent = this.transform;
    Hide (bullet);
    return bullet;
  }

  public void Appear() {
    for (int i = 0; i < nomal_bullets.Count; i ++) {
      if (!nomal_bullets[i].gameObject.activeSelf) {
        nomal_bullets [i].gameObject.SetActive (true);
        nomal_bullets [i].transform.position = this.transform.position;
        break;
      }
    }
  }

  public void NomalAttack () {
    for (int i = 0; i < nomal_bullets.Count; i++) {
      if (nomal_bullets [i].gameObject.activeSelf) {
        nomal_bullets [i].transform.position =
                           new Vector3 (nomal_bullets[i].transform.position.x, 0, nomal_bullets [i].transform.position.z - nomal_bullet_speed);
        if (nomal_bullets[i].transform.position.z < -15) {
          Hide (nomal_bullets [i]);
        }
      }
    }
  }

  public void Hide (GameObject bullet) {
    bullet.transform.position = new Vector3 (0, 0, 200);
    bullet.gameObject.SetActive (false);
  }

  public bool IsHit () {
    
    return false;
  }

}
