using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySingleton {
  private static EnemySingleton instance = null;
  [SerializeField]
  private Dictionary<string, GameObject> enemy_wave;

  public static EnemySingleton Instance {
    get {
      if (instance == null) {
        instance = new EnemySingleton();
      }
      return instance;
    }
    set {
      
    }
  }
}
