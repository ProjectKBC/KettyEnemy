using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GManager : MonoBehaviour
{
  private static GManager instan = null;
  public EnemyManager e_sc;

  private EnemyManager inst;
  private int x = 10, y = 0, z = 10;

  public static GManager Instance {
    get {
      if (instan == null) {
        instan = new GManager ();
      }
      return instan;
    }
    set {

    }
  }

  protected GManager () {

  }

	void Start () {
    EnemyManager.Instance.Start ();
    /*
    inst = EnemyManager.Instance;
    foreach(KeyValuePair<string, GameObject> w in inst.enemy_waves) {
      Create (w.Key, w.Value);
    }
    */
	}
	
	void Update () {
		
	}

  public void Create (string s, GameObject obj) {
    GameObject wave;
    wave = (GameObject)Instantiate (obj, new Vector3 (x, y, z), Quaternion.identity);
    wave.transform.localScale = new Vector3 (30, 30, 30);
    wave.gameObject.SetActive (false);
    wave.transform.parent = this.transform;
    inst.pool_enemy_waves.Add (s, wave);
  }
}
