using UnityEngine;
using UnityEngine.UI;

public class TestUIManager : MonoBehaviour
{
    private Text mText_EditModeValue;
    private Text mText_AxisModeValue;
    private Text mText_PositionXValue;
    private Text mText_PositionYValue;
    private Text mText_PositionZValue;
    private Text mText_RotateXValue;
    private Text mText_RotateYValue;
    private Text mText_RotateZValue;
    private Text mText_ScaleXValue;
    private Text mText_ScaleYValue;
    private Text mText_ScaleZValue;
    private Text mText_SpeedValue;

    private bool ready = false;

    private void Awake()
    {
        // todo: Findを使わずに改善せよ
        mText_EditModeValue  = GameObject.Find("Canvas_TestUI/Text_EditModeValue").GetComponent<Text>();
        mText_AxisModeValue  = GameObject.Find("Canvas_TestUI/Text_AxisModeValue").GetComponent<Text>();
        mText_PositionXValue = GameObject.Find("Canvas_TestUI/Position/Text_PositionXValue").GetComponent<Text>();
        mText_PositionYValue = GameObject.Find("Canvas_TestUI/Position/Text_PositionYValue").GetComponent<Text>();
        mText_PositionZValue = GameObject.Find("Canvas_TestUI/Position/Text_PositionZValue").GetComponent<Text>();
        mText_RotateXValue   = GameObject.Find("Canvas_TestUI/Rotate/Text_RotateXValue").GetComponent<Text>();
        mText_RotateYValue   = GameObject.Find("Canvas_TestUI/Rotate/Text_RotateYValue").GetComponent<Text>();
        mText_RotateZValue   = GameObject.Find("Canvas_TestUI/Rotate/Text_RotateZValue").GetComponent<Text>();
        mText_ScaleXValue    = GameObject.Find("Canvas_TestUI/Scale/Text_ScaleXValue").GetComponent<Text>();
        mText_ScaleYValue    = GameObject.Find("Canvas_TestUI/Scale/Text_ScaleYValue").GetComponent<Text>();
        mText_ScaleZValue    = GameObject.Find("Canvas_TestUI/Scale/Text_ScaleZValue").GetComponent<Text>();
        mText_SpeedValue     = GameObject.Find("Canvas_TestUI/Speed/Text_SpeedValue").GetComponent<Text>();

        ready = true;
    }

    public void SetEditMode(string _str)
    {
        if (!ready) { return; }

        mText_EditModeValue.text = _str;
    }   

    public void SetAxisMode(string _str)
    {
        if (!ready) { return; }
   
        mText_AxisModeValue.text = _str;
    }

    public void SetParam(Transform _trans, float _speed)
    {
        if (!ready) { return; }

        Vector3 pos = _trans.position;
        Vector3 rotate = _trans.eulerAngles;
        Vector3 scale = _trans.localScale;

        mText_PositionXValue.text = pos.x.ToString();
        mText_PositionYValue.text = pos.y.ToString();
        mText_PositionZValue.text = pos.z.ToString();

        mText_RotateXValue.text = rotate.x.ToString();
        mText_RotateYValue.text = rotate.y.ToString();
        mText_RotateZValue.text = rotate.z.ToString();

        mText_ScaleXValue.text = scale.x.ToString();
        mText_ScaleYValue.text = scale.y.ToString();
        mText_ScaleZValue.text = scale.z.ToString();

        mText_SpeedValue.text = _speed.ToString();
    }
}
