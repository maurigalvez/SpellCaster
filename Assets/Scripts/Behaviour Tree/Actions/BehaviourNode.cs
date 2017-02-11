using UnityEngine;
using System.Collections;
/// ==============================================================
/// © Mauricio Galvez ALL RIGHTS RESERVED
/// ==============================================================
public abstract class BehaviourNode : MonoBehaviour
{
    public enum Status
    {
        Error = 0,
        Failure,
        Running,
        Success
    }

    public delegate void EnterEvent();
    public EnterEvent OnEnter = delegate { };

    public delegate void ExitEvent();
    public ExitEvent OnExit = delegate { }; 

    /// <summary>
    /// Function that will be fired when entering action
    /// </summary>
    public virtual void Enter()
    {
        OnEnter();
    }

    /// <summary>
    /// Function that will be fired when updating/executing action
    /// </summary>
    /// <returns>Status of update.</returns>
    public abstract Status UpdateNode();

    public virtual void Execute()
    {
        Enter();
        UpdateNode();
        Exit();
    }

    /// <summary>
    /// Function that will be fired when exiting action
    /// </summary>
    public virtual void Exit()
    {
        OnExit();
    }
}
