using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyManager : MonoBehaviour {

  public enum WavePattern {
    Horizontal,
    Vertical
  }

  //敵の生成や出現を管理するクラス

  public List<GameObject> waves_model; //waveprefab入れ
  public WavePattern [] wave_patterns; //出方を記憶するenum配列
  private Dictionary<string, List<GameObject>> instance_waves; //waveをプールする辞書型配列

  /*
  [HideInInspector]
  public List<GameObject> waves;
  */

  public float speed = 0.1f;
  public float interval = 2;

  private static EnemyManager instance = null;
  private float time;
  private float pass;
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

  private void Awake () {
    instance_waves = new Dictionary<string, List<GameObject>>();
    pass = interval;
    for (int i = 0; i < waves_model.Count; i ++) {
      instance_waves.Add (waves_model[i].name, new List<GameObject> { CreateWave (waves_model [i]), CreateWave (waves_model [i]) });
    }
  }

  private void Update () {
    time += Time.deltaTime;
    if (Mathf.Floor(time * 10) / 10 == pass) {
      Appear ();
      wave_count ++;
      pass += interval;
    }
    Move ();
  }

  public GameObject CreateWave (GameObject obj) {
    GameObject wave;
    wave = (GameObject)Instantiate (obj);
    wave.transform.parent = this.transform;
    Hide (wave);
    return wave;
  }

  public void Appear () {
    if (wave_count < wave_patterns.Length) {
      List<GameObject> want_waves = instance_waves [wave_patterns [wave_count].ToString()];
      for (int i = 0; i < want_waves.Count; i++) {
        if (!want_waves [i].gameObject.activeSelf) {
          want_waves [i].transform.position = this.transform.position;
          want_waves [i].gameObject.SetActive (true);
          break;
        }
      }
    }
  }

  public void Move () {
    foreach (KeyValuePair<string, List<GameObject>> obj in instance_waves) {
      for (int k = 0; k < obj.Value.Count; k++) {
        if (obj.Value[k].gameObject.activeSelf) {
          obj.Value [k].transform.position = 
            new Vector3 (obj.Value [k].transform.position.x, obj.Value [k].transform.position.y, obj.Value [k].transform.position.z - speed);
        }
        BottomBorder (obj.Value [k]);
      }
    }
  }

  public void BottomBorder (GameObject wave) {
    if (wave.transform.position.z < -15) {
      Hide (wave);
    }
  }

  public void Hide (GameObject wave) {
    wave.transform.position = new Vector3 (0, 0, 100);
    wave.gameObject.SetActive (false);
  }

}
