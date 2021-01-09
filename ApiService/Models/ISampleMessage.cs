using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiService.Models {
    public interface ISampleMessage {
        string MessageType { get; set; }
        string Name { get; set; }
        string LastName { get; set; }
    }

    public interface ISampleMessageAck {
        string ackData { get; set; }
    }

    public class SampleMessage : ISampleMessage {
        public SampleMessage() { }

        public string MessageType { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
    }
}
