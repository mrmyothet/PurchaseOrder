﻿namespace PurchaseOrder.API;

public class Result<T>
{
    public bool IsSuccess { get; private set; }
    public bool IsError => !IsSuccess;
    public bool IsValidationError => ResultType == EnumResultType.ValidationError;
    private EnumResultType ResultType { get; set; }
    public T? Data { get; private set; }
    public string? Message { get; private set; }

    private Result(bool isSuccess, T? data, string? message)
    {
        IsSuccess = isSuccess;
        Data = data;
        Message = message;
    }

    public static Result<T> Success(T data, string? message = "Operation Successful.")
    {
        var item = new Result<T>(true, data, message);
        item.ResultType = EnumResultType.Success;
        return item;
    }

    public static Result<T> Failure(string errorMessage)
    {
        var item = new Result<T>(false, default, errorMessage);
        item.ResultType = EnumResultType.Failure;
        return item;
    }

    public static Result<T> ValidationError(string errorMessage)
    {
        var item = new Result<T>(false, default, errorMessage);
        item.ResultType = EnumResultType.ValidationError;
        return item;
    }
}

public enum EnumResultType
{
    None,
    Success,
    Failure,
    ValidationError,
}
