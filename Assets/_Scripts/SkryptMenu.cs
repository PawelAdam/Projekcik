﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
public class SkryptMenu : MonoBehaviour
{
    public Canvas menuWyjscia;
    public Canvas menuGłówne;
    public Button przyciskRozpoczecia;
    public Button przyciskWyjscia;
    public Button trybZrecznosciowy;
    public GameObject a123;
    void Start()
    {
        menuWyjscia = menuWyjscia.GetComponent<Canvas>();
        przyciskRozpoczecia = przyciskRozpoczecia.GetComponent<Button>();
        przyciskWyjscia = przyciskWyjscia.GetComponent<Button>();
        trybZrecznosciowy = trybZrecznosciowy.GetComponent<Button>();
        menuWyjscia.enabled = false;
    }
    public void PrzyciskWyjsciaAktywny()
    {
        menuWyjscia.enabled = true;
        //menuGłówne.enabled = false;
        a123.active = false;
    }
    public void PrzyciskNieAktywny()
    {
        menuWyjscia.enabled = false;
        //menuGłówne.enabled = true;
        a123.active = true;
    }
    public void PoziomStartowy()
    {
        SceneManager.LoadScene("Poziom1");
    }
    public void TrybZrecznosciowy()
    {
        Camera.main.transform.Translate( new Vector3(-21.45f, 0f, 0f) );
        SceneManager.LoadScene("Parkour");
    }
    public void ZakonczGre()
    {
        Application.Quit();
    }
}