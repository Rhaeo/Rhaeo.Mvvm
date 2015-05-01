// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ObservableObjectExtensionMethods.cs" company="Rhaeo">
//   Licenced under the MIT licence.
// </copyright>
// <summary>
//   Provides extension methods for the <see cref="ObservableObject" /> class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Rhaeo.Mvvm
{
  /// <summary>
  /// Provides extension methods for the <see cref="ObservableObject"/> class.
  /// </summary>
  public static class ObservableObjectExtensionMethods
  {
    #region Methods

    /// <summary>
    /// Raises the <see cref="ObservableObject.PropertyChanged"/> event with a property name extracted from the property expression.
    /// </summary>
    /// <typeparam name="TViewModel">
    /// The view model type.
    /// </typeparam>
    /// <typeparam name="TValue">
    /// The property value type.
    /// </typeparam>
    /// <param name="viewModel">
    /// The view model to raise the event at.
    /// </param>
    /// <param name="propertyExpression">
    /// The property expression.
    /// </param>
    public static void RaisePropertyChanged<TViewModel, TValue>(this TViewModel viewModel, Expression<Func<TViewModel, TValue>> propertyExpression) where TViewModel : ObservableObject
    {
      if (viewModel == null)
      {
        throw new ArgumentNullException("viewModel", "The view model must not be null.");
      }

      if (propertyExpression == null)
      {
        throw new ArgumentNullException("propertyExpression", "The property expression must not be null.");
      }

      var memberExpression = propertyExpression.Body as MemberExpression;
      if (memberExpression != null && memberExpression.Member is PropertyInfo)
      {
        viewModel.RaisePropertyChanged(memberExpression.Member.Name);
      }
      else
      {
        throw new ArgumentException("The member specified in the expression must be a property.", "propertyExpression");
      }
    }

    #endregion
  }
}