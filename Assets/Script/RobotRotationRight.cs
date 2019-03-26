using UnityEngine;
using System.Collections;

public class RobotRotationRight : MonoBehaviour
{

    private Transform Hand;
    private Transform Forearm;//小臂
    private Transform BigArm;//大臂
    public Transform Shouder;//肩膀

    float m_RotateHand;
    float m_RotateForearm;
    float m_RotateBigArm;
    float m_RotateShouder;
    // Use this for initialization
    string Tag;
    void Start()
    {
        Shouder = transform;
        BigArm = transform.Find("右侧肩膀/大臂");
        Forearm = transform.Find("右侧肩膀/大臂/小臂");
        Hand = transform.Find("右侧肩膀/大臂/小臂/手");


    }
    //肩
    void RobotShouderRotate(Transform Rotation, float MinAngle, float MaxAngle, float Speed)
    {
        m_RotateShouder -= Input.GetAxis("Mouse X") * Speed;
        m_RotateShouder = Mathf.Clamp(m_RotateShouder, MinAngle, MaxAngle);
        Rotation.transform.localEulerAngles = new Vector3(0, 0, m_RotateShouder);

    }
    //大臂
    void RobotBigArmRotate(Transform Rotation, float MinAngle, float MaxAngle, float Speed)
    {
        m_RotateBigArm -= Input.GetAxis("Mouse X") * Speed;
        m_RotateBigArm = Mathf.Clamp(m_RotateBigArm, MinAngle, MaxAngle);
        Rotation.transform.localEulerAngles = new Vector3(0, 0, m_RotateBigArm);
        // Debug.Log(m_RotateBigArm);
    }
    //小臂
    void RobotForearmRotate(Transform Rotation, float MinAngle, float MaxAngle, float Speed)
    {
        m_RotateForearm += Input.GetAxis("Mouse X") * Speed;
        m_RotateForearm = Mathf.Clamp(m_RotateForearm, MinAngle, MaxAngle);
        Rotation.transform.localEulerAngles = new Vector3(0, m_RotateForearm, 0);

    }
    //手
    void RobotHandRotate(Transform Rotation, float MinAngle, float MaxAngle, float Speed)
    {
        m_RotateHand += Input.GetAxis("Mouse X") * Speed;
        m_RotateHand = Mathf.Clamp(m_RotateHand, MinAngle, MaxAngle);
        Rotation.transform.localEulerAngles = new Vector3(0, 0, m_RotateHand);
    }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        { //首先判断是否点击了鼠标左键


            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //定义一条射线，这条射线从摄像机屏幕射向鼠标所在位置
            RaycastHit hit; //声明一个碰撞的点(暂且理解为碰撞的交点)
            if (Physics.Raycast(ray, out hit)) //如果真的发生了碰撞，ray这条射线在hit点与别的物体碰撞了
            {
              Tag=hit.collider.gameObject.tag;
            }
        }
        if (Tag=="ShouderRight")
        {
            RobotShouderRotate(Shouder, 0f, 40f, 5);
        }
        if (Tag=="BigArmRight")
        {
            RobotBigArmRotate(BigArm, 0f, 180f, 10);
        }
        if (Tag== "ForearmRight" && m_RotateBigArm>70f)
        {
            RobotForearmRotate(Forearm, 0f, 90f, 10);
        }
        if (Tag== "handRight")
        {
            RobotHandRotate(Hand, -90f, 90f, 10);

        }
        if (Input.GetMouseButtonUp(0))
        {
            Tag = null;
        }
        Debug.Log(Tag);
    }
    // RobotForearmRotate(Forearm, 0f, 90f, 10);
    //RobotHandRotate(Hand, -90f, 90f, 10);
}

