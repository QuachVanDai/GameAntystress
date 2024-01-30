using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class WrapperInterruttore : MonoBehaviour
{
    [SerializeField] private BoxCollider[] _InterruttoreBoxColliders;
    [SerializeField] private GameObject _WrapperInterruttore;
    [SerializeField] private int _Angle, _Coefficient;
    [SerializeField] private SoundManage _SoundManage;
    [SerializeField] private AudioClip _SoundWrapperInterruttoreClip;

    private float _GetWaitTime;

    private void Reset()
    {
        _SoundManage = FindObjectOfType<SoundManage>();
        _WrapperInterruttore = GameObject.Find("WrapperInterruttore");
    }
    private void OnMouseDown()
    {
        CubeRotation.Instance.IsCubeRotation = false;
        _GetWaitTime = Time.time;
    }
    private void OnMouseUp()
    {
        CubeRotation.Instance.IsCubeRotation = true;
        if (Time.time - _GetWaitTime > 0.4f)  return;

        _WrapperInterruttore.transform.DOLocalRotate(new Vector3(0,0, _Angle),0.1f).SetEase(Ease.OutBack).OnComplete(()=>
        {
            _SoundManage.PlaySound(_SoundWrapperInterruttoreClip);

            _WrapperInterruttore.transform.DOLocalRotate(new Vector3(0, 0, _Angle - _Coefficient), 0.05f).OnComplete(() =>
            {
                _WrapperInterruttore.transform.DOLocalRotate(new Vector3(0, 0, _Angle ), 0.05f).OnComplete(() =>
                {
                    _SoundManage.StopSound();
                });

            });
        });
        _InterruttoreBoxColliders[0].enabled = !_InterruttoreBoxColliders[0].enabled;
        _InterruttoreBoxColliders[1].enabled = !_InterruttoreBoxColliders[1].enabled;
    }
}
