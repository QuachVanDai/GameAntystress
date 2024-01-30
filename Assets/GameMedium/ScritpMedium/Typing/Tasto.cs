using DG.Tweening;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Tasto : MonoBehaviour
{
    [SerializeField] private string _Word;
    [SerializeField] private Transform _Mesh;
    public string Word { get { return _Word; } set { _Word = value; } }
    private bool _IsTying=true;
    public Vector3 PosStartTasto;
    public Vector3 PosEndTasto ;

    private void Start()
    {
        _IsTying = true;
    }
    public void OnMouseDown()
    {
        if (!StartGame.Instance.IsPlayGame) return;
        if (!_IsTying) return;
        SoundKeyboard.Instance.PlaySound();
        _Mesh.transform.DOLocalMove(PosEndTasto, 0.1f);
        _IsTying = false;
        if (Word == "null") return;
        Scritta.Instance.SetTasto(this);
        Scritta.Instance.Typing();
    }
    private void OnMouseUp()
    {
        _IsTying = true;
    }
    private void OnMouseExit()
    {
        _IsTying = true;
    }
    public void Update()
    {
        if (!_IsTying) return;
        _Mesh.transform.DOLocalMove(PosStartTasto, 0.1f).SetDelay(0.05f);
    }

}
