using bpfull_shared.Model.System;

namespace bpfull_core.Utils.Validator;

public interface IRequestValidator<T>
{
    ApiResultModel ValidateRequest(T request);
}