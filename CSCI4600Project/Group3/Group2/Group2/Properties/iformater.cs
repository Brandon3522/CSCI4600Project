using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Group2
{
    public interface IRemotingFormatter : IFormatter { 
        object Deserialize(Stream serializationStream, HeaderHandler handler); 
        void Serialize(Stream serializationStream, object graph, Header[] headers); 

    }

}
