﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using SalesAPI.Exceptions;
using SalesAPI.Exceptions.Domain;
//using System;
using System.Net;

namespace SalesAPI.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {

            var exception = context.Exception;
            var tName = exception.GetType().Name + " :\n";


            switch (exception)
            {
                case StockException stockException:
                    {
                        string json = tName + JsonConvert.SerializeObject(stockException.Message);

                        context.Result = new BadRequestObjectResult(json);
                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    }

                case DomainException domainException:
                    {
                        string json = tName + JsonConvert.SerializeObject(domainException.Message);

                        context.Result = new BadRequestObjectResult(json);
                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    }

                case ApplicationException applicationException:
                    {
                        string json = tName + JsonConvert.SerializeObject(applicationException.Message);

                        context.Result = new BadRequestObjectResult(json);
                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    }

                case EntityNotFoundException entityNotFoundException:
                    {
                        string json = tName + JsonConvert.SerializeObject(entityNotFoundException.Message);

                        context.Result = new NotFoundObjectResult(json);
                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    }

                case InfrastructureException infraException:
                    {
                        string json = tName + JsonConvert.SerializeObject(infraException.Message);

                        context.Result = new BadRequestObjectResult(json);
                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                    }

                case DomainNotFoundException domainNotFoundException:
                    {
                        string json = tName + JsonConvert.SerializeObject(domainNotFoundException.Message);

                        context.Result = new BadRequestObjectResult(json);
                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    }

                case IdentityException identityException:
                    {
                        string errors = "";
                        foreach (IdentityError e in identityException.Errors)
                        {
                            errors += e.ToString()+"\n";
                        }
                        string json = tName + JsonConvert.SerializeObject(identityException.Message) + "\n" +
                            JsonConvert.SerializeObject(identityException.Errors);

                        context.Result = new BadRequestObjectResult(json);
                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    }

                default:
                    {
                        string json = tName + JsonConvert.SerializeObject(exception.Message) +
                            "\nInner Exception : \n" + exception.InnerException?.Message +
                            "\nStack Trace : \n" + exception.StackTrace;

                        context.Result = new BadRequestObjectResult(json);
                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                    }
            }
        }
    }
}
