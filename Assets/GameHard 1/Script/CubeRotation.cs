
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
    private void Start()
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


#if UNITY_ANDROID
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                _mouseDelta = touch.deltaPosition;
                _mouseDelta *= _RotationSpeed;
                transform.rotation = Quaternion.Euler(_mouseDelta.y, -_mouseDelta.x, 0) * transform.rotation;
            }
        }

#endif


    }
}
