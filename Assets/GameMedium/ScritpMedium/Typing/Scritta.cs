using DG.Tweening;
using System.Collections;
using UnityEngine;

public class Scritta : MonoBehaviour
{
    private static Scritta _Instance;
    public static Scritta Instance { get { return _Instance; } }
    [SerializeField] private TextMesh _TextMesh;
    [SerializeField] private  Aste _Aste;
    private bool _IsCanSetTextMesh;
    private int _WordCountOneLine;
    public int WordCountOneLine { get { return _WordCountOneLine; } set { _WordCountOneLine = value; } }


    #region phần khởi tạo
    private void Awake()
    {
        if (_Instance != null) { Debug.LogWarning(TagTemplate.OnlyOneExistsObject + "ScrittaMove "); return; }
        Scritta._Instance = this;
    }
    void Start()
    {
        LoadStart();
    }
    private void Reset()
    {
        LoadComponent();
    }
    private void LoadStart()
    {
        _TextMesh.text = "";
        _IsCanSetTextMesh = true;
    }
    public void LoadComponent()
    {
        if (_TextMesh) return;
        _TextMesh = GetComponent<TextMesh>();
        if (_Aste) return;
        _Aste = FindObjectOfType<Aste>();
    }
    #endregion
 
    public void Typing()
    {
        StartCoroutine(_Aste.AstesAnimation());
    }
    public void DownLine()
    {
        _TextMesh.text += "\n";
    }

//    #region phần get set
    public void SetTextMesh(string s)
    {
       if(_IsCanSetTextMesh)
        {
            if (_IsCanSetTextMesh && WordCountOneLine <= 15)
            {
                _TextMesh.text = s;
                WordCountOneLine++;
            }
             if (WordCountOneLine+1 == 16)
            {
                _IsCanSetTextMesh = false;
                StartCoroutine(nameof(WaitTimeCompleteDownLine));
            }
        }
    }
    public IEnumerator WaitTimeCompleteDownLine()
    {
        StartGame.Instance.IsPlayGame = false;
        yield return new WaitForSeconds(1);
        if (FoglioDietroMove.Instance.LineCount < 12)
        {
            StartGame.Instance.IsPlayGame = true;
        }
        _IsCanSetTextMesh = true;
    }
    public TextMesh GetTextMesh()
    {
        return _TextMesh;
    }
    private Tasto _Tasto;

    public void SetTasto(Tasto Tasto)
    {
        this._Tasto = Tasto;
    }
    public Tasto GetTasto()
    {
        return this._Tasto;
    }
  //  #endregion
}
