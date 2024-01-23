# SkiServiceModels

This is a collection of models used by the SkiService project. It is divided into multiple modules for easier management.

[`SkiServiceModels.EF`](../SkiServiceModels.EF) for a Entity Framework Core implementation of the models, 
see [`SkiServiceModels.BSON`](../SkiServiceModels.BSON) for a MongoDB implementation of the models.

This project contains everything not related to a specific database implementation. And is not meant to be used on its own.


## Contents

<!--TOC-->
  - [Common](#common)
    - [RefreshRequestBase](#refreshrequestbase)
  - [DTOs](#dtos)
    - [ErrorData](#errordata)
    - [TokenData](#tokendata)
  - [DTOs/Requests](#dtosrequests)
    - [LoginRequest](#loginrequest)
    - [RefreshRequest](#refreshrequest)
  - [Enums](#enums)
    - [RoleNames](#rolenames)
  - [Interfaces](#interfaces)
    - [IAuthRequest](#iauthrequest)
    - [ICreateDTO](#icreatedto)
    - [IDTO](#idto)
    - [IRequestDTO](#irequestdto)
    - [IRequestDTO](#irequestdto)
    - [IUpdateDTO](#iupdatedto)
    - [IModelBase](#imodelbase)
    - [Models](#models)
      - [IOrderBase](#iorderbase)
      - [IPriorityBase](#iprioritybase)
      - [IServiceBase](#iservicebase)
      - [IStateBase](#istatebase)
      - [IUserBase](#iuserbase)
<!--/TOC-->

## Common

### RefreshRequestBase
<<COMMON::RefreshRequestBase>>

## DTOs

### ErrorData
<<DTO::ErrorData>>

### TokenData
<<DTO::TokenData>>

## DTOs/Requests

### LoginRequest
<<REQDTO::LoginRequest>>

### RefreshRequest
<<REQDTO::RefreshRequest>>

## Enums

### RoleNames
<<ENUM::RoleNames>>

## Interfaces

### IAuthRequest
<<INTERFACE::IAuthRequest>>

### ICreateDTO
<<INTERFACE::ICreateDTO>>

### IDTO
<<INTERFACE::IDTO>>

### IRequestDTO
<<INTERFACE::IRequestDTO>>

### IRequestDTO
<<INTERFACE::IRequestDTO>>

### IUpdateDTO
<<INTERFACE::IUpdateDTO>>

### IModelBase
<<INTERFACE::IModelBase>>

### Models

#### IOrderBase
<<INTERFACEMODEL::IOrderBase>>

#### IPriorityBase
<<INTERFACEMODEL::IPriorityBase>>

#### IServiceBase
<<INTERFACEMODEL::IServiceBase>>

#### IStateBase
<<INTERFACEMODEL::IStateBase>>

#### IUserBase
<<INTERFACEMODEL::IUserBase>>