using System;
using System.Web;

public static class Cerez
{
    /******************/
    public static bool At(string Adi, string AtanacakDeger, DateTime zamanAsimi)
    {
        bool netice = false;
        try
        {
            HttpCookie cerez = new HttpCookie(Adi)
            {
                Value = HttpContext.Current.Server.UrlEncode(AtanacakDeger),
                Expires = zamanAsimi
            };
            HttpContext.Current.Response.Cookies.Add(cerez);
            netice = true;
        }
        catch (Exception) { netice = false; }
        return netice;
    }
    /******************/
    public static string Oku(string Adi)
    {
        HttpCookie cerezim;
        cerezim = HttpContext.Current.Request.Cookies[Adi];
        return HttpContext.Current.Server.UrlDecode(cerezim.Value);
    }
    /******************/
    /// <summary>
    ///çerez varsa True döndürür 
    /// </summary>
    public static bool VarMi(string Adi)
    {
        return HttpContext.Current.Request.Cookies[Adi] != null;
    }
    /******************/

    public static void Sil(string Adi)
    {
        HttpContext.Current.Response.Cookies[Adi].Expires = DateTime.Now.AddDays(-1);
    }

}