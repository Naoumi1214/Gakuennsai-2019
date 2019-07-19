using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Windows.Kinect;
public class KinectController
{
    //プレイヤーの身長
    Single Height = 0;

    //Kinect関係
    KinectSensor _Sensor;
    BodyFrameReader _Reader;
    Body[] _Data = null;


    //ジャンプの判定
    Boolean Jumping = false;

    //とんだ高さ割合
    Single JumpingHeight = 0;
    public KinectController()
    {
        _Sensor = KinectSensor.GetDefault();
        if (_Sensor != null)
        {
            _Reader = _Sensor.BodyFrameSource.OpenReader();
            if (!_Sensor.IsOpen)
            {
                _Sensor.Open();
            }
        }
        this.Height = CountTimer.getHeight();
        Debug.Log(this.Height);
    }

    public Boolean getJumping()
    {
        Debug.Log(this.Jumping);
        return this.Jumping;
    }//getJumping()

    public Single getJumpingHeight()
    {
        Debug.Log(this.JumpingHeight);
        return this.JumpingHeight;
    }

    public Single getHeight()
    {
        return this.Height;
    }

    /**
     * Kinectがボディを取得
     */
    public void KinectUpdate()
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
     * ジャンプ可能かを判定＆座標に関するログを表示
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

                        var point = joint.Position;

                        //ジャンプするための判定
                        if (point.Y > (this.Height * 1.2))
                        {
                            Debug.Log("超えてるよ");
                            this.Jumping = true;
                            this.JumpingHeight = point.Y　/ Height;
                        }
                        else if (point.Y < (this.Height * 1.2))
                        {
                            Debug.Log("超えてないよ");
                            this.Jumping = false;
                        }


                        /*
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
                        }*/
                    }

                }
            }
        }
    }//writeJointsData()
}


