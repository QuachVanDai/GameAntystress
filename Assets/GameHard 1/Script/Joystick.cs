using UnityEngine;

public class Joystick : MonoBehaviour
{
    [SerializeField] private GameObject _JoystickWrapper;
    [SerializeField] private GameObject _JoystickCentro;
    [SerializeField] private SoundManage _SoundManage;
    [SerializeField] private AudioClip _SoundJoystickClip;
    [SerializeField] private bool _IsPlaySound;
    private Vector3 _PosCurrMouse;
    public float RotationSpeed = 5.0f;

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
        _JoystickCentro = GameObject.Find("JoystickCentro");
        if(!_JoystickCentro) { Debug.LogWarning("JoystickCentro không tìm thấy"); return; }
        _JoystickWrapper = GameObject.Find("JoystickWrapper");
        if (!_JoystickWrapper) { Debug.LogWarning("JoystickWrapper không tìm thấy"); return; }
        _IsPlaySound = true;
    }
    #endregion
    private void OnMouseDown()
    {
        CubeRotation.Instance.IsCubeRotation = false;
        transform.localScale = new Vector3(transform.localScale.x*10, transform.localScale.y, transform.localScale.z*10);
    }
    private void OnMouseUp()
    {
        _IsPlaySound = true;
        _JoystickWrapper.transform.localRotation = Quaternion.Euler(90,0, 0);
        CubeRotation.Instance.IsCubeRotation = true;
        transform.localScale = new Vector3(transform.localScale.x / 10, transform.localScale.y, transform.localScale.z / 10);
        _SoundManage.StopSound();
    }
    private void OnMouseDrag()
    {
         Vector3 mousePosition = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            // Lấy hướng từ đối tượng đến vị trí chuột
            Vector3 targetDirection = hit.point - transform.position;
            if (mousePosition == _PosCurrMouse)
            {
                _SoundManage.m_AudioSource.volume = 0;
            }
            else
            {
                _SoundManage.m_AudioSource.volume = 1;
            }
            if (_IsPlaySound)
            {
                _SoundManage.PlaySound(_SoundJoystickClip);
                _IsPlaySound = false;
            }
            _PosCurrMouse = mousePosition;
            _JoystickWrapper.transform. LookAt(targetDirection);
            _JoystickWrapper.transform.localRotation = Quaternion.Euler(70, _JoystickWrapper.transform.localRotation.eulerAngles.y +180,0);
        }
    }
  
}
