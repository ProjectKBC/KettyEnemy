using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

  public int len;
  public GameObject enemy_pre;
  private List<GameObject> enemys = new List<GameObject> ();
  private int count = 0;

  public bool test_flg = false; //作られてることが目に見えるようにするためのテスト用flg

  void Start () {
    for (int i = 0; i < len; i++) {
      CreateEnemy (false, -i);
    }
  }

  void Update () {
    if (Input.GetKey (KeyCode.T)) {
      count++;
      GameObject ene;
      ene = GetEnemy ();
      Debug.Log(enemys.Count);
    }
    if (Input.GetKey (KeyCode.F)) {
      foreach (GameObject obj in enemys) {
        if (obj.activeSelf) {
          obj.SetActive (false);
          break;
        }
      }
    }
  }

  GameObject GetEnemy () {
    foreach (GameObject obj in enemys) {
      if (!obj.activeSelf) {
        obj.SetActive(true);
        return obj;
      }
    }
    CreateEnemy (true, 1 * count);
    return enemys [enemys.Count - 1];
  }

  void CreateEnemy (bool flg, int y) {
    GameObject enemy;
    enemy = (GameObject)Instantiate (enemy_pre, new Vector3 (this.transform.position.x, y, this.transform.position.z), Quaternion.identity);
    enemy.transform.localScale = new Vector3 (30, 30, 30);
    enemy.gameObject.SetActive (flg);
    enemy.transform.parent = this.transform;
    enemys.Add (enemy);
  }

}
