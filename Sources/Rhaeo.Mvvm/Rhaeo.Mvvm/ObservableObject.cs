// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ObservableObject.cs" company="Rhaeo">
//   Licenced under the MIT licence.
// </copyright>
// <summary>
//   Defines the ObservableObject type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Linq.Expressions;

namespace Rhaeo.Mvvm
{
  /// <summary>
  /// Serves as a back class for object instances obserable through the <see cref="INotifyPropertyChanged"/> interface.
  /// </summary>
  public class ObservableObject
    : INotifyPropertyChanged
  {
    #region Events

    /// <summary>
    /// Occurs when a property value changes.
    /// </summary>
    public event PropertyChangedEventHandler PropertyChanged;

    #endregion

    #region Methods

    /// <summary>
    /// Raises the <see cref="PropertyChanged"/> event with a property name extracted from the property expression.
    /// </summary>
    /// <typeparam name="TViewModel">
    /// The view model type.
    /// </typeparam>
    /// <typeparam name="TValue">
    /// The property value type.
    /// </typeparam>
    /// <param name="propertyExpression">
    /// The property expression.
    /// </param>
    protected void RaisePropertyChanged<TViewModel, TValue>(Expression<Func<TViewModel, TValue>> propertyExpression) where TViewModel : ObservableObject
    {
      var propertyName = (propertyExpression.Body as MemberExpression).Member.Name;

      var propertyChangedHandler = this.PropertyChanged;
      if (propertyChangedHandler != null)
      {
        propertyChangedHandler(this, new PropertyChangedEventArgs(propertyName));
      }
    }

    #endregion
  }
}