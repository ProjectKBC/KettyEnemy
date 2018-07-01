using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyManager {

  //[SerializeField]
  //private int len = 30;
  public GameObject enemy_pre;
  [SerializeField]
  public Dictionary<string, GameObject> enemy_waves;
  public Dictionary<string, GameObject> pool_enemy_waves;
  private List<GameObject> enemys;
  //private int count = 0;

  private static EnemyManager instance = null;

  public static EnemyManager Instance {
    get {
      if (instance == null) {
        instance = new EnemyManager ();
      }
      return instance;
    }
    set {
      
    }
  }

  protected EnemyManager () {
    
  }

  public void Start () {
    foreach (KeyValuePair<string, GameObject> w in EnemyManager.Instance.enemy_waves) {
      GManager.Instance.Create (w.Key, w.Value);
    }
  }

  /*
  public void Update () {
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
  */

  /*
  GameObject GetEnemy () {
    for (int i = 0; i < enemys.Count; i++) {
      if (enemys [i].activeSelf == false) {
        enemys [i].SetActive (true);
        return enemys [i];
      }
    }
    GManager.CreateEnemy (true, 1 * count);
    return enemys [enemys.Count - 1];
  }
  */
  /*
  void CreateEnemy (bool flg, int y) {
    GameObject enemy;
    enemy = (GameObject)Instantiate (enemy_pre, new Vector3 (this.transform.position.x, y, this.transform.position.z), Quaternion.identity);
    enemy.transform.localScale = new Vector3 (30, 30, 30);
    enemy.gameObject.SetActive (flg);
    enemy.transform.parent = this.transform;
    enemys.Add (enemy);
  }
  */

}
