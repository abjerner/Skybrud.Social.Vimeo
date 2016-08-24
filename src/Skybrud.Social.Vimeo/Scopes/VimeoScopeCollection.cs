using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Skybrud.Social.Vimeo.Scopes {
    
    /// <summary>
    /// Class representing a collection of scopes for the Vimeo API.
    /// </summary>
    public class VimeoScopeCollection : IEnumerable<VimeoScope> {

        #region Private fields

        private readonly List<VimeoScope> _list = new List<VimeoScope>();

        #endregion

        #region Properties

        /// <summary>
        /// Gets an array of all the scopes added to the collection.
        /// </summary>
        public VimeoScope[] Items {
            get { return _list.ToArray(); }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new collection based on the specified <code>array</code> of scopes.
        /// </summary>
        /// <param name="array">Array of scopes.</param>
        public VimeoScopeCollection(params VimeoScope[] array) {
            _list.AddRange(array);
        }

        /// <summary>
        /// Initializes a new collection based on the specified <code>collection</code> of scopes.
        /// </summary>
        /// <param name="collection">Collection of scopes.</param>
        public VimeoScopeCollection(IEnumerable<VimeoScope> collection) {
            _list.AddRange(collection);
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Adds the specified <code>scope</code> to the collection.
        /// </summary>
        /// <param name="scope">The scope to be added.</param>
        public void Add(VimeoScope scope) {
            _list.Add(scope);
        }

        /// <summary>
        /// Returns an array of scopes based on the collection.
        /// </summary>
        /// <returns>Array of scopes contained in the location.</returns>
        public VimeoScope[] ToArray() {
            return _list.ToArray();
        }

        /// <summary>
        /// Returns an array of strings representing each scope in the collection.
        /// </summary>
        /// <returns>Array of strings representing each scope in the collection.</returns>
        public string[] ToStringArray() {
            return (from scope in _list select scope.Name).ToArray();
        }

        public IEnumerator<VimeoScope> GetEnumerator() {
            return _list.GetEnumerator();
        }

        /// <summary>
        /// Returns a string representing the scopea added to the collection using a space as a separator.
        /// </summary>
        /// <returns>String of scopes separated by a space.</returns>
        public override string ToString() {
            return String.Join(" ", from scope in _list select scope.Name);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        #region Static methods

        public static VimeoScopeCollection Parse(string str) {
            return new VimeoScopeCollection(
                from alias in (str ?? "").Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                let scope = VimeoScope.All.FirstOrDefault(x => x.Alias == alias)
                select scope ?? new VimeoScope(alias, null, null)
            );
        }

        #endregion

        #region Operator overloading

        /// <summary>
        /// Initializes a new collection based on a single <code>scope</code>.
        /// </summary>
        /// <param name="scope">The scope the collection should be based on.</param>
        /// <returns>Returns a new collection based on a single <code>scope</code>.</returns>
        public static implicit operator VimeoScopeCollection(VimeoScope scope) {
            return new VimeoScopeCollection(scope);
        }

        /// <summary>
        /// Initializes a new collection based on an <code>array</code> of scopes.
        /// </summary>
        /// <param name="array">The array of scopes the collection should be based on.</param>
        /// <returns>Returns a new collection based on an <code>array</code> of scopes.</returns>
        public static implicit operator VimeoScopeCollection(VimeoScope[] array) {
            return new VimeoScopeCollection(array ?? new VimeoScope[0]);
        }

        /// <summary>
        /// Adds support for adding a <code>scope</code> to the <code>collection</code> using the plus operator.
        /// </summary>
        /// <param name="collection">The collection to which <code>scope</code> will be added.</param>
        /// <param name="scope">The scope to be added to the <code>collection</code>.</param>
        public static VimeoScopeCollection operator +(VimeoScopeCollection collection, VimeoScope scope) {
            collection.Add(scope);
            return collection;
        }

        #endregion

    }

}