using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SceneSettings", menuName = "Game/Settings/Scene Settings")]
[System.Serializable]
public class SceneSettings : ScriptableObject
{
    public Scene scene;
    public SoundClip activeSoundClip;

    public bool scoreLabelEnabled;
    public bool livesLabelEnabled;
    public bool highScoreLabelEnabled;

    public bool startLabelSetActive;
    public bool endLabelSetActive;

    public bool startButtonSetActive;
    public bool restartButtonSetActive;

}
