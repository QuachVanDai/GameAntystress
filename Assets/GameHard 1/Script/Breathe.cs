
using UnityEngine;
public class Breathe : MonoBehaviour
{
    [SerializeField] private SoundManage _SoundManage;
    [SerializeField] private AudioClip _SoundBreatheClip;
    [SerializeField] private bool _IsPlaySound;
    private Vector3 _PosCurrMouse;

    private void Reset()
    {
        _SoundManage = FindObjectOfType<SoundManage>();
    }
    private void Start()
    { 
      _IsPlaySound = true;
    }
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
        Vector3 mousePosition = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        RaycastHit hit;

        if (!Physics.Raycast(ray, out hit)) return;

        if (hit.collider.name != "BreatheCollider")
        {
            _IsPlaySound = true;
            _SoundManage.StopSound();
            return;
        }
        if (mousePosition == _PosCurrMouse)
            _SoundManage.m_AudioSource.volume = 0;
        else
            _SoundManage.m_AudioSource.volume = 1;
          
        if (_IsPlaySound == true)
        {
            _SoundManage.PlaySound(_SoundBreatheClip);
            _IsPlaySound = false;
        }
            _PosCurrMouse = mousePosition;

    }
}
