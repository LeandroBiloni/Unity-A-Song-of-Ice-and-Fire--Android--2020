using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Console : MonoBehaviour
{
    public delegate void Commands(List<string> data);

    private Dictionary<string, Commands> _console = new Dictionary<string, Commands>();
    private Dictionary<string, string> _description = new Dictionary<string, string>();

    public Text consoleText;
    public InputField consoleInput;

    private int _commandCount = 1;

    internal void AddCommand(string v1, object heal, string v2)
    {
        throw new NotImplementedException();
    }

    // Start is called before the first frame update
    void Awake()
    {
        AddCommand("CommandsList", CommandsList, "Show available commands.");
        AddCommand("Clear", ClearConsole, "Clears console window.");
        AddCommand("Exit", ExitConsole, "Close console window.");
    }

    public void AddCommand(string dictionaryKey, Commands command, string description)
    {
        if (_console.ContainsKey(dictionaryKey) == false)
            _console.Add(dictionaryKey, command);
        else _console[dictionaryKey] += command;

        if (_description.ContainsKey(dictionaryKey) == false)
            _description.Add(dictionaryKey, description);
        else _description[dictionaryKey] += description;
    }

    public void EnterCommand()
    {
        Input(consoleInput.text);
    }

    private void Input(string dictionaryKey)
    {

        char[] division = new char[] { ' ' };
        string[] command = dictionaryKey.Split(division);

        string key = command[0];
        List<string> data = new List<string>();
        for (int i = 1; i < command.Length; i++)
        {
            data.Add(command[i]);
        }

        if (_console.ContainsKey(key))
            _console[key](data);
        else consoleText.text += "\n" + "Invalid command. Try again.";
        consoleInput.text = "";
    }

    private void CommandsList(List<string> data)
    {
        consoleText.text += "\n" + "Commands Syntax: CommandName Parameter";
        foreach (var command in _console)
        {
            if (_description[command.Key] == null)
                consoleText.text += "\n" + _commandCount + ": " + command.Key + ".";
            else consoleText.text += "\n" + _commandCount + ": " + command.Key + ": " + _description[command.Key];
            _commandCount++;
        }
        _commandCount = 1;
    }

    private void ClearConsole(List<string> data)
    {
        consoleText.text = "Write CommandsList for available commands. \n";
    }

    private void ExitConsole(List<string> data)
    {
        CloseConsole();
    }

    public void CloseConsole()
    {
        consoleText.text = "Write CommandsList for available commands. \n";
        consoleInput.text = "Enter command...";
        gameObject.SetActive(false);
    }
}
