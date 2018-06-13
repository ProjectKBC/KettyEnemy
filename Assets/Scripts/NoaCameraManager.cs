using UnityEditorInternal;
using UnityEngine;

public class NoaCameraManager : NoaSingletonMonoBehaviour<NoaCameraManager>
{
    [System.Serializable]
    public sealed class SettingParam
    {
        public bool isLive;
        public Object obj;
        public float depth;
        public CULLING_MASK cullingMask;

        public SettingParam(GameObject _gameObject, float _depth, CULLING_MASK _cullingMask, bool _isLive)
        {
            this.isLive = _isLive;
            this.obj = _gameObject;
            this.depth = _depth;
            this.cullingMask = _cullingMask;
        }
        public SettingParam()
        {
            this.isLive = true;
            this.obj = null;
            this.depth = -1.0f;
            this.cullingMask = CULLING_MASK.Nothing;
        }
    }

    [SerializeField]
    private bool doUpdate = false;
    [SerializeField]
    private float mNearClipPlane = 0.3f;
    [SerializeField]
    private float mFarClipPlane = 1000f;

    public SettingParam[] serializedParams = new SettingParam[] { new SettingParam() };

    // Cameraのキャッシュ
    private static Camera[] cameraParams_ = null;

    protected override void OnAwake()
    {
        int cameraMax = serializedParams.Length;
        cameraParams_ = new Camera[cameraMax];

        for (int i = 0; i < cameraMax; ++i)
        {
            // Cameraをキャッシュ
            cameraParams_[i] = (serializedParams[i].obj as GameObject).GetComponent<Camera>();
            
            cameraParams_[i].depth = serializedParams[i].depth;
            /// わかりにくい拡張メソッドを使わないといけない by flanny 04/02 2:16
            /// CULLING_MASK.ToCullingMaskInt()：cullingMask用のIDを返す
            /// CULLING_MASK.ToLayerInt()：layer用のIDを返す
            cameraParams_[i].cullingMask = serializedParams[i].cullingMask.ToCullingMaskInt();
            cameraParams_[i].gameObject.layer = serializedParams[i].cullingMask.ToLayerInt();

            cameraParams_[i].clearFlags = 
                (cameraParams_[i].cullingMask == CULLING_MASK.Default.ToCullingMaskInt())
                ? CameraClearFlags.SolidColor
                : CameraClearFlags.Depth;

            cameraParams_[i].nearClipPlane = mNearClipPlane;
            cameraParams_[i].farClipPlane = mFarClipPlane;

            if (serializedParams[i].isLive == false)
            {
                cameraParams_[i].gameObject.SetActive(false);
            }
        }
    }

    private void Update()
    {
        if (!doUpdate) { return; }

        for (int i = 0; i < cameraParams_.Length; ++i)
        {
            cameraParams_[i].gameObject.SetActive(serializedParams[i].isLive);
        }
    }
}