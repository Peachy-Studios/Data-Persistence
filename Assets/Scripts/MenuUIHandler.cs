using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Data.Persistence
{
    public class MenuUIHandler : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _nameInputField;
        public void StartGame()
        {
            GameManager.Instance.PlayerName = _nameInputField.text;
            SceneManager.LoadScene(1);
        }
    }
}