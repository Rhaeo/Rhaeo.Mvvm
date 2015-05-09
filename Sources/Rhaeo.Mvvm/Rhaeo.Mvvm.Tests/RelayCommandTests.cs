// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RelayCommandTests.cs" company="Rhaeo">
//   Licenced under the MIT licence.
// </copyright>
// <summary>
//   Proves correctness of the <see cref="RelayCommand" /> class implementation.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace Rhaeo.Mvvm.Tests
{
  /// <summary>
  /// Proves correctness of the <see cref="RelayCommand"/> class implementation.
  /// </summary>
  [TestClass]
  public sealed class RelayCommandTests
  {
    #region Methods

    /// <summary>
    /// Test the <see cref="RelayCommand.Execute"/> method only being callable when <see cref="RelayCommand.CanExecute"/> is positive.
    /// </summary>
    [TestMethod]
    public void TestRelayCommandExecuteOnlyWorkWhenCanExecuteReturnsTrue()
    {
      var results = new List<Boolean>();

      var raiseCanExecuteChanged = default(Action);
      var canExecute = default(Boolean);
      var relayCommand = new RelayCommand(() => results.Add(canExecute), out raiseCanExecuteChanged, () => canExecute);

      canExecute = false;
      relayCommand.Execute(null);
      canExecute = true;
      relayCommand.Execute(null);
      canExecute = false;
      relayCommand.Execute(null);
      canExecute = true;
      relayCommand.Execute(null);

      CollectionAssert.AreEqual(new[] { true, true }, results);

      var invoked = false;
      relayCommand.CanExecuteChanged += (sender, e) => { invoked = true; };
      raiseCanExecuteChanged();

      Assert.IsTrue(invoked);
    }

    /// <summary>
    /// Tests <see cref="RelayCommand.CanExecuteChanged"/> being called after calling the provided predicate status updating action.
    /// </summary>
    [TestMethod]
    public void TestRelayCommandCanExecuteChangedIsRaisedByTheReturnedAction()
    {
      var results = new List<Boolean>();

      var raiseCanExecuteChanged = default(Action);
      var canExecute = default(Boolean);
      var relayCommand = new RelayCommand(() => results.Add(canExecute), out raiseCanExecuteChanged, () => canExecute);
      relayCommand.CanExecuteChanged += (sender, e) => { results.Add(canExecute); };

      canExecute = false;
      raiseCanExecuteChanged();
      relayCommand.Execute(null);
      canExecute = true;
      raiseCanExecuteChanged();
      relayCommand.Execute(null);
      canExecute = false;
      raiseCanExecuteChanged();
      relayCommand.Execute(null);
      canExecute = true;
      raiseCanExecuteChanged();
      relayCommand.Execute(null);

      CollectionAssert.AreEqual(new[] { false, true, true, false, true, true }, results);
    }

    #endregion
  }
}