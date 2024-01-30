using UnityEngine;

public class TastiControll : MonoBehaviour
{

    [SerializeField] private Tasto _Tasto;
    private float _GetWaitTime=0;
    public void Update()
    {
        if (!StartGame.Instance.IsPlayGame || Time.time - _GetWaitTime < 0.08f) return;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Input.GetMouseButton(0))
        {
            _Tasto = null;
            if (!Physics.Raycast(ray, out hit)) return;

            if (hit.collider.tag == "Tasto")
            {
                _Tasto = hit.collider.GetComponent<Tasto>();
                _Tasto.OnMouseDown();
                _GetWaitTime = Time.time;
            }
        }

    }

}
/*[SerializeField] private GameObject[] _FilaSopra;
[SerializeField] private GameObject[] _FilaQWERTY;
[SerializeField] private GameObject[] _FilaASD;
[SerializeField] private GameObject[] _FilaZXC;

[SerializeField] private GameObject _SopraHolder;
[SerializeField] private GameObject _QWERTYHolder;
[SerializeField] private GameObject _ASDHolder;
[SerializeField] private GameObject _ZXCHolder;

[SerializeField] private GameObject _spazio;
public void loadCompoent()
{
    _SopraHolder = GameObject.Find("FilaSopra");
    _FilaSopra = new GameObject[_SopraHolder.transform.childCount];
    AddObject(ref _SopraHolder, ref _FilaSopra);


    _QWERTYHolder = GameObject.Find("FilaQWERTY");
    _FilaQWERTY = new GameObject[_QWERTYHolder.transform.childCount];
    AddObject(ref _QWERTYHolder, ref _FilaQWERTY);

    _ASDHolder = GameObject.Find("FilaASD");
    _FilaASD = new GameObject[_ASDHolder.transform.childCount];
    AddObject(ref _ASDHolder, ref _FilaASD);

    _ZXCHolder = GameObject.Find("FilaZXC");
    _FilaZXC = new GameObject[_ZXCHolder.transform.childCount];
    AddObject(ref _ZXCHolder, ref _FilaZXC);

    _spazio = GameObject.Find("Spazio");

}
public void AddObject(ref GameObject Holder, ref GameObject[] Tastis)
{
    for (int i = 0; i < Holder.transform.childCount; i++)
    {
        Tastis[i] = Holder.transform.GetChild(i).gameObject;
    }
}*/