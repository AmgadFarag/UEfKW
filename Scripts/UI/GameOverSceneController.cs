using UnityEngine;

namespace UI {
    public class GameOverSceneController : MonoBehaviour {
        public void Restart() {
            StartCoroutine(GameController.loadSceneAsync(GameController.GameSceneName));
        }

        public void ToMainMenu() {
            // TODO, are there any actions that should be done before loading the main menu scene,
            // like saving any thing.
            StartCoroutine(GameController.loadSceneAsync(GameController.MainMenuSceneName));
        }
    }
}
