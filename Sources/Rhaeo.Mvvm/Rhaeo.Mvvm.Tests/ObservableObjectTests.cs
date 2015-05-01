// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ObservableObjectTests.cs" company="Rhaeo">
//   Licenced under the MIT licence.
// </copyright>
// <summary>
//   Contains tests for the <see cref="ObservableObject" /> class implementation.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Rhaeo.Mvvm.Tests.ViewModels;

namespace Rhaeo.Mvvm.Tests
{
  /// <summary>
  /// Proves correctness of the <see cref="ObservableObject"/> class implementation.
  /// </summary>
  [TestClass]
  public class ObservableObjectTests
  {
    #region Methods

    /// <summary>
    /// Tests the <see cref="ObservableObject.PropertyChanged"/> event being called with a correct property name extracted from the property expression.
    /// </summary>
    [TestMethod]
    public void TestPropertyChangedPropertyNameFromPropertyExpressionExtraction()
    {
      var propertyChangedInvocations = new List<PropertyChangedEventArgs>();
      var viewModel = new TestViewModel();
      viewModel.PropertyChanged += (sender, e) => propertyChangedInvocations.Add(e);

      viewModel.FirstName = "Tomáš";
      viewModel.LastName = "Hübelbauer";
      viewModel.BirthDateAndTime = new DateTime(1992, 12, 17);

      CollectionAssert.AreEqual(new[] { "FirstName", "LastName", "BirthDateAndTime" }, propertyChangedInvocations.Select(propertyChangedEventArgs => propertyChangedEventArgs.PropertyName).ToArray());
    }

    /// <summary>
    /// Tests the <see cref="ObservableObject.PropertyChanged"/> event not being called when passing an equal value to the property's current value to the property.
    /// </summary>
    [TestMethod]
    public void TestPropertyChangedEventNotCalledOnEqualValue()
    {
      var propertyChangedInvocations = new List<PropertyChangedEventArgs>();
      var viewModel = new TestViewModel();
      viewModel.PropertyChanged += (sender, e) => propertyChangedInvocations.Add(e);

      // Fires for FirstName, LastName and that's it.
      viewModel.FirstName = "Tomáš";
      viewModel.LastName = "Hübelbauer";
      viewModel.FirstName = "Tomáš";

      var viewModel2 = new TestViewModel("Tomáš", "Hübelbauer", new DateTime(1992, 12, 17));
      viewModel2.PropertyChanged += (sender, e) => propertyChangedInvocations.Add(e);

      // Doesn't fire at all since the current value of the FirstName property was initialized through the constructor.
      viewModel2.FirstName = "Tomáš";

      CollectionAssert.AreEqual(new[] { "FirstName", "LastName" }, propertyChangedInvocations.Select(propertyChangedEventArgs => propertyChangedEventArgs.PropertyName).ToArray());
    }

    #endregion
  }
}