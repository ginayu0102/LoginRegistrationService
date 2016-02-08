using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IVenueLoginService" in both code and config file together.
[ServiceContract]
public interface IVenueLoginService
{
    [OperationContract]
    int VenueLogin(string username, string password);

    [OperationContract]
    int VenueRegistration(VenueLite v);
}

public class VenueLite
{
    [DataMember]
    public string VenueName { set; get; }

    [DataMember]
    public string VenueAddress { set; get; }

    [DataMember]
    public string VenueCity { get; set; }

    [DataMember]
    public string VenueState { set; get; }

    [DataMember]
    public string VenueZipCode { set; get; }

    [DataMember]
    public string VenuePhone { set; get; }

    [DataMember]
    public string VenueWebpage { set; get; }

    [DataMember]
    public int VenueAgeRestriction { set; get; }

    [DataMember]
    public string Email { set; get; }

    [DataMember]
    public string UserName { set; get; }

    [DataMember]
    public string Password { set; get; }



}