using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameplayscript : MonoBehaviour
{
    public GameObject gameoverPanel;

    AudioSource gunshotAudioSource;
    public AudioClip gunShotClip;

    public GameObject timerTextView;
    public GameObject scoreTextView;
  //  int roundshot = 0;
    int enemykilled = 0;

    public GameObject bazookaGO;
    public GameObject crosshairGo;
    bool gameispaused = false;

    int gameTime = 100;
    int timeMinutes;
    int timeSeconds;

    // Use this for initialization
    void Start()
    {

        scoreTextView.GetComponent<Text>().text = enemykilled.ToString();
        gunshotAudioSource = gameObject.GetComponent<AudioSource>();
        InvokeRepeating("timeCounterAction", 0, 1);


    }



    void timeCounterAction()
    {
        if (gameTime >= 0)
        {
            timeMinutes = (int)(gameTime / 60);
            timeSeconds = gameTime % 60;

            string timerTextString = timeMinutes.ToString() + "\' " + timeSeconds.ToString() + "\"";

            timerTextView.GetComponent<Text>().text = timerTextString;
            gameTime = gameTime - 1;
        }
        else
        {
            Time.timeScale = 0;
            gameispaused = true;
            gameoverPanel.GetComponent<CanvasGroup>().alpha = 1;
            gameoverPanel.GetComponent<CanvasGroup>().interactable = true;
            gameoverPanel.GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
    }

    void shootAction()
    {
        gunshotAudioSource.PlayOneShot(gunShotClip);
      //  roundshot = roundshot + 1;
        Vector2 dir = new Vector2(crosshairGo.transform.position.x, crosshairGo.transform.position.y);
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.transform.position, dir);
        enemykilled++;
        Destroy(hit.collider.gameObject);
        scoreTextView.GetComponent<Text>().text = enemykilled.ToString();

    }


    // Update is called once per frame
    void Update()
    {
        Vector2 dir = new Vector2(crosshairGo.transform.position.x, crosshairGo.transform.position.y);
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.transform.position, dir);

        if (!gameispaused)
        {
            if (hit.collider != null && hit.collider.gameObject != crosshairGo)
               
            shootAction();


            //bazookaGO.transform.LookAt(crosshairGo.transform);

            // float h = Input.GetAxis("Mouse X");
            //float v = Input.GetAxis("Mouse Y");

            //Vector3 crosshairMov = new Vector3(h, v, 0);
            // crosshairGo.transform.Translate(crosshairMov);

            float x = crosshairGo.transform.position.x;
            float y = crosshairGo.transform.position.y;

            if (x > 10)
                x = 10;
            if (x < -10)
                x = -10;
            if (y > 6)
                y = 6;
            if (y < -1)
                y = -1;

            crosshairGo.transform.position = new Vector3(x, y, 0);
        }
    }


public void RestartAction()
{
    Time.timeScale = 1;
    gameispaused = false;
    gameoverPanel.GetComponent<CanvasGroup>().alpha = 0;
    gameoverPanel.GetComponent<CanvasGroup>().interactable = false;
    gameoverPanel.GetComponent<CanvasGroup>().blocksRaycasts = false;

        gameTime = 100;
        enemykilled = 0;
       // roundshot = 0;
        scoreTextView.GetComponent<Text>().text = enemykilled.ToString();
        timeCounterAction();
    }
}