[![.NET](https://github.com/aimenux/ConditionalEndpointsDemo/actions/workflows/ci.yml/badge.svg?branch=main)](https://github.com/aimenux/ConditionalEndpointsDemo/actions/workflows/ci.yml)

# ConditionalEndpointsDemo
```
Using various ways in order to conditionally disable endpoints
```

In this demo, i m using various ways in order to disable some endpoints in production environment.
>
> :one: Using feature provider `ConditionalControllerProvider` to enable/disable endpoints based on environment.
>
> :two: Using action filter `ConditionalActionFilterAttribute` to enable/disable endpoints based on environment.
>
> :three: Using middleware `ConditionalMiddleware` to enable/disable endpoints based on environment.
>
> :four: Using [feature flags](https://github.com/microsoft/FeatureManagement-Dotnet) `ConditionalFeatureFilter` to enable/disable endpoints based on environment.
>

The first way is the simplest one in my opinion. The other ways needs more code to disable endpoints also in swagger.

In order to simulate the behaviour in production environment :
>
> :heavy_minus_sign: Open file `launchSettings.json` of some project for example `01-Way`
>
> :heavy_minus_sign: Edit the appropriate profile for example `_01_Way` or `IIS Express`
>
> :heavy_minus_sign: Set variable `ASPNETCORE_ENVIRONMENT` to `Production` value

**`Tools`** : vs22, net 6.0