
using UnityEngine;
public class Breathe : MonoBehaviour
{
    [SerializeField] private SoundManage _SoundManage;
    [SerializeField] private AudioClip _SoundBreatheClip;
    [SerializeField] private bool _IsPlaySound;
    private Vector3 _PosCurrMouse;

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
        _IsPlaySound = true;
    }
    #endregion
    private void OnMouseDown()
    {
        CubeRotation.Instance.IsCubeRotation = false;
    }
    private void OnMouseUp()
    {
        CubeRotation.Instance.IsCubeRotation = true;
        _IsPlaySound = true;
        _SoundManage.StopSound();

    }
    private void OnMouseDrag()
    {
        // Lấy vị trí chuột trên màn hình
        Vector3 mousePosition = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.name != "BreatheCollider")
            {
                _IsPlaySound = true;
                _SoundManage.StopSound();
                return;
            }
            if (mousePosition == _PosCurrMouse)
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
        }
        _PosCurrMouse = mousePosition;

    }
}
