using DG.Tweening;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    private static StartGame _Instance;
    public static StartGame Instance { get { return _Instance; } }

    [SerializeField] private GameObject[] _ojectMove;
    [SerializeField] private bool _IsPlayGame;
    [SerializeField] private SpriteRenderer[] _SpriteGradiente;
    public bool IsPlayGame { get { return _IsPlayGame; } set { this._IsPlayGame = value; } }
   public GameObject[] OjectMove { get { return _ojectMove; } }
    private void Awake()
    {
        if(_Instance != null) { Debug.LogWarning(TagTemplate.OnlyOneExistsObject + "StartGame"); return; }
        _Instance = this;
    }
    private void Start()
    {
        IsPlayGame = false;
        FadeSpriteGradiente(0);
    }
    public void GameObjectMoveX(float pos,float timeMove)
    {
        for (int i = 0; i < _ojectMove.Length; i++)
        {
            _ojectMove[i].transform.DOMoveX(pos,timeMove);
        }
    }
    public void FadeSpriteGradiente(int alpha)
    {
            _SpriteGradiente[0].DOFade(alpha, 1f);
            _SpriteGradiente[1].DOFade(alpha, 1f);
    }
    public void GameObjectMoveXY(Vector3 pos, float timeMove)
    {
        for (int i = 0; i < _ojectMove.Length; i++)
        {
            _ojectMove[i].transform.DOMove(pos, timeMove);
        }
    }

}
