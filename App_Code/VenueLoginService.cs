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


    //-------------Venue Part------------------------------
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



    //-----------Fan Part------------------------------------
    public int FanLogin(string fusername, string fpassword)
    {
        int result = db.usp_FanLogin(fusername, fpassword);
        if (result != -1)
        {
            var key = from f in db.FanLogins
                      where f.FanLoginUserName.Equals(fusername)
                      select new { f.FanKey };
            foreach (var f in key)
            {
                result = (int)f.FanKey;
            }

        }
        return result;
    }

    public int FanRegistration(FanLite fl)
    {
        int result = db.usp_RegisterFan(fl.FName, fl.FEmail, fl.FUsername, fl.FPassword);

        return result;
    }

    public int AddFanArtist(int fanKey, string artistName)
    {
        /*********************************
         * This method will add an artist to the artistFan
         * table. First we have to find the fan
         * and then the particular artist
         * Then we add the artist to the Fan's list
         * of artists to follow
         * **********************************/
        int result = 1;

        //get the fan. the key can come from their login
        Fan myFan = (from f in db.Fans
                     where f.FanKey == fanKey
                     select f).First();

        //get the artist by name
        Artist myArtist = (from a in db.Artists
                           where a.ArtistName.Equals(artistName)
                           select a).First();

        //add the artist to the fan's collection of artists
        myFan.Artists.Add(myArtist);

        //save the changes
        db.SaveChanges();

        return result;
    }



    //-----Add shows and add artists assignment---------
    public int AddArtist(ArtistLite al)
    {
        int result = 1;
        Artist a = new Artist();
        a.ArtistName = al.ArtistName;
        a.ArtistEmail = al.ArtistEmail;
        a.ArtistWebPage = al.WebPage;
        a.ArtistDateEntered = DateTime.Now;
        try
        {
            db.Artists.Add(a);
            db.SaveChanges();
        }
        
        catch(Exception ex)
        {
        result=0;
        throw ex;
        }

        return result;
    }


    public int AddShow(ShowLite sl)
    {
        
        int result = 1;
        Show s = new Show();
        s.VenueKey = sl.VenueKey;
        s.ShowName = sl.ShowName;
        s.ShowDate = DateTime.Parse(sl.ShowDate);
        s.ShowTime = TimeSpan.Parse(sl.ShowTime);
        s.ShowTicketInfo = sl.ShowTicket;
        s.ShowDateEntered = DateTime.Now;

        try
        {
            db.Shows.Add(s);
            db.SaveChanges();
        }
        catch(Exception ex) 
        {
            result = 0;
            throw ex;
        }


        return result;
    }


    public int AddShowDetail(ShowDetailLite sdl)
    {



        int result = 1;
        ShowDetail sd = new ShowDetail();

        var key = from k in db.Artists
                  where k.ArtistName.Equals(sdl.ArtistName)
                  select new { k.ArtistKey };

        int AKey = 0;
        foreach (var k in key)
        {
            AKey = (int)k.ArtistKey;
        }

        var kkey = from kk in db.Shows
                   where kk.ShowName.Equals(sdl.ShowName)
                   select new { kk.ShowKey };

        int SKey = 0;
        foreach (var kk in kkey)
        {
            SKey = (int)kk.ShowKey;
        }

        sd.ArtistKey = AKey;
        sd.ShowDetailArtistStartTime = TimeSpan.Parse(sdl.ArtistStartTime);
        sd.ShowDetailAdditional = sdl.Note;
        sd.ShowKey = SKey;




        try
        {
            db.ShowDetails.Add(sd);
            db.SaveChanges();

        }

        catch (Exception ex)
        {
            result = 0;
            throw ex;
        }

        return result;

    }
}
