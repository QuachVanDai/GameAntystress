using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear : MonoBehaviour
{
    public float RotationSpeed = 5.0f;
    public GameObject _Gear;
    public BoxCollider BoxCollider;

    [SerializeField] private SoundManage _SoundManage;

    [SerializeField] private AudioClip _SoundGearClip;
    [SerializeField] private bool _IsPlaySound;

    #region phần khởi tạo
    private void Reset()
    {
        LoadComponent();
    }
    private void Start()
    {
    }
    private void LoadComponent()
    {
        _SoundManage = FindObjectOfType<SoundManage>();
        BoxCollider = GetComponent<BoxCollider>();
    }
    #endregion
    private void OnMouseDrag()
    {
        if (Input.GetMouseButton(0))
        {
            float mouseX = Input.GetAxis("Mouse X");
            if (mouseX!=0 && _IsPlaySound)
            {
                _SoundManage.PlaySound(_SoundGearClip);
                _IsPlaySound = false;
            }
            else if (mouseX == 0)
            {
                _IsPlaySound=true;
                _SoundManage.StopSound();
            }
            _Gear.transform.Rotate(Vector3.up, mouseX * RotationSpeed);
        }
    }
    private void OnMouseDown()
    {
        CubeRotation.Instance.IsCubeRotation = false;
    }
    private void OnMouseUp()
    {
        CubeRotation.Instance.IsCubeRotation = true;
        _SoundManage.StopSound();
    }
}
