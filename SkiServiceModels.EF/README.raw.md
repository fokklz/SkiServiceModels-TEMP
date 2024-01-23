# SkiServiceModels.EF

This package contains the EF models for the SkiService project.

## Installation

```bash
dotnet add package SkiServiceModels.EF
```

## Contents

<!--TOC-->
- [SkiServiceModels.EF](#skiservicemodelsef)
  - [Installation](#installation)
  - [Contents](#contents)
  - [DTOs/Requests](#dtosrequests)
    - [CreateOrderRequest](#createorderrequest)
    - [CreatePriorityRequest](#createpriorityrequest)
    - [CreateServiceRequest](#createservicerequest)
    - [CreateStateRequest](#createstaterequest)
    - [CreateUserRequest](#createuserrequest)
    - [UpdateOrderRequest](#updateorderrequest)
    - [UpdatePriorityRequest](#updatepriorityrequest)
    - [UpdateServiceRequest](#updateservicerequest)
    - [UpdateStateRequest](#updatestaterequest)
    - [UpdateUserRequest](#updateuserrequest)
    - [Base](#base)
      - [CreateRequest](#createrequest)
      - [UpdateRequest](#updaterequest)
  - [DTOs/Responses](#dtosresponses)
    - [LoginResponse](#loginresponse)
    - [OrderResponse](#orderresponse)
    - [PriorityResponse](#priorityresponse)
    - [ServiceResponse](#serviceresponse)
    - [StateResponse](#stateresponse)
    - [UserResponse](#userresponse)
    - [Base](#base-1)
      - [ModelResponse](#modelresponse)
  - [Interfaces](#interfaces)
    - [IOrder](#iorder)
    - [IPriority](#ipriority)
    - [IService](#iservice)
    - [IState](#istate)
    - [IUser](#iuser)
    - [Base](#base-2)
      - [IModel](#imodel)
  - [Models](#models)
    - [Order](#order)
    - [Priority](#priority)
    - [Service](#service)
    - [State](#state)
    - [User](#user)
    - [Refresh Result](#refresh-result)
    - [Base](#base-3)
      - [Model](#model)
<!--/TOC-->


## DTOs/Requests

### CreateOrderRequest
<<REQDTO::CreateOrderRequest>>

### CreatePriorityRequest
<<REQDTO::CreatePriorityRequest>>

### CreateServiceRequest
<<REQDTO::CreateServiceRequest>>

### CreateStateRequest
<<REQDTO::CreateStateRequest>>

### CreateUserRequest
<<REQDTO::CreateUserRequest>>

### UpdateOrderRequest
<<REQDTO::UpdateOrderRequest>>

### UpdatePriorityRequest
<<REQDTO::UpdatePriorityRequest>>

### UpdateServiceRequest
<<REQDTO::UpdateServiceRequest>>

### UpdateStateRequest
<<REQDTO::UpdateStateRequest>>

### UpdateUserRequest
<<REQDTO::UpdateUserRequest>>

### Base

#### CreateRequest
<<REQDTOBASE::CreateRequest>>

#### UpdateRequest
<<REQDTOBASE::UpdateRequest>>

## DTOs/Responses

### LoginResponse
<<RESDTO::LoginResponse>>

### OrderResponse
<<RESDTO::OrderResponse>>

### PriorityResponse
<<RESDTO::PriorityResponse>>

### ServiceResponse
<<RESDTO::ServiceResponse>>

### StateResponse
<<RESDTO::StateResponse>>

### UserResponse
<<RESDTO::UserResponse>>

### Base

#### ModelResponse
<<RESDTOBASE::ModelResponse>>

## Interfaces

### IOrder
<<INTERFACE::IOrder>>

### IPriority
<<INTERFACE::IPriority>>

### IService
<<INTERFACE::IService>>

### IState
<<INTERFACE::IState>>

### IUser
<<INTERFACE::IUser>>

### Base

#### IModel
<<INTERFACEBASE::IModel>>

## Models

### Order
<<MODEL::Order>>

### Priority
<<MODEL::Priority>>

### Service
<<MODEL::Service>>

### State
<<MODEL::State>>

### User
<<MODEL::User>>

### Refresh Result
<<MODEL::RefreshResult>>

### Base

#### Model
<<MODELBASE::Model>>