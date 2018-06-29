using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[System.Serializable]
public class EnemyManager : MonoBehaviour{

  [SerializeField]
  private int len;
  public GameObject enemy_pre;
  private List<GameObject> enemys;
  private int count = 0;

  void Start () {
    enemys = new List<GameObject> ();
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
      for (int i = 0; i < enemys.Count; i ++) {
        if (enemys[i].activeSelf) {
          enemys[i].SetActive (false);
          break;
        }
      }
    }
  }

  GameObject GetEnemy () {
    for (int i = 0; i < enemys.Count; i++) {
      if (enemys [i].activeSelf) {
        enemys [i].SetActive (true);
        return enemys [i];
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
