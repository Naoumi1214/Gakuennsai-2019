using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Windows.Kinect;

public class Kinecter
{
    //Kinect関係
    KinectSensor _Sensor;
    BodyFrameReader _Reader;
    Body[] _Data = null;

    Camera camera;
    public Kinecter()
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
    }//Constructor

    public bool KinectUpdate()
    {
        var frame = _Reader.AcquireLatestFrame();
        if (frame == null)
        {
            return false;
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
            return false;
        }

        foreach (var body in _Data)
        {
            if (body == null)
            {
                continue;
            }
            if (body.IsTracked)
            {
                return true;
            }
        }
        return false;
    }//KinectUpdate()

    public Single[] GetPosition()
    {
        Single[] righthand = null;
        foreach (Body body in this._Data)
        {
            if (body.IsTracked)
            {



                foreach (Windows.Kinect.Joint joint in body.Joints.Values)
                {

                    if (joint.JointType == JointType.HandRight)
                    {

                        
                        //骨格情報表示
                        /*switch (joint.TrackingState)
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
                        return righthand = new Single[2] { joint.Position.X, joint.Position.Y };

                    }

                }
            }
        }
        return righthand = null;
    }// GetVector3()
}
