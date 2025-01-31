namespace bpfull_shared.Model.System;

public class CustomExceptionModel : Exception
{
    #region [ PROPERTIES ]
    public ApiResultModel ResultModel { get; private set; }
    #endregion

    #region [ CTOR ]
    public CustomExceptionModel(ApiResultModel resultModel) => ResultModel = resultModel;
    public CustomExceptionModel(string errorMessage) => ResultModel = new ApiResultModel().WithError(errorMessage);
    #endregion

    #region [ METHODS ]
    public ApiResultModel GetError() => ResultModel;
    #endregion
}