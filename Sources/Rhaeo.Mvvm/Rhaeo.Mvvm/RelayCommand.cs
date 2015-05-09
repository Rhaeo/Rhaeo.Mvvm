// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RelayCommand.cs" company="Rhaeo">
//   Licenced under the MIT licence.
// </copyright>
// <summary>
//   A command whose sole purpose is to relay its functionality
//   to other objects by invoking delegates.
//   The default return value for the CanExecute method is 'true'.
//   <see cref="RaiseCanExecuteChanged" /> needs to be called whenever
//   <see cref="CanExecute" /> is expected to return a different value.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Rhaeo.Mvvm
{
  /// <summary>
  /// A command whose sole purpose is to relay its functionality 
  /// to other objects by invoking delegates. 
  /// The default return value for the CanExecute method is 'true'.
  /// <see cref="RaiseCanExecuteChanged"/> needs to be called whenever
  /// <see cref="CanExecute"/> is expected to return a different value.
  /// </summary>
  /// <seealso cref="http://go.microsoft.com/fwlink/?LinkID=390556">
  /// Adapted from the Basic Page item template in Visual Studio Windows Phone application project menu.
  /// </seealso>
  public class RelayCommand
    : ICommand
  {
    #region Fields

    /// <summary>
    /// Holds the <see cref="Execute"/> method value.
    /// </summary>
    private readonly Action execute;

    /// <summary>
    /// Holds the <see cref="CanExecute"/> method value.
    /// </summary>
    private readonly Func<Boolean> canExecute;

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance of the <see cref="RelayCommand"/> class given the execution delegate and predicate.
    /// </summary>
    /// <param name="execute">
    /// The execution delegate.
    /// </param>
    /// <param name="raiseCanExecuteChanged">
    /// The delegate used by the command owner to notify about a predicate status update.
    /// </param>
    /// <param name="canExecute">
    /// The execution predicate.
    /// </param>
    public RelayCommand(Action execute, out Action raiseCanExecuteChanged, Func<Boolean> canExecute = null)
    {
      if (execute == null)
      {
        throw new ArgumentNullException("execute");
      }

      this.execute = execute;
      this.canExecute = canExecute;

      raiseCanExecuteChanged = () =>
      {
        var canExecuteChangedHandler = this.CanExecuteChanged;
        if (canExecuteChangedHandler != null)
        {
          canExecuteChangedHandler(this, EventArgs.Empty);
        }
      };
    }

    #endregion

    #region Events

    /// <summary>
    /// Raised when RaiseCanExecuteChanged is called.
    /// </summary>
    public event EventHandler CanExecuteChanged;

    #endregion

    #region Methods

    /// <summary>
    /// Determines whether this <see cref="RelayCommand"/> can execute in its current state.
    /// </summary>
    /// <param name="parameter">
    /// Data used by the command. If the command does not require data to be passed, this object can be set to null.
    /// </param>
    /// <returns>true
    /// <code>true</code>, if this command can be executed; otherwise, <code>false</code>.
    /// </returns>
    public Boolean CanExecute(Object parameter)
    {
      return this.canExecute == null || this.canExecute();
    }

    /// <summary>
    /// Executes the <see cref="RelayCommand"/> on the current command target.
    /// </summary>
    /// <param name="parameter">
    /// Data used by the command. If the command does not require data to be passed, this object can be set to null.
    /// </param>
    public void Execute(Object parameter)
    {
      if (this.CanExecute(parameter))
      {
        this.execute();
      }
    }

    #endregion
  }
}