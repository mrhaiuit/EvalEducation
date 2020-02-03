using System.Collections.Generic;
using System.Linq;
using EVE.Commons;

namespace EVE.WebApi.Shared
{
    /// <summary>
    ///     Error
    /// </summary>
    public class Error
    {
        #region public method

        /// <summary>
        ///     Update Attribute
        /// </summary>
        /// <param name="attributeName"></param>
        public void UpdateAttribute(string attributeName)
        {
            if(!Message.StartsWith($"{attributeName}:"))
            {
                Message = attributeName + ":" + Message;
            }
        }

        #endregion

        #region safe method

        /// <summary>
        ///     Update Error code and Message
        /// </summary>
        /// <param name="error"></param>
        protected void Update(Error error)
        {
            ErrorCode = error.ErrorCode;
            Message = error.Message;
        }

        protected void Update(List<Error> error)
        {
            ErrorCode = string.Join("|", error.Select(c => c.ErrorCode)
                                              .Distinct());
            Message = string.Join("|", error.Select(c => c.Message)
                                            .Distinct());
        }

        #endregion

        #region C'tor

        /// <summary>
        ///     C'tor
        /// </summary>
        /// <param name="errorCode"></param>
        /// <param name="message"></param>
        public Error(string errorCode,
                     string message)
        {
            ErrorCode = errorCode;
            Message = message;
        }

        public Error(string errorCode,
                     string messageTemplate,
                     params object[] args)
        {
            ErrorCode = errorCode;
            Message = string.Format(messageTemplate, args);
        }

        public Error(EnumError enumError)
        {
            ErrorCode = ((int) enumError).ToString();
            Message = enumError.GetStringValue();
        }

        #endregion

        #region Atrributes

        /// <summary>
        ///     Error Code
        /// </summary>
        public string ErrorCode { get; private set; }

        /// <summary>
        ///     Message
        /// </summary>
        public string Message { get; private set; }

        #endregion
    }
}
