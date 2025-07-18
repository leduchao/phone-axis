using MediatR;
using PhoneAxis.Application.DTOs.User;
using PhoneAxis.Domain.Common;

namespace PhoneAxis.Application.Queries.User;

public record GetUserBasicInfoQuery() : IRequest<Result<UserBasicInfo>>;
