using System;

namespace EVE.Commons
{

    public sealed class enDialogQuestions : StringEnumClass
    {

        public static readonly enDialogQuestions QuestionDelete = new enDialogQuestions("Bạn có muốn xóa dữ liệu này không?");
        public static readonly enDialogQuestions QuestionSelection = new enDialogQuestions("Bạn có chắc chắn với sự lựa chọn này không?");
        public static readonly enDialogQuestions QuestionAction = new enDialogQuestions("Bạn có chắc chắn với hành động này không?");
        public static readonly enDialogQuestions Question = new enDialogQuestions("Bạn có chắc chắn với hành động này không?");

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="code"></param>
        private enDialogQuestions(String code)
            : base(code)
        {

        }
    }

}