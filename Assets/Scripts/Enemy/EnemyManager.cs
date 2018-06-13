using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

  public int len;
  public GameObject enemy_pre;
  private List<GameObject> enemys = new List<GameObject> ();

  public bool test_flg = false; //作られてることが目に見えるようにするためのテスト用flg

  void Start () {
    GameObject enemy;
    for (int i = 0; i < len; i++) {
      enemy = (GameObject)Instantiate (enemy_pre, new Vector3 (this.transform.position.x, -i, this.transform.position.z), Quaternion.identity);
      enemy.transform.localScale = new Vector3 (30, 30, 30);
      enemy.gameObject.SetActive (false);
      enemy.transform.parent = this.transform;
      enemys.Add (enemy);
    }
  }

  void Update () {
    foreach (GameObject obj in enemys) {
      obj.gameObject.SetActive (test_flg);
    }
  }
}
