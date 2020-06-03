using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public GameObject GameModesMenu;
    public GameObject ChallengesMenu;
    public GameObject RewardsMenu;

    public void PlayLevel1() {
        SceneManager.LoadScene("Level1");
    }

    public void PlayLevel2() {
        SceneManager.LoadScene("Level2");
    }

    public void PlayLevel3() {
        SceneManager.LoadScene("Level3");
    }

    public void PlayLevel4() {
        SceneManager.LoadScene("Level4");
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void OpenGamesModesTab() {
        GameModesMenu.SetActive(true);
        ChallengesMenu.SetActive(false);
        RewardsMenu.SetActive(false);
    }

    public void OpenChallengesTab() {
        GameModesMenu.SetActive(false);
        ChallengesMenu.SetActive(true);
        RewardsMenu.SetActive(false);
    }

    public void OpenRewardsTab() {
        GameModesMenu.SetActive(false);
        ChallengesMenu.SetActive(false);
        RewardsMenu.SetActive(true);
    }
}