using UnityEngine;

public abstract class Foglio : MonoBehaviour
{
    public int LineCount = 1;
    public virtual void FoglioMove() { }
    public virtual void FoglioShow() { }
    public virtual void CreateNewFoglio() { }

}
