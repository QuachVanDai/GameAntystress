using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PestleContactsBowl : MonoBehaviour
{
    [SerializeField] private GameObject _SingingBowlMazza;
    [SerializeField] private GameObject _PernoMazza;

    private float _GetTimeCurrent;
    private Vector3 _FirstPosContactsBowl; 
    public Vector3 FirstPosContactsBowl {  get { return _FirstPosContactsBowl; } set { _FirstPosContactsBowl = value;} }
    #region Phần khởi tạo 
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
        _SingingBowlMazza = GameObject.Find("SingingBowlMazza");
        if( !_SingingBowlMazza) { Debug.LogWarning("SingingBowlMazza "+TagTemplate.NotFindObject); return; }
        _PernoMazza = GameObject.Find("PernoMazza");
        if (!_PernoMazza) { Debug.LogWarning("PernoMazza"+ TagTemplate.NotFindObject); return; }

    }
    #endregion


    // chạm một lần vào thành bát 
    public void OnMouseDown()
    {
        _FirstPosContactsBowl = Input.mousePosition; //lấy vị trí click chuột đầu tiên
        _GetTimeCurrent = Time.time;  // lấy thời gian game đã chạy được tính bắt đầu bấm nút Play
        SetPositionBowl();  
        KnockBowl_1();
    }
    public void OnMouseUp()
    {
        if (Time.time - _GetTimeCurrent < 0.3f) // kiểm tra nếu vị trí bấm mà dữ sẽ không phát âm thanh
            SoundKlowBowl.Instance.PlaySound(); 
    }
    public void KnockBowl_1()
    {
        _SingingBowlMazza.transform.DOLocalRotate(new Vector3(_SingingBowlMazza.transform.localRotation.eulerAngles.x-5, 0, 0), 0.05f).SetEase(Ease.Linear)
            .OnComplete(() => {
                _SingingBowlMazza.transform.DOLocalRotate(new Vector3(_SingingBowlMazza.transform.localRotation.eulerAngles.x+5 , 0, 0), 0.05f).SetEase(Ease.Linear);
            });
    }
    
    public void SetPositionBowl()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //  tạo một tia bắt đầu từ 
        RaycastHit hit;   // Tạo một RaycastHit để chứa thông tin về va chạm nếu có
        if (Physics.Raycast(ray, out hit))
        {
            _PernoMazza.transform.localRotation = Quaternion.LookRotation(hit.point - transform.position, Vector3.up);
            _PernoMazza.transform.localRotation = Quaternion.Euler(0, _PernoMazza.transform.localRotation.eulerAngles.y, 0);
            //   StartCoroutine(knockBowl2());
        }
    }

    IEnumerator KnockBowl2()
    {
        Quaternion newRotation;
        newRotation = Quaternion.Euler(-17, 0, 0);
        _SingingBowlMazza.transform.localRotation = newRotation;
        yield return new WaitForSeconds(0.05f);
        newRotation = Quaternion.Euler(-25, 0, 0);
        _SingingBowlMazza.transform.localRotation = newRotation;
        yield return new WaitForSeconds(0.05f);
        newRotation = Quaternion.Euler(-17, 0, 0);
        _SingingBowlMazza.transform.localRotation = newRotation;
        yield return null;
    }
}
