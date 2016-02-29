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

    [OperationContract]
    int AddArtist(ArtistLite al);

    [OperationContract]
    int AddShow(ShowLite sl);

    [OperationContract]
    int AddShowDetail(ShowDetailLite sdl);


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

[DataContract]
public class ShowLite
{
    [DataMember]
    public int VenueKey { set; get; }
    
    [DataMember]
    public string ShowName{set; get;}

    [DataMember]
    public string ShowDate{set; get;}

    
    [DataMember]
    public string ShowTime { set; get; }

    [DataMember]
    public string ShowTicket { set; get; }


}

[DataContract]

public class ArtistLite
{
    [DataMember]
    public string ArtistName { set; get; }

   
    [DataMember]
    public string ArtistEmail { set; get; }

    [DataMember]
    public string WebPage { set; get; }


}

[DataContract]
public class ShowDetailLite
{
    [DataMember]
    public string ArtistName { set; get; }

    [DataMember]
    public string ShowName { set; get; }

    [DataMember]
    public string ArtistStartTime { set; get; }

    [DataMember]
    public string Note { set; get; }

}
