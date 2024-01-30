using System.Collections;
using UnityEngine;

public class ColliderGesti : MonoBehaviour
{
    [SerializeField] private GameObject _PosizioneRulloCentrale;
    [SerializeField] private GameObject _PosizioneRulloIniziale;
    [SerializeField] private BoxCollider _BoxColliderGesti;
    [SerializeField] private bool _IsShowOrNewText=true;

    private float _GetTimePreviousMouseDown;
    private void Reset()
    {
        LoadReset();
    }
    private void LoadReset()
    {
        _PosizioneRulloCentrale = GameObject.Find("PosizioneRulloCentrale");
        if (_PosizioneRulloCentrale == null) { Debug.LogWarning("PosizioneRulloCentrale " + TagTemplate.NotFindObject); return; }

        _PosizioneRulloIniziale = GameObject.Find("PosizioneRulloIniziale");
        if (_PosizioneRulloIniziale == null) { Debug.LogWarning("PosizioneRulloIniziale " + TagTemplate.NotFindObject); return; }
        _BoxColliderGesti = GetComponent<BoxCollider>();
    }
    private void Start()
    {
        LoadStart();
    }
    private void LoadStart()
    {
        _BoxColliderGesti.enabled = false;
        _IsShowOrNewText = true;
        _GetTimePreviousMouseDown = -3;
        Invoke("CreateFirstNewText", 0.6f);
        Invoke(nameof(SetActiveBoxColliderGesti), 2.6f);// CreateNewText() => SumWaitTime = 2.6f

    }
    public void OnMouseDown()
    {
        if (Time.time - _GetTimePreviousMouseDown < 3) return;

            if (_IsShowOrNewText)
                StartCoroutine(PublishingText());
            else
                StartCoroutine(CreateNewText());

            _IsShowOrNewText = !_IsShowOrNewText;
            _GetTimePreviousMouseDown = Time.time;
    }

    public void SetActiveBoxColliderGesti()
    {
       _BoxColliderGesti.enabled = true;
    }
    public IEnumerator PublishingText()
    {
        StartGame.Instance.IsPlayGame = false;
        StartGame.Instance.GameObjectMoveXY(_PosizioneRulloCentrale.transform.position, 0.5f);
        yield return new WaitForSeconds(1f);
        FoglioDietroMove.Instance.FoglioShow();
        FoglioDavantiMove.Instance.FoglioShow();
    }
    public void CreateFirstNewText()
    {
        StartCoroutine(CreateNewText());
    }
    public IEnumerator CreateNewText()
    {
        FoglioDavantiMove.Instance.CreateNewFoglio(); // hoàn thành frame mất 1.5s
        yield return new WaitForSeconds(0.1f);
        FoglioDietroMove.Instance.CreateNewFoglio();  // hoàn thành frame mất 1.5s
        yield return new WaitForSeconds(1f);
        SoundPaperRoll.Instance.PlaySound();
        yield return new WaitForSeconds(1f);
        FoglioDietroMove.Instance.LoadStart(); // khởi tạo lại giá trị
        FoglioDavantiMove.Instance.LoadStart();
        Manopola.Instance.LoadStart();
        StartGame.Instance.GameObjectMoveXY(_PosizioneRulloIniziale.transform.position, 0.5f);
        yield return new WaitForSeconds(0.5f);
        StartGame.Instance.IsPlayGame = true;
    }
}
