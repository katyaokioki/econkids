
using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dialogues : MonoBehaviour
{
    private Story _currentStory;
    private TextAsset _inkJson;

    private GameObject _dialoguePanel;
    private TextMeshProUGUI _dialogueText;
    private TextMeshProUGUI _nameText;

    private GameObject _choiceButtonsPanel;
    [SerializeField] private GameObject choiceButton;
    private List<TextMeshProUGUI> _choiseText = new();
    public bool DialogPlay { get; private set;}

    private void Awake()
    {
        _currentStory = new Story(_inkJson.text);
    }
    void Start()
    {
        StartDialogue();
    }
    public void StartDialogue()
    {
        DialogPlay = true;
        _dialoguePanel.SetActive(true);
        ContuinueStory();
    }
    public void ContuinueStory()
    {
        if (_currentStory.canContinue)
        {
            ShowDialogue();
            ShowChoiceButton();
        }
        else
        {
            ExitDialogue();
        }
    }
    private void ShowDialogue()
    {
        _dialogueText.text = _currentStory.Continue();
        _nameText.text = (string)_currentStory.variablesState["characterName"];
    }
    private void ShowChoiceButton()
    {
        List<Choice> currentChoices = _currentStory.currentChoices;
        _choiceButtonsPanel.SetActive(currentChoices.Count != 0);
        if (currentChoices.Count <= 0)
        {
            return;
        }
        for (int i  = 0; i< currentChoices.Count; i++)
        {
            GameObject choice = Instantiate(choiceButton);
            choice.GetComponent<ButtonActions>().index = i;
            choice.transform.SetParent(_choiceButtonsPanel.transform);

            TextMeshProUGUI choiceText = choice.GetComponentInChildren<TextMeshProUGUI>();
            choiceText.text = currentChoices[i].text;
            _choiseText.Add(choiceText);
        }
    }
    public void ChoiceButtonAction()
    {

    }
    private void ExitDialogue()
    {

    }
}
