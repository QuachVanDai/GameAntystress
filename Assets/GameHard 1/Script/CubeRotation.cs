using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public class CubeRotation : MonoBehaviour
{
    private static CubeRotation _instance;
    public static CubeRotation Instance { get { return _instance; } }
    private Vector3 _mouseDelta;
    private Vector3 _preMousePos;
    private bool _IsCubeRotation;
    [SerializeField] private float _RotationSpeed;


    public bool IsCubeRotation { get { return _IsCubeRotation; } set {  _IsCubeRotation = value; } }
    private void Awake()
    {
        if (_instance != null) { Debug.LogWarning("Chi ton tai 1 CubeRotation "); return; }
        CubeRotation._instance = this;
    }
    void Start()
    {
        LoadComponent();
    }
    private void LoadComponent()
    {
        _IsCubeRotation = true;
    }
    private void  Update()
    {
        if(!_IsCubeRotation) { return; }
        Rotation();
    }
    private void Rotation()
    {
        if(Input.GetMouseButton(0))
        {
             _mouseDelta = Input.mousePosition - _preMousePos;
             _mouseDelta *= _RotationSpeed;
             transform.rotation = Quaternion.Euler(_mouseDelta.y, -_mouseDelta.x, 0) * transform.rotation;
        }
        _preMousePos = Input.mousePosition;
    }
}
