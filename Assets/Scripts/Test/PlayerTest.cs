using UnityEngine;

public class PlayerTest : MonoBehaviour
{
    public enum EditMode
    {
        EditPosition_Move,
        EditRotate,
        EditScale,
        EditSpeed,
    }

    public enum AxisMode
    {
        X,
        Y,
        Z,
    }

    // ver2018でプロパティがまともに対応するはず
    public float speed = 0.0f;
    private float mSpeed { get { return speed * 0.1f; } set { speed = value; } }

    private EditMode mEditMode ;
    private AxisMode mAxisMode;

    // transformのキャッシュ
    private Transform mTrans;

    // TestUIManagerのキャッシュ
    private TestUIManager mTestUIManager;

	private void Awake ()
    {
        // キャッシュ類
        mTrans = transform;
        mTestUIManager = GameObject.Find("Canvas_TestUI").GetComponent<TestUIManager>();

        // パラメータの初期化
        mEditMode = EditMode.EditPosition_Move;
        mAxisMode = AxisMode.X;
	}
	
	private void Update ()
    {
        ChangeEditMode();

        switch(mEditMode)
        {
            case EditMode.EditPosition_Move:
                Move();
                break;

            case EditMode.EditRotate:
                EditRotate();
                break;

            case EditMode.EditScale:
                EditScale();
                break;

            case EditMode.EditSpeed:
                EditSpeed();
                break;

            default: Debug.LogError("Impossible EditMode"); break;
        }

        SendParam();
    }

    private void ChangeEditMode()
    {
        if (Input.GetKey(KeyCode.P) || Input.GetKey(KeyCode.M))
        {
            mEditMode = EditMode.EditPosition_Move;
        }

        if (Input.GetKey(KeyCode.R))
        {
            mEditMode = EditMode.EditRotate;
        }

        // Sのみ
        if (Input.GetKey(KeyCode.S) && !(Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt)))
        {
            mEditMode = EditMode.EditScale;
        }

