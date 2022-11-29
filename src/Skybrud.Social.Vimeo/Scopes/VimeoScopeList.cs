using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Skybrud.Essentials.Collections;

namespace Skybrud.Social.Vimeo.Scopes {

    /// <summary>
    /// Class representing a collection of scopes for the Vimeo API.
    /// </summary>
    public class VimeoScopeList : IReadOnlyList<VimeoScope> {

        #region Private fields

        private readonly List<VimeoScope> _list = new();

        #endregion

        #region Properties

        /// <summary>
        /// Gets the amount of scopes in the list.
        /// </summary>
        public int Count => _list.Count;

        /// <summary>
        /// Gets or sets the scope at the specified <paramref name="index"/>.
        /// </summary>
        /// <param name="index">The zero-based index of the scope to get or set.</param>
        /// <returns>The scope at the specified index.</returns>
        public VimeoScope this[int index] => _list[index];

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new collection based on the specified <paramref name="array"/> of scopes.
        /// </summary>
        /// <param name="array">Array of scopes.</param>
        public VimeoScopeList(params VimeoScope[] array) {
            _list.AddRange(array);
        }

        /// <summary>
        /// Initializes a new collection based on the specified <paramref name="collection"/> of scopes.
        /// </summary>
        /// <param name="collection">Collection of scopes.</param>
        public VimeoScopeList(IEnumerable<VimeoScope> collection) {
            _list.AddRange(collection);
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Adds the specified <paramref name="scope"/> to the collection.
        /// </summary>
        /// <param name="scope">The scope to be added.</param>
        public void Add(VimeoScope scope) {
            _list.Add(scope);
        }

        /// <summary>
        /// Returns an array of strings representing each scope in the collection.
        /// </summary>
        /// <returns>Array of strings representing each scope in the collection.</returns>
        public string[] ToStringArray() {
            return (from scope in _list select scope.Alias).ToArray();
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection of scopes.
        /// </summary>
        public IEnumerator<VimeoScope> GetEnumerator() {
            return _list.GetEnumerator();
        }

        /// <summary>
        /// Returns a string representing the scopes added to the collection using a space as a separator.
        /// </summary>
        /// <returns>String of scopes separated by a space.</returns>
        public override string ToString() {
            return string.Join(" ", from scope in _list select scope.Alias);
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified space separated string into an instance of <see cref="VimeoScopeList"/>.
        /// </summary>
        /// <param name="str">String containing the individual scopes.</param>
        /// <returns>An instance of <see cref="VimeoScopeList"/> with the specified scopes.</returns>
        public static VimeoScopeList Parse(string? str) {
            return new VimeoScopeList(
                from alias in (str ?? string.Empty).Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                let scope = VimeoScope.All.FirstOrDefault(x => x.Alias == alias)
                select scope ?? new VimeoScope(alias, null, null)
            );
        }

        #endregion

        #region Operator overloading

        /// <summary>
        /// Initializes a new collection based on a single <paramref name="scope"/>.
        /// </summary>
        /// <param name="scope">The scope the collection should be based on.</param>
        /// <returns>A new collection based on a single <paramref name="scope"/>.</returns>
        public static implicit operator VimeoScopeList(VimeoScope scope) {
            return new VimeoScopeList(scope);
        }

        /// <summary>
        /// Initializes a new collection based on an <paramref name="array"/> of scopes.
        /// </summary>
        /// <param name="array">The array of scopes the collection should be based on.</param>
        /// <returns>A new collection based on an <paramref name="array"/> of scopes.</returns>
        public static implicit operator VimeoScopeList(VimeoScope[]? array) {
            return new VimeoScopeList(array ?? ArrayUtils.Empty<VimeoScope>());
        }

        /// <summary>
        /// Adds support for adding a <paramref name="scope"/> to the <paramref name="collection"/> using the plus operator.
        /// </summary>
        /// <param name="collection">The collection to which <paramref name="scope"/> will be added.</param>
        /// <param name="scope">The scope to be added to the <paramref name="collection"/>.</param>
        public static VimeoScopeList operator +(VimeoScopeList collection, VimeoScope scope) {
            collection.Add(scope);
            return collection;
        }

        #endregion

    }

}