using UnityEngine;

public class Test : MonoBehaviour
{
    private float Score;
    private float dupa;

    // Use this for initialization
    private void Start()
    {
        Score = 0;
        dupa = 0;
    }

    // Update is called once per frame
    private void Update()
    {

        Debug();

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Score++;
            
        }

        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            dupa+=10;
            
        }
    }

    private void Debug()
    {
        DebugPanel.Log("Score", "DupaKwas", Score);
        DebugPanel.Log("Dupa", "DupaKwas", dupa);
    }
}