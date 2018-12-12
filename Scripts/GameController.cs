using System.Collections;
using UnityEngine.SceneManagement;

public class GameController {
    public const string GameSceneName = "GameScene";
    public const string MainMenuSceneName = "MainMenuScene";
    public const string PauseSceneName = "PauseScreenScene";
    public const string SkillUpgradeSceneName = "SkillUpgradeScene";
    public const string GameOverSceneName = "GameOverScreenScene";

    private static int currentGameLevel;
    private static float currentMovementLevel;
    private static float maxMovementLevel;
    private static float currentAttackLevel;
    private static float maxAttackLevel;
    private static float currentHealthLevel;
    private static float maxHealthLevel;
    private static bool isGamePaused = true;
    private static bool isGameOver = false;

    private static float musicSoundLevel = 1;
    private static float speechSoundLevel = 1;
    private static float effectsSoundLevel = 1;

    public static int CurrentGameLevel {
        get { return currentGameLevel; }
        private set { currentGameLevel = value; }
    }

    public static float CurrentMovementLevel {
        get { return currentMovementLevel; }
        private set { currentMovementLevel = value; }
    }

    public static float MaxMovementLevel {
        get { return maxMovementLevel; }
        private set { maxMovementLevel = value; }
    }

    public static float CurrentAttackLevel {
        get { return currentAttackLevel; }
        private set { currentAttackLevel = value; }
    }

    public static float MaxAttackLevel {
        get { return maxAttackLevel; }
        private set { maxAttackLevel = value; }
    }

    public static float CurrentHealthLevel {
        get { return currentHealthLevel; }
        private set { currentHealthLevel = value; }
    }

    public static float MaxHealthLevel {
        get { return maxHealthLevel; }
        private set { maxHealthLevel = value; }
    }

    public static void SetMusicSoundLevel(float value) {
        MusicSoundLevel = value;
    }

    public static void SetSpeechSoundLevel(float value) {
        SpeechSoundLevel = value;
    }

    public static void SetEffectsSoundLevel(float value) {
        EffectsSoundLevel = value;
    }

    public static float MusicSoundLevel {
        get { return musicSoundLevel; }
        private set { musicSoundLevel = value; }
    }

    public static float SpeechSoundLevel {
        get { return speechSoundLevel; }
        private set { speechSoundLevel = value; }
    }

    public static float EffectsSoundLevel {
        get { return effectsSoundLevel; }
        private set { effectsSoundLevel = value; }
    }

    public static bool IsGamePaused {
        get { return isGamePaused; }
    }

    public static bool IsGameOver {
        get { return isGameOver; }
    }

    public static void PauseGame() {
        isGamePaused = true;
    }

    public static void ResumeGame() {
        isGamePaused = false;
    }

    public static void GameOver() {
        isGamePaused = true;
        isGameOver = true;
        //loadSceneAsync(GameOverSceneName);
    }

    public static IEnumerator loadSceneAsync(string sceneName) {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.
        var asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone) yield return null;
    }

    public static IEnumerator unloadSceneAsync(string sceneName) {
        var sceneAlreadyLoaded = SceneManager.GetSceneByName(sceneName).isLoaded;
        if (sceneAlreadyLoaded) {
            var asyncOperation = SceneManager.UnloadSceneAsync(sceneName);
            while (!asyncOperation.isDone) yield return null;
        }
    }
}
