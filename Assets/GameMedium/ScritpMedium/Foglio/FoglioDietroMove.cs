using DG.Tweening;
using UnityEngine;
public class FoglioDietroMove : Foglio
{
    private static FoglioDietroMove _Instance;

    public static FoglioDietroMove Instance { get { return _Instance; } }
    [SerializeField] private GameObject _PosizioneFoglioDietroSu;  // vi tri xuất hiện từ trên 
    [SerializeField] private GameObject _PosizioneFoglioDietroInserito; // vi tri thay doi khi danh chu
    [SerializeField] private GameObject _PosizioneFoglioDietroNascosto; // vi tri an sau khi

    #region phần khỏi tạo
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
        LoadComponent();
    }
    public void LoadComponent()
    {
        this.LineCount= 1;

        _PosizioneFoglioDietroSu = GameObject.Find("PosizioneFoglioDietroSu");
        if (_PosizioneFoglioDietroSu == null) { Debug.LogWarning("PosizioneFoglioDietroSu "+ TagTemplate.NotFindObject); return; }

        _PosizioneFoglioDietroInserito = GameObject.Find("PosizioneFoglioDietroInserito");
        if (_PosizioneFoglioDietroInserito == null) { Debug.LogWarning("PosizioneFoglioDietroInserito "+ TagTemplate.NotFindObject); return; }

        _PosizioneFoglioDietroNascosto = GameObject.Find("PosizioneFoglioDietroNascosto");
        if (_PosizioneFoglioDietroNascosto == null) { Debug.LogWarning("PosizioneFoglioDietroNascosto " + TagTemplate.NotFindObject); return; }
    }
    #endregion
    public override void FoglioMove()
    {
  
        this.transform.DOMoveY(_PosizioneFoglioDietroInserito.transform.position.y - (0.222f * this.LineCount++), 0.5f);

    }
    public override void FoglioShow()
    {
        base.FoglioShow();
        transform.DOMove(_PosizioneFoglioDietroNascosto.transform.position, 0.5f)
       .OnComplete(() =>
       {
           transform.position = _PosizioneFoglioDietroSu.transform.position;
       });
    }
    public override void CreateNewFoglio()
    {
        base.CreateNewFoglio();
        transform.DOMove(_PosizioneFoglioDietroInserito.transform.position, 1f).SetDelay(0.5f);
    }
}
