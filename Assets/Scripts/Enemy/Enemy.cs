using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Enemy : MonoBehaviour{
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
  private int pass;
  public int interval = 2;

  private const int bulletPool = 10;

  public enum MovePattern {
    quadratic
  }

  private void Awake () {
    hp = fix_hp;
    Debug.Log (nomal_bullet);
    for (int i = 0; i < bulletPool; i++) {
      nomal_bullets.Add (CreateBullet (nomal_bullet));
    }
  }

  private void Start () {
    
  }

  private void Update () {
    time += Time.deltaTime;
    if (Mathf.Floor (time) % interval == 0) {
      Appear ();
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
    bullet.transform.position = new Vector3 (0, 0, 200);
    bullet.gameObject.SetActive (false);
    return bullet;
  }

  public void Appear() {
    for (int i = 0; i < nomal_bullets.Count; i ++) {
      if (!nomal_bullets[i].gameObject.activeSelf) {
        nomal_bullets [i].gameObject.SetActive (true);
        break;
      }
    }
  }

  public void NomalAttack () {
    for (int i = 0; i < nomal_bullets.Count; i++) {
      if (nomal_bullets [i].gameObject.activeSelf) {
        nomal_bullets [i].transform.position =
                      new Vector3 (0, 0, nomal_bullets [i].transform.position.z - nomal_bullet_speed);
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
