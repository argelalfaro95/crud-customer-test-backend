﻿using Ardalis.Result;
using Ardalis.SharedKernel;

namespace API_CleanArchitecture.UseCases.Contributors.Update;

public record UpdateContributorCommand(int ContributorId, string NewName) : ICommand<Result<ContributorDTO>>;
