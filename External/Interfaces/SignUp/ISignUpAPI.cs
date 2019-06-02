﻿using System.Threading.Tasks;
using Refit;
using TransportSystems.Frontend.External.Models.SignUp;

namespace TransportSystems.Frontend.External.SignUp
{
    public interface ISignUpAPI
    {
        [Post("/api/signup/dispatcher")]
        [Headers("Authorization: Bearer")]
        Task RegisterDispatcher([Body(BodySerializationMethod.Json)] DispatcherCompanyEM dispatcherCompany);

        [Post("/api/signup/driver")]
        [Headers("Authorization: Bearer")]
        Task RegisterDriver([Body(BodySerializationMethod.Json)] DriverCompanyEM driverCompany);
    }
}
