using System;

namespace WebTestFramework
{
	/// <summary>
	/// A base class for implementing the generic 
	/// <see cref="ICreateControl{T}"/> interface.
	/// </summary>
	public abstract class SeleniumControlFactory<T> : ICreateControl<T>
	{
		/// <summary>
		/// Template function that the specialized classes should implement
		/// to create the actual control
		/// </summary>
		/// <param name="locator">
		/// The selenium locator string that the control should use.
		/// </param>
		protected abstract T CreateControl(string locator);

		/// <summary>
		/// Creates a control from the element ID.
		/// </summary>
		public T FromID(string id)
		{
			return CreateControl("id=" + id);
		}

		public T FromName(string name)
		{
			return CreateControl("name=" + name);
		}

		/// <summary>
		/// Creates a control from a CSS locator
		/// </summary>
		public T FromCss(string cssLocator)
		{
			return CreateControl("css=" + cssLocator);
		}
	}

	/// <summary>
	/// A specialized <see cref="SeleniumControlFactory{T}"/> that takes a
	/// factory function as constructor parameter.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class SeleniumDelegateControlFactory<T> : SeleniumControlFactory<T>
	{
		private readonly Func<string, T> _createControlDelegate;

		/// <summary>
		/// Creates a new <see cref="SeleniumDelegateControlFactory{T}"/> instance
		/// </summary>
		/// <param name="createControlDelegate">
		/// A delegate used to construct that actual control
		/// </param>
		public SeleniumDelegateControlFactory(Func<string, T> createControlDelegate)
		{
			if (createControlDelegate == null) throw new ArgumentNullException("createControlDelegate");
			_createControlDelegate = createControlDelegate;
		}

		/// <summary>
		/// Constructs the actual control by calling the delegate passed
		/// to the constructor
		/// </summary>
		/// <param name="locator">
		/// The locator to pass to the factory function
		/// </param>
		/// <returns>
		/// The result of the factory function
		/// </returns>
		protected override T CreateControl(string locator)
		{
			return _createControlDelegate(locator);
		}
	}
}