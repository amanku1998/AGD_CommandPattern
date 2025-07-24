using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandInvoker 
{
    private Stack<ICommand> commandRegistry = new Stack<ICommand>();

    //Process a command, which involves both executing it and registering it.
    public void ProcessCommand(ICommand commandToProcess)
    {
        ExecuteCommand(commandToProcess);
        RegisterCommand(commandToProcess);
    }

    //Execute a command, invoking its associated action.
    public void ExecuteCommand(ICommand commandToExecute) => commandToExecute.Execute();

    //Register a command by adding it to the command registry stack.
    public void RegisterCommand(ICommand commandToRegister) => commandRegistry.Push(commandToRegister);
}
