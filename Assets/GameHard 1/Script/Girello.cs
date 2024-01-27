using UnityEngine;

public class Girello : MonoBehaviour
{
    [SerializeField] private GameObject _Girello;
    [SerializeField] private GameObject _RootFidget;
    [SerializeField] private SoundManage _SoundManage;
    [SerializeField] private AudioClip _SoundGirelloClip;
    [SerializeField] private bool _IsPlaySound;

    public float RotationSpeed = 5.0f;
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
        _Girello = GameObject.Find("Girello");
        _SoundManage = FindObjectOfType<SoundManage>();
        _IsPlaySound = true;
    }
    #endregion
    private void OnMouseDown()
    {
        CubeRotation.Instance.IsCubeRotation = false;
        transform.localScale = new Vector3(transform.localScale.x*6, transform.localScale.y, transform.localScale.z*6);
    }
    private void OnMouseUp()
    {
        CubeRotation.Instance.IsCubeRotation = true;
        transform.localScale = new Vector3(transform.localScale.x / 6, transform.localScale.y, transform.localScale.z / 6);
        _IsPlaySound = true;
        _SoundManage.StopSound();
    }
    private void OnMouseDrag()
    {
        Vector3 mousePosition = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Vector3 targetDirection = hit.point - transform.position;
            if (mousePosition == _PosCurrMouse)
            {
                _SoundManage.m_AudioSource.volume=0;
            }
            else
            {
                _SoundManage.m_AudioSource.volume = 1;
            }
            if (_IsPlaySound)
            {
                _SoundManage.PlaySound(_SoundGirelloClip);
                 _IsPlaySound=false;
            }
            // Chuyển đổi hướng thành góc quay và áp dụng quay cho hình tròn
            float targetRotation = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
            Quaternion newRotation = Quaternion.Euler(0, 0, targetRotation -90 - Mathf.Abs(_RootFidget.transform.rotation.eulerAngles.z));
            _Girello.transform.localRotation = Quaternion.Slerp(_Girello.transform.localRotation, newRotation, RotationSpeed * Time.deltaTime);
        }
        _PosCurrMouse = mousePosition;
    }
}
