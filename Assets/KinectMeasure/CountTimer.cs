using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Windows.Kinect;

public class CountTimer : MonoBehaviour
{
    //動的カウントテキスト用のオブジェクト
    public GameObject Timer = null;

    float NowTime = 7;

    //身長
    List<Single> HeightList = new List<Single>();  
    public static Single Height = -1;

    //Kinect関係
    KinectSensor _Sensor;
    BodyFrameReader _Reader;
    Body[] _Data = null;

    // Start is called before the first frame update
    void Start()
    {

        Invoke("boole", 1.2f);//進む処理の処理の遅延→★
        _Sensor = KinectSensor.GetDefault();
        if (_Sensor != null)
        {
            _Reader = _Sensor.BodyFrameSource.OpenReader();
            if (!_Sensor.IsOpen)
            {
                _Sensor.Open();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        KinectUpdate();

        //カウントダウン
        Text Timer_text = Timer.GetComponent<Text>();
        NowTime -= Time.deltaTime;
        Timer_text.text = "残り時間" + (int)NowTime + "秒";
        //シーン切り替え
        if (NowTime <=0)
        {
            Debug.Log(this.HeightList.Count());
            Height = (Single)(this.HeightList.Sum() / this.HeightList.Count());
            SceneManager.LoadScene("main");
        }

    }


    public static Single getHeight()
    {
        return Height;
    }

    /**
     * Kinectがボディを取得
     */
    void KinectUpdate()
    {
        var frame = _Reader.AcquireLatestFrame();
        if (frame == null)
        {
            return;
        }
        if (_Data == null)
        {
            _Data = new Body[_Sensor.BodyFrameSource.BodyCount];
        }
        frame.GetAndRefreshBodyData(_Data);
        frame.Dispose();
        frame = null;

        if (_Data == null)
        {
            return;
        }

        foreach (var body in _Data)
        {
            if (body == null)
            {
                continue;
            }
            if (body.IsTracked)
            {
                writeJointsData();
                break;
            }
        }
    }//KinectUpdate()

    /**
     * Kinectが頭の伸長を取得する
     */
    private void writeJointsData()
    {
        //複数の体をトラックしている際に、一つ一つの体の情報をトラックする
        foreach (Body body in this._Data)
        {
           
            if (body.IsTracked)
            {



               
                foreach (Windows.Kinect.Joint joint in body.Joints.Values)
                {

                    if (joint.JointType == JointType.Head)
                    {
                        //頭のYの位置を代入
                        this.HeightList.Add(joint.Position.Y);

                        var point = joint.Position;




                        //骨格情報表示
                        switch (joint.TrackingState)
                        {
                            case TrackingState.Tracked:
                                Debug.Log(joint.JointType + "は正しく計測されており、" + "X:" + joint.Position.X + ", Y:" + joint.Position.Y + ", Z:" + joint.Position.Z);
                                break;
                            case TrackingState.Inferred:
                                Debug.Log(joint.JointType + "は位置を推測しており、その値は" + "X:" + joint.Position.X + ", Y:" + joint.Position.Y + ", Z:" + joint.Position.Z);
                                break;
                            case TrackingState.NotTracked:
                                Debug.Log(joint.JointType + "は位置を測定できませんでした。");
                                break;
                        }
                    }

                }
            }
        }
    }//writeJointsData()
}
