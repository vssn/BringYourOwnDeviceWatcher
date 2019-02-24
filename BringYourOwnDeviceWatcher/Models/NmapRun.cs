using BringYourOwnDeviceWatcher.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BringYourOwnDeviceWatcher.Models
{
    public class NmapRunContext : DbContext
    {
        public NmapRunContext(DbContextOptions<NmapRunContext> options)
            : base(options)
        { }

        public DbSet<NmapRun> NmapRuns { get; set; }
        public DbSet<Verbose> Verboses { get; set; }
        public DbSet<Host> Hosts { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Hostname> Hostnames { get; set; }

    }

    [XmlRoot("nmaprun")]
    public class NmapRun
    {
        public int NmapRunId { get; set; }

        [XmlElement("verbose")]
        public Verbose Verbose { get; set; }

        [XmlElement("host")]
        public List<Host> Host { get; set; }
    }

    public class Verbose
    {
        public int VerboseId { get; set; }

        [XmlAttribute("level")]
        public string Level { get; set; }

    }

    public class Host
    {
        public int HostId { get; set; }

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
        public int AddressId { get; set; }

        [XmlAttribute]
        public string addr { get; set; }

        [XmlAttribute]
        public string addrtype { get; set; }
    }

    public class Status
    {
        public int StatusId { get; set; }

        [XmlAttribute]
        public string state { get; set; }
    }

    public class Hostname
    {
        public int HostnameId { get; set; }

        [XmlAttribute]
        public string name { get; set; }

        [XmlAttribute]
        public string type { get; set; }
    }
}