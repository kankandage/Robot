using UnityEngine;
using System.Collections;

public class CamerraControl : MonoBehaviour
{
    // Use this for initialization
    public Transform target;//获取旋转目标
    private float speed = 5f;
    //
    private void camerarotate() //摄像机围绕目标旋转操作
    {
        var mouse_x = Input.GetAxis("Mouse X");//获取鼠标X轴移动
        //if (Input.GetMouseButton(1) && mouse_x > 0)
        //{
        //    transform.RotateAround(target.position, Vector3.up, speed * (mouse_x * 15f) * Time.deltaTime); //摄像机围绕目标旋转
        //}
        //if (Input.GetMouseButton(1) && mouse_x < 0)
        //{
        //    transform.RotateAround(target.position, Vector3.down, speed * (mouse_x * 15f) * Time.deltaTime); //摄像机围绕目标旋转
        //}
        var mouse_y = -Input.GetAxis("Mouse Y");//获取鼠标Y轴移动
        if (Input.GetMouseButton(1))
        {
            transform.RotateAround(target.transform.position, Vector3.up, mouse_x * 5);
            transform.RotateAround(target.transform.position, transform.right, mouse_y * 5);
        }
    }
    private void camerazoom() //摄像机滚轮缩放
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
            transform.Translate(Vector3.forward * 0.5f);
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
            transform.Translate(Vector3.forward * -0.5f);
    }
    void Update()
    {
        camerarotate();
        camerazoom();
    }
}
