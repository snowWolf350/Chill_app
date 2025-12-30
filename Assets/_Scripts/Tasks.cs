using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Tasks : ButtonScript
{
    [SerializeField] TMP_InputField TaskInput;
    [SerializeField] Button CreateButton;
    [SerializeField] Transform taskContainer;
    [SerializeField] Transform taskTemplate;

    List<TaskTemplate> taskList;
    string taskString;

    Animator animator;

    const string IS_OPEN = "isOpen";

    protected override void Awake()
    {
        base.Awake();
        taskList = new List<TaskTemplate>();
        TaskInput.onValueChanged.AddListener((string text) =>
        {
            taskString = text;
        });
        CreateButton.onClick.AddListener(() =>
        {   if(taskString != null)
            {
            Transform taskTransform = Instantiate(taskTemplate, taskContainer);
            if (taskTransform.TryGetComponent(out TaskTemplate TaskTemplate))
            {
                TaskTemplate.setText(taskString);
                taskList.Add(TaskTemplate);
            }
            taskTransform.gameObject.SetActive(true);
            TaskInput.text = "";
            taskString = null;
            }
        });
    }
    private void Start()
    {
        taskTemplate.gameObject.SetActive(false);
        base.OnTabClosed += Afirmations_OnTabClosed;
        base.OnTabToggled += Afirmations_OnTabToggled;
        animator = GetComponent<Animator>();
    }
    private void Afirmations_OnTabToggled(object sender, System.EventArgs e)
    {
        Animatewindow();
    }

    private void Afirmations_OnTabClosed(object sender, System.EventArgs e)
    {
        Animatewindow();
    }
    private void Animatewindow()
    {
        animator.SetBool(IS_OPEN, base.TemplateState);
    }
}
