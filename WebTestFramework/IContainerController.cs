using System;

namespace WebTestFramework
{
	/// <summary>
	/// Implements functionality to inspect and manipulate collections of elements.
	/// </summary>
	/// <typeparam name="T">
	/// A type that is used to implement the controller for each individual element in the array
	/// </typeparam>
	public interface IContainerController<out T>
	{
		/// <summary>
		/// Gets the number of elements in the collection
		/// </summary>
		int Count { get; }

		/// <summary>
		/// Gets the controller for controlling a specific element in the collection
		/// </summary>
		/// <param name="index">
		/// The index of the element to retrieve. This is the zero-based index, so the interface
		/// follows a c# indexing style
		/// </param>
		/// <remarks>
		/// An implementation of this function does not necessarily throw an 
		/// <see cref="ArgumentOutOfRangeException"/> if the specified index is too high.
		/// This is because that some implementations of this interface, each call take a significant
		/// large amount of time to execute. So the check for the argument to be lower than the
		/// <see cref="Count"/> property is not necessarily implemented.
		/// In this case, you will just get a different exception from the concrete driver that
		/// the element you are trying to access is not present.
		/// </remarks>
		T this[int index] { get; }
	}

	/// <summary>
	/// Interface for 
	/// </summary>
	public interface ICollectionElementDriver
	{
		/// <summary>
		/// Creates a controller for a specific text field inside an collection element
		/// </summary>
		/// <param name="localXPath">
		/// The xpath to identify the element, local to the container element xpath.
		/// </param>
		/// <returns>
		/// An <see cref="ITextField"/> implementation that can be used to control this text field
		/// </returns>
		ITextField CreateTextField(string localXPath);

		/// <summary>
		/// Creates a controller for a specific button inside a collection element
		/// </summary>
		/// <param name="localXPath">
		/// The xpath to identify the element, local to the container element xpath.
		/// </param>
		/// <returns>
		/// An <see cref="ITextField"/> implementation that can be used to control this button
		/// </returns>
		IButton CreateButton(string localXPath);

		/// <summary>
		/// Creates a controller for a specific radio button inside a collection element
		/// </summary>
		/// <param name="localXPath">
		/// The xpath to identify the element, local to the container element xpath.
		/// </param>
		/// <returns>
		/// An <see cref="IRadioButton"/> implementation that can be used to control this radio button
		/// </returns>
		IRadioButton CreateRadioButton(string localXPath);
	}
}