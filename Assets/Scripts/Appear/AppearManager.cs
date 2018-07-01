using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AppearManager {
  //敵発生装置

  public GameObject appear_prefab;
  [HideInInspector]
  public GameObject appear_obj;

  private static AppearManager instance = null;

  public static AppearManager Instance {
    get {
      if (instance == null) {
        instance = new AppearManager ();
      }
      return instance;
    }
    set {

    }
  }

  protected AppearManager () {

  }
}
