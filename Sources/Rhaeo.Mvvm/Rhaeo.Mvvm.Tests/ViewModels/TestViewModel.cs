// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestViewModel.cs" company="Rhaeo">
//   Licenced under the MIT licence.
// </copyright>
// <summary>
//   Represents a view model holding test data in properties whose property names are extracted from property expressions using the <see cref="ObservableObject" /> implementation.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace Rhaeo.Mvvm.Tests.ViewModels
{
  /// <summary>
  /// Represents a view model holding test data in properties whose property names are extracted from property expressions using the <see cref="ObservableObject"/> implementation.
  /// </summary>
  public sealed class TestViewModel
    : ObservableObject
  {
    #region Fields

    /// <summary>
    /// Holds the first name value.
    /// </summary>
    private String firstName;

    /// <summary>
    /// Holds the last name value.
    /// </summary>
    private String lastName;

    /// <summary>
    /// Holds the birth date and time value.
    /// </summary>
    private DateTime bithDateAndTime;

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance of the <see cref="TestViewModel"/> class.
    /// </summary>
    public TestViewModel()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="TestViewModel"/> class given the full name and date of birth.
    /// </summary>
    /// <param name="firstName">
    /// The first name.
    /// </param>
    /// <param name="lastName">
    /// The last name.
    /// </param>
    /// <param name="birthDateAndTime">
    /// The birth date and time.
    /// </param>
    public TestViewModel(String firstName, String lastName, DateTime birthDateAndTime)
    {
      this.FirstName = firstName;
      this.LastName = lastName;
      this.BirthDateAndTime = birthDateAndTime;
    }

    #endregion

    #region Properties

    /// <summary>
    /// Gets or sets the first name.
    /// </summary>
    public String FirstName
    {
      get
      {
        return this.firstName;
      }

      set
      {
        if (this.firstName == value)
        {
          return;
        }

        this.firstName = value;
        this.RaisePropertyChanged<TestViewModel, String>(testViewModel => testViewModel.FirstName);
      }
    }

    /// <summary>
    /// Gets or sets the last name.
    /// </summary>
    public String LastName
    {
      get
      {
        return this.lastName;
      }

      set
      {
        if (this.lastName == value)
        {
          return;
        }

        this.lastName = value;
        this.RaisePropertyChanged<TestViewModel, String>(testViewModel => testViewModel.LastName);

      }
    }

    /// <summary>
    /// Gets or sets the birth date and time.
    /// </summary>
    public DateTime BirthDateAndTime
    {
      get
      {
        return this.bithDateAndTime;
      }

      set
      {
        if (this.bithDateAndTime == value)
        {
          return;
        }

        this.bithDateAndTime = value;
        this.RaisePropertyChanged<TestViewModel, DateTime>(testViewModel => testViewModel.BirthDateAndTime);
      }
    }

    #endregion
  }
}