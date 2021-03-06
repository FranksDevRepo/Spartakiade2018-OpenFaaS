﻿using System;
using System.Net.Http;
using FP.Spartakiade2018.CQRS.Data;
using Newtonsoft.Json;
using OpenFaaS.Dotnet;

namespace Function
{
    public class FunctionHandler : BaseFunction
    {
        public FunctionHandler(IFunctionContext functionContext)
            : base(functionContext)
        {
        }

        public override void Handle(string input)
        {
            if (Context.HttpMethod == HttpMethod.Get)
            {
                var dl = new ReadDataLayer();
                var attendeeList = dl.GetAttendeeList();
                Context.WriteContent(JsonConvert.SerializeObject(attendeeList));
            }
            else
            {
                throw new NotSupportedException();
            }
        }
    }
}
