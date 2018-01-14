using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class SkryptPauzy : MonoBehaviour
{
    public GameObject PauseUI;
    // odpowiedzialny za uaktywnianie i dezaktywowanie
    // widoczności menu
    private bool zapauzowana = false;
    // informuje czy gra została zapauzowana
    void Start()
    {
        PauseUI.SetActive(false);
        // wyłącza widoczność menu po uruchmieniu gry
    }
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            zapauzowana = !zapauzowana;
            // gdy uaktywniony zostanie przycisk pauzy,
            // wartość zmiennej zapauzowana
            // zostanie ustawiona na przeciwstawną:
            // prawda na fałsz, fałsz na prawdę
        }
        if (zapauzowana)
        {
            PauseUI.SetActive(true);
            Time.timeScale = 0.0f;
            // określa skalę upływającego czasu,
            // ustawiona na 0 zatrzymuje jego upływ
        }
        if (!zapauzowana)
        {
            PauseUI.SetActive(false);
            Time.timeScale = 1.0f;
            // powrót upływającego czasu do normy
        }
    }
    public void Wznowienie()
    {
        zapauzowana = false;
    }
    public void RestartPoziomu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void PowortMenuGlowne()
    {
        SceneManager.LoadScene("MenuGL", LoadSceneMode.Single);
    }
    public void ZakonczenieZatwierdzone()
    {
        Application.Quit();
    }
}