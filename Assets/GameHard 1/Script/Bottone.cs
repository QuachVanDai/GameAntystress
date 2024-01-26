using DG.Tweening;
using UnityEngine;

public class Bottone : MonoBehaviour
{
    [SerializeField] private Transform _PosSwitchDown;
    [SerializeField] private SoundManage _SoundManage;
    [SerializeField] private AudioClip _SoundBottoneClip;

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
        _PosSwitchDown = transform;
    }
    #endregion
    private void OnMouseDown()
    {
        CubeRotation.Instance.IsCubeRotation = false;
        _SoundManage.PlaySound(_SoundBottoneClip);
        transform.DOLocalMove(new Vector3(0.81f, _PosSwitchDown.localPosition.y, _PosSwitchDown.localPosition.z), 0.1f).OnComplete(() =>
        {
            transform.DOLocalMove(new Vector3(0.96f, _PosSwitchDown.localPosition.y, _PosSwitchDown.localPosition.z), 0.1f);
        });
    }
    private void OnMouseUp()
    {
        CubeRotation.Instance.IsCubeRotation = true;
        _SoundManage.StopSound();
    }


}
