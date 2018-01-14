using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
public class SkryptMenu : MonoBehaviour
{
    public Canvas menuWyjscia;
    public Button przyciskRozpoczecia;
    public Button przyciskWyjscia;
    void Start()
    {
        menuWyjscia = menuWyjscia.GetComponent<Canvas>();
        przyciskRozpoczecia = przyciskRozpoczecia.GetComponent<Button>();
        przyciskWyjscia = przyciskWyjscia.GetComponent<Button>();
        menuWyjscia.enabled = false;
    }
    public void PrzyciskWyjsciaAktywny()
    {
        menuWyjscia.enabled = true;
        przyciskRozpoczecia.enabled = false;
        przyciskWyjscia.enabled = false;
    }
    public void PrzyciskNieAktywny()
    {
        menuWyjscia.enabled = false;
        przyciskRozpoczecia.enabled = true;
        przyciskWyjscia.enabled = true;
    }
    public void PoziomStartowy()
    {
        SceneManager.LoadScene("Scene1");
    }
    public void ZakonczGre()
    {
        Application.Quit();
    }
}