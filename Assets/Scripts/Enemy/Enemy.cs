using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy {
  // EnemyManagerで言及したやつ
  //public int hp;
  [SerializeField]
  private int hp;

  public Enemy () {
    // これ this.hp = this.hp してるよ
    this.hp = hp;
  }

  public Enemy (int hp) {
    this.hp = hp;
  }

}
