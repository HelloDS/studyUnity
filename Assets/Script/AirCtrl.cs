using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirCtrl : MonoBehaviour
{
    //旋转最大角度
    public int yMinLimit = -45;

    public int yMaxLimit = 45;

    //旋转速度
    public float xSpeed = 250.0f;

    public float ySpeed = 120.0f;

    //旋转角度
    private float x = 0.0f;
    private float y = 0.0f;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            //将屏幕坐标转化为世界坐标  ScreenToWorldPoint函数的z轴不能为0，不然返回摄像机的位置，而Input.mousePosition的z轴为0
            //z轴设成10的原因是摄像机坐标是（0，0，-10），而物体的坐标是（0，0，0），所以加上10，正好是转化后物体跟摄像机的距离
            // Vector3 temp = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
            // transform.position = temp;
            
            x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
            x = ClampAngle(x, yMinLimit, yMaxLimit);
            Debug.Log("ssss===x   " + x);
            //欧拉角转化为四元数
            Quaternion rotation = Quaternion.Euler(0, x, 0);
            transform.rotation = rotation;
        }
    }

    //角度范围值限定
    static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360)
            angle += 360;
        if (angle > 360)
            angle -= 360;
        return Mathf.Clamp(angle, min, max);
    }
}