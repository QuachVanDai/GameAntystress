using UnityEngine;

public class PestleContactsAroundBowl : MonoBehaviour
{
    [SerializeField] private PestleContactsBowl _PestleContactsBowl;
    [SerializeField] private AudioClip _SoundContactsBowlClip;

    private bool _IsIncreaseVolume=true;
    private Vector3 _PosMouseCurrent;

    private void Reset()
    {
        _PestleContactsBowl = FindObjectOfType<PestleContactsBowl>();
    }
    private void Start()
    {
        _IsIncreaseVolume = true;
    }
  
    // chày di chuyển quanh thành bát 
    private void OnMouseDrag()
    {
        if(_PestleContactsBowl.FirstPosContactsBowl ==Input.mousePosition)  return;
        _PestleContactsBowl.SetPositionBowl();

        if (_IsIncreaseVolume == true) // isIncreaseVolume == ture  đảm bảo câu lệnh
                                      // if (isIncreaseVolume == ture ) hoạt động một lần
                                      // vì OnMouseDrag() gọi lại nhiều lần
        {
            SoundMoveAroundBowl.Instance.PlaySound();
            SoundMoveAroundBowl.Instance.IncreaseVolume();
            _IsIncreaseVolume = false;
        }
        if (Input.mousePosition == _PosMouseCurrent) // Nếu vẫn đang trạng thái xoay mà dừng lại
             SoundMoveAroundBowl.Instance.DecreaseVolume();

        else if (SoundMoveAroundBowl.Instance.AudioSource.volume == 0) // vẫn chưa tối ưu 
                     _IsIncreaseVolume = true;

        _PosMouseCurrent = Input.mousePosition;
    }
    private void OnMouseUp()
    {
        SoundMoveAroundBowl.Instance.DecreaseVolume();
        _IsIncreaseVolume = true;
    }
}
