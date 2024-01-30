using DG.Tweening;
using UnityEngine;
public class FoglioDietroMove : MonoBehaviour
{
    private static FoglioDietroMove _Instance;
    public int LineCount = 1;
    public static FoglioDietroMove Instance { get { return _Instance; } }
    [SerializeField] private GameObject _PosizioneFoglioDietroSu;  
    [SerializeField] private GameObject _PosizioneFoglioDietroInserito;
    [SerializeField] private GameObject _PosizioneFoglioDietroNascosto;

    private void Awake()
    {
        if (_Instance != null) { Debug.LogWarning(TagTemplate.OnlyOneExistsObject + "FoglioDietroMove "); return; }
        FoglioDietroMove._Instance = this;
    }
    private void Reset()
    {
        LoadComponent();
    }
    private void Start()
    {
        LoadStart();
    }
    public void LoadStart()
    {
        this.LineCount = 1;
    }
    public void LoadComponent()
    {
        _PosizioneFoglioDietroSu = GameObject.Find("PosizioneFoglioDietroSu");
        if (_PosizioneFoglioDietroSu == null) { Debug.LogWarning("PosizioneFoglioDietroSu "+ TagTemplate.NotFindObject); return; }

        _PosizioneFoglioDietroInserito = GameObject.Find("PosizioneFoglioDietroInserito");
        if (_PosizioneFoglioDietroInserito == null) { Debug.LogWarning("PosizioneFoglioDietroInserito "+ TagTemplate.NotFindObject); return; }

        _PosizioneFoglioDietroNascosto = GameObject.Find("PosizioneFoglioDietroNascosto");
        if (_PosizioneFoglioDietroNascosto == null) { Debug.LogWarning("PosizioneFoglioDietroNascosto " + TagTemplate.NotFindObject); return; }
    }
    public  void FoglioMove()
    {
        this.transform.DOMoveY(_PosizioneFoglioDietroInserito.transform.position.y - (0.222f * this.LineCount++), 0.5f);
    }
    public  void FoglioShow()
    {
        transform.DOMove(_PosizioneFoglioDietroNascosto.transform.position, 0.5f)
       .OnComplete(() =>
       {
           transform.position = _PosizioneFoglioDietroSu.transform.position;
       });
    }
    public  void CreateNewFoglio()
    {
        transform.DOMove(_PosizioneFoglioDietroInserito.transform.position, 1f).SetDelay(0.5f);
    }
}
