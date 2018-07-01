using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GManager : MonoBehaviour
{
  private static GManager instan = null;
  public EnemyManager e_sc = EnemyManager.Instance;
  public AppearManager a_sc = AppearManager.Instance;

  private int x = 0, y = 0, z = 0;

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
    AppearManager.Instance.appear_obj = Instantiate (AppearManager.Instance.appear_prefab, new Vector3 (0, 0, 0), Quaternion.identity);
    EnemyManager.Instance.Init ();
	}
	
	void Update () {
		
	}

  public void CreateWave (GameObject obj) {
    GameObject wave;
    wave = (GameObject)Instantiate (obj, new Vector3 (x, y, z), Quaternion.identity, AppearManager.Instance.appear_obj.transform);
    wave.transform.localScale = new Vector3 (1, 1, 1);
    wave.gameObject.SetActive (false);
    EnemyManager.Instance.waves.Add (wave);
  }
}
