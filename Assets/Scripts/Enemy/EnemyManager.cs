using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyManager : MonoBehaviour{
  //敵の生成を管理するクラス
  //機能はAppearManagerに渡す予定

  public List<GameObject> waves_model; //waveprefab入れ
  /*
  [HideInInspector]
  public List<GameObject> waves;
  */

  public float speed = 0.1f;
  public int interval = 2;

  public GameObject nomal_bullet;
  private static EnemyManager instance = null;
  private float time;
  private int pass;
  private int wave_count;
  [HideInInspector]
  public static List<GameObject> nomal_bullets;

  private const int bulletPool = 100;

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

  private void Start () {
    pass = interval;
    for (int i = 0; i < waves_model.Count; i++) {
      waves_model[i] = CreateWave (waves_model[i]);
    }
  }

  private void Update () {
    time += Time.deltaTime;
    if (Mathf.Floor(time) == pass) {
      Appear ();
      wave_count ++;
      pass += interval;
    }
    Move ();
    Border ();
  }

  public GameObject CreateWave (GameObject obj) {
    GameObject wave;
    wave = (GameObject)Instantiate (obj);
    wave.transform.parent = this.transform;
    Hide (wave);
    return wave;
  }

  public void Appear () {
    if (wave_count < waves_model.Count) {
      waves_model[wave_count].transform.position = this.transform.position;
      waves_model[wave_count].gameObject.SetActive (true);
    }
  }

  public void Move () {
    for (int i = 0; i < waves_model.Count; i++) {
      if (waves_model [i].gameObject.activeSelf) {
        waves_model [i].transform.position =
                        new Vector3 (waves_model [i].transform.position.x, waves_model [i].transform.position.y, waves_model [i].transform.position.z - speed);
      }
    }
  }

  public void Border () {
    for (int i = 0; i < waves_model.Count; i ++) {
      if (waves_model[i].transform.position.z < -15) {
        Hide (waves_model[i]);
      }
    }
  }

  public void Hide (GameObject wave) {
    wave.transform.position = new Vector3 (0, 0, 100);
    wave.gameObject.SetActive (false);
  }

}
