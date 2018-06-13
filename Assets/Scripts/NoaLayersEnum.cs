using UnityEngine;

/// Issue:Layersの更新にあわせて手動で書き直す必要がある by flanny 04/02 2:16
public enum CULLING_MASK
{
    Nothing,
    Everything,
    Default,
    TransparentFX,
    IgnoreRaycast,
    Water,
    UI,

    PostProcessing,

    Enemy,
    Player,
    EnemyBullet,
    PlayerBullet,
    Stage,
    userLayer14,
    userLayer15,
    userLayer16,
    userLayer17,
    userLayer18,
    userLayer19,
    userLayer20,
    userLayer21,
    userLayer22,
    userLayer23,
    userLayer24,
    userLayer25,
    userLayer26,
    userLayer27,
    userLayer28,
    userLayer29,
    userLayer30,
    userLayer31
}

// CULLING_MASKの拡張メソッド集
/// Issue: Layersの更新にあわせて手動で書き直す必要がある by flanny 04/02 2:16
public static class CullingMaskExtensions
{
    public static int ToCullingMaskInt(this CULLING_MASK _cullingMask)
    {
        switch (_cullingMask)
        {
            case CULLING_MASK.Nothing: return 0;
            case CULLING_MASK.Everything: return -1;
            case CULLING_MASK.Default: return (int)Mathf.Pow(2, 0);
            case CULLING_MASK.TransparentFX: return (int)Mathf.Pow(2, 1);
            case CULLING_MASK.IgnoreRaycast: return (int)Mathf.Pow(2, 2);
            case CULLING_MASK.Water: return (int)Mathf.Pow(2, 4);
            case CULLING_MASK.UI: return (int)Mathf.Pow(2, 5);

            case CULLING_MASK.PostProcessing: return (int)Mathf.Pow(2, 8);

            case CULLING_MASK.Enemy:  return (int)Mathf.Pow(2, 9);
            case CULLING_MASK.Player: return (int)Mathf.Pow(2, 10);
            case CULLING_MASK.EnemyBullet: return (int)Mathf.Pow(2, 11);
            case CULLING_MASK.PlayerBullet: return (int)Mathf.Pow(2, 12);
            case CULLING_MASK.Stage: return (int)Mathf.Pow(2, 13);
            case CULLING_MASK.userLayer14: return (int)Mathf.Pow(2, 14);
            case CULLING_MASK.userLayer15: return (int)Mathf.Pow(2, 15);
            case CULLING_MASK.userLayer16: return (int)Mathf.Pow(2, 16);
            case CULLING_MASK.userLayer17: return (int)Mathf.Pow(2, 17);
            case CULLING_MASK.userLayer18: return (int)Mathf.Pow(2, 18);
            case CULLING_MASK.userLayer19: return (int)Mathf.Pow(2, 19);
            case CULLING_MASK.userLayer20: return (int)Mathf.Pow(2, 20);
            case CULLING_MASK.userLayer21: return (int)Mathf.Pow(2, 21);
            case CULLING_MASK.userLayer22: return (int)Mathf.Pow(2, 22);
            case CULLING_MASK.userLayer23: return (int)Mathf.Pow(2, 23);
            case CULLING_MASK.userLayer24: return (int)Mathf.Pow(2, 24);
            case CULLING_MASK.userLayer25: return (int)Mathf.Pow(2, 25);
            case CULLING_MASK.userLayer26: return (int)Mathf.Pow(2, 26);
            case CULLING_MASK.userLayer27: return (int)Mathf.Pow(2, 27);
            case CULLING_MASK.userLayer28: return (int)Mathf.Pow(2, 28);
            case CULLING_MASK.userLayer29: return (int)Mathf.Pow(2, 29);
            case CULLING_MASK.userLayer30: return (int)Mathf.Pow(2, 30);
            case CULLING_MASK.userLayer31: return (int)Mathf.Pow(2, 31);
        }

        return 0;
    }

    public static int ToLayerInt(this CULLING_MASK _cullingMask)
    {
        switch (_cullingMask)
        {
            case CULLING_MASK.Default: return 0;
            case CULLING_MASK.TransparentFX: return 1;
            case CULLING_MASK.IgnoreRaycast: return 2;
            case CULLING_MASK.Water: return 4;
            case CULLING_MASK.UI: return 5;

            case CULLING_MASK.PostProcessing: return 8;

            case CULLING_MASK.Enemy:  return 9;
            case CULLING_MASK.Player:  return 10;
            case CULLING_MASK.EnemyBullet: return 11;
            case CULLING_MASK.PlayerBullet: return 12;
            case CULLING_MASK.Stage: return 13;
            case CULLING_MASK.userLayer14: return 14;
            case CULLING_MASK.userLayer15: return 15;
            case CULLING_MASK.userLayer16: return 16;
            case CULLING_MASK.userLayer17: return 17;
            case CULLING_MASK.userLayer18: return 18;
            case CULLING_MASK.userLayer19: return 19;
            case CULLING_MASK.userLayer20: return 20;
            case CULLING_MASK.userLayer21: return 21;
            case CULLING_MASK.userLayer22: return 22;
            case CULLING_MASK.userLayer23: return 23;
            case CULLING_MASK.userLayer24: return 24;
            case CULLING_MASK.userLayer25: return 25;
            case CULLING_MASK.userLayer26: return 26;
            case CULLING_MASK.userLayer27: return 27;
            case CULLING_MASK.userLayer28: return 28;
            case CULLING_MASK.userLayer29: return 29;
            case CULLING_MASK.userLayer30: return 30;
            case CULLING_MASK.userLayer31: return 31;
        }
        return -1;
    }
}