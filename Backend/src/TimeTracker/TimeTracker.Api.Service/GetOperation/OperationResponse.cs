﻿using TimeRegistration.TimeTracker.Domain.Operations;

namespace TimeRegistration.TimeTracker.Api.Service.GetOperation;
public record OperationResponse(string RequestId, Guid CustomerId, OperationName OperationName,
    OperationStatus OperationStatus, string CreatedBy, DateTime CreatedUtc, DateTime? LastModifiedUtc,
    DateTime? CompletedUtc, Dictionary<string, string>? Data);

public static class OperationMapper
{
    public static OperationResponse ToResponseModel(Operation operation)
    {
        return new OperationResponse(
            operation.RequestId,
            operation.ArduinoId,
            operation.Name,
            operation.Status,
            operation.CreatedBy,
            operation.CreatedUtc,
            operation.ModifiedUtc,
            operation.CompletedUtc,
            operation.Data
        );
    }
}
