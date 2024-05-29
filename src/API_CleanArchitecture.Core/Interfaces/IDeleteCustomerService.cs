﻿using Ardalis.Result;

namespace API_CleanArchitecture.Core.Interfaces;

public interface IDeleteCustomerService
{
  // This service and method exist to provide a place in which to fire domain events
  // when deleting this aggregate root entity
  public Task<Result> DeleteCustomer(int customerId);
}