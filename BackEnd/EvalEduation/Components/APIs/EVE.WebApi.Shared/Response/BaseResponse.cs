using System;
using System.Collections.Generic;

namespace EVE.WebApi.Shared.Response
{
    public class BaseResponse<T> : Error, IBaseResponse
    {
        #region Properties

        /// <summary>
        ///     Data information type generic template
        /// </summary>
        public T Data { get; private set; }

        /// <summary>
        ///     Flag error
        /// </summary>
        public bool IsError { get; private set; }

        #endregion

        #region C'tor

        /// <summary>
        ///     C'tor TResponse(T data)
        /// </summary>
        /// <param name="data"></param>
        public BaseResponse(T data) : base(string.Empty, string.Empty)
        {
            Data = data;
            IsError = false;
        }

        /// <summary>
        ///     C'tor TResponse(T data, bool isError, string message, string errorCode)
        /// </summary>
        /// <param name="data"></param>
        /// <param name="isError"></param>
        /// <param name="message"></param>
        /// <param name="errorCode"></param>
        public BaseResponse(T data,
                            bool isError,
                            string message,
                            string errorCode) : base(errorCode, message)
        {
            Data = data;
            IsError = isError;
        }

        #endregion

        #region public methods

        /// <summary>
        ///     Update Message Error
        /// </summary>
        /// <param name="error"></param>
        public void UpdateMessageError(Error error)
        {
            IsError = true;
            Update(error);
        }

        public void UpdateMessageError(List<Error> errors)
        {
            IsError = true;
            Update(errors);
        }

        /// <summary>
        ///     Update data
        /// </summary>
        /// <param name="data"></param>
        public void UpdateData(T data)
        {
            Data = data;
        }

        #endregion

        #region IDispose pattern

        private bool _disposed;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if(_disposed)
                return;

            if(disposing)
            {
                // Free any other managed objects here.
                Data = default(T);
                IsError = default(bool);
            }

            _disposed = true;
        }

        #endregion
    }
}
