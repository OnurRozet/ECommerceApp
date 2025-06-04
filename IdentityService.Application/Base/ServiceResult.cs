#nullable enable
using IdentityService.Application.Enums;

namespace IdentityService.Application.Base;

public class ServiceResult<TUser>
{
    public TUser? ResultObject { get; set; }
    public MessageTypeEnum MessageType { get; set; }
    public string Message { get; set; } = string.Empty;
    public bool IsSuccess { get; set; }

    public static ServiceResult<TUser> Success() => new() { IsSuccess = true, Message = string.Empty, MessageType = MessageTypeEnum.Success };
    public static ServiceResult<TUser> Success(List<TUser> updatedRequests) => new() { IsSuccess = true, Message = string.Empty, MessageType = MessageTypeEnum.Success };


    public static ServiceResult<TUser> Success(string message) => new() { IsSuccess = true, Message = message, MessageType = MessageTypeEnum.Success };

    public static ServiceResult<TUser> Success(TUser result) => new() { ResultObject = result, IsSuccess = true, Message = string.Empty, MessageType = MessageTypeEnum.Success };

    public static ServiceResult<TUser> Success(TUser result, string message) => new() { ResultObject = result, IsSuccess = true, Message = message, MessageType = MessageTypeEnum.Success };

    public static ServiceResult<TUser> Error(string message) => new() { IsSuccess = false, Message = message, MessageType = MessageTypeEnum.Error };
    public static ServiceResult<TUser> Error(TUser result, string message) => new() { ResultObject = result, IsSuccess = false, Message = message, MessageType = MessageTypeEnum.Success };
}