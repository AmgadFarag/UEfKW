using UnityEngine;
using UnityEngine.UI;

namespace UI {
    public class MainMenuSceneController : MonoBehaviour {
        private GameObject optionsWindow;
        private GameObject optionsMenuSection;
        private GameObject sectionTitle;
        private GameObject audioSettingsSection;
        private GameObject musicSoundSlider;
        private GameObject speechSoundSlider;
        private GameObject effectsSoundSlider;
        private GameObject creditsSection;
        private GameObject howToPlaySection;

        public void StartGame() {
            // Use a co-routine to load the Scene in the background
            StartCoroutine(GameController.loadSceneAsync(GameController.GameSceneName));
        }

        public void ShowOptionsWindow() {
            optionsWindow.SetActive(true);
            optionsMenuSection.SetActive(true);
            sectionTitle.GetComponent<Text>().text = "OPTIONS";
        }

        public void CloseOptionsWindow() {
            optionsWindow.SetActive(false);
            optionsMenuSection.SetActive(false);
            audioSettingsSection.SetActive(false);
            creditsSection.SetActive(false);
            howToPlaySection.SetActive(false);
            sectionTitle.GetComponent<Text>().text = "";
        }

        public void QuitGame() {
            Application.Quit();
        }

        public void OpenAudioSettings() {
            optionsWindow.SetActive(true);
            audioSettingsSection.SetActive(true);
            sectionTitle.GetComponent<Text>().text = "AUDIO SETTINGS";

            musicSoundSlider.GetComponent<Slider>().value = GameController.MusicSoundLevel * 100;
            speechSoundSlider.GetComponent<Slider>().value = GameController.SpeechSoundLevel * 100;
            effectsSoundSlider.GetComponent<Slider>().value = GameController.EffectsSoundLevel * 100;
        }

        public void OpenHowToPlayScreen() {
            optionsWindow.SetActive(true);
            howToPlaySection.SetActive(true);
            sectionTitle.GetComponent<Text>().text = "HOW TO PLAY";
        }

        public void OpenCreditsScreen() {
            optionsWindow.SetActive(true);
            creditsSection.SetActive(true);
            sectionTitle.GetComponent<Text>().text = "CREDITS";
        }

        public void ReturnToOptionsWindow() {
            optionsWindow.SetActive(true);
            optionsMenuSection.SetActive(true);
            sectionTitle.GetComponent<Text>().text = "OPTIONS";

            audioSettingsSection.SetActive(false);
            creditsSection.SetActive(false);
            howToPlaySection.SetActive(false);
        }

        public void MusicLevelChanged(float value) {
            // divide the value by 100 (chosen max value for the slider) to get the result on a scale of 1 (for the sound level)
            GameController.SetMusicSoundLevel(value / 100);
        }

        public void SpeechLevelChanged(float value) {
            GameController.SetSpeechSoundLevel(value / 100);
        }

        public void EffectsLevelChanged(float value) {
            GameController.SetEffectsSoundLevel(value / 100);
        }

        // Use this for initialization
        private void Start() {
            optionsWindow = GameObject.FindWithTag("OptionsWindow");
            optionsMenuSection = GameObject.FindWithTag("OptionsMenuSection");
            sectionTitle = GameObject.FindWithTag("WindowSectionTitleText");
            creditsSection = GameObject.FindWithTag("CreditsSection");
            howToPlaySection = GameObject.FindWithTag("HowToPlaySection");
            audioSettingsSection = GameObject.FindWithTag("AudioSettingsSection");
            musicSoundSlider = GameObject.FindWithTag("MusicSoundSlider");
            speechSoundSlider = GameObject.FindWithTag("SpeechSoundSlider");
            effectsSoundSlider = GameObject.FindWithTag("EffectsSoundSlider");

            optionsWindow.SetActive(false);
            optionsMenuSection.SetActive(false);
            audioSettingsSection.SetActive(false);
            creditsSection.SetActive(false);
            howToPlaySection.SetActive(false);
            sectionTitle.GetComponent<Text>().text = "";
        }
    }
}
