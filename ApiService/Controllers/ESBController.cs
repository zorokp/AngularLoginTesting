using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MassTransit;
using ApiService.Models;
using System.Security.Authentication;

namespace ApiService.Controllers {

    [Produces("application/json")]
    [Route("api/ESB")]
    [ApiController]
    public class ESBController : ControllerBase {

        IBusControl _cloudAMQPBusControl;
        IBus _cloudAMQPBus;
        public IRequestClient<ISampleMessage, ISampleMessageAck> _sampleMessageClient;

        [HttpGet]
        public async Task TestBus() {


 

        }

    }

}
