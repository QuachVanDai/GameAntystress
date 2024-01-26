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
        LoadComponent();
    }
    private void LoadComponent()
    {
        _SoundManage = FindObjectOfType<SoundManage>();
        BoxCollider = GetComponent<BoxCollider>();
    }
    #endregion
    private void OnMouseDrag()
    {
        // Kiểm tra nếu nút chuột trái đang được giữ
        if (Input.GetMouseButton(0))
        {
            // Lấy giá trị di chuyển chuột theo trục X và Y
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
            // Xoay đối tượng dựa trên giá trị di chuyển chuột
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
