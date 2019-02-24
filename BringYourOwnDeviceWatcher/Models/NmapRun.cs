using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BringYourOwnDeviceWatcher.Models
{
    [XmlRoot("nmaprun")]
    public class NmapRun
    {
        [XmlElement("verbose")]
        public Verbose Verbose { get; set; }

        [XmlElement("host")]
        public List<Host> Host { get; set; }
    }

    public class Verbose
    {
        [XmlAttribute("level")]
        public string Level { get; set; }

    }

    public class Host
    {
        [XmlElement("status")]
        public Status Status { get; set; }

        [XmlArray("hostnames")]
        [XmlArrayItem("hostname")]
        public List<Hostname> Hostname { get; set; }

        [XmlElement("address")]
        public List<Address> Address { get; set; }
    }

    public class Address
    {
        [XmlAttribute]
        public string addr { get; set; }

        [XmlAttribute]
        public string addrtype { get; set; }
    }

    public class Status
    {
        [XmlAttribute]
        public string state { get; set; }
    }

    public class Hostname
    {
        [XmlAttribute]
        public string name { get; set; }

        [XmlAttribute]
        public string type { get; set; }
    }
}