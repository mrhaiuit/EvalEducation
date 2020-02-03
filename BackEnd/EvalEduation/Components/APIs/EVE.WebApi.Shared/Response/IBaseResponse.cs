using System;

namespace EVE.WebApi.Shared.Response
{
    public interface IBaseResponse : IDisposable
    {
        /// <summary>
        ///     Update Message Error
        /// </summary>
        /// <param name="error"></param>
        void UpdateMessageError(Error error);
    }
}
