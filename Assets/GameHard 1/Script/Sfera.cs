using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sfera : MonoBehaviour
{

    [SerializeField] private SoundManage _SoundManage;
    [SerializeField] private AudioClip _SoundBreatheClip;
    [SerializeField] private bool _IsPlaySound;
    [SerializeField] private float _RotationSpeed;

    public GameObject _Sfrea;
    private Vector3 _PosCurrMouse;
    private Vector3 _MouseDelta;
    private Vector3 _PreMousePos;
    #region phần khởi tạo
    private void Reset()
    {
        LoadComponent();
    }
    private void Start()
    {
        LoadComponent();
    }
    private void LoadComponent()
    {
        _IsPlaySound = true;
        _SoundManage = FindObjectOfType<SoundManage>();
    }
    #endregion
    private void OnMouseDown()
    {
        CubeRotation.Instance.IsCubeRotation = false;
    }
    private void OnMouseUp()
    {
        CubeRotation.Instance.IsCubeRotation = true;

    }
    private void OnMouseDrag()
    {
        _MouseDelta = Input.mousePosition - _PreMousePos;
        _MouseDelta *= _RotationSpeed;
        _Sfrea.transform.localRotation = Quaternion.Euler(_MouseDelta.y, -_MouseDelta.x, 0) * _Sfrea.transform.localRotation;
        _PreMousePos = Input.mousePosition;
        if (Input.mousePosition == _PosCurrMouse)
        {
            _SoundManage.m_AudioSource.volume = 0;
        }
        else
        {
            _SoundManage.m_AudioSource.volume = 1;
        }

        if (_IsPlaySound == true)
        {
            _SoundManage.PlaySound(_SoundBreatheClip);
            _IsPlaySound = false;
        }
        _PosCurrMouse = Input.mousePosition;
    }
}
