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

namespace Rhaeo.Mvvm
{
  /// <summary>
  /// Serves as a back class for object instances obserable through the <see cref="INotifyPropertyChanged"/> interface.
  /// </summary>
  public abstract class ObservableObject
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
    /// Raises the <see cref="PropertyChanged"/> event with a given property name.
    /// </summary>
    /// <param name="propertyName">
    /// The name of the property.
    /// </param>
    internal void RaisePropertyChanged(String propertyName)
    {
      var propertyChangedHandler = this.PropertyChanged;
      if (propertyChangedHandler != null)
      {
        propertyChangedHandler(this, new PropertyChangedEventArgs(propertyName));
      }
    }

    #endregion
  }
}