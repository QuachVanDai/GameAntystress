﻿using DG.Tweening;
using UnityEngine;

public class FoglioDavantiMove : MonoBehaviour
{
    private static FoglioDavantiMove _instance;
    [SerializeField] private GameObject _Scritta;
    public static FoglioDavantiMove Instance { get { return _instance; } }
    [SerializeField] private GameObject _PosizioneFoglioDavantiSu;  
    [SerializeField] private GameObject _PosizioneFoglioDavantiInserito;
    [SerializeField] private GameObject _PosizioneFoglioDavantiNascosto; 
    [SerializeField] private Vector3 _PosizioneFoglioDavantiShow;

    public int LineCount = 1;

    #region phần khởi tạo
    private void Awake()
    {
        if (_instance != null) { Debug.LogWarning(TagTemplate.OnlyOneExistsObject + "FoglioDavantiMove "); return; }
        FoglioDavantiMove._instance = this;
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
        _Scritta = GameObject.Find("Scritta");
        if (_Scritta == null) { Debug.LogWarning("Scritta "+ TagTemplate.NotFindObject); return; }
        _Scritta.transform.SetParent(this.transform);

        _PosizioneFoglioDavantiSu = GameObject.Find("PosizioneFoglioDavantiSu");
        if (_PosizioneFoglioDavantiSu == null) { Debug.LogWarning("PosizioneFoglioDavantiSu " + TagTemplate.NotFindObject); return; }

        _PosizioneFoglioDavantiInserito = GameObject.Find("PosizioneFoglioDavantiInserito");
        if (_PosizioneFoglioDavantiInserito == null) { Debug.LogWarning("PosizioneFoglioDavantiInserito "+ TagTemplate.NotFindObject); return; }

        _PosizioneFoglioDavantiNascosto = GameObject.Find("PosizioneFoglioDavantiNascosto");
        if (_PosizioneFoglioDavantiNascosto == null) { Debug.LogWarning("PosizioneFoglioDavantiNascosto "+ TagTemplate.NotFindObject); return; }
    }
    #endregion
    public  void FoglioMove()
    {
        this.transform.DOMoveY(_PosizioneFoglioDavantiInserito.transform.position.y + (0.222f * this.LineCount++), 0.5f);
    }
    public  void FoglioShow()
    {
        transform.DOMove(_PosizioneFoglioDavantiSu.transform.position, 0.5f)
       .OnComplete(() =>
       {
           _PosizioneFoglioDavantiShow = new Vector3(0, 2, -3);
           transform.localRotation = Quaternion.Euler(new Vector3(45, -3, 0));
           transform.DOLocalMove(_PosizioneFoglioDavantiShow, 0.5f);
           StartGame.Instance.FadeSpriteGradiente(1);
       });
    }

    public void CreateNewFoglio() 
    {
        transform.DOMove(_PosizioneFoglioDavantiSu.transform.position, 0.5f)
     .OnComplete(() =>
      {
          Scritta.Instance.SetTextMesh("");
          StartGame.Instance.FadeSpriteGradiente(0);
          transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
              transform.position = _PosizioneFoglioDavantiNascosto.transform.position;
              transform.DOMove(_PosizioneFoglioDavantiInserito.transform.position, 0.5f).SetDelay(0.5f);
      });
    }


}
