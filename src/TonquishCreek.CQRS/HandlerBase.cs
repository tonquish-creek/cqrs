using System;

namespace TonquishCreek.CQRS
{
    /// <summary>Base class for all handlers.</summary>
    [Serializable()]
    public abstract class HandlerBase : IDisposable
    {
        #region Private Variable(s)
        /// <summary>Indicates if the object has been disposed. Used to block redundant calls.</summary>
        [NonSerialized()]
        private volatile Boolean _isDisposed;
        #endregion

        #region Constructor(s)
        /// <summary>Creates a new instance of the <see cref="HandlerBase" /> class.</summary>
        protected HandlerBase()
            : base()
        {
        }
        #endregion

        #region Destructor(s)
        /// <summary>Finalizes the current instance of the <see cref="HandlerBase" /> class.</summary>
        /// <remarks>
        /// <para>
        /// The destructor will be called by the Garbage Collector if the object has not been explicitly disposed.
        /// This means that the instance will remain for an additional cycle before the memory can be reclaimed by the GC.
        /// </para>
        /// <para>
        /// If the object has been explicitly disposed, by calling the public Dispose() method, the destructor will NOT be called.
        /// </para>
        /// <para>
        /// The boolean argument to the protected Dispose(bool) method indicates whether the call is coming from the public Dispose() method or the destructor.
        /// This ensures that we don't try to make changes twice should the destructor be called after the object has been explicitly disposed.
        /// </para>
        /// </remarks>
        ~HandlerBase()
        {
            Dispose(false);
        }
        #endregion

        #region Public Method(s)
        /// <summary>Performs application-defined tasks associated with freeing, releasing or resetting unmanaged resources.</summary>
        public void Dispose()
        {
            if (!_isDisposed)
            {
                // Do not change this code. Put cleanup code in Dispose(System.Boolean disposing) method instead.
                Dispose(true);
                GC.SuppressFinalize(this);
            }
        }
        #endregion

        #region Protected Method(s)
        /// <summary>Releases the managed resources used by the object and optionally releases the unmanaged resources.</summary>
        /// <param name="disposing"><c>true</c> to release managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        /// <remarks>
        /// A good reference source covering the Disposable pattern and how it's used can be found at: http://msdn.microsoft.com/msdnmag/issues/07/07/CLRInsideOut/.
        /// Pattern guidelines can be found at: http://www.bluebytesoftware.com/blog/PermaLink.aspx?guid=88e62cdf-5919-4ac7-bc33-20c06ae539ae.
        /// </remarks>
        protected virtual void Dispose(Boolean disposing)
        {
            _isDisposed = true;
        }

        /// <summary>Throws an <see cref="ObjectDisposedException"/> if the current instance has already been disposed.</summary>
        protected internal void ThrowIfDisposed()
        {
            if (_isDisposed)
            {
                throw new ObjectDisposedException(GetType().Name);
            }
        }
        #endregion
    }
}
