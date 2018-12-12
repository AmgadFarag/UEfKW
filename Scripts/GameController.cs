using System;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController {
    /* game constants, states and general controls variables */
    public const string GameSceneName = "GameScene";
    public const string MainMenuSceneName = "MainMenuScene";
    public const string PauseSceneName = "PauseScreenScene";
    public const string SkillUpgradeSceneName = "SkillUpgradeScene";
    public const string GameOverSceneName = "GameOverScreenScene";
    private static bool _isGamePaused = true;
    private static bool _isGameOver = false;
    private static float _musicSoundLevel = 1;
    private static float _speechSoundLevel = 1;
    private static float _effectsSoundLevel = 1;

    /* player variables */
    private static int _currentGameLevel = 1;
    private static int _skillPoints = 0;
    private static int _currentXP = 0;
    private static int _currentLevelMaxXP = 500;

    private static double _maxHealthPoints = 100;
    private static double _currentHealthPoints = _maxHealthPoints;

    private static double _maxRageValue = 100;
    private static double _currentRageValue = 0;
    private static bool _isRageReadyToActivate = false;
    private static bool _isRageActivated = false;

    private static double _currentMovementSpeed;

    private static double _lightAttackDamage = 10;

    private static double _heavyAttackDamage = 30;
    /**********************/

    /* boss variables */
    // TODO
    /******************/


    /***** game variables controls *****/

    /* player controls */
    public static int CurrentGameLevel {
        get { return _currentGameLevel; }
        private set { _currentGameLevel = value; }
    }

    // for debugging
    public static void IncCurrentGameLevelBy(int value) {
        CurrentGameLevel += value;
    }

    public static int SkillPoints {
        get { return _skillPoints; }
        private set {
            if (value <= 0) {
                _skillPoints = 0;
                return;
            }

            _skillPoints = value;
        }
    }

    // for debugging
    public static void IncSkillPointsBy(int value) {
        SkillPoints += value;
    }

    // for debugging
    public static void DecSkillPointsBy(int value) {
        SkillPoints -= value;
    }

    public static void UseSkillPoint() {
        SkillPoints--;
    }

    public static int CurrentLevelMaxXp {
        get { return _currentLevelMaxXP; }
        private set { _currentLevelMaxXP = value; }
    }

    public static int CurrentXp {
        get { return _currentXP; }
        private set {
            if (value >= CurrentLevelMaxXp) {
                // this is where we level up
                _currentXP = 0;
                CurrentLevelMaxXp *= 2;
                CurrentGameLevel++;
                SkillPoints++;
                return;
            }

            _currentXP = value;
        }
    }

    // for debugging
    public static void IncCurrentXPBy(int value) {
        CurrentXp += value;
    }

    // this should be used whenever an enemy is killed
    public static void AddEnemyKillXP() {
        CurrentXp += 50;
    }

    public static double MaxHealthPoints {
        get { return _maxHealthPoints; }
        private set { _maxHealthPoints = value; }
    }

    // for debugging
    public static void IncMaxHealthPoints(double value) {
        MaxHealthPoints += value;
    }

    public static double CurrentHealthPoints {
        get { return _currentHealthPoints; }
        private set {
            if (value >= MaxHealthPoints) {
                _currentHealthPoints = MaxHealthPoints;
                return;
            } else if (value <= 0) {
                _currentHealthPoints = 0;
                // TODO, call the game over from here or what?
                GameOver();
            }

            _currentHealthPoints = value;
        }
    }

    public static void LosePlayerHealthPointsBy(double value) {
    }

    public static void RestorePlayerHealthPoints() {
        CurrentHealthPoints = MaxHealthPoints;
    }

    public static void UpgradeHealthPoints() {
        var upgradeValue = 0.1 * MaxHealthPoints;
        MaxHealthPoints += Math.Floor(upgradeValue);
        UseSkillPoint();
    }

    // for debugging
    public static void IncCurrentHealthPointsBy(double value) {
        CurrentHealthPoints += value;
    }

    // for debugging
    public static void DecCurrentHealthPoints(double value) {
        CurrentHealthPoints -= value;
    }

    public static double MaxRageValue {
        get { return _maxRageValue; }
    }

    public static double CurrentRageValue {
        get { return _currentRageValue; }
        private set {
            if (value >= _maxRageValue) {
                IsRageReadyToActivate = true;
            }

            _currentRageValue = value;
        }
    }

    // for debugging
    public static void IncCurrentRageValueBy(double value) {
        CurrentRageValue += value;
    }

    public static bool IsRageReadyToActivate {
        get { return _isRageReadyToActivate; }
        private set { _isRageReadyToActivate = value; }
    }

    public static bool IsRageActivated {
        get { return _isRageActivated; }
        private set { _isRageActivated = value; }
    }

    // this will be used whenever we want to activate the rage from the controllers
    public static void ActivateRage() {
        if (IsRageReadyToActivate) {
            IsRageActivated = true;
            CurrentRageValue = 0;
        }
    }

    public static double CurrentMovementSpeed {
        get { return _currentMovementSpeed; }
        private set { _currentMovementSpeed = value; }
    }

    public static void UpgradeMovementSpeed() {
        var upgradeValue = 0.1 * CurrentMovementSpeed;
        CurrentMovementSpeed += Math.Floor(upgradeValue);
        UseSkillPoint();
    }

    public static double LightAttackDamage {
        get { return _lightAttackDamage; }
        private set { _lightAttackDamage = value; }
    }

    public static double HeavyAttackDamage {
        get { return _heavyAttackDamage; }
        private set { _heavyAttackDamage = value; }
    }

    public static void UpgradeAttacks() {
        var lightAttackUpgradeValue = 0.1 * LightAttackDamage;
        var heavyAttackUpgradeValue = 0.1 * HeavyAttackDamage;

        LightAttackDamage += Math.Floor(lightAttackUpgradeValue);
        HeavyAttackDamage += Math.Floor(heavyAttackUpgradeValue);
        UseSkillPoint();
    }

    /*light attack:0, heavy attack: 1 */
    public static double CalcAttackDamage(int attackType) {
        switch (attackType) {
            case 0:
                if (IsRageActivated) {
                    return 2 * LightAttackDamage;
                }

                return LightAttackDamage;
                break;
            case 1:
                if (IsRageActivated) {
                    return 2 * HeavyAttackDamage;
                }

                return HeavyAttackDamage;
                break;
            default:
                return 0;
                break;
        }
    }
    /*********************/

    /* boss controls */
    // TODO
    /******************/

    /***** sound controls *****/
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
        get { return _musicSoundLevel; }
        private set { _musicSoundLevel = value; }
    }

    public static float SpeechSoundLevel {
        get { return _speechSoundLevel; }
        private set { _speechSoundLevel = value; }
    }

    public static float EffectsSoundLevel {
        get { return _effectsSoundLevel; }
        private set { _effectsSoundLevel = value; }
    }
    /************************/

    /* game states controls */
    public static bool IsGamePaused {
        get { return _isGamePaused; }
    }

    public static bool IsGameOver {
        get { return _isGameOver; }
    }

    public static void PauseGame() {
        _isGamePaused = true;
    }

    public static void ResumeGame() {
        _isGamePaused = false;
    }

    public static void GameOver() {
        _isGamePaused = true;
        _isGameOver = true;
        loadScene(GameOverSceneName, LoadSceneMode.Additive);
    }
    /************************/

    /* helper methods */
    public static IEnumerator loadSceneAsync(string sceneName, LoadSceneMode mode) {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.
        var asyncLoad = SceneManager.LoadSceneAsync(sceneName, mode);
        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone) yield return null;
    }

    public static void loadScene(string sceneName, LoadSceneMode mode) {
        SceneManager.LoadScene(sceneName, mode);
    }

    public static IEnumerator unloadSceneAsync(string sceneName) {
        var sceneAlreadyLoaded = SceneManager.GetSceneByName(sceneName).isLoaded;
        if (sceneAlreadyLoaded) {
            var asyncOperation = SceneManager.UnloadSceneAsync(sceneName);
            while (!asyncOperation.isDone) yield return null;
        }
    }
}
