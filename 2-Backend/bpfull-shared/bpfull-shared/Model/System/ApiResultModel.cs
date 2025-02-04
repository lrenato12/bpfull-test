using System.Text.Json.Serialization;

namespace bpfull_shared.Model.System;

/// <summary>
/// Model for API result model.
/// </summary>
public class ApiResultModel
{
    #region Properties
    public bool Success { get; set; }
    public ApiErrorModel Error { get; set; }
    public List<ApiErrorModel> Errors { get; set; } = new List<ApiErrorModel>();
    public dynamic ApiResultData { get; set; }
    public bool HasErrors => !string.IsNullOrEmpty(Error?.ErrorMessage) || Errors.Count > 0;

    [JsonIgnore]
    public string JsonResultData => ApiResultData == null ? "" : $"{ApiResultData}";
    #endregion

    #region Constructor
    public ApiResultModel() => Error = new ApiErrorModel();
    #endregion

    #region Methods
    private void SetSucces(dynamic resultData)
    {
        Success = true;
        ApiResultData = resultData;
        Error = null;
    }

    private void SetError(ApiErrorModel error)
    {
        Success = false;
        ApiResultData = null;
        Error = error;
        Errors.Add(error);
    }

    private void SetErrors(List<ApiErrorModel> errors)
    {
        Success = false;
        ApiResultData = null;
        Error = errors?.FirstOrDefault();
        Errors = errors;
    }

    public ApiResultModel WithError(string errorMessage)
    {
        var ApiResultModel = new ApiResultModel();
        ApiResultModel.SetError(new ApiErrorModel { ErrorMessage = errorMessage });
        return ApiResultModel;
    }

    public ApiResultModel WithError(string errorCode, string errorMessage)
    {
        var ApiResultModel = new ApiResultModel();
        ApiResultModel.SetError(new ApiErrorModel { ErrorCode = errorCode, ErrorMessage = errorMessage });
        return ApiResultModel;
    }

    public ApiResultModel WithError(ApiErrorModel error)
    {
        var ApiResultModel = new ApiResultModel();
        ApiResultModel.SetError(error);
        return ApiResultModel;
    }

    public ApiResultModel WithErrors(List<ApiErrorModel> errors)
    {
        var ApiResultModel = new ApiResultModel();
        ApiResultModel.SetErrors(errors);
        return ApiResultModel;
    }

    public ApiResultModel WithSuccess(dynamic resultData)
    {
        var ApiResultModel = new ApiResultModel();
        ApiResultModel.SetSucces(resultData);
        return ApiResultModel;
    }
    #endregion
}