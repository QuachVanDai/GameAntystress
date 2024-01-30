using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear : MonoBehaviour
{
    private const float RotationSpeed = 7.0f;
    [SerializeField] private GameObject _Gear;
    [SerializeField] private BoxCollider BoxCollider;
    [SerializeField] private SoundManage _SoundManage;
    [SerializeField] private AudioClip _SoundGearClip;
    [SerializeField] private bool _IsPlaySound;

    private void Reset()
    {
        _SoundManage = FindObjectOfType<SoundManage>();
        BoxCollider = GetComponent<BoxCollider>();
    }
    private void OnMouseDrag()
    {
       // if (!Input.GetMouseButton(0)) return;

            float mouseX = Input.GetAxis("Mouse X");
        if (mouseX != 0 && _IsPlaySound)
        {
            _SoundManage.PlaySound(_SoundGearClip);
            _IsPlaySound = false;
        }
        else if (mouseX == 0)
        {
            _IsPlaySound = true;
            _SoundManage.StopSound();
        }
            _Gear.transform.Rotate(Vector3.up, mouseX * RotationSpeed);
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
