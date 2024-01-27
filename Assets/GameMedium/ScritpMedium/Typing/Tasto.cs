using DG.Tweening;
using System.Collections;
using UnityEngine;

public class Tasto : MonoBehaviour
{
    [SerializeField] private string _Word;
    public string Word { get { return _Word; } set { _Word = value; } }

    private bool _IsTying=true;
    public Vector3 PosStartTasto;
    public Vector3 PosEndTasto;
    private void Start()
    {
        _IsTying = true;
        PosStartTasto = new Vector3(transform.localPosition.x, transform.localPosition.y , transform.localPosition.z);
        PosEndTasto = new Vector3(transform.localPosition.x, transform.localPosition.y -0.08f, transform.localPosition.z);
    }
    // public bool IsAsteAnimation { get { return _IsAsteAnimation; } set { _IsAsteAnimation = value; } }
    public void OnMouseDown()
    {
        if (!StartGame.Instance.IsPlayGame) return;
        if (!_IsTying) return;
             SoundKeyboard.Instance.PlaySound();
        transform.DOLocalMove(PosEndTasto, 0.2f);
        _IsTying = false;
        if (Word == "null") 
            return;
            Scritta.Instance.SetTasto(this);
            Scritta.Instance.Typing();
        // StartGame.Instance.IsPlayGame = false;
    }
    private void OnMouseUp()
    {
        _IsTying = true;
       // StartCoroutine(nameof(TastoAnimation));
    }
    private void OnMouseExit()
    {
        _IsTying = true;

    }
    public void Update()
    {
        if (!_IsTying) return;
        transform.DOLocalMove(PosStartTasto, 0.2f);
    }
    public IEnumerator TastoAnimation()
    {
        yield return new WaitForSeconds(0.2f);
    }

}
