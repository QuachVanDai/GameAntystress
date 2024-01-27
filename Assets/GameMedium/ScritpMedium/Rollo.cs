using DG.Tweening;
using UnityEngine;

public class Rollo : MonoBehaviour
{
    private static Rollo _Instance;
    public static Rollo Instance { get { return _Instance; } }

    [SerializeField] private GameObject _Typewriter_Rullo;
    [SerializeField] private GameObject _PosizioneRulloIniziale, _PosizioneRulloFinale;
    [SerializeField] private ColliderGesti _ColliderGesti;


    private float _Angle=20,_GetTimePreviousMouseDown;

    #region phần khởi tạo
    private void Awake()
    {
        if (_Instance != null) { Debug.LogWarning(TagTemplate.OnlyOneExistsObject + "RolloRotation "); return; }
        Rollo._Instance = this;
    }
    private void Start()
    {
        LoadComponent();
    }
    private void Reset()
    {
        LoadStart();
    }
    public void LoadStart()
    {
        Scritta.Instance.WordCountOneLine = 0;
        _Angle = 20;
        _GetTimePreviousMouseDown = 0;
    }
    public void LoadComponent()
    {
        _ColliderGesti = FindObjectOfType<ColliderGesti>();

        _PosizioneRulloIniziale = GameObject.Find("PosizioneRulloIniziale");
        if(!_PosizioneRulloIniziale) { Debug.LogWarning("PosizioneRulloIniziale " + TagTemplate.NotFindObject); }

        _PosizioneRulloFinale = GameObject.Find("PosizioneRulloFinale");
        if (!_PosizioneRulloFinale) { Debug.LogWarning("PosizioneRulloFinale " + TagTemplate.NotFindObject); }

        _Typewriter_Rullo = GameObject.Find("Typewriter_Rullo");
        if (!_Typewriter_Rullo) { Debug.LogWarning("Rullo" + TagTemplate.NotFindObject); }
   
    }
    #endregion

    private void OnMouseDown()
    {
        if (!StartGame.Instance.IsPlayGame) return;
        if(Time.time - _GetTimePreviousMouseDown >= 1)
        {
            RolloRotation();
            _GetTimePreviousMouseDown = Time.time;
        }
    }
    public void RolloRotation()
    {
        _Angle += 20;
        Scritta.Instance.DownLine();
        Scritta.Instance.WordCountOneLine=0;
        SoundDownLine.Instance.PlaySound();
        _Typewriter_Rullo.transform.DOLocalRotate(new Vector3(_Angle,0, 0), 0.5f);
        FoglioDietroMove.Instance.FoglioMove();
        FoglioDavantiMove.Instance.FoglioMove();
        if (FoglioDietroMove.Instance.LineCount == 12)
        {
            _ColliderGesti.OnMouseDown();
            return;
        }
        StartGame.Instance.GameObjectMoveXY(_PosizioneRulloIniziale.transform.position, 0.5f);

    }

    public void RolloMove()
    {
        float distance = (_PosizioneRulloIniziale.transform.position.x - _PosizioneRulloFinale.transform.position.x);
        StartGame.Instance.GameObjectMoveX(_PosizioneRulloIniziale.transform.position.x - ((distance / 15f) * Scritta.Instance.WordCountOneLine), 0.2f);
        if (Scritta.Instance.WordCountOneLine == 15)
        {
            RolloRotation();
        }
    }

}
