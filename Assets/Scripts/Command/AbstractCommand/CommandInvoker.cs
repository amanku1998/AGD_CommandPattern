using Command.Main;
using System.Collections.Generic;

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

    private bool RegistryEmpty() => commandRegistry.Count == 0;

    private bool CommandBelongsToActivePlayer()
    {
       return (commandRegistry.Peek() as UnitCommand).commandData.ActorPlayerID == GameService.Instance.PlayerService.ActivePlayerID;
    }

    public void Undo()
    {
        if (!RegistryEmpty() && CommandBelongsToActivePlayer())
            commandRegistry.Pop().Undo();
    }
}
