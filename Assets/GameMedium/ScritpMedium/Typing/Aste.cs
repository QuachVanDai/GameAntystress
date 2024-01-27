using DG.Tweening;
using System.Collections;
using UnityEngine;

public class Aste : MonoBehaviour
{
    [SerializeField] private GameObject _AstesHolder;
    [SerializeField]  private GameObject[] _Astes;
    // [SerializeField]  private List<GameObject> _LstAstes ;

    #region phần khởi tạo
    private void Reset()
    {
        LoadComponent();
    }
    private void Start()
    {
        
    }
    public void LoadComponent()
    {
        if (_AstesHolder) return;
        _AstesHolder = GameObject.Find("Aste");
        _Astes = new GameObject[_AstesHolder.transform.childCount];
       // _LstAstes = new List<GameObject>();
        for (int i = 0; i < _AstesHolder.transform.childCount; i++)
        {
            //_LstAstes.Add( _AstesHolder.transform.GetChild(i).gameObject);
            _Astes[i] = _AstesHolder.transform.GetChild(i).gameObject;
        }
    }
    #endregion
    public IEnumerator AstesAnimation()
    {
        int index = Random.Range(0, _Astes.Length);
        _Astes[index].transform.DOLocalRotate(new Vector3(90, _Astes[index].transform.localRotation.eulerAngles.y, 0), 0.2f);
        yield return new WaitForSeconds(0.22f);
        Scritta.Instance.SetTextMesh(Scritta.Instance.GetTextMesh().text +  Scritta.Instance.GetTasto().Word);
        Rollo.Instance.RolloMove();
        _Astes[index].transform.DOLocalRotate(new Vector3(0, _Astes[index].transform.localRotation.eulerAngles.y, 0), 0.2f);
    }

}
