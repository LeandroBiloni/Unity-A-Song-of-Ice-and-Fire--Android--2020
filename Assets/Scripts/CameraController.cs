using easyar;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class CameraController : MonoBehaviour
{
    public VideoCameraDevice camController;
    public GameObject normalCam;
    public GameObject arCam;
    public GameObject _camToUse;
    private bool _arOn;
    public bool hasGyro;
    public GameObject crosshair;
    public GameObject changeARButton;
    public GameObject joystick;
    public Joystick joystickMagnitude;
    public GameObject joystickContainer;
    public float joystickCameraSpeed;
    public float speed;
    private Vector3 _cameraRot;
    public float crosshairDistance;

    private void Awake()
    {        
        hasGyro = SystemInfo.supportsGyroscope;
        if (hasGyro)
        {
            Input.gyro.enabled = true;
            normalCam.SetActive(false);
            arCam.SetActive(true);
            crosshair.transform.parent = arCam.transform;
            changeARButton.SetActive(true);
            joystickContainer.SetActive(false);
            _arOn = true;
            _camToUse = arCam;
            camController.Open();
        }
        else
        {
            normalCam.SetActive(true);
            arCam.SetActive(false);
            changeARButton.SetActive(false);
            joystickContainer.SetActive(true);
            crosshair.transform.parent = normalCam.transform;
            _arOn = false;
            _camToUse = normalCam;
        }            
        print(hasGyro);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (_arOn)
        {
            var angle = Input.gyro.attitude.eulerAngles;
            print(angle);
            _camToUse.transform.localEulerAngles = new Vector3(-angle.x, -angle.y, angle.z);
            crosshair.transform.localEulerAngles = new Vector3(-angle.x, -angle.y, angle.z);
            print("mi camara gira");
        }
        if(_arOn == false)
        {
            speed = joystickMagnitude.joyMagnitude;
            _cameraRot = new Vector3(-joystick.transform.localPosition.y, joystick.transform.localPosition.x, 0) * speed / joystickCameraSpeed;
            _camToUse.transform.Rotate(_cameraRot);
        }
        crosshair.transform.localPosition = new Vector3(0, 0, crosshairDistance);
        crosshair.transform.localEulerAngles = Vector3.zero;
        crosshair.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    }
    public void ChangeAR()
    {
        if (_arOn)
        {
            crosshair.transform.parent = normalCam.transform;
            normalCam.SetActive(true);
            arCam.SetActive(false);
            _camToUse = normalCam;
            _arOn = false;
            camController.Close();
            joystickContainer.SetActive(true);
        }
        else
        {
            crosshair.transform.parent = arCam.transform;
            arCam.SetActive(true);
            normalCam.SetActive(false);
            _camToUse = arCam;
            _arOn = true;
            camController.Open();
            joystickContainer.SetActive(false);
        }
    }
}
