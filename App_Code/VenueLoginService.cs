using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "VenueLoginService" in code, svc and config file together.
public class VenueLoginService : IVenueLoginService
{
    ShowTrackerEntities db = new ShowTrackerEntities();

    public int VenueLogin(string username, string password)
    {
        int result = db.usp_venueLogin(username, password);
        if (result != -1)
        {
            var key = from k in db.VenueLogins
                      where k.VenueLoginUserName.Equals(username)
                      select new { k.VenueKey };
            foreach (var k in key)
            {
                result = (int)k.VenueKey;
            }


        }

        return result;
    
    }
    
   
    public int VenueRegistration(VenueLite v)
    {
        int result = db.usp_RegisterVenue(v.VenueName, v.VenueAddress, v.VenueCity, v.VenueState, v.VenueZipCode, v.VenuePhone, v.Email, v.VenueWebpage, v.VenueAgeRestriction, v.UserName, v.Password);
        return result;
    }
}
