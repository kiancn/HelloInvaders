using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Player Setup/Keybindings")]
public class ButtonReferences : ScriptableObject
{
    public KeyCode moveUp;
    public KeyCode moveDown;
    public KeyCode moveLeft;
    public KeyCode moveRight;
    public KeyCode fireOne;
    public KeyCode fireTwo;
    public KeyCode activateShield;

}
