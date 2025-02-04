namespace bpfull_shared.Model.System;

/// <summary>
/// Model for API error response.
/// </summary>
public class ApiErrorModel
{
    #region Properties
    public string ErrorCode { get; set; } = string.Empty;
    public string ErrorMessage { get; set; } = string.Empty;
    #endregion
}