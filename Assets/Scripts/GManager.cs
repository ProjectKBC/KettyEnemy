using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//そのうち使うのかもしれないので残しているだけのクラス
public class GManager : MonoBehaviour {
  private static GManager instan = null;

  //public EnemyManager e_sc = EnemyManager.Instance;
  public GameObject e_mana_pre;
  public static GameObject e_mana;

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

  /*
  protected GManager () {

  }
  */

	void Start () {
    //AppearManager.Instance.Init ();
    //Vector3 test = new Vector3 (0.0f, 0.0f, 10.0f);
    //Instantiate (AppearManager.Instance.appear_prefab, test, Quaternion.identity);
    //AppearManager.Instance.appear_obj.transform.localScale = new Vector3 (1, 1, 1);
    //e_mana = Instantiate (e_mana_pre, new Vector3 (0.0f, 0.0f, 100.0f), Quaternion.identity);
    //EnemyManager.Instance.Init ();
	}
	
	void Update () {
    //Debug.Log (AppearManager.Instance.appear_obj.transform.position + "絶対座標");
    //Debug.Log (AppearManager.Instance.appear_obj.transform.localPosition + "親から見た座標");
	}

  /*
  public void CreateAppear (GameObject obj) {
    GManager.Instance.appear_machine = (GameObject)Instantiate (obj, new Vector3 (0.0f, 0.0f, 10.0f), Quaternion.identity);
    Debug.Log (GManager.Instance.appear_machine + "aaa");
    GManager.Instance.appear_machine.transform.localScale = new Vector3 (1, 1, 1);
  }
  */
}
