using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyWaveObj {
  //waveをdictionaryで管理したい→だけどdictionaryはinspectorに表示されない
  //→ならば自分でinspectorに表示されるdictionaryクラスを作りましょう（予定）
  private Dictionary<string, GameObject> waves;
}