        // S + Alt
        if (Input.GetKey(KeyCode.S) && (Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt)))
        {
            mEditMode = EditMode.EditSpeed;
        }
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.UpArrow))    { mTrans.localPosition += Vector3.forward * mSpeed; }
        if (Input.GetKey(KeyCode.DownArrow))  { mTrans.localPosition += Vector3.back    * mSpeed; }
        if (Input.GetKey(KeyCode.RightArrow)) { mTrans.localPosition += Vector3.right   * mSpeed; }
        if (Input.GetKey(KeyCode.LeftArrow))  { mTrans.localPosition += Vector3.left    * mSpeed; }
    }

    private void EditRotate()
    {
        ChangeAxisMode();

        switch(mAxisMode)
        {
            case AxisMode.X:
                if (Input.GetKey(KeyCode.UpArrow))    { mTrans.Rotate(new Vector3(1, 0, 0) * 1);     }
                if (Input.GetKey(KeyCode.DownArrow))  { mTrans.Rotate(new Vector3(1, 0, 0) * -1);    }
                if (Input.GetKey(KeyCode.RightArrow)) { mTrans.Rotate(new Vector3(1, 0, 0) * 0.1f);  }
                if (Input.GetKey(KeyCode.LeftArrow))  { mTrans.Rotate(new Vector3(1, 0, 0) * -0.1f); }
                break;

            case AxisMode.Y:
                if (Input.GetKey(KeyCode.UpArrow))    { mTrans.Rotate(new Vector3(0, 1, 0) * 1);     }
                if (Input.GetKey(KeyCode.DownArrow))  { mTrans.Rotate(new Vector3(0, 1, 0) * -1);    }
                if (Input.GetKey(KeyCode.RightArrow)) { mTrans.Rotate(new Vector3(0, 1, 0) * 0.1f);  }
                if (Input.GetKey(KeyCode.LeftArrow))  { mTrans.Rotate(new Vector3(0, 1, 0) * -0.1f); }
                break;

            case AxisMode.Z:
                if (Input.GetKey(KeyCode.UpArrow))    { mTrans.Rotate(new Vector3(0, 0, 1) * 1);     }
                if (Input.GetKey(KeyCode.DownArrow))  { mTrans.Rotate(new Vector3(0, 0, 1) * -1);    }
                if (Input.GetKey(KeyCode.RightArrow)) { mTrans.Rotate(new Vector3(0, 0, 1) * 0.1f);  }
                if (Input.GetKey(KeyCode.LeftArrow))  { mTrans.Rotate(new Vector3(0, 0, 1) * -0.1f); }
                break;

            default: Debug.LogError("Impossible AxisMode"); break;
        }

    }

    private void EditScale()
    {
        ChangeAxisMode();
        
        switch(mAxisMode)
        {
            case AxisMode.X:
                if (Input.GetKey(KeyCode.UpArrow))    { mTrans.localScale += new Vector3(1, 0, 0) * 0.1f;   }
                if (Input.GetKey(KeyCode.DownArrow))  { mTrans.localScale += new Vector3(1, 0, 0) * -0.1f;  }
                if (Input.GetKey(KeyCode.RightArrow)) { mTrans.localScale += new Vector3(1, 0, 0) * 0.01f;  }
                if (Input.GetKey(KeyCode.LeftArrow))  { mTrans.localScale += new Vector3(1, 0, 0) * -0.01f; }
                break;

            case AxisMode.Y:
                if (Input.GetKey(KeyCode.UpArrow))    { mTrans.localScale += new Vector3(0, 1, 0) * 0.1f;   }
                if (Input.GetKey(KeyCode.DownArrow))  { mTrans.localScale += new Vector3(0, 1, 0) * -0.1f;  }
                if (Input.GetKey(KeyCode.RightArrow)) { mTrans.localScale += new Vector3(0, 1, 0) * 0.01f;  }
                if (Input.GetKey(KeyCode.LeftArrow))  { mTrans.localScale += new Vector3(0, 1, 0) * -0.01f; }
                break;

            case AxisMode.Z:
                if (Input.GetKey(KeyCode.UpArrow))    { mTrans.localScale += new Vector3(0, 0, 1) * 0.1f;   }
                if (Input.GetKey(KeyCode.DownArrow))  { mTrans.localScale += new Vector3(0, 0, 1) * -0.1f;  }
                if (Input.GetKey(KeyCode.RightArrow)) { mTrans.localScale += new Vector3(0, 0, 1) * 0.01f;  }
                if (Input.GetKey(KeyCode.LeftArrow))  { mTrans.localScale += new Vector3(0, 0, 1) * -0.01f; }
                break;

            default: Debug.LogError("Impossible AxisMode"); break;
        }
    }

    private void EditSpeed()
    {
        if (Input.GetKey(KeyCode.UpArrow))    { mSpeed += 1; }
        if (Input.GetKey(KeyCode.DownArrow))  { mSpeed += -1; }
        if (Input.GetKey(KeyCode.RightArrow)) { mSpeed += 0.1f; }
        if (Input.GetKey(KeyCode.LeftArrow))  { mSpeed += -0.1f; }

        SendMode();
    }

    private void ChangeAxisMode()
    {
        if (Input.GetKey(KeyCode.X)) { mAxisMode = AxisMode.X; }
        if (Input.GetKey(KeyCode.Y)) { mAxisMode = AxisMode.Y; }
        if (Input.GetKey(KeyCode.Z)) { mAxisMode = AxisMode.Z; }

        SendMode();
    }

    private void SendMode()
    {
        // TestUIManagerにModeの状態を送る

        mTestUIManager.SetEditMode(mEditMode.ToString());
        mTestUIManager.SetAxisMode(mAxisMode.ToString());
    }

    private void SendParam()
    {
        // TestUIManagerにパラメータの値を送る

        mTestUIManager.SetParam(mTrans, speed);
    }
}
