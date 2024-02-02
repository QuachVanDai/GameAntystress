using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class Bottone : MonoBehaviour
{
    [SerializeField] private Transform _PosSwitchDown;
    [SerializeField] private SoundManage _SoundManage;
    [SerializeField] private AudioClip _SoundBottoneClip;

    private float _GetWaitTime;

    private void Reset()
    {
        _SoundManage = FindObjectOfType<SoundManage>();
        _PosSwitchDown = transform;
    }
   
  /*    private void OnMouseDown()
 {
     _GetWaitTime = Time.time;
     CubeRotation.Instance.IsCubeRotation = false;

 }
 private void OnMouseUp()
 {
     if (Time.time - _GetWaitTime >= 0.35f) return;
     CubeRotation.Instance.IsCubeRotation = true;
     _SoundManage.PlaySound(_SoundBottoneClip);
     transform.DOLocalMove(new Vector3(0.81f, _PosSwitchDown.localPosition.y, _PosSwitchDown.localPosition.z), 0.1f).OnComplete(() =>
     {
         _SoundManage.StopSound();
         transform.DOLocalMove(new Vector3(0.96f, _PosSwitchDown.localPosition.y, _PosSwitchDown.localPosition.z), 0.1f);
     });
 }*/


}
