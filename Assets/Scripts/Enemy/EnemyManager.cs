using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyManager {
  //敵の生成を管理するクラス
  //機能はAppearManagerに渡す予定

  //dictionaryはinspectorに表示されない
  public Dictionary<string, GameObject> enemy_waves;
  public Dictionary<string, GameObject> pool_enemy_waves;
  public List<GameObject> waves_model; //waveprefab入れ

  //生成したwaveオブジェクト入れ、改善が必要かもしれない？

  //[System.NonSerialized]だとaddができない
  [HideInInspector]
  public List<GameObject> waves;

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

  public void Init () {
    for (int i = 0; i < Instance.waves_model.Count; i ++) {
      GManager.Instance.CreateWave (Instance.waves_model[i]);
    }
  }
}
