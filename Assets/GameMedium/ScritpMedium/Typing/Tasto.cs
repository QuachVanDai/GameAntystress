using DG.Tweening;
using System.Collections;
using UnityEngine;

public class Tasto : MonoBehaviour
{
    [SerializeField] private string _Word;
    public string Word { get { return _Word; } set { _Word = value; } }
  
    // public bool IsAsteAnimation { get { return _IsAsteAnimation; } set { _IsAsteAnimation = value; } }
    public void OnMouseDown()
    {
        if (!StartGame.Instance.IsPlayGame) return;

            StartCoroutine(TastoAnimation());
            SoundKeyboard.Instance.PlaySound();
            if (Word == "null") return;
            Scritta.Instance.SetTasto(this);
            Scritta.Instance.Typing();
    }

    public IEnumerator TastoAnimation()
    {
        transform.DOLocalRotate(new Vector3(-5, transform.localRotation.eulerAngles.y, transform.localRotation.eulerAngles.z), 0.2f);
        yield return new WaitForSeconds(0.1f);
        transform.DOLocalRotate(new Vector3(0, transform.localRotation.eulerAngles.y, transform.localRotation.eulerAngles.z), 0.2f);
    }
   
}
