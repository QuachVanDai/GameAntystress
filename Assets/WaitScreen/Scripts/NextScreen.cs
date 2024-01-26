using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScreen : MonoBehaviour
{
    // Start is called before the first frame update

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "GameEasy")
                {
                    CallScreenGameEasy();
                }
                if (hit.collider.tag == "GameMedium")
                {
                    CallScreenGameMedium();
                }
                if (hit.collider.tag == "GameHard")
                {
                    CallScreenGameHard();
                }
            }
        }

    }
    public void CallHomeScreen()
    {
        SceneManager.LoadScene(0);
    }
        public void CallScreenGameEasy()
    {
        SceneManager.LoadScene(1);
    }
    public void CallScreenGameMedium()
    {
        SceneManager.LoadScene(2);
    }
    public void CallScreenGameHard()
    {
        SceneManager.LoadScene(3);
    }
}
